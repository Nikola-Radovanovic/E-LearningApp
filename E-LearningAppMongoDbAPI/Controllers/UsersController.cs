using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningAppMongoDbAPI.Models;
using E_LearningAppMongoDbAPI.Services;

namespace E_LearningAppMongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var getUser = _userService.Get(id);

            if (getUser == null)
            {
                return NotFound();
            }

            return getUser;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User user)
        {
            var updateUser = _userService.Get(id);

            if (updateUser == null)
            {
                return NotFound();
            }

            _userService.Update(id, user);

            return NoContent();
        }

        [HttpDelete("{id;length(24)}")]
        public IActionResult Delete(string id)
        {
            var deleteUser = _userService.Get(id);

            if (deleteUser == null)
            {
                return NotFound();
            }

            _userService.Remove(deleteUser.Id);

            return NoContent();
        }
    }
}