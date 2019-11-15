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

        internal List<MercadoDTO> RetrieveDTO()
        {
            /*
            Mercado merca = new Mercado(60, 2.00, 2.20, 2.50, 2.90, 1000);

            return merca;
            */
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from mercado;";

            con.Open();
            MySqlDataReader res = comand.ExecuteReader();

            MercadoDTO merca = null;
            List<MercadoDTO> mercad = new List<MercadoDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                merca = new MercadoDTO(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2));
                mercad.Add(merca);
            }
            con.Close();
            return mercad;
        }

        internal List<Mercado> RetrieveByEvento(int idEvento)
        {
            MySqlConnection cone = Connect();
            MySqlCommand command = cone.CreateCommand();
            command.CommandText = "SELECT idEvento, tipoMercado, infocuotaOver, infocuotaUnder from mercado WHERE idEvento = idEvento;";
            command.Parameters.AddWithValue("idEvento", idEvento);

            try
            {
                cone.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado merca = null;
                List<Mercado> mercad = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetDouble(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2));
                    merca = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                    mercad.Add(merca);
                }
                cone.Close();
                return mercad;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }

    }



   
    }

    




 