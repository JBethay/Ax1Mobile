using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using Ax1Mobile.ViewModels;

namespace Ax1Mobile.Views
{
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