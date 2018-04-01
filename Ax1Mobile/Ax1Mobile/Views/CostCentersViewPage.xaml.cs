using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using Ax1Mobile.ViewModels;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ax1Mobile.Views
{
    /// <summary>
    /// Note: technically the below violates the MVVM design pattern, however because of the low level of complexity 
    /// I did felt it was acceptable to simply build off of the OnSelection method below rather then building out
    /// the actions in the View Model.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostCentersViewPage : ContentPage
    {
        private const string Uri = "https://ax1web.azurewebsites.net/api/Employees.js";
        private readonly HttpClient _client = new HttpClient();

        public CostCentersViewPage()
        {
            InitializeComponent();
            BindingContext = new CostCentersViewModel();
        }

        public async Task OnSelection(object sender, SelectedItemChangedEventArgs e) 
        {            
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            var count = 0;
            var employees = await DownloadEmployeesAsync();
            var c =(CostCenter)e.SelectedItem;
            foreach(var emp in employees)
            {
                if (emp.CostCenterId == c.CostCenterId)
                {
                    count++;
                }
            }
            await DisplayAlert($"Cost Center", $"Name: {c.CostCenterName}, State: {c.State}, Employee Count: {count}", "Ok");
        }

        /// <summary>
        /// Makes an API call for JSON data.
        /// </summary>
        /// <returns></returns>
        protected async Task<List<Employee>> DownloadEmployeesAsync()
        {
            string contentE = await _client.GetStringAsync(Uri);
            List<Employee> employeesData = JsonConvert.DeserializeObject<List<Employee>>(contentE);

            return employeesData;
        }
    }
}