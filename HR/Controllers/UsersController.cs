using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR.Entities;
using HR.Models;
using HR.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] SaveUserModel userModel)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = mapper.Map<SaveUserModel, User>(userModel);

            var userId = await this.userService.AddAsync(user);

            user = await this.userService.GetByIdAsync(userId);

            var result = mapper.Map<User, UserModel>(user);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] SaveUserModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await this.userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            var updateUser = mapper.Map<SaveUserModel, User>(userModel);

            var updateUserId = await this.userService.UpdateAsync(updateUser);

            user = await this.userService.GetByIdAsync(updateUserId);
            
            var result = mapper.Map<User, UserModel>(user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await this.userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            await this.userService.DeleteAsync(user.Id);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await this.userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            var userModel = mapper.Map<User, UserModel>(user);

            return Ok(userModel);
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var result = await this.userService.GetAllAsync();

            return mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(result);
        }
    }
}