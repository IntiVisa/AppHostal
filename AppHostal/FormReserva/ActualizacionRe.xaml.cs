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
    public partial class ActualizacionRe : ContentPage
    {
        public ActualizacionRe(int id, int idp, DateTime finicio, DateTime ffin, int idh, int numA, int numN, double monto)
        {
            InitializeComponent();
            txtReserva.Text = Convert.ToString(id);
            txtPersona.Text = Convert.ToString(idp);
            txtFInicio.Text = Convert.ToString(finicio);
            txtFFin.Text = Convert.ToString(ffin);
            txtHabitacion.Text = Convert.ToString(idh);
            txtAdultos.Text = Convert.ToString(numA);
            txtNinios.Text = Convert.ToString(numN);
            txtNinios.Text = Convert.ToString(monto);
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id_reservacion", txtReserva.Text);
                parametros.Add("id_persona", txtPersona.Text);
                parametros.Add("fInicioReserva", txtFInicio.Text);
                parametros.Add("fFinReserva", txtFFin.Text);
                parametros.Add("id_habitacion", txtHabitacion.Text);
                parametros.Add("num_adultos", txtAdultos.Text);
                parametros.Add("num_ninios", txtNinios.Text);
                parametros.Add("monto_reserva", txtMontoR.Text);

                cliente.UploadValues("http://192.168.1.7/hosteriaApp/postReservas.php ? id_reservacion= " + Int32.Parse(txtReserva.Text)
                    + "&" + "id_persona=" + Int32.Parse(txtPersona.Text)
                    + "&" + "fInicioReserva=" + txtFInicio.Text
                    + "&" + "fFinReserva=" + txtFFin.Text
                    + "&" + "id_habitacion=" + Int32.Parse(txtHabitacion.Text)
                    + "&" + "num_adultos=" + Int32.Parse(txtAdultos.Text)
                    + "&" + "num_ninios=" + Int32.Parse(txtNinios.Text)
                    + "&" + "monto_reserva=" + Double.Parse(txtMontoR.Text)
                    , "PUT", parametros);

                await DisplayAlert("Mensaje", "Elemento actualizado con exito", "OK");

                txtReserva.Text = "";
                txtPersona.Text = "";
                txtFInicio.Text = "";
                txtFFin.Text = "";
                txtHabitacion.Text = "";
                txtAdultos.Text = "";
                txtNinios.Text = "";
                txtMontoR.Text = "";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ocurrio un error al actualizar", "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaReservaciones());
        }
    }
}