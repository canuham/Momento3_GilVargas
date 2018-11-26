using Momento3_GilLopera.Models;
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
	public partial class ArtistaPage : ContentPage
	{
        private Estudio estudio;
		public ArtistaPage (Estudio estudio)
		{
			InitializeComponent ();
            this.estudio = estudio;
            BindingContext = estudio;
		}

        private async void Artista_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var artista = (Artista)e.SelectedItem;
            await Navigation.PushAsync(new DetallePage(estudio, artista));
        }
    }
}