using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("/api/departments")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

       
        [HttpGet]
        public async Task<QueryResultModel<DepartmentModel>> GetDepartments()
        {
            var departments = await this.departmentService.GetAllAsync();
            var result = mapper.Map<QueryResult<Department>, QueryResultModel<DepartmentModel>>(departments);

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> SaveDepartment([FromBody]DepartmentSaveModel model)
        {
           
             model.Id = Guid.NewGuid();
            var entity = mapper.Map<DepartmentSaveModel,Department>(model);
            await this.departmentService.AddAsync(entity);
            var result = mapper.Map<Department,DepartmentSaveModel>(entity);
            return Ok(result);
        }
          [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody]DepartmentSaveModel model)
        {
           
           if(model.Id==Guid.Empty)
           {
               return BadRequest();
           }
            var entity = await this.departmentService.GetByIdAsync(model.Id);
            if(entity==null)
            {
                return NotFound();
            }

            entity.DepartmentName = model.DepartmentName;
            await this.departmentService.UpdateAsync(entity);
            var result = mapper.Map<Department,DepartmentSaveModel>(entity);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            var department = await this.departmentService.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            await this.departmentService.DeleteAsync(department.Id);

            return Ok(id);
        }
    }
}