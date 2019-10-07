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

        internal Apuestas Retrieve()
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

            Apuestas apues = null;
            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetBoolean(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
                Apuestas apuesta = new Apuestas(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
            }
            con.Close();
            return apues;
        }
    }
}