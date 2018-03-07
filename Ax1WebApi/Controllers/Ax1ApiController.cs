using Ax1WebApi.Models;
using System.Collections;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ax1WebApi.Controllers
{
    /// <summary>
    /// Note, this controller effectively only has Read Privileges.
    /// </summary>
    public class Ax1ApiController : ApiController
    {
        Ax1WebdbEntities _context = new Ax1WebdbEntities();
        // GET: api/Ax1Api
        [HttpGet]
        [ActionName("Ax1CostCenterList")]
        public async Task<IList> CostCenterIndex()
        {
            var costCenters = await _context.CostCenters.ToListAsync();
            return costCenters;
        }

        // GET: CostCenters/Details/5
        [HttpGet]
        [ActionName("Ax1CostCenter")]
        public async Task<CostCenter> CostCenterDetails(int? id)
        {
            var costCenter = await _context.CostCenters
                .SingleOrDefaultAsync(m => m.CostCenterId == id);

            return costCenter;
        }

        // GET: Employees
        [HttpGet]
        [ActionName("Ax1EmployeeList")]
        public async Task<IList> EmployeeIndex()
        {
            var ax1Context = _context.Employees.Include(e => e.CostCenter);
            var employees = await ax1Context.ToListAsync();
            return employees;
        }

        // GET: Employees/Details/5
        [HttpGet]
        [ActionName("Ax1Employeet")]
        public async Task<Employee> EmployeeDetails(int? id)
        {
            var employee = await _context.Employees
                .Include(e => e.CostCenter)
                .SingleOrDefaultAsync(m => m.EmployeeId == id);

            return employee;
        }
    }
}
