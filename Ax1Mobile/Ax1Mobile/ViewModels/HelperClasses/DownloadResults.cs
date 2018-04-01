using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ax1Mobile.ViewModels.HelperClasses
{
    /// <summary>
    /// Class used for Objects in Reports View Model
    /// </summary>
    public class DownloadResults
    {
        public ObservableCollection<CostCenter> CostCentersResults;
        public ObservableCollection<Employee> EmployeesResults;
    }
}
