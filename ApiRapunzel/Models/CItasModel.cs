using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRapunzel.Models
{
    public class CitasModel
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string  Estilista { get; set; }
        public string Cliente { get; set; }
        public string Usuario { get; set; }
        public string  ApellidosCliente { get; set; }
        public string ApellidosEstilista { get; set; }

    }
}
