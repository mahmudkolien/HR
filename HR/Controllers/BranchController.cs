using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Models;
using HR.Models.QueryModels;
using HR.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR.Controllers
{
    [Route("/api/branches")]
    public class BranchController : Controller
    {
     
        private readonly IBranchService branchService;
        private readonly IMapper mapper;

        public BranchController(IBranchService branchService, IMapper mapper)
        {
            this.branchService = branchService;
            this.mapper = mapper;
        }

       
        [HttpGet]
        public async Task<QueryResultModel<BranchModel>> GetBranches()
        {
            var branches = await this.branchService.GetAllAsync();
            var result = mapper.Map<QueryResult<Branch>, QueryResultModel<BranchModel>>(branches);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> SaveBranch([FromBody]BranchSaveModel model)
        {
           
             model.Id = Guid.NewGuid();
            var entity = mapper.Map<BranchSaveModel,Branch>(model);
            await this.branchService.AddAsync(entity);
            var result = mapper.Map<Branch,BranchSaveModel>(entity);
            return Ok(result);
        }
          [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody]BranchSaveModel model)
        {
           
           if(model.Id==Guid.Empty)
           {
               return BadRequest();
           }
            var entity = await this.branchService.GetByIdAsync(model.Id);
            if(entity==null)
            {
                return NotFound();
            }
            mapper.Map<BranchSaveModel,Branch>(model,entity);
            await this.branchService.UpdateAsync(entity);
            var result = mapper.Map<Branch,BranchSaveModel>(entity);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var branch = await this.branchService.GetByIdAsync(id);
            if (branch == null)
                return NotFound();

            await this.branchService.DeleteAsync(branch.Id);

            return Ok(id);
        }
       
    }
}