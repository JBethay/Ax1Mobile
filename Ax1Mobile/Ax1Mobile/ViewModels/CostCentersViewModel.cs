using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ax1Mobile.ViewModels
{
    public class CostCentersViewModel : INotifyPropertyChanged
    {
        private const string Uri = "https://ax1web.azurewebsites.net/api/CostCenters.js";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<CostCenter> _costCenters;
        public ObservableCollection<CostCenter> CostCenters;
        public bool IsLoading { get; set; } = false;

        CostCenter x = new CostCenter() { CostCenterId = 112013, CostCenterName = "Blah", State = StateAbrv.AK, CenterEmployees = null };

        public CostCentersViewModel()
        {
            SetCostCentersAsync();            
            CostCenters.Add(x);
        }

        protected async Task<ObservableCollection<CostCenter>> DownloadCostCentersAsync()
        {
            string content = await _client.GetStringAsync(Uri);
            List<CostCenter> costCenters = JsonConvert.DeserializeObject<List<CostCenter>>(content);
            _costCenters = new ObservableCollection<CostCenter>(costCenters);
            return _costCenters;
        }

        public async void SetCostCentersAsync()
        {
            IsLoading = true;
            CostCenters = null;
            CostCenters = new ObservableCollection<CostCenter>();
            CostCenters = await DownloadCostCentersAsync();
            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
