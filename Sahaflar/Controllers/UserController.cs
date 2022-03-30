using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sahaflar.Entities;
using Sahaflar.Models;
using Sahaflar.Repositories.Abstract;
using System.Collections.Generic;

namespace Sahaflar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
                this.userRepository= userRepository;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
           bool result= userRepository.AddUser(user);
            if(result)
            {
            return Ok(new ResultModel {State="Succeed",Message="User created successfully" });
           }

            return BadRequest(new ResultModel { State = "Warning", Message = "User could not create" });

        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            List<User> users = userRepository.GetUsers();
            if (users!=null)
            {
                return Ok(users);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "Any users cannot be found" });

        }

        [HttpGet]
        [Route("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            User user = userRepository.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "User cannot be found" });

        }

    }
}
