using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHostal.FormPersonas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarCli : ContentPage
    {
        public RegistrarCli()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("id_identificacion", txtTipoIden.Text);
                parametros.Add("identificacion", txtIdentificacion.Text);
                parametros.Add("direccion", txtDireccion.Text);
                parametros.Add("celular", txtCelular.Text);
                parametros.Add("correo", txtCorreo.Text);
                parametros.Add("estado", txtEstado.Text);

                cliente.UploadValues("http://192.168.1.7/hosteriaApp/postPersonas.php", "POST", parametros);
                await DisplayAlert("Mensaje", "Elemento ingresado con exito", "OK");

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTipoIden.Text = "";
                txtIdentificacion.Text = "";
                txtDireccion.Text = "";
                txtCelular.Text = "";
                txtCorreo.Text = "";
                txtEstado.Text = "";

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaClientes());
        }
    }
}