using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{

    [Authorize(Roles ="Role")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
       
        [HttpGet]
        public String Index()
        {
            return "home";
        }
    }
}
