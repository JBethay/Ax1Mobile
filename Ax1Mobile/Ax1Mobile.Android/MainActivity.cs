
using Android.App;
using Android.Content.PM;
using Android.OS;
using Ax1.DAL;
using System.IO;

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

            var localdb = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "localDB.db");

            var costCenterRepository = new CostCenterRepository(localdb);
            //var employeeRepositroy = new EmployeeRepository(localdb);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(costCenterRepository));
        }
    }
}

