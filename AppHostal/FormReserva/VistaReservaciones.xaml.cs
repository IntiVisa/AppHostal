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

namespace AppHostal.FormReserva
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaReservaciones : ContentPage
    {
        private const string Url = "http://192.168.1.7/hosteriaApp/postReservaciones.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppHostal.Datos.DReservaciones> _post;
        public VistaReservaciones()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<AppHostal.Datos.DReservaciones> posts = JsonConvert.DeserializeObject<List<AppHostal.Datos.DReservaciones>>(content);
                _post = new ObservableCollection<AppHostal.Datos.DReservaciones>(posts);

                ListaRegistro.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Error" + ex.Message, "OK");
            }
        }

        private void ListaRegistro_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

        }
    }
}