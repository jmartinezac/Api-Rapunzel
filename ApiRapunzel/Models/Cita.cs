using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRapunzel.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        [ForeignKey("EstadoCita")]
        public int IdEstadoCita { get; set; }
        [ForeignKey("Cliente")]
        public  int IdCliente { get; set; }
        [ForeignKey("Estilista")]
        public int IdEstilista { get; set; }



    }
}
