using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{

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
