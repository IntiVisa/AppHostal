using System;
using System.Collections.Generic;
using System.Text;

namespace AppHostal.Datos
{
    class DReservaciones
    {
        public int id_reservacion { get; set; }
        public int id_persona { get; set; }
        public DateTime fInicioReserva { get; set; }
        public DateTime fFinReserva { get; set; }
        public int id_habitacion { get; set; }
        public int num_adultos { get; set; }
        public int num_ninios { get; set; }
        public double monto_reserva { get; set; }
    }
}
