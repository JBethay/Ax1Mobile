using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ax1Mobile
{   
    /// <summary>
    /// Basic CostCenter class.
    /// </summary>
    public class CostCenter
    {
        [Key]
        public int CostCenterId { get; set; }

        [DisplayName("Cost Center Name")]
        [RegularExpression(@"^[A-Z][-a-zA-Z.\s_-]+$", ErrorMessage = "Name is not formated properly.")]
        [MaxLength (200)]
        public string CostCenterName { get; set; }

        public StateAbrv State { get; set; }

        //public ICollection<Employee> CenterEmployees { get; set; }

        public override string ToString()
        {
            return string.Format("({0}) {1} {2}", CostCenterId, CostCenterName, State);
        }
    }
}
