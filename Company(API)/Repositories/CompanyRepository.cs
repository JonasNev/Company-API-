using Company_API_.Data;
using Company_API_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_API_.Repositories
{
    public class CompanyRepository
    {
        private readonly DataContext _context;


        public async Task<List<CompanyModel>> GetAsync()
        {
            return await _context.CompanyModel.ToListAsync();
        }

        public async Task<CompanyModel> GetByIdAsync(int id)
        {
            return await _context.CompanyModel.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(CompanyModel company)
        {
            _context.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CompanyModel company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}
