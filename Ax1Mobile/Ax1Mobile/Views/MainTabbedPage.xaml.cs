using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BottomBar.XamarinForms;

namespace Ax1Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainTabbedPage : BottomBarPage
	{
		public MainTabbedPage ()
		{
			InitializeComponent ();
		}
	}
}