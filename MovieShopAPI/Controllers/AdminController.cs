using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // can only be accessd with roles of admin or Super Admin

        [HttpPost]
        [Route("movie")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMovie()
        {
            return Ok();
        }
    }
}