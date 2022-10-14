using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using exam.Dtos.User;
using exam.Services.UserService;

namespace exam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // private static List<User> Users = new List<User> {
        //     new User(),
        //     new User{ Id = 1, Name = "Gabriel"}
        // };
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Get()
        {
            return Ok(await _UserService.GetAllUser());
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetSingle(int id)
        {
            return Ok(await _UserService.GetUserById(id));
        }

        [HttpDelete("DeleteUserById")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Delete(int id)
        {
            var response = await _UserService.DeleteUser(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("PostUser")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> AddUser(AddUserDto newUser)
        {
            return Ok(await _UserService.AddUser(newUser));
        }

        [HttpPut("PutUser")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(UpdateUserDto updateUser)
        {
            var response = await _UserService.UpdateUser(updateUser);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}