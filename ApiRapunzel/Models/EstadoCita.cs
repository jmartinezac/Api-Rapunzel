using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRapunzel.Models
{
    public class EstadoCita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoCita { get; set; }
        public string Nombre { get; set; }

        public virtual List<Cita> IdCita { get; set; }

    }
}
