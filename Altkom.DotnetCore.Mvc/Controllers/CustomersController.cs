using Altkom.DotnetCore.IServices;
using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.Mvc.Controllers
{
   


    [Route("api/[controller]")]
    [Authorize(Roles ="developers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService customersService;
        private readonly ILogger<CustomersController> logger;

        public CustomersController(
            ICustomersService customersService,
            ILogger<CustomersController> logger
            
            )
        {
            this.logger = logger;

            this.customersService = customersService;
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            //if (!this.User.Identity.IsAuthenticated)
            //{
            //    return BadRequest();
            //}

            logger.LogInformation("Get Customers");

            if (this.User.IsInRole("Boss"))
            {
            }

            var customers = customersService.Get();

            return Ok(customers);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromServices]ICustomersService localService, Customer customer)
        {
            if (this.User.HasClaim(p=>p.Type == "Phone"))
            {
                var phone = this.User.Claims.First(p => p.Type == "Phone").Value;

                   
            }
            return Ok();
        }
    }
}
