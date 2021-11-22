using AppHostal.FormPersonas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHostal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaClientes : ContentPage
    {
        private const string Url = "http://192.168.1.7/hosteriaApp/postPersonas.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppHostal.Datos.DPersonas> _post;
        public VistaClientes()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<AppHostal.Datos.DPersonas> posts = JsonConvert.DeserializeObject<List<AppHostal.Datos.DPersonas>>(content);
                _post = new ObservableCollection<AppHostal.Datos.DPersonas>(posts);

                ListaPersonas.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Error" + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaPrincipal());
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarCli());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Datos.DPersonas)ListaPersonas.SelectedItem;
                var itemP = obj.id_persona.ToString();
                var itemN = obj.nombre.ToString();
                var itemA = obj.apellido.ToString();
                var itemI = obj.id_identificacion.ToString();
                var itemID = obj.identificacion.ToString();
                var itemD = obj.direccion.ToString();
                var itemCe = obj.celular.ToString();
                var itemCo = obj.correo.ToString();
                var itemE = obj.estado.ToString();

                int cod = Convert.ToInt32(itemP);
                string nom = Convert.ToString(itemN);
                string ape = Convert.ToString(itemA);
                int idn = Convert.ToInt32(itemI);
                string ident = Convert.ToString(itemID);
                string dir = Convert.ToString(itemD);
                string cel = Convert.ToString(itemCe);
                string corr = Convert.ToString(itemCo);
                string est = Convert.ToString(itemE);

                ListaPersonas.ItemsSource = _post;
                await Navigation.PushAsync(new ActualizarCli(cod, nom, ape, idn, ident, dir, cel, corr, est));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Debe seleccionar un registro ha Actualizar", "OK");
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Datos.DPersonas)ListaPersonas.SelectedItem;
                var itemP = obj.id_persona.ToString();
                var itemN = obj.nombre.ToString();
                var itemA = obj.apellido.ToString();
                var itemI = obj.id_identificacion.ToString();
                var itemID = obj.identificacion.ToString();
                var itemD = obj.direccion.ToString();
                var itemCe = obj.celular.ToString();
                var itemCo = obj.correo.ToString();
                var itemE = obj.estado.ToString();

                int cod = Convert.ToInt32(itemP);
                string nom = Convert.ToString(itemN);
                string ape = Convert.ToString(itemA);
                int idn = Convert.ToInt32(itemI);
                string ident = Convert.ToString(itemID);
                string dir = Convert.ToString(itemD);
                string cel = Convert.ToString(itemCe);
                string corr = Convert.ToString(itemCo);
                string est = Convert.ToString(itemE);

                ListaPersonas.ItemsSource = _post;
                await Navigation.PushAsync(new EliminarCli(cod, nom, ape, idn, ident, dir, cel, corr, est));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Debe seleccionar un registro ha Actualizar", "OK");
            }
        }

        private async void ListaPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}