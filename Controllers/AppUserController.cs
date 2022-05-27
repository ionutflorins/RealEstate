using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateDAL.Entities;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostAppUser(AppUserEntity appUserEntity)
        {
            var appUser = new AppUser()
            {
                UserName = appUserEntity.UserName,
                Email = appUserEntity.Email,
                FirstName = appUserEntity.FirstName,
                LastName = appUserEntity.LastName,
            };

            try
            {
                var result =await _userManager.CreateAsync(appUser, appUserEntity.Password);
                return Ok(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
