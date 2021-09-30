using Company_API_.Data;
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
        private EmployeeRepository _employeeRepository;
        private CompanyRepository _companyRepository;
        private readonly DataContext _context;

        public CompanyService(EmployeeRepository employeeRepository, CompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyModel>> GetAllAsync()
        {
            return await _companyRepository.GetAsync();
        }

        public async Task<CompanyModel> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CompanyModel company)
        {
            await _companyRepository.AddAsync(company);
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            await _companyRepository.DeleteAsync(company);
        }

        public async Task UpdateAsync(int id, CompanyModel company)
        {
            company.Id = id;
            await _companyRepository.UpdateAsync(company);
        }

        public async Task<CompanyModel> GetCompanyEmployeesAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            company.
            return await _companyRepository.GetByIdAsync(id);
        }
    }
}
