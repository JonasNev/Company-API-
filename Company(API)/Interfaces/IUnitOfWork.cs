using Company_API_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_API_.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<EmployeeModel> Employees { get; }
        IGenericRepository<CompanyModel> Companies { get; }
        Task<int> Complete();
    }
}
