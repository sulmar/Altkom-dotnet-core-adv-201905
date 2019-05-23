using Microsoft.AspNetCore.Mvc;

namespace Altkom.DotnetCore.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var product = new { ProductId = 1 , Name = "Product 1"};

            return Ok(product);  
        }
    }
}