using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Apuestas
    {
        public Apuestas(int idMercado, bool tipoApuesta, double cuota, double dineroApostado, int id, int idUsuario)
        {
            this.idMercado = idMercado;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.DineroApostado = dineroApostado;
            this.id = id;
            this.idUsuario = idUsuario;
        }

        public int idMercado { get; set; }
        public Boolean tipoApuesta { get; set; }

        public double cuota { get; set; }

        public double DineroApostado { get; set; }

        public int id { get; set; }

        public int idUsuario { get; set; }

    }

    public class ApuestasDTO
    {
        public ApuestasDTO(Boolean tipoApuesta, double cuota, double DineroApostado, int idTipo, int idUsuario)
        {
            TApuesta = tipoApuesta;
            Cuota = cuota;
            DineroApos = DineroApostado;
            IDTipo = idTipo;
            IDUsu = idUsuario;
        }

        public bool TApuesta { get; set; }

        public double Cuota { get; set; }

        public double DineroApos { get; set; }

        public double IDTipo { get; set; }

        public double IDUsu { get; set; }

    }


}
