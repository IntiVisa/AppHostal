using AppHostal.FormReserva;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppHostal
{
    public partial class VistaPrincipal : ContentPage
    {
        public VistaPrincipal()
        {
            InitializeComponent();
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaClientes());
        }

        private async void btnHabitaciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaHabitaciones());
        }

        private async void btnReservaciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaReservaciones());
        }
    }
}
