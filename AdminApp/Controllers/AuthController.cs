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
            LoginEntity login = new LoginEntity(){Username = "maarten.jakobs@gmail.com", Password = "sonu@123" };
            UserEntity user = cont.Login(login);
            if (user != null)
            {
                //await notificationController.GetAsync("user", user.Id);
                return Ok(user);
            }

            return Unauthorized(new {message = "Username or password is incorrect"});
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginEntity loginParam)
        {
            UserEntity user = cont.Login(loginParam);
            if (user != null)
            {
                //await notificationController.GetAsync("user", user.Id);
                return Ok(user);
            }

            return Unauthorized(new { message = "Username or password is incorrect" });
        }
    }
}
