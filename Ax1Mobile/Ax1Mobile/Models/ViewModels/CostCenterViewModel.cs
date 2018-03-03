using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace Ax1Mobile
{
    public class CostCenterViewModel : INotifyPropertyChanged
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
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RefreshCommand
        {
            get
            {
                return new Xamarin.Forms.Command(async () =>
                {
                    CostCenters = await _costCenterRepository.GetCostCentersAsync();
                });
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
