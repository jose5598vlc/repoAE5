using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Mercado
    {
        public Mercado(int id, double infocuotaover, double infocuotaunder, double dineroapostadoOver, double dineroapostadoUnder, double tipoMercado, int idEvento)
        {
            this.id = id;
            this.infocuotaover = infocuotaover;
            this.infocuotaunder = infocuotaunder;
            this.dineroapostadoOver = dineroapostadoOver;
            this.dineroapostadoUnder = dineroapostadoUnder;
            this.tipoMercado = tipoMercado;
            this.idEvento = idEvento;
        }

        public int id { get; set; }
        public double infocuotaover { get; set; }
        public double infocuotaunder { get; set; }

        public double dineroapostadoOver { get; set; }

        public double dineroapostadoUnder { get; set; }

        public double tipoMercado { get; set; }

        public int idEvento { get; set; }


    }

    public class MercadoDTO
    {
        public MercadoDTO(int id, double infocuotaover, double infocuotaunder)
        {
            ID = id;
            InfoCuotaOver = infocuotaover;
            InfoCuotaUnder = infocuotaunder;
        }

        public int ID { get; set; }

        public double InfoCuotaOver { get; set; }

        public double InfoCuotaUnder { get; set; }

    }
}
