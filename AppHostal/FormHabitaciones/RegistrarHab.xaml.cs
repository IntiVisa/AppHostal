using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHostal.FormHabitaciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarHab : ContentPage
    {
        public InsertarHab()
        {
            InitializeComponent();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id_tipo_habitacion", txtHabitacion.Text);
                parametros.Add("nro_habitacion", txtNHabitacion.Text);
                parametros.Add("precio_dia", txtPrecioDia.Text);
                parametros.Add("estado", txtEstado.Text);

                cliente.UploadValues("http://192.168.1.7/hosteriaApp/postHabitaciones.php", "POST", parametros);
                await DisplayAlert("Mensaje", "Elemento ingresado con exito", "OK");

                txtHabitacion.Text = "";
                txtNHabitacion.Text = "";
                txtPrecioDia.Text = "";
                txtEstado.Text = "";

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaHabitaciones());
        }
    }
}