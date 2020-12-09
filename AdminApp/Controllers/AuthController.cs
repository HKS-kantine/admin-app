using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminLogic;
using AdminLogic.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Auth cont = new Auth();

        [HttpGet]
        public IActionResult Get()
        {
            UserEntity user = cont.Login();
            if (user != null)
            {
                //await notificationController.GetAsync("user", user.Id);
                return Ok(user);
            }

            return Unauthorized(new {message = "Username or password is incorrect"});
        }
    }
}
