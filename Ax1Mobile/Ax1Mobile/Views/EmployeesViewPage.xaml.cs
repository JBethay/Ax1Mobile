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

    }
}