﻿using System;
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
using Company_API_.Interfaces;

namespace Company_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeModelsController(IUnitOfWork unitOfWork, EmployeeService employeeService)
        {
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
        }


        // GET: api/EmployeeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
        {
            return Ok(_unitOfWork.Employees.GetAll());
        }

        // GET: api/EmployeeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeModel(int id)
        {
            return Ok(_unitOfWork.Employees.GetById(id));
        }

        // PUT: api/EmployeeModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeModel employeeModel)
        {
            await _employeeService.UpdateAsync(id, employeeModel);
            return NoContent();
        }

        // POST: api/EmployeeModels
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> Post(EmployeeCreate employee)
        {

            await _employeeService.AddAsync(employee);

            return NoContent();
        }

        // DELETE: api/EmployeeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }


    }
}
