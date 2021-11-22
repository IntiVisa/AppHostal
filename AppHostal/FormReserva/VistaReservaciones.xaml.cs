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

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroRe());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Datos.DReservaciones)ListaRegistro.SelectedItem;
                var itemR = obj.id_reservacion.ToString();
                var itemP = obj.id_persona.ToString();
                var itemFi = obj.fInicioReserva.ToString();
                var itemFf = obj.fFinReserva.ToString();
                var itemH = obj.id_habitacion.ToString();
                var itemA = obj.num_adultos.ToString();
                var itemN = obj.num_ninios.ToString();
                var itemM = obj.monto_reserva.ToString();

                int cod = Convert.ToInt32(itemR);
                int per = Convert.ToInt32(itemP);
                DateTime fin = Convert.ToDateTime(itemFi);
                DateTime ffin = Convert.ToDateTime(itemFf);
                int hab = Convert.ToInt32(itemH);
                int adul = Convert.ToInt32(itemA);
                int nin = Convert.ToInt32(itemN);
                double mont = Convert.ToDouble(itemM);

                ListaRegistro.ItemsSource = _post;
                await Navigation.PushAsync(new ActualizacionRe(cod,per,fin,ffin,hab,adul,nin,mont));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Debe seleccionar un registro ha Actualizar", "OK");
            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Datos.DReservaciones)ListaRegistro.SelectedItem;
                var itemR = obj.id_reservacion.ToString();
                var itemP = obj.id_persona.ToString();
                var itemFi = obj.fInicioReserva.ToString();
                var itemFf = obj.fFinReserva.ToString();
                var itemH = obj.id_habitacion.ToString();
                var itemA = obj.num_adultos.ToString();
                var itemN = obj.num_ninios.ToString();
                var itemM = obj.monto_reserva.ToString();

                int cod = Convert.ToInt32(itemR);
                int per = Convert.ToInt32(itemP);
                DateTime fin = Convert.ToDateTime(itemFi);
                DateTime ffin = Convert.ToDateTime(itemFf);
                int hab = Convert.ToInt32(itemH);
                int adul = Convert.ToInt32(itemA);
                int nin = Convert.ToInt32(itemN);
                double mont = Convert.ToDouble(itemM);

                ListaRegistro.ItemsSource = _post;
                //await Navigation.PushAsync(new EliminarRe(cod, per, fin, ffin, hab, adul, nin, mont));
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", "Debe seleccionar un registro ha Actualizar", "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaPrincipal());
        }
    }
}