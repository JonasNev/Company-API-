using Company_API_.Data;
using Company_API_.Interfaces;
using Company_API_.Models;
using Company_API_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_API_.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IGenericRepository<EmployeeModel> Employees { get; private set; }
        public IGenericRepository<CompanyModel> Companies { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Employees = new GenericRepository<EmployeeModel>(_context);
            Companies = new GenericRepository<CompanyModel>(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }

}
