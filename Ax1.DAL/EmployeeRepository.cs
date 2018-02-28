using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ax1Mobile;
using Microsoft.EntityFrameworkCore;

namespace Ax1.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Ax1Context _context;

        public EmployeeRepository()
        {
            _context = new Ax1Context();
        }

        /// <summary>
        /// Get List of employees Async
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            var employee = await _context.Employees.ToListAsync();

            return employee;
        }

        /// <summary>
        /// Finds single employee by ID, returns details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(e => e.EmployeeId == id);
            return employee;
        }
    }
}
