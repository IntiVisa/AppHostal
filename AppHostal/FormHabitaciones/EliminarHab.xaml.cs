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
    public partial class EliminarHab : ContentPage
    {
        public EliminarHab(int codigo)
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString(codigo);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("id_habitacion", txtCodigo.Text);

                cliente.UploadValues("http://192.168.1.7/hosteriaApp/postHabitaciones.php ? id_habitacion= " + Int32.Parse(txtCodigo.Text), "DELETE", parametros);

                await DisplayAlert("alerta", "Registro Eliminado Correctamente", "OK");

                txtCodigo.Text = "";
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