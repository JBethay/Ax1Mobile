﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Ax1Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CostCentersViewPage : ContentPage
	{
        private const string Url = "https://ax1web.azurewebsites.net/api/CostCenters.js";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<CostCenter> _costCenters;

        public CostCentersViewPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url);
            List<CostCenter> costCenters = JsonConvert.DeserializeObject<List<CostCenter>>(content);
            _costCenters = new ObservableCollection<CostCenter>(costCenters);
            CostCentersListView.ItemsSource = _costCenters;
            base.OnAppearing();
        }

    }
}