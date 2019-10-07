using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Eventos
    {
        public Eventos(int idEvento, string EquipoLocal, string EquipoVisitante)
        {
            this.idEvento = idEvento;
            this.EquipoLocal = EquipoLocal;
            this.EquipoVisitante = EquipoVisitante;
        }

        public int idEvento { get; set; }
        public string EquipoLocal { get; set; }

        public string EquipoVisitante { get; set; }

    }
}