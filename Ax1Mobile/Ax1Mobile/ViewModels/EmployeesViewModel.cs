using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ax1Mobile.ViewModels
{
    public class EmployeesViewModel: INotifyPropertyChanged
    {
        private const string Uri = "https://ax1web.azurewebsites.net/api/Employees.js";
        private const string UriCc = "https://ax1web.azurewebsites.net/api/CostCenters.js";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Employee> _employees;
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeesViewModel()
        {
            SetEmployeesAsync();
        }

        /// <summary>
        /// Makes the API call for JSON data.
        /// </summary>
        /// <returns></returns>
        protected async Task<ObservableCollection<Employee>> DownloadEmployeesAsync()
        {
            string contentE = await _client.GetStringAsync(Uri);
            List<Employee> employeesData = JsonConvert.DeserializeObject<List<Employee>>(contentE);

            string contentC = await _client.GetStringAsync(UriCc);
            List<CostCenter> costCenters = JsonConvert.DeserializeObject<List<CostCenter>>(contentC);

            foreach (Employee e in employeesData)
            {
                e.CostCenter = costCenters.FirstOrDefault(o => o.CostCenterId == e.CostCenterId);
            }

            _employees = new ObservableCollection<Employee>(employeesData);

            return _employees;
        }

        /// <summary>
        /// Sets the value of the ListView on appearing.
        /// </summary>
        public async void SetEmployeesAsync()
        {
            IsBusy = false;
            _employees = await DownloadEmployeesAsync();
            employees.Clear();
            foreach (Employee e in _employees)
            {
                employees.Add(e);
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
                    _employees = await DownloadEmployeesAsync();
                    employees.Clear();
                    foreach (Employee e in _employees)
                    {
                        employees.Add(e);
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
