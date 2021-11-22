using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHostal.FormReserva
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroRe : ContentPage
    {
        public RegistroRe()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id_persona", txtPersona.Text);
                parametros.Add("fInicioReserva", dtpFInicio.ToString());
                parametros.Add("fFinReserva", dtpFFin.ToString());
                parametros.Add("id_habitacion", txtHabitacion.Text);
                parametros.Add("num_adultos", txtAdultos.Text);
                parametros.Add("num_ninios", txtNinios.Text);
                parametros.Add("monto_reserva", txtMontoR.Text);

                cliente.UploadValues("http://192.168.1.7/hosteriaApp/postReservaciones.php", "POST", parametros);
                await DisplayAlert("Mensaje", "Elemento ingresado con exito", "OK");

                txtPersona.Text = "";
                txtHabitacion.Text = "";
                txtAdultos.Text = "";
                txtNinios.Text = "";
                txtMontoR.Text = "";

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaReservaciones());
        }
    }
}