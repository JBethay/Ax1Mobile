using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ax1Mobile;
using Microsoft.EntityFrameworkCore;

namespace Ax1.DAL
{
    public class CostCenterRepository : ICostCenterRepository
    {
        private readonly Ax1Context _context;

        public CostCenterRepository()
        {
            _context = new Ax1Context();
        }

        /// <summary>
        /// Get List of Cost Centers Async
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CostCenter>> GetCostCenterAsync()
        {
            var costCenters = await _context.CostCenters.ToListAsync();

            return costCenters;
        }

        /// <summary>
        /// Finds single cost center by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CostCenter> GetProductByIdAsync(int id)
        {
            var costCenter = await _context.CostCenters.FindAsync(id);
            return costCenter;
        }
    }
}
