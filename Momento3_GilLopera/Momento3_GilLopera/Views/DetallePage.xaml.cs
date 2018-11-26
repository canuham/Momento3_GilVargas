using Momento3_GilLopera.Models;
using Momento3_GilLopera.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Momento3_GilLopera.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetallePage : ContentPage
	{
		public DetallePage (Estudio estudio, Artista artista)
		{
			InitializeComponent ();
            gridEstudio.BindingContext = estudio;
            gridArtista.BindingContext = artista;
		}

        private async void Finalizar_Click(object sender, EventArgs e)
        {
            await DisplayAlert(AppResources.Gracias, AppResources.Realizado, AppResources.Continuar);
        }

        private async void Camara(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CamaraPage());
        }
    }
}