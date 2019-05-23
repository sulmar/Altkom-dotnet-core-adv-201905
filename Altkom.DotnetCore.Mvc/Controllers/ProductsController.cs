
using Microsoft.AspNetCore.Mvc;

namespace Altkom.DotnetCore.Mvc.Controllers
{

    public class ProductsController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
        
    }

}