using Ax1Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ax1Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportsPage : ContentPage
	{
		public ReportsPage ()
		{
			InitializeComponent ();
            BindingContext = new ReportsViewModel();
        }
	}
}