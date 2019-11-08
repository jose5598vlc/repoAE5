using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [Authorize]
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<EventosDTO> Get()
        {
            var repo = new EventosRepository();
            List<EventosDTO> eventos = repo.RetrieveDTO();
            return eventos;
        }


       
 


        // GET: api/Eventos/5
        public Eventos Get(int id)
        {
            /*
            var repo = new EventosRepository();
            Eventos evento1 =  repo.Retrieve();
            */
            return null;

        }

        // POST: api/Eventos
        public void Post([FromBody]Eventos evento)
        {
          
         

        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
