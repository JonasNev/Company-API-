using Company_API_.Data;
using Company_API_.Interfaces;
using Company_API_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_API_.Repositories
{
    public class EmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeModel>> GetAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(EmployeeModel employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EmployeeModel employee)
        {
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(EmployeeModel employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

    }
}
