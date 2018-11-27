using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiTatuajes.Models
{
    public class TatuajesContext : DbContext
    {
        public TatuajesContext() : base("TatuajesConnection")
        {

        }

        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Login> Login { get; set; }


    }
}