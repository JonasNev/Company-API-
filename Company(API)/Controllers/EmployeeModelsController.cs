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

namespace Company_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly EmployeeService _employeeService;

        public EmployeeModelsController(DataContext context, EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }


        // GET: api/EmployeeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
        {
            return await _employeeService.GetAllAsync();
        }

        // GET: api/EmployeeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeModel(int id)
        {
            var employeeModel = await _employeeService.GetByIdAsync(id);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return employeeModel;
        }

        // PUT: api/EmployeeModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeModel employeeModel)
        {
            if (id != employeeModel.Id)
            {
                return BadRequest();
            }
            await _employeeService.UpdateAsync(id, employeeModel);

            return NoContent();
        }

        // POST: api/EmployeeModels
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> Post(EmployeeModel employeeModel)
        {

            await _employeeService.AddAsync(employeeModel);

            return CreatedAtAction("GetEmployeeModel", new { id = employeeModel.Id }, employeeModel);
        }

        // DELETE: api/EmployeeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }

        private bool EmployeeModelExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
