using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTatuajes.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Imagen { get; set; }
    }
}