using Momento3_GilLopera.Models;
using Momento3_GilLopera.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Momento3_GilLopera.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TatuajesPage : ContentPage
	{
		public TatuajesPage ()
		{
			InitializeComponent ();
            CargarTatuajes();
		}

        private async void CargarTatuajes()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost/Tatuajes");

            var request = await cliente.GetAsync("/api/Tatuaje");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var listado = JsonConvert.DeserializeObject<List<Estudio>>(responseJson);
                listTatuajes.ItemsSource = listado;
            }
            else
            {
                await DisplayAlert(AppResources.Sentimos, AppResources.ErrorComu, AppResources.Continuar);
            }
        }

        private async void Tatuaje_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var Estudio = (Estudio)e.SelectedItem;
            await Navigation.PushAsync(new ArtistaPage(Estudio));
        }
    }
}