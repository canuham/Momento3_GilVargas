using ApiTatuajes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTatuajes.Controllers
{
    public class TatuajeController : ApiController
    {
        [HttpGet]
        public IEnumerable<Estudio> Get(){
            using (var context = new TatuajesContext())
            {
                return context.Estudios.ToList();
            }
        }

        [HttpGet]
        public Estudio Get(int id)
        {
            using (var context = new TatuajesContext())
            {
                return context.Estudios.FirstOrDefault(x=> x.Id == id);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Estudio estudio)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new TatuajesContext())
            {
                context.Estudios.Add(estudio);
                context.SaveChanges();
                return Ok(estudio);
            }
        }

        
    }
}
