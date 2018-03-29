using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using Ax1Mobile.ViewModels;

namespace Ax1Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostCentersViewPage : ContentPage
    {
        public CostCentersViewPage()
        {
            InitializeComponent();
            BindingContext = new CostCentersViewModel();
        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e) 
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            var c =(CostCenter)e.SelectedItem;

            DisplayAlert($"Cost Center", $"Name: {c.CostCenterName}, State: {c.State}", "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
    }
}