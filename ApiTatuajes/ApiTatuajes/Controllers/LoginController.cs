using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiTatuajes.Models;
using Newtonsoft.Json;

namespace ApiTatuajes.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public IEnumerable<Login> Get()
        {
            using (var context = new TatuajesContext())
            {
                return context.Login.ToList();
            }
        }

        [HttpGet]
        public Login Get(int id)
        {
            using (var context = new TatuajesContext())
            {
                return context.Login.FirstOrDefault(x => x.Id == id);
            }
        }

        [HttpPost]
        public Validacion Post(Login login)
        {
            using (var context = new TatuajesContext())
            {
                Validacion validar = new Validacion();
                var usuario = context.Login.Count(x => x.Usuario == login.Usuario);
                var clave = context.Login.Count(x => x.Clave == login.Clave);
                if ( usuario >= 1 && clave >= 1)
                {                    
                    validar.EsPermitido = true;
                    validar.Mensaje = "OK";
                } else
                {
                    validar.EsPermitido = false;
                    validar.Mensaje = "Denegado";
                }

                JsonConvert.SerializeObject(validar);

                return validar;
            }
        }
    }
}
