using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private ApiResponse response = new ApiResponse();
        private readonly UserProfileDBContext _context;

        public UserProfileController(UserProfileDBContext context)
        {
            _context = context;
        }


        [HttpGet("/userprofile")]
        public async Task<ActionResult<IEnumerable<UserProfileDb>>> GetUserProfiles()
        {
            var data = await _context.UserProfileDbs.ToListAsync();
            response = new ApiResponse().setSuccess(data: new Dictionary<string, dynamic> { { "profiles", data } });
            return Ok(response); 
        }


        [HttpGet("/userprofile{Uid}")]
        public ActionResult<UserProfileDb> GetUserProfile(int Uid)
        {
            var userProfile = _context.UserProfileDbs.FirstOrDefault(e => e.Uid == Uid);
            if (userProfile != null)
            {
                response = new ApiResponse().setSuccess(data: new Dictionary<string, dynamic> { { "userprofile", userProfile } });
                return Ok(userProfile);
            }
            else
            {
                response = new ApiResponse().setFailure();
                response.message = "User does't exsist";
                return NotFound(response);
            } 
        }
         
        [HttpPost("/userprofile")]
        public ActionResult SetUserProfile(UserProfileDb userProfile)
        {
            if (userProfile != null)
            {
                _context.UserProfileDbs.Add(userProfile);
                _context.SaveChanges();
                response = new ApiResponse().setSuccess(data: new Dictionary<string, dynamic> { { "userprofile", userProfile } });
                return Ok(response);
            }

            response = new ApiResponse().setFailure();
            return BadRequest(response);
        } 
    }
}