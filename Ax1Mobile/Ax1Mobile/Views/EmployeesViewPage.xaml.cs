using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using Ax1Mobile.ViewModels;

namespace Ax1Mobile.Views
{
    /// <summary>
    /// Note: technically the below violates the MVVM design pattern, however because of the low level of complexity 
    /// I did felt it was acceptable to simply build off of the OnSelection method below rather then building out
    /// the actions in the View Model.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeesViewPage : ContentPage
	{
        public EmployeesViewPage ()
		{
			InitializeComponent ();
            BindingContext = new EmployeesViewModel();
		}

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            var c = (Employee)e.SelectedItem;

            DisplayAlert($"Employee Details", $"Name: {c.FirstName} {c.LastName}, Cost Center: {c.CostCenter.CostCenterName}, Pay: {c.AnnualPay:C0}, Start Date: {c.StartDate:MM/dd/yyyy}", "Ok");
        }

    }
}