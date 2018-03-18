using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Ax1Mobile
{
    /// <summary>
    /// Basic Employee Class.
    /// </summary>
    public class Employee
    {
        public int EmployeeId { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("AnnualPay")]
        public double AnnualPay { get; set; }

        [JsonProperty("CostCenterId")]
        public int CostCenterId { get; set; }

        public CostCenter CostCenter { get; set; }
    }
}
