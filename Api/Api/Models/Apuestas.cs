using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Apuestas
    {
        public Apuestas(int idMercado, bool tipoApuesta, double cuota, double dineroApostado, int idTipo, int idUsuario)
        {
            this.idMercado = idMercado;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.DineroApostado = dineroApostado;
            this.idTipo = idTipo;
            this.idUsuario = idUsuario;
        }

        public int idMercado { get; set; }
        public Boolean tipoApuesta { get; set; }

        public double cuota { get; set; }

        public double DineroApostado { get; set; }

        public int idTipo { get; set; }

        public int idUsuario { get; set; }

    }
}