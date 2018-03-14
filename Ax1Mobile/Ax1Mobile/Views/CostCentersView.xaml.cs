using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ax1Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CostCentersView : ContentPage
	{
        private string Uri = "https://ax1web.azurewebsites.net/api/CostCenters.js";

		public CostCentersView ()
		{
			InitializeComponent ();

            DownloadCostCentersAsync();
		}

        private async Task DownloadCostCentersAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Uri);
        }
    }
}