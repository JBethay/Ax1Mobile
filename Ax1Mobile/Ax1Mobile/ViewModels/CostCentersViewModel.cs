using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ax1Mobile.ViewModels
{
    public class CostCentersViewModel : INotifyPropertyChanged
    {

        private const string Uri = "https://ax1web.azurewebsites.net/api/CostCenters.js";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<CostCenter> _costCenters;
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        private ObservableCollection<CostCenter> costCenters = new ObservableCollection<CostCenter>();
        public ObservableCollection<CostCenter> CostCenters
        {
            get { return costCenters; }
            set { costCenters = value;
                OnPropertyChanged(nameof(CostCenters));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CostCentersViewModel()
        {
            SetCostCentersAsync();
        }


        /// <summary>
        /// Makes the API call for JSON data.
        /// </summary>
        /// <returns></returns>
        protected async Task<ObservableCollection<CostCenter>> DownloadCostCentersAsync()
        {
            string content = await _client.GetStringAsync(Uri);
            List<CostCenter> costCenters = JsonConvert.DeserializeObject<List<CostCenter>>(content);
            _costCenters = new ObservableCollection<CostCenter>(costCenters);
            return _costCenters;
        }

        /// <summary>
        /// Sets the value of the ListView on appearing.
        /// </summary>
        public async void SetCostCentersAsync()
        {
            IsBusy = false;
            _costCenters = await DownloadCostCentersAsync();
            costCenters.Clear();
            foreach (CostCenter c in _costCenters)
            {
                costCenters.Add(c);
            }
            IsBusy = false;
        }

        /// <summary>
        /// Refresh Command
        /// </summary>
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    _costCenters = await DownloadCostCentersAsync();
                    costCenters.Clear();
                    foreach (CostCenter c in _costCenters)
                    {
                        costCenters.Add(c);
                    }
                    IsBusy = false;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
