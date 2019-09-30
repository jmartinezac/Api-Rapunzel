using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRapunzel.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Apellidos { get; set; }
        public int Documento { get; set; }
        public virtual List<Cita> IdCita { get; set; }

    }
}
