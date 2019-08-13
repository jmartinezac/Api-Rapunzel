using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRapunzel.Models
{
    public class ContextoApi : DbContext
    {
        public ContextoApi(DbContextOptions<ContextoApi> options)
            :base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Estilista> Estilistas { get; set; }
    }
}
