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
    public partial class Loggin : ContentPage
    {
        private const string Url = "http://192.168.1.7/hosteriaApp/postUsuarios.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppHostal.Datos.DUsuarios> _post;

        public Loggin()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<AppHostal.Datos.DUsuarios> posts = JsonConvert.DeserializeObject<List<AppHostal.Datos.DUsuarios>>(content);
                _post = new ObservableCollection<AppHostal.Datos.DUsuarios>(posts);
                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Error" + ex.Message, "OK");
            }
        }

        private async void btnAbrir_Clicked(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text;
            string contraseña = txtcontraseña.Text;
            if ((usuario == "Admin") && (contraseña == "123456"))
            {
                await Navigation.PushAsync(new VistaPrincipal());
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Text = "El usuario o contraseña son incorrectos";
            }
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}