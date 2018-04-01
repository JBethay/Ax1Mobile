using Ax1Mobile.ViewModels.HelperClasses;
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

namespace Ax1Mobile.ViewModels
{
    public class ReportsViewModel: INotifyPropertyChanged
    {
        #region Properties
        private double totalCost = 0;
        public double TotalCost
        {
            get { return totalCost; }
            set
            {
                totalCost = value;
                OnPropertyChanged(nameof(TotalCost));
            }
        }
        private double averageCost = 0;
        public double AverageCost
        {
            get { return averageCost; }
            set
            {
                averageCost = value;
                OnPropertyChanged(nameof(AverageCost));
            }
        }
        private double totalEmployees = 0;
        public double TotalEmployees
        {
            get { return totalEmployees; }
            set
            {
                  totalEmployees = value;
                  OnPropertyChanged(nameof(TotalEmployees));
            }
        }
        private double averageEmployees = 0;
        public double AverageEmployees
        {
            get { return averageEmployees; }
            set
            {
                averageEmployees = value;
                OnPropertyChanged(nameof(AverageEmployees));
            }
        }
        private double totalCostCenters = 0;
        public double TotalCostCenters
        {
            get { return totalCostCenters; }
            set
            {
                totalCostCenters = value;
                OnPropertyChanged(nameof(TotalCostCenters));
            }
        }
        private const string UriE = "https://ax1web.azurewebsites.net/api/Employees.js";
        private const string UriC = "https://ax1web.azurewebsites.net/api/CostCenters.js";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<CostCenter> _costCenters;
        private bool isLoading = false;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        //private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        //public ObservableCollection<Employee> Employees
        //{
        //    get { return employees; }
        //    set
        //    {
        //        employees = value;
        //        OnPropertyChanged(nameof(Employees));
        //    }
        //}
        //private ObservableCollection<CostCenter> costCenters = new ObservableCollection<CostCenter>();
        //public ObservableCollection<CostCenter> CostCenters
        //{
        //    get { return costCenters; }
        //    set
        //    {
        //        costCenters = value;
        //        OnPropertyChanged(nameof(CostCenters));
        //    }
        //}
        #endregion

        public ReportsViewModel()
        {
            SetReportsTabAsync();
        }


        /// <summary>
        /// Makes the API call for JSON data.
        /// </summary>
        /// <returns></returns>
        protected async Task<DownloadResults> DownloadEmployeesAsync()
        {
            string contentE = await _client.GetStringAsync(UriE);
            List<Employee> employeesData = JsonConvert.DeserializeObject<List<Employee>>(contentE);

            string contentC = await _client.GetStringAsync(UriC);
            List<CostCenter> costCenters = JsonConvert.DeserializeObject<List<CostCenter>>(contentC);

            foreach (CostCenter c in costCenters)
            {
                CostCenter reportCostCenter = new CostCenter();
                c.CenterEmployees = new List<Employee>();
                reportCostCenter = c;

                foreach (Employee e in employeesData)
                {
                    if (e.CostCenterId == c.CostCenterId)
                    {
                        c.CenterEmployees.Add(e);
                        e.CostCenter = reportCostCenter;
                    }
                }
            }

            _employees = new ObservableCollection<Employee>(employeesData);
            _costCenters = new ObservableCollection<CostCenter>(costCenters);

            DownloadResults results = new DownloadResults() {CostCentersResults = _costCenters, EmployeesResults = _employees };

            return results;
        }

        /// <summary>
        /// Sets the Reports Tab on appearing.
        /// </summary>
        public async void SetReportsTabAsync()
        {
            IsLoading = true;
            var result = await DownloadEmployeesAsync();

            TotalCost = Ax1Mobile.ViewModels.HelperClasses.CostCenterReport.TotalUSOppsCost(result.CostCentersResults);
            AverageCost = Ax1Mobile.ViewModels.HelperClasses.CostCenterReport.AverageUSOppsCost(result.CostCentersResults);
            TotalEmployees = Ax1Mobile.ViewModels.HelperClasses.CostCenterReport.TotalNumberOfUSEmployees(result.CostCentersResults);
            AverageEmployees = Ax1Mobile.ViewModels.HelperClasses.CostCenterReport.AverageNumberOfEmployeesUSOpps(result.CostCentersResults);
            TotalCostCenters = result.CostCentersResults.Count;
            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
