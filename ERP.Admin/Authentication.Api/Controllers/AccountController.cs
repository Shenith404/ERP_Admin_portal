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
        private readonly UserManager<UserModel> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AccountController(JwtTokenHandler jwtTokenHandler, UserManager<UserModel> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _userManager = userManager;
            _roleManager = roleManager;
        }



        //Login User
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

               
                //check is user deleted
                if(existing_user.Status != 1)
                {
                    return BadRequest(
                         new AuthenticationResponse()
                         {
                             Message = "This user is Deleted"
                         });
                }

                //check is user Locked
                var isLocked = await _userManager.IsLockedOutAsync(existing_user);
                if (isLocked==true)
                {
                    return BadRequest(
                         new AuthenticationResponse()
                         {
                             IsLocked=true,
                             Message = "This user is Locked"
                         });
                }

                //check is user Email is conformed
                if (existing_user.EmailConfirmed ==false)
                {
                    return BadRequest(
                         new AuthenticationResponse()
                         {
                             EmailConfirmed = await _userManager.IsEmailConfirmedAsync(existing_user),
                             Message = "Your Email is not Confirmed"
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

                //Get Role from database
                //Default add Roles as Reguler
                /*var user = await _userManager.FindByEmailAsync(tokenRequest.UserName);
                Console.WriteLine("User name is " +user.UserName);
                await _roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
                await _userManager.AddToRoleAsync(user, "Admin");
*/

            

                var result = _jwtTokenHandler.GenerateJwtToken(tokenRequest);

                return Ok(
                    new AuthenticationResponse
                    {
                        JwtToken = result!.JwtToken,
                        ExpiresIn = result.ExpiresIn,
                        UserName = result.UserName,
                        Message = "User Login Successfully",
                        IsLocked =await _userManager.IsLockedOutAsync(existing_user),
                        EmailConfirmed = await _userManager.IsEmailConfirmedAsync(existing_user),

                    });


            }

            return BadRequest(
              new AuthenticationResponse()
              {
                  Message = "Invalid User Credentials"
              });
        }

        //Register User

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationRequest authenticationRequest)
        {
            if(ModelState.IsValid)
            {

                
                var user_exist = await _userManager.FindByEmailAsync(authenticationRequest.UserName);


                //Check Email is already taken
                if (user_exist != null)
                {

                    //check added email is contain in deleted account
                    if (user_exist.Status != 1)
                    {
                        return BadRequest(
                             new AuthenticationResponse()
                             {
                                 Message = "You cant user this email"
                             });
                    }

                    return BadRequest(
                        new AuthenticationResponse()
                        {
                            Message = "Email Is Already Exist"
                        });
                }

                //Create User

                var new_user = new UserModel()
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

                    
                    //Generate token

                    var result = _jwtTokenHandler.GenerateJwtToken(tokenRequest);

                    return Ok(
                        new AuthenticationResponse
                        {
                            JwtToken=result!.JwtToken,
                            ExpiresIn=result.ExpiresIn,
                            UserName=result.UserName,
                            Message="User Create Successfully",
                            IsLocked = await _userManager.IsLockedOutAsync(new_user),
                            EmailConfirmed = await _userManager.IsEmailConfirmedAsync(new_user), 

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

        [HttpPost("Security")]
        public async Task<IActionResult> ChangeSecurity([FromBody] LockOutDetailsInfo lockOutDetailsInfo)
        {
            if(ModelState.IsValid) { 
                var exist_user = await _userManager.FindByEmailAsync(lockOutDetailsInfo.Email);

                if( exist_user != null)
                {
                   
                    var result = await _userManager.SetLockoutEnabledAsync(exist_user,lockOutDetailsInfo.LockoutEnable);
                    if(result.Succeeded) {
                        return Ok();
                    }
                    

                    

                }


            
            }

            return BadRequest();
        }
    }

}
