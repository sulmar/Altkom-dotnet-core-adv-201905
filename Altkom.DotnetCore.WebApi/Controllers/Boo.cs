using Microsoft.AspNetCore.Mvc;

namespace Altkom.DotnetCore.WebApi.Controllers
{
    [Route("/api/[controller]")]
    [Route("/api/Foo")]
    public class BooController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok();
        }        
    }

}