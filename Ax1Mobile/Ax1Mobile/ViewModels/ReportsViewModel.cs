using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ax1Mobile.ViewModels
{
    public class ReportsViewModel: INotifyPropertyChanged
    {
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
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        private ObservableCollection<CostCenter> costCenters = new ObservableCollection<CostCenter>();
        public ObservableCollection<CostCenter> CostCenters
        {
            get { return costCenters; }
            set
            {
                costCenters = value;
                OnPropertyChanged(nameof(CostCenters));
            }
        }

        public ReportsViewModel()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
