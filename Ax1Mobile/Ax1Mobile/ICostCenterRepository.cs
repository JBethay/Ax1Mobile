using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ax1Mobile
{
    public interface ICostCenterRepository
    {
        Task<IEnumerable<CostCenter>> GetCostCenterAsync();

        Task<CostCenter> GetProductByIdAsync(int id);
    }
}
