using Company_API_.Data;
using Company_API_.Dtos;
using Company_API_.Interfaces;
using Company_API_.Models;
using Company_API_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_API_.Services
{
    public class CompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CompanyModel>> GetAllAsync()
        {
            return await _unitOfWork.Companies.GetAll();
        }

        public async Task<CompanyModel> GetByIdAsync(int id)
        {
            return await _unitOfWork.Companies.GetById(id);
        }

        public async Task AddAsync(CompanyCreate company)
        {
            var model = new CompanyModel()
            {
                Name = company.Name
            };
            _unitOfWork.Companies.Add(model);
            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            _unitOfWork.Companies.Remove(company);
            await _unitOfWork.Complete();
        }

        public async Task UpdateAsync(int id, CompanyModel company)
        {
            company.Id = id;
            _unitOfWork.Companies.Update(company);
            await _unitOfWork.Complete();
        }

        public async Task<List<EmployeeModel>> GetCompanyEmployeesAsync(int id)
        {
            var employees = _unitOfWork.Employees.Find(x => x.CompanyId == id);
            return await employees;
        }
    }
}
