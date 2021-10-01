using Company_API_.Data;
using Company_API_.Dtos;
using Company_API_.Models;
using Company_API_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_API_.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository;
        private CompanyRepository _companyRepository;
        private readonly DataContext _context;

        public EmployeeService(EmployeeRepository employeeRepository, CompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            return await _employeeRepository.GetAsync();
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(EmployeeCreate employee)
        {
            var model = new EmployeeModel()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Sex = employee.Sex,
                CompanyId = employee.CompanyId
            };
            await _employeeRepository.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task UpdateAsync(int id, EmployeeModel employeeModel)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee != null)
            {
                employee.Id = employeeModel.Id;
                employee.FirstName = employeeModel.FirstName;
                employee.LastName = employeeModel.LastName;
                employee.Sex = employeeModel.Sex;
            }

            await _employeeRepository.UpdateAsync(employee);
        }

    }
}
