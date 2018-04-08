using Ax1Mobile.ViewModels;
using Ax1Mobile.ViewModels.HelperClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Ax1Mobile.Views
{
	/// <summary>
    /// Note: technically the below violates the MVVM design pattern, however because of the low level of complexity 
    /// I did not feel it was necessary to create an entirely separate Binding Map context and instead utilized the below.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportsPage : ContentPage
	{
        private ObservableCollection<Pin> pins;
        public ObservableCollection<Pin>Pins
        {
            get { return pins; }
            set { pins = value; }
        }

        private const string Uri = "https://ax1web.azurewebsites.net/api/CostCenters.js";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<CostCenter> _costCenters;

        public ReportsPage ()
		{
			InitializeComponent ();
            BindingContext = new ReportsViewModel();
            SetMap();
        }

        /// <summary>
        /// Makes the API call for JSON data.
        /// </summary>
        /// <returns></returns>
        protected async Task<ObservableCollection<Pin>> DownloadCostCenterLocationsAsync()
        {
            string content = await _client.GetStringAsync(Uri);
            List<CostCenter> costCenters = JsonConvert.DeserializeObject<List<CostCenter>>(content);
            _costCenters = new ObservableCollection<CostCenter>(costCenters);
            var _pins = new ObservableCollection<Pin>();

            foreach(CostCenter c in _costCenters)
            {
                var geolocation = GetGeoLocation.GetLocatoinServices($"{c.CostCenterName}, {c.State}");

                for (var i = 0; i < 10; i++)
                {
                    if (geolocation.Item3 == false)
                    {
                        geolocation = GetGeoLocation.GetLocatoinServices($"{c.CostCenterName}, {c.State}");
                    }
                    else { break; }
                }

                if (geolocation.Item3 == true)
                {
                    Pin pin = new Pin() { Position = new Position(Convert.ToDouble(geolocation.Item1), Convert.ToDouble(geolocation.Item2)), Label = $"{c.CostCenterName}" };
                    _pins.Add(pin);
                }
                //else { DisplayAlert("oops", "Somthings off", "Ok"); }
            }
            return _pins; 
        }

        private async void SetMap()
        {
            CostCenterLocations.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(39, -96), Distance.FromMiles(1000)));
            Pins = await DownloadCostCenterLocationsAsync();
            foreach(Pin p in Pins)
            {
                CostCenterLocations.Pins.Add(p);
            }
        }
    }
}