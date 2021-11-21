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
    public partial class ActualizarHab : ContentPage
    {
        public ActualizarHab(int codigo, int tipohabitacion, string nrohabitacion, double precio, string estado)
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString(codigo);
            txtHabitacion.Text = Convert.ToString(tipohabitacion);
            txtNHabitacion.Text = nrohabitacion;
            txtPrecioDia.Text = Convert.ToString(precio);
            txtEstado.Text = estado;
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id_habitacion", txtCodigo.Text);
                parametros.Add("id_tipo_habitacion", txtHabitacion.Text);
                parametros.Add("nro_habitacion", txtNHabitacion.Text);
                parametros.Add("precio_dia", txtPrecioDia.Text);
                parametros.Add("estado", txtEstado.Text);

                cliente.UploadValues("http://192.168.1.7/hosteriaApp/postHabitaciones.php ? id_habitacion= " + Int32.Parse(txtCodigo.Text) 
                    + "&" + "id_tipo_habitacion=" + Int32.Parse(txtHabitacion.Text) 
                    + "&" + "nro_habitacion=" + txtNHabitacion.Text 
                    + "&" + "precio_dia=" + Double.Parse(txtPrecioDia.Text) 
                    + "&" + "estado=" + txtEstado.Text, "PUT", parametros);
                
                await DisplayAlert("Mensaje", "Elemento actualizado con exito", "OK");

                txtCodigo.Text = "";
                txtHabitacion.Text = "";
                txtNHabitacion.Text = "";
                txtPrecioDia.Text = "";
                txtEstado.Text = "";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ocurrio un error al actualizar", "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaHabitaciones());
        }
    }
}