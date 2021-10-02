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

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyModel>> GetAsync()
        {
            return await _context.CompanyModel.ToListAsync();
        }

        public async Task<CompanyModel> GetByIdAsync(int id)
        {
            return await _context.CompanyModel.Include(x => x.Employees).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(CompanyModel company)
        {
            _context.CompanyModel.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CompanyModel company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CompanyModel company)
        {

            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
