using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using HR.Core;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Models;
using HR.Models.QueryModels;
using HR.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HR.Controllers
{
    [Route("/api/users")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment host;
        private readonly PhotoSettings photoSettings;
        private readonly IPhotoStorage photoStorage;

        public UsersController(
            IHostingEnvironment host, 
            IOptionsSnapshot<PhotoSettings> options, 
            IPhotoStorage photoStorage, 
            IUserService userService, 
            IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.photoSettings = options.Value;
            this.host = host;
            this.photoStorage = photoStorage;
        }

        [HttpPost]
        [Authorize(Roles = RolePermission.SuperAdmin+","+RolePermission.UserCreate)]
        public async Task<IActionResult> CreateUser([FromForm] SaveUserModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = mapper.Map<SaveUserModel, User>(userModel);

            if (userModel.InputFile!=null)
            {
                if (userModel.InputFile == null) return BadRequest("Null file");
                if (userModel.InputFile.Length == 0) return BadRequest("Empty file");
                if (userModel.InputFile.Length > photoSettings.MaxBytes) return BadRequest("Max file size exceeded");
                if (!photoSettings.IsSupported(userModel.InputFile.FileName)) return BadRequest("Invalid file type.");
                var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
                var image = await photoStorage.StorePhoto(uploadsFolderPath, userModel.InputFile);
                user.ImageFile = image;
            }

            var userId = await this.userService.AddAsync(user);

            user = await this.userService.GetByIdAsync(userId);

            var result = mapper.Map<User, UserModel>(user);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = RolePermission.SuperAdmin+","+RolePermission.UserEdit)]
        public async Task<IActionResult> UpdateUser(Guid id, [FromForm] SaveUserModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await this.userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            //var updateUser = mapper.Map<SaveUserModel, User>(userModel);
            //var updateUserId = await this.userService.UpdateAsync(updateUser);
            //user = await this.userService.GetByIdAsync(updateUserId);

            mapper.Map<SaveUserModel, User>(userModel, user);

            if (userModel.InputFile!=null)
            {
                if (userModel.InputFile == null) return BadRequest("Null file");
                if (userModel.InputFile.Length == 0) return BadRequest("Empty file");
                if (userModel.InputFile.Length > photoSettings.MaxBytes) return BadRequest("Max file size exceeded");
                if (!photoSettings.IsSupported(userModel.InputFile.FileName)) return BadRequest("Invalid file type.");
                var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
                var image = await photoStorage.StorePhoto(uploadsFolderPath, userModel.InputFile);
                user.ImageFile = image;
            }
            
            var userId = await this.userService.UpdateAsync(user);

            user = await this.userService.GetByIdAsync(userId);
            
            var result = mapper.Map<User, UserModel>(user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RolePermission.SuperAdmin+","+RolePermission.UserDelete)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await this.userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            await this.userService.DeleteAsync(user.Id);

            return Ok(id);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = RolePermission.SuperAdmin+","+RolePermission.UserView)]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await this.userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            var userModel = mapper.Map<User, UserModel>(user);

            return Ok(userModel);
        }

        [HttpGet]
        [Authorize(Roles = RolePermission.SuperAdmin+","+RolePermission.UserView)]
        public async Task<QueryResultModel<UserModel>> GetUsers([FromQuery] UserQueryModel queryModel)
        {
            var query = mapper.Map<UserQueryModel, UserQuery>(queryModel);
            
            var result = await this.userService.GetAllAsync(query);

            return mapper.Map<QueryResult<User>, QueryResultModel<UserModel>>(result);
        }
    }
}