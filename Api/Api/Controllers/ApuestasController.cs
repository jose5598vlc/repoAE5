using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestasDTO> Get()
        {
            var repo = new ApuestasRepository();
            List<ApuestasDTO> apuest = repo.RetrieveDTO();
            return apuest;
        }

        // GET: api/Apuestas/5
        public Apuestas Get(int id)
        {
            /*
            var apues = new ApuestasRepository();
            Apuestas apues1 = apues.Retrieve();
            */
            return null;
        }

        // POST: api/Apuestas
        public void Post([FromBody] Apuestas apuestas)
        {

            var repo = new ApuestasRepository();
            repo.Save(apuestas);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
