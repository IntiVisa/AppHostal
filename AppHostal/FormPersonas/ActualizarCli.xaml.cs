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
    public partial class ActualizarCli : ContentPage
    {
        public ActualizarCli(int id, string nombre, string apellido, int ident, string identi, string direccion, string celular, string correo, string estado)
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

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id_persona", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("id_identificacion", txtTipoIden.Text);
                parametros.Add("identificacion", txtIdentificacion.Text);
                parametros.Add("direccion", txtDireccion.Text);
                parametros.Add("celular", txtCelular.Text);
                parametros.Add("correo", txtCorreo.Text);
                parametros.Add("estado", txtEstado.Text);

                cliente.UploadValues("http://192.168.1.7/hosteriaApp/postPersonas.php ? id_persona= " + Int32.Parse(txtCodigo.Text)
                    + "&" + "nombre=" + txtNombre.Text
                    + "&" + "apellido=" + txtApellido.Text
                    + "&" + "id_identificacion=" + Int32.Parse(txtTipoIden.Text)
                    + "&" + "identificacion=" + txtIdentificacion.Text
                    + "&" + "direccion=" + txtDireccion.Text
                    + "&" + "celular=" + txtCelular.Text
                    + "&" + "correo=" + txtCorreo.Text
                    + "&" + "estado=" + txtEstado.Text
                    , "PUT", parametros);

                await DisplayAlert("Mensaje", "Elemento actualizado con exito", "OK");

                txtCodigo.Text = "";
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
                await DisplayAlert("Alerta", "Ocurrio un error al actualizar", "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaClientes());
        }
    }
}