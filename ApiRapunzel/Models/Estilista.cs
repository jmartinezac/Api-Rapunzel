using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRapunzel.Models
{
    public class Estilista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstilista { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public List<Cita> IdCita { get; set; }
    }
}
