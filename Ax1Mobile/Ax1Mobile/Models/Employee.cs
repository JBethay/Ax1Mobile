using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ax1Mobile
{
    /// <summary>
    /// Basic Employee Class.
    /// </summary>
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [DisplayName("First Name")]
        [RegularExpression(@"^[A-Z][-a-zA-Z]+$", ErrorMessage = "Name is not formated properly.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [RegularExpression(@"^[A-Z][-a-zA-Z]+$", ErrorMessage = "Name is not formated properly.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayName("Annual Pay")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:C0}")]
        public double AnnualPay { get; set; }

        [DisplayName("Cost Center")]
        public int CostCenterId { get; set; }

        [DisplayName("Cost Center")]
        public CostCenter CostCenter { get; set; }
    }
}
