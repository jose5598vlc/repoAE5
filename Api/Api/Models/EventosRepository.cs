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

        internal List<EventosDTO> RetrieveDTO()
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

            EventosDTO evento = null;
            List<EventosDTO> eventos = new List<EventosDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3));
                evento = new EventosDTO(res.GetString(1), res.GetString(2));
                eventos.Add(evento);
            }
            con.Close();
            return eventos;
        }
        // ejercicio 3, una vez actualizada la bbdd con un ALTER TABLE en eventos DONDE añadimos un campo dinero = 100 fijo. // sin terminar
        internal void Save(Eventos eventos)
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "INSERT INTO eventos (idEvento, EquipoLocal, EquipoVisitante, dinero) VALUES (' " + eventos.idEvento + " ', ' " + eventos.EquipoLocal + " ', ' " + eventos.EquipoVisitante + " ' '  )";
        }
    }

}
