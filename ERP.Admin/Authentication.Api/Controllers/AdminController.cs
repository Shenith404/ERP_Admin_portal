using Authentication.jwt;
using ERP.Authentication.Core.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IJwtTokenHandler _jwtTokenHandler;
        private readonly UserManager<UserModel> _userManager;




        public AdminController(IJwtTokenHandler jwtTokenHandler,
            UserManager<UserModel> userManager
           )
        {
            _jwtTokenHandler = jwtTokenHandler;
            _userManager = userManager;

        }

        [HttpPost]
        [Route("getUsers-details")]
        //[Authorize] should change
        public async Task<IActionResult> GetUsers([FromBody] string? searchString)
        {
            var users = _userManager.Users.ToList();

            if (users == null || !users.Any())
            {
                return BadRequest("User List is Empty");
            }

            if (string.IsNullOrEmpty(searchString))
            {
                return Ok(users);
            }

            var searchResult = users.Where(u =>
                u.UserName!.Contains(searchString, StringComparison.OrdinalIgnoreCase) || // Search by username
                u.Email!.Contains(searchString, StringComparison.OrdinalIgnoreCase)   // Search by email
                  ).ToList();

            return Ok(searchResult);
        }

        [HttpGet]
        [Route("Delete-User")]
        //[Authorize] should change
        public async Task<IActionResult> DeleteUser([FromBody] string email)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email);

                //check user is exist or not
                if (user == null)
                {
                    return BadRequest("User is not exist");

                }
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Ok("User is Deleted");

                }
                return BadRequest("Can't Delete User");


            }
            return BadRequest("Invalid email");
        }


    }


}
