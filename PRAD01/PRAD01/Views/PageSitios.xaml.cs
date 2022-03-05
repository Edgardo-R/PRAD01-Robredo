using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PRAD01.Models;
using PRAD01.Controlers;

namespace PRAD01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSitios : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public PageSitios()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            CancellationTokenSource cts;
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    latitud.Text = Convert.ToString(location.Latitude);
                    longitud.Text = Convert.ToString(location.Longitude);
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    location = await Geolocation.GetLocationAsync(request, cts.Token);

                    if (location != null)
                    {
                        latitud.Text = Convert.ToString(location.Latitude);
                        longitud.Text = Convert.ToString(location.Longitude);
                    }

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                fnsEx.ToString();
                // Handle not supported on device exception
            }
        }
        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            CancellationTokenSource cts;
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    location = await Geolocation.GetLocationAsync(request, cts.Token);

                    if (location != null)
                    {
                        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    }

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                fnsEx.ToString();
                // Handle not supported on device exception
            }
        }

        private async void btnagregar_Clicked_1(object sender, EventArgs e)
        {
            var site = new Sitios()
            {
                descripcion = descripcion.Text,
                longitud = Convert.ToDouble(longitud.Text),
                latitud = Convert.ToDouble(latitud.Text),
                
                fecha = fecha.Date

            };
            if (await SitiosControlers.AddSitios(site)>0)
            {
                await DisplayAlert("Aviso", "Registro Adicionado", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha ocurrido un error", "OK");
            }
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}