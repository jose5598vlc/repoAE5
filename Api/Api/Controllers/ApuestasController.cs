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
        /*
        [Authorize(Roles = "Admin")] */// solo los usuarios con rol admin pueden tener acceso a la funcion que devuelve todas las apuestas de un mercado
        // GET: api/Apuestas
        public IEnumerable<Apuestas> GetApuestas(int idUsuario)
        {
            var repos = new ApuestasRepository();
            List<Apuestas> apuest = repos.RetrieveByidUsuario(idUsuario);
            return apuest;
        }

     public IEnumerable<Apuestas> GetEmail(string Email)
        {
            var repo = new ApuestasRepository();
            List<Apuestas> apuest = repo.RetrieveByEmail(Email);
            return apuest;
        }

        public IEnumerable<Apuestas> GetMercado (int id)
        {
            var repo = new ApuestasRepository();
            List<Apuestas> apuest = repo.RetrieveByMercado(id);
            return apuest;
        }

        public IEnumerable<Apuestas> GetTodasApuestas (int idUsuario)
        {
            var repo = new ApuestasRepository();
            List<Apuestas> apuest = repo.RetrieveByidUsuario(idUsuario);
            return apuest;
        }
        // GET: api/Apuestas/5
        public Apuestas Get(int idUsuario)
        {
            /*
            var apues = new ApuestasRepository();
            Apuestas apues1 = apues.Retrieve();
            */
            return null;
        }

        // POST: api/Apuestas
        [Authorize(Roles = "Standard")] // solo los usuarios autenticados pueden apostar
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
