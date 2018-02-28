
using Android.App;
using Android.Content.PM;
using Android.OS;
using Ax1.DAL;

namespace Ax1Mobile.Droid
{
    [Activity(Label = "Ax1Mobile", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            var costCenterRepository = new CostCenterRepository();
            var employeeRepositroy = new EmployeeRepository();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(costCenterRepository, employeeRepositroy));
        }
    }
}

