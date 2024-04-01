using JormungandrBE.Collections.User.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JormungandrBE.Collections.User.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly UserService service;

        public UserController(UserService _service)
        {
            service = _service;
        }

        [HttpGet]
        public ActionResult<List<Models.User>> GetUsers()
        {
            return service.GetUsers();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Models.User> GetUser(string id)
        {
            var user = service.GetUser(id);
            if (user is null)
            {
                return new Models.User();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<Models.User> CreateUser(Models.User user)
        {
            service.CreateUser(user);

            return new JsonResult(user);
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public ActionResult<string> Authenticate([FromBody] Models.User user)
        {
            var token = service.Authenticate(user.Email, user.Password);
            if (token is null)
            {
                return new JsonResult("Invalid email or password");
            }
            return new JsonResult(token);
        }
    }
}
