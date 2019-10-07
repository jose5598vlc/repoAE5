using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class EventosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=casaapuestas;Uid=root;password='';sslMode=none";
            MySqlConnection cone = new MySqlConnection(connString);
            return cone;
        }

        internal Eventos Retrieve()
        {
            /*
            Eventos evento1 = new Eventos(1, "Barcelona", "RealMadrid");

            return evento1;
            */
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Eventos evento = null;
            if (res.Read())
                {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2));
                evento = new Eventos(res.GetInt16(0), res.GetString(1), res.GetString(2));
            }
            con.Close();
            return evento;
            }
        }
    }
