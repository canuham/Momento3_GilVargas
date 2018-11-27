using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTatuajes.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }        
    }
}