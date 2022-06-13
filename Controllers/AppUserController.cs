using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealEstateBussinesLogic.Models.User;
using RealEstateDAL.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostAppUser(AppUserEntity appUserEntity)
        {

            appUserEntity.Role = "Client";
            var appUser = new AppUser()
            {
                UserName = appUserEntity.UserName,
                Email = appUserEntity.Email,
                FirstName = appUserEntity.FirstName,
                LastName = appUserEntity.LastName,
            };
           
            try
            {
                var result = await _userManager.CreateAsync(appUser, appUserEntity.Password);
                await _userManager.AddToRoleAsync(appUser, appUserEntity.Role);
                return Ok(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginView loginView)
        {
            var user = await _userManager.FindByNameAsync(loginView.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginView.Password))
            {
                //get the role assign to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890987654321")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorect" });
        }
    }
}
