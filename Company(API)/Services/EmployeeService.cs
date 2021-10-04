using Company_API_.Data;
using Company_API_.Dtos;
using Company_API_.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAll();
            return employees;
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            return await _unitOfWork.Employees.GetById(id);
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
            _unitOfWork.Employees.Add(model);
            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            _unitOfWork.Employees.Remove(employee);
            await _unitOfWork.Complete();
        }

        public async Task UpdateAsync(int id, EmployeeModel employeeModel)
        {
            var employee = await _unitOfWork.Employees.GetById(id);
            if (employee != null)
            {
                employee.Id = employeeModel.Id;
                employee.FirstName = employeeModel.FirstName;
                employee.LastName = employeeModel.LastName;
                employee.Sex = employeeModel.Sex;
            }

            await _unitOfWork.Complete();
        }

    }
}
