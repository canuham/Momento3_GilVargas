using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Momento3_GilLopera.Models;
using Momento3_GilLopera.Resources;

namespace Momento3_GilLopera.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void Ingresar_click(object sender, EventArgs e)
        {
            string usuario, password;
            usuario = txtUsuario.Text;
            password = txtPassword.Text;           

            if (string.IsNullOrEmpty(usuario))
            {
                await DisplayAlert(AppResources.Validacion, AppResources.UsuarioV, AppResources.Continuar);
                txtUsuario.Focus();
                return;
             }
            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert(AppResources.Validacion, AppResources.ContrasenaV, AppResources.Continuar);
                txtPassword.Focus();
                return;
            }

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("");

            var autenticacion = new Autenticacion
            {
                Usuario = usuario,
                Password = password
            };
            var json = JsonConvert.SerializeObject(autenticacion);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await cliente.PostAsync("/api/Login" , content);
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<Respuesta>(responseJson);
                if (respuesta.EsPermitido)
                {
                    await Navigation.PushAsync(new TatuajesPage());
                }
                else
                {
                    await DisplayAlert(AppResources.Sentimos , respuesta.Mensaje, AppResources.Continuar);
                }
            }
            else
            {
                await DisplayAlert(AppResources.Sentimos , AppResources.ErrorCon, AppResources.Continuar);
            }
        }
    }
}