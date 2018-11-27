using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTatuajes.Models
{
    public class Estudio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Whatsapp { get; set; }
        public List<Artista> Artistas { get; set; }
    }
}