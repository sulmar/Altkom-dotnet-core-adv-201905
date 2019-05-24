
using Microsoft.AspNetCore.Mvc;
using System;

namespace Altkom.DotnetCore.Mvc.Controllers
{

    public class ProductsController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }

        [Route("~/api/products")]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
        
    }

}