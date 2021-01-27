using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Dtos;
using SocialNetwork.Models;
using SocialNetwork.Repositories;

namespace SocialNetwork.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _todoRepository;

        public UserController(IPostRepository todoRepository, IUserRepository userRepository)
        {
            _todoRepository = todoRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            if (users is null)
                return NotFound(users);
            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user is null)
                return NotFound(user);
            return user;
        }

        [HttpPost]
        [Route("adduser")]
        public ActionResult<User> AddUser([FromBody] UserDto userDto)
        {
            try
            {
                _userRepository.AddUser(userDto);
                return NoContent();
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult RemoveUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user is null)
                return NotFound($"No post found. (Id: {id})");
            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
