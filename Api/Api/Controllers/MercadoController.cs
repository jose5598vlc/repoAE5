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
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadoRepository();
            List<MercadoDTO> mercad = repo.RetrieveDTO();
            return mercad;
        }

     public IEnumerable<Mercado> GetEvento(int idEvento)
        {
            var repo = new MercadoRepository();
            List<Mercado> mercad = repo.RetrieveByEvento(idEvento);
            return mercad;
        }

     
        // GET: api/Mercado/5
        public Mercado Get(int id)
        {
            /*
            var merca = new MercadoRepository();
            Mercado merca1 = merca.Retrieve();
            */
            return null;
        }

        // POST: api/Mercado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
