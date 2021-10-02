using Company_API_.Data;
using Company_API_.Interfaces;
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
        public IEmployeeRepository Employees { get; private set; }

        public UnitOfWork(DataContext context, IEmployeeRepository employees)
        {
            _context = context;
            Employees = employees;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
