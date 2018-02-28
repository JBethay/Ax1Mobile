using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ax1Mobile
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeeAsync();

        Task<Employee> GetEmployeeByIdAsync(int id);
    }
}
