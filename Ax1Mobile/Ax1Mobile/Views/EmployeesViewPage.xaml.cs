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
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Employee> _employees;

        public EmployeesViewPage ()
		{
			InitializeComponent ();

            DownloadEmployeesAsync();
		}

        protected async void DownloadEmployeesAsync()
        {
            string content = await _client.GetStringAsync(Uri);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(content);
            _employees = new ObservableCollection<Employee>(employees);
            EmployeesListView.ItemsSource = _employees;
        }

    }
}