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

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }
        private async void ListaPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}