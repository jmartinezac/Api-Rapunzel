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
        public string Fecha { get; set; }
        public string Hora { get; set; }
        [ForeignKey("IdEstadoCita")]
        public int IdEstadoCita { get; set; }

        public int IdEstilista { get; set; }
        
        public int IdCliente { get; set; }

        // a continuacion esto retorna el objeto de cliente y estilista mkon
        
        //public virtual EstadoCita  EstadoCita { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("IdEstilista")]
        public virtual Estilista Estilista { get; set; }


    }
}
