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

namespace Ax1Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeesViewPage : ContentPage
	{
        private const string Uri = "https://ax1web.azurewebsites.net/api/Employees.js";
        private const string UriCc = "https://ax1web.azurewebsites.net/api/CostCenters.js";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Employee> _employees;

        public EmployeesViewPage ()
		{
			InitializeComponent ();

            DownloadEmployeesAsync();
		}

        protected async void DownloadEmployeesAsync()
        {
            string contentE = await _client.GetStringAsync(Uri);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(contentE);
            
            string contentC = await _client.GetStringAsync(UriCc);
            List<CostCenter> costCenters = JsonConvert.DeserializeObject<List<CostCenter>>(contentC);

            foreach(Employee e in employees)
            {
                e.CostCenter = costCenters.FirstOrDefault(o => o.CostCenterId == e.CostCenterId);
            }

            _employees = new ObservableCollection<Employee>(employees);
            EmployeesListView.ItemsSource = _employees;
        }

    }
}