using AppHostal.FormHabitaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHostal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaHabitaciones : ContentPage
    {

        private const string Url = "http://192.168.1.7/hosteriaApp/postHabitaciones.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppHostal.Datos.DHabitaciones> _post;

        public VistaHabitaciones()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<AppHostal.Datos.DHabitaciones> posts = JsonConvert.DeserializeObject<List<AppHostal.Datos.DHabitaciones>>(content);
                _post = new ObservableCollection<AppHostal.Datos.DHabitaciones>(posts);

                ListaHabitaciones.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error" + ex.Message, "OK");
            }
        }

        private void ListaHabitaciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertarHab());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Datos.DHabitaciones)ListaHabitaciones.SelectedItem;
                var itemC = obj.id_habitacion.ToString();
                var itemT = obj.id_tipo_habitacion.ToString();
                var itemH = obj.nro_habitacion.ToString();
                var itemP = obj.precio_dia.ToString();
                var itemE = obj.estado.ToString();

                int cod = Convert.ToInt32(itemC);
                int tip = Convert.ToInt32(itemT);
                string hab = Convert.ToString(itemH);
                double pre = Convert.ToDouble(itemP);
                string est = Convert.ToString(itemE);

                ListaHabitaciones.ItemsSource = _post;
                await Navigation.PushAsync(new ActualizarHab(cod, tip, hab, pre, est));
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
                var obj = (Datos.DHabitaciones)ListaHabitaciones.SelectedItem;
                var itemC = obj.id_habitacion.ToString();

                int cod = Convert.ToInt32(itemC);

                ListaHabitaciones.ItemsSource = _post;

                Navigation.PushAsync(new EliminarHab(cod));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Debe seleccionar un registro ha Actualizar", "OK");
            }
        }
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaPrincipal());
        }

    }
}