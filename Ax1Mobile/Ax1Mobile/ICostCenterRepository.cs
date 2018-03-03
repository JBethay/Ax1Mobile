using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ax1Mobile
{
    public interface ICostCenterRepository
    {
        Task<IEnumerable<CostCenter>> GetCostCentersAsync();

        Task<CostCenter> GetCostCenterByIdAsync(int id);
    }
}
