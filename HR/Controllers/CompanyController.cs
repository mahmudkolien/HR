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
    [Route("/api/Companies")]
    public class CompanyController : Controller
    {
        private const string V = "/api/getMonths";
        private readonly ICompanyService CompanyService;
        private readonly IMapper mapper;

        public CompanyController(ICompanyService CompanyService, IMapper mapper)
        {
            this.CompanyService = CompanyService;
            this.mapper = mapper;
        }

       
        [HttpGet]
        public async Task<QueryResultModel<CompanyModel>> GetCompanies()
        {
            var Companys = await this.CompanyService.GetAllAsync();
            var result = mapper.Map<QueryResult<Company>, QueryResultModel<CompanyModel>>(Companys);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCompany([FromBody]CompanySaveModel model)
        {
           
             model.Id = Guid.NewGuid();
            var entity = mapper.Map<CompanySaveModel,Company>(model);
            await this.CompanyService.AddAsync(entity);
            var result = mapper.Map<Company,CompanySaveModel>(entity);
            return Ok(result);
        }
          [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody]CompanySaveModel model)
        {
           
           if(model.Id==Guid.Empty)
           {
               return BadRequest();
           }
            var entity = await this.CompanyService.GetByIdAsync(model.Id);
            if(entity==null)
            {
                return NotFound();
            }
            mapper.Map<CompanySaveModel,Company>(model,entity);
            await this.CompanyService.UpdateAsync(entity);
            var result = mapper.Map<Company,CompanySaveModel>(entity);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var Company = await this.CompanyService.GetByIdAsync(id);
            if (Company == null)
                return NotFound();

            await this.CompanyService.DeleteAsync(Company.Id);

            return Ok(id);
        }
        [HttpGet("/api/months")]
        public IEnumerable<SelectListItem> SMonthList()
        {
           
                return Enumerable.Range(1, 12).Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(x)
                });
            
        }
    }
}