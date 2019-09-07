using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Models;
using HR.Models.QueryModels;
using HR.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [Route("/api/userroles")]
    public class UserRolesController : Controller
    {
        private readonly IUserRoleService userRoleService;
        private readonly IMapper mapper;

        public UserRolesController(IUserRoleService userRoleService, IMapper mapper)
        {
            this.userRoleService = userRoleService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRole([FromBody] SaveUserRoleModel userRoleModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userRole = mapper.Map<SaveUserRoleModel, UserRole>(userRoleModel);

            var userRoleId = await this.userRoleService.AddAsync(userRole);

            userRole = await this.userRoleService.GetByIdAsync(userRoleId);

            var result = mapper.Map<UserRole, UserRoleModel>(userRole);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserRole(Guid id, [FromBody] SaveUserRoleModel userRoleModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userRole = await this.userRoleService.GetByIdAsync(id);

            if (userRole == null)
                return NotFound();

            mapper.Map<SaveUserRoleModel, UserRole>(userRoleModel, userRole);
            
            var userRoleId = await this.userRoleService.UpdateAsync(userRole);

            userRole = await this.userRoleService.GetByIdAsync(userRoleId);
            
            var result = mapper.Map<UserRole, UserRoleModel>(userRole);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(Guid id)
        {
            var userRole = await this.userRoleService.GetByIdAsync(id);

            if (userRole == null)
                return NotFound();

            await this.userRoleService.DeleteAsync(userRole.Id);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRole(Guid id)
        {
            var userRole = await this.userRoleService.GetByIdAsync(id);

            if (userRole == null)
                return NotFound();

            var userRoleModel = mapper.Map<UserRole, UserRoleModel>(userRole);

            return Ok(userRoleModel);
        }

        [HttpGet]
        public async Task<QueryResultModel<UserRoleModel>> GetUserRoles([FromQuery] UserRoleQueryModel queryModel)
        {
            var query = mapper.Map<UserRoleQueryModel, UserRoleQuery>(queryModel);
            
            var result = await this.userRoleService.GetAllAsync(query);

            return mapper.Map<QueryResult<UserRole>, QueryResultModel<UserRoleModel>>(result);
        }
    }
}