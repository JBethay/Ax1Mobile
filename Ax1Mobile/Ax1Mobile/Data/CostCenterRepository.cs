using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ax1Mobile
{
    public class CostCenterRepository : ICostCenterRepository
    {
        private readonly Ax1Context _dbContext;

        public CostCenterRepository(string dbPath)
        {
            _dbContext = new Ax1Context(dbPath);
        }

        public async Task<IEnumerable<CostCenter>> GetCostCentersAsync()
        {
            try
            {
                var costcenters = await _dbContext.CostCenters.ToListAsync();

                return costcenters;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<CostCenter> GetCostCenterByIdAsync(int id)
        {
            try
            {
                var costCenter = await _dbContext.CostCenters.FindAsync(id);

                return costCenter;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> AddCostCenterAsync(CostCenter costCenter)
        {
            try
            {
                var tracking = await _dbContext.CostCenters.AddAsync(costCenter);

                await _dbContext.SaveChangesAsync();

                var isAdded = tracking.State == EntityState.Added;

                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCostCenterAsync(CostCenter costCenter)
        {
            try
            {
                var tracking = _dbContext.Update(costCenter);

                await _dbContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;

                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveCostCenterAsync(int id)
        {
            try
            {
                var costCenter = await _dbContext.CostCenters.FindAsync(id);

                var tracking = _dbContext.Remove(costCenter);

                await _dbContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;

                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CostCenter>> QueryCostCenterAsync(Func<CostCenter, bool> predicate)
        {
            try
            {
                var costCenters = _dbContext.CostCenters.Where(predicate);

                return costCenters.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
