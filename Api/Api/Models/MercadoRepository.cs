using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class MercadoRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=casaapuestas;Uid=root;password='' ;sslMode=none";
            MySqlConnection cone = new MySqlConnection(connString);
            return cone;
        }

        internal Mercado Retrieve()
        {
            /*
            Mercado merca = new Mercado(60, 2.00, 2.20, 2.50, 2.90, 1000);

            return merca;
            */
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from mercado";

            con.Open();
            MySqlDataReader res = comand.ExecuteReader();

            Mercado merca = null;
            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetInt32(5));
                Mercado mercado = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetInt32(5));
            }
            con.Close();
            return merca;
        }
    }
}