using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Ax1Mobile
{   
    /// <summary>
    /// Basic CostCenter class.
    /// </summary>
    public class CostCenter
    {
        public int CostCenterId { get; set; }

        [JsonProperty("CostCenterName")]
        public string CostCenterName { get; set; }

        [JsonProperty("State")]
        public StateAbrv State { get; set; }

        public ICollection<Employee> CenterEmployees { get; set; }
    }
}
