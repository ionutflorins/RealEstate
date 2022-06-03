
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        

        public UserProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userID = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userID);
            return new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName,
            };
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Developer")]
        [Route("ForDeveloper")]
        public string GetForDeveloper()
        {
            return "Web method for Developer";
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        [Route("ForClient")]
        public string GetForClient()
        {
            return "Web method for Client";
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Developer,Client")]
        [Route("ForAdminOrDeveloperOrClient")]
        public string GetForAdminOrDeveloperOrClient()
        {
            return "Web method for Admin Or Developer Or Client";
        }
    }
}
