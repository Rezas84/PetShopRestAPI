using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetShop.RestAPI.Controllers
{
    //comment

    [Route("[action]")]
    [ApiController]
    [Authorize]
    public class TestAutorize : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(User.Identity.Name);
        }
    }
}
