using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Ax1Mobile.ViewModels;

namespace Ax1Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostCentersViewPage : ContentPage
    {
        private const string Uri = "https://ax1web.azurewebsites.net/api/CostCenters.js";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<CostCenter> _costCenters;
        public bool IsLoading { get; set; } = false;

        public CostCentersViewPage()
        {
            InitializeComponent();
            //BindingContext = new CostCentersViewModel();
            //SetCostCentersAsync();
        }

        
        protected async Task<ObservableCollection<CostCenter>> DownloadCostCentersAsync()
        {
            string content = await _client.GetStringAsync(Uri);
            List<CostCenter> costCenters = JsonConvert.DeserializeObject<List<CostCenter>>(content);
            _costCenters = new ObservableCollection<CostCenter>(costCenters);
            return _costCenters;
        }

        protected async void SetCostCentersAsync()
        {
            IsLoading = true;
            CostCentersListView.ItemsSource = null;
            CostCentersListView.ItemsSource = await DownloadCostCentersAsync();
            IsLoading = false;
        }

        protected async void Refresh_CostCenterList(object sender, EventArgs e)
        {
            CostCentersListView.ItemsSource = null;
            CostCentersListView.ItemsSource = await DownloadCostCentersAsync();
            CostCentersListView.EndRefresh();
        } 
    }
}