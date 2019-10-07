using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Mercado
    {
        public Mercado(int idTipo, double infocuotaover, double infocuotaunder, double dineroapostadoOver, double dineroapostadoUnder, int idEvento)
        {
            this.idTipo = idTipo;
            this.infocuotaover = infocuotaover;
            this.infocuotaunder = infocuotaunder;
            this.dineroapostadoOver = dineroapostadoOver;
            this.dineroapostadoUnder = dineroapostadoUnder;
            this.idEvento = idEvento;
        }

        public int idTipo { get; set; }
        public double infocuotaover { get; set; }
        public double infocuotaunder { get; set; }

        public double dineroapostadoOver { get; set; }

        public double dineroapostadoUnder { get; set; }

        public int idEvento { get; set; }


    }
}