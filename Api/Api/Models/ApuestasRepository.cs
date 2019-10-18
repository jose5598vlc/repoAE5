using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class ApuestasRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=casaapuestas;Uid=root;password='';sslMode=none";
            MySqlConnection cone = new MySqlConnection(connString);
            return cone;
        }

        internal List<ApuestasDTO> RetrieveDTO()
        {
            /*
            Apuestas apuesta1 = new Apuestas(1000, true, 2.29, 2.50, 1, 1098);

            return apuesta1;
            */
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from apuestas";

            con.Open();
            MySqlDataReader res = comand.ExecuteReader();

            ApuestasDTO apues = null;
            List<ApuestasDTO> apuest = new List<ApuestasDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetBoolean(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
                apues = new ApuestasDTO(res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
                apuest.Add(apues);


            }
            con.Close();
            return apuest;
        }

        

        internal void Save(Apuestas apuestas)
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "insert * into apuestas (tipoApuesta, cuota, DineroApostado, id, idUsuario) values (' " + apuestas.tipoApuesta + " ' , ' " + apuestas.cuota + " ', ' " + apuestas.DineroApostado + " ', ' " + apuestas.id + " ', ' " + apuestas.idUsuario + " ') ";
            Debug.WriteLine("comando " + comand.CommandText);

            try
            {
                con.Open();
                comand.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
            }

            // calculos operaciones cuota dependiendo de probabilidad

            MySqlCommand comandoDineroTotalOver = con.CreateCommand();
            comandoDineroTotalOver.CommandText = "SELECT DineroApostadoOver, DineroApostadoUnder FROM mercado;";

            double dineroTotalOver = 0, dineroTotalUnder = 0;

            con.Open();
            MySqlDataReader res = comandoDineroTotalOver.ExecuteReader();

            while (res.Read())
            {
                dineroTotalOver = res.GetDouble(3);
                dineroTotalUnder = res.GetDouble(4);
            }

            con.Close();

        }

    }

    

    

  
}



