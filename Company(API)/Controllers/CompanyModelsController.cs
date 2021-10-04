using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Company_API_.Data;
using Company_API_.Models;
using Company_API_.Services;
using Company_API_.Dtos;

namespace Company_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyModelsController : ControllerBase
    {
        private CompanyService _companyService;

        public CompanyModelsController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/CompanyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyModel>>> GetAll()
        {
            return await _companyService.GetAllAsync();
        }

        // GET: api/CompanyModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyModel>> GetById(int id)
        {
            return await _companyService.GetByIdAsync(id);
        }

        // PUT: api/CompanyModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CompanyModel companyModel)
        {

            await _companyService.UpdateAsync(id, companyModel);
            return NoContent();
        }

        // POST: api/CompanyModels
        [HttpPost]
        public async Task<ActionResult<CompanyModel>> Add(CompanyCreate company)
        {
            await _companyService.AddAsync(company);
            return NoContent();
        }

        // DELETE: api/CompanyModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/EmployeeModels")]
        public async Task<IActionResult> GetCompanyEmployees(int id)
        {
            var employees = await _companyService.GetCompanyEmployeesAsync(id);
            return Ok(new { Employees = employees });
        }


        [HttpGet("{id}/EmployeeModelsCount")]
        public async Task<ActionResult> GetCount(int id)
        {
            var employees = await _companyService.GetCompanyEmployeesAsync(id);
            return Ok(new { Count = employees.Count });
        }
    }
}
