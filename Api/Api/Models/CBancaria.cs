using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class CBancaria
    {

        public CBancaria(int NumTarjeta, double saldo, string Nombrebanco, int idUsuario)
        {
            this.NumTarjeta = NumTarjeta;
            this.Saldo = saldo;
            this.Nombrebanco = Nombrebanco;
            this.idUsuario = idUsuario;

        }

        public int NumTarjeta { get; set; }

        public double Saldo { get; set; }

        public string Nombrebanco { get; set; }

        public int idUsuario { get; set; }

        
    }
}