using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ax1Mobile
{
    public class CostCenterViewModel //: INotifyPropertyChanged
    {
        private readonly ICostCenterRepository _costCenterRepository;
        private IEnumerable<CostCenter> _costCenters;
        
        public CostCenterViewModel(ICostCenterRepository costCenterRepository)
        {
            _costCenterRepository = costCenterRepository;
        }

        public IEnumerable<CostCenter> CostCenters
        {
            get
            {
                return _costCenters;
            }
            set
            {
                _costCenters = value;
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
