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
    public partial class EliminarCli : ContentPage
    {
        public EliminarCli(int id, string nombre, string apellido, int ident, string identi, string direccion, string celular, string correo, string estado)
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString(id);
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtTipoIden.Text = Convert.ToString(ident);
            txtIdentificacion.Text = identi;
            txtDireccion.Text = direccion;
            txtCelular.Text = celular;
            txtCorreo.Text = correo;
            txtEstado.Text = estado;
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("id_habitacion", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("id_identificacion", txtTipoIden.Text);
                parametros.Add("identificacion", txtIdentificacion.Text);
                parametros.Add("direccion", txtDireccion.Text);
                parametros.Add("celular", txtCelular.Text);
                parametros.Add("correo", txtCorreo.Text);
                parametros.Add("estado", txtEstado.Text);

                cliente.UploadValues("http://192.168.1.7/hosteriaApp/postPersonas.php ? id_habitacion= " + Int32.Parse(txtCodigo.Text), "DELETE", parametros);

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
            await Navigation.PushAsync(new VistaClientes());
        }
    }
}