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
        public async Task<IEnumerable<UserRoleModel>> GetUserRoles()
        {
            var result = await this.userRoleService.GetAllAsync();

            return mapper.Map<IEnumerable<UserRole>, IEnumerable<UserRoleModel>>(result);
        }
    }
}