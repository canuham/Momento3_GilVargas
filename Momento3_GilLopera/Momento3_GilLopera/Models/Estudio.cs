using System;
using System.Collections.Generic;
using System.Text;

namespace Momento3_GilLopera.Models
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
