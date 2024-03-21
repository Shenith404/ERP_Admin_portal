using Authentication.jwt;
using Authentication.jwt.DTOs;
using ERP.Authentication.Jwt;
using ERP.Authentication.Jwt.DTOs;
using ERP.Authentication.Jwt.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly UserManager<BaseEntity> _userManager;

        public AccountController(JwtTokenHandler jwtTokenHandler, UserManager<BaseEntity> userManager)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _userManager = userManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest authenticationRequest)
        {
            if(ModelState.IsValid)
            {
                //check user is exist
                var existing_user = await _userManager.FindByEmailAsync(authenticationRequest.UserName);
                if (existing_user == null)
                {
                    return BadRequest(
                          new AuthenticationResponse()
                          {
                              Message = "Username is not Exist"
                          });
                 }
                //check password is match
                var isCorrect = await _userManager.CheckPasswordAsync(existing_user,authenticationRequest.Password);
                if (isCorrect==false)
                {
                    return BadRequest(
                      new AuthenticationResponse()
                      {
                          Message = "Password is Incorrect"
                      });
                }
                //Generate token

                TokenRequest tokenRequest = new TokenRequest();
                tokenRequest.UserName = authenticationRequest.UserName;
                tokenRequest.Password = authenticationRequest.Password;
                tokenRequest.Role = "Role";

                var result = _jwtTokenHandler.GenerateJwtToken(tokenRequest);

                return Ok(
                    new AuthenticationResponse
                    {
                        JwtToken = result!.JwtToken,
                        ExpiresIn = result.ExpiresIn,
                        UserName = result.UserName,
                        Message = "User Login Successfully"

                    });


            }

            return BadRequest(
              new AuthenticationResponse()
              {
                  Message = "Invalid User Credentials"
              });
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationRequest authenticationRequest)
        {
            if(ModelState.IsValid)
            {

                //Check Email is already taken
                var user_exist = await _userManager.FindByEmailAsync(authenticationRequest.UserName);


                if (user_exist != null)
                {
                    return BadRequest(
                        new AuthenticationResponse()
                        {
                            Message = "Email Is Already Exist"
                        });
                }

                //Create User

                var new_user = new BaseEntity()
                {
                    Email = authenticationRequest.UserName,
                    UserName =authenticationRequest.UserName,
                    Status=1
                };  

                var is_created =await _userManager.CreateAsync(new_user,authenticationRequest.Password);

                if (is_created.Succeeded)
                {
                    TokenRequest tokenRequest = new TokenRequest();
                    tokenRequest.UserName = authenticationRequest.UserName;
                    tokenRequest.Password = authenticationRequest.Password;
                    tokenRequest.Role = "Reguler";

                    //Default add Roles as Reguler
                    var user = await _userManager.FindByEmailAsync(tokenRequest.UserName);
                    await _userManager.AddToRoleAsync(user!, "Reguler");
                    //Generate token

                    var result = _jwtTokenHandler.GenerateJwtToken(tokenRequest);

                    return Ok(
                        new AuthenticationResponse
                        {
                            JwtToken=result!.JwtToken,
                            ExpiresIn=result.ExpiresIn,
                            UserName=result.UserName,
                            Message="User Create Successfully"

                        });

                }
                return BadRequest(
                    new AuthenticationResponse() {
                        Message="Server Error"
                    });
            }

            return BadRequest(
                new AuthenticationResponse()
                {
                    Message = "Invalid User Credentials"
                });

        }
             
    }
}
