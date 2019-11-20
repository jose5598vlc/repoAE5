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


        
        internal List<ApuestasDTO> RetrieveDTO(int id)
        {
           
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from apuestas;";
            

            con.Open();
            MySqlDataReader res = comand.ExecuteReader();

            ApuestasDTO apues = null;
            List<ApuestasDTO> apuest = new List<ApuestasDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetBoolean(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetInt32(3) + " " + res.GetInt32(5));
                apues = new ApuestasDTO(res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
                apuest.Add(apues);


            }
            con.Close();
            return apuest;
        }

        internal List<Apuestas> RetrieveByEmail(string Email)
        {
            MySqlConnection conec = Connect();
            MySqlCommand command = conec.CreateCommand();
            command.CommandText = "SELECT Email, idEvento, tipoMercado, tipoApuesta, cuota, DineroApostado FROM Usuario U, Mercado M, Apuestas A WHERE U.Email = U.Email;";
            command.Parameters.AddWithValue("U.Email", Email);

            try
            {
                conec.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuestas apuesta = null;
                List<Apuestas> apuest = new List<Apuestas>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetBoolean(3) + " " + res.GetDouble(4));
                    apuesta = new Apuestas(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
                    apuest.Add(apuesta);
                }

                conec.Close();
                return apuest;
            } catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }
        }

        internal List<Apuestas> RetrieveByMercado(int id)
        {
            MySqlConnection conect = Connect();
            MySqlCommand command = conect.CreateCommand();
            command.CommandText = "SELECT idMercado, tipoMercado, tipoApuesta, cuota, DineroApostado FROM Apuestas A, Mercado M WHERE M.id = A.id;";
            command.Parameters.AddWithValue("A.id", id);

            try
            {
                conect.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuestas apue = null;
                List<Apuestas> apues = new List<Apuestas>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetDouble(1) + " " + res.GetBoolean(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4));
                    apue = new Apuestas(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
                    apues.Add(apue);
                }

                conect.Close();
                return apues;

            } catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }
        }

        // codigo del ejercicio 1 donde se pide que se devuelvan: Nombre_Usuario, Cantidad Apostada, Mercado y Cuota de la apuesta
        internal List<Apuestas> RetrieveByidUsuario(int idUsuario)
        {
            MySqlConnection conecti = Connect();
            MySqlCommand command = conecti.CreateCommand();
            command.CommandText = "SELECT Nombre, DineroApostado, tipoMercado, cuota FROM Usuario U, Apuestas A, Mercado M WHERE A.id=U.idUsuario;";
            command.Parameters.AddWithValue("U.idUsuario", idUsuario);


            try
            {
                conecti.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuestas ap = null;
                List<Apuestas> apu = new List<Apuestas>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3));
                    ap = new Apuestas(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
                    apu.Add(ap);
                }
                conecti.Close();
                return apu;
            } catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }
        }


        // ejercicio 2 donde se pide todas las apuestas cuya cuota este entre un valor minimo y uno maximo
        internal List<Apuestas> RetrieveByCuota(double cuota)
        {
            MySqlConnection conect = Connect();
            MySqlCommand command = conect.CreateCommand();
            command.CommandText = "SELECT Nombre, DineroApostado, tipoMercado, cuota FROM Usuario U, Apuestas A, Mercado M WHERE A.cuota>0 && A.cuota<3;";
            command.Parameters.AddWithValue("A.cuota", cuota);


            try
            {
                conect.Open();
                MySqlDataReader re = command.ExecuteReader();

                Apuestas a = null;
                List<Apuestas> apus = new List<Apuestas>();

                while (re.Read())
                {
                    Debug.WriteLine("Recuperado: " + re.GetString(0) + " " + re.GetDouble(1) + " " + re.GetDouble(2) + " " + re.GetDouble(3));
                    new Apuestas(re.GetInt32(0), re.GetBoolean(1), re.GetDouble(2), re.GetDouble(3), re.GetInt32(4), re.GetInt32(5));
                    apus.Add(a);
                }
                conect.Close();
                return apus;
            } catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }
        }

        





        internal void Save(Apuestas apuestas)
        {

            //HACEMOS LA APUESTA
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



            // sacamos el dinero total del mercado (over o under) y sumarlo a nuestra apuesta anterior


            // SELECT que saca el dinero total tanto de over y under 

            MySqlCommand dineroApuesta = con.CreateCommand();
            dineroApuesta.CommandText = "SELECT dineroapostadoOver, dineroapostadoUnder, DineroApostado FROM mercado, apuestas;";

            double dineroOver = 0, dineroUnder = 0, Apostado = 0; // VARIABLE A LA QUE GUARDAMOS dinero OVER, UNDER y apostado

            con.Open();
            MySqlDataReader res2 = dineroApuesta.ExecuteReader();

            while (res2.Read())
            {
                dineroOver = res2.GetDouble(0);
                dineroUnder = res2.GetDouble(1);
                Apostado = res2.GetDouble(2);
            }

            if (apuestas.tipoApuesta == false)
            {
                dineroOver += dineroOver;
            } else
            {
                dineroUnder += dineroUnder;
            }

            con.Close();



            //Actualizar con el dinero total del mercado en el mercado correspondiente.

            if (apuestas.tipoApuesta == false)
            {
                MySqlCommand insertarApuesta = con.CreateCommand();
                insertarApuesta.CommandText = "UPDATE mercado SET dineroapostadoOver = " + dineroOver + " WHERE id = " + apuestas.idMercado + " ";
                Debug.WriteLine("comando " + comand.CommandText);

                try
                {
                    con.Open();
                    comand.ExecuteNonQuery();
                    con.Close();
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("se ha producido error de conexion");
                }

            } else
            {
                MySqlCommand insertarApuestaUnder = con.CreateCommand();
                insertarApuestaUnder.CommandText = "UPDATE mercado SET dineroapostadoUnder = " + dineroUnder + " WHERE id = " + apuestas.idMercado + " ";

                try
                {
                    con.Open();
                    comand.ExecuteNonQuery();
                    con.Close();
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("se ha producido error de conexion");
                }


            }


            
            //Sacas el dinero total OVER y dinero total UNDER.

            MySqlCommand comandoDineroTotal = con.CreateCommand();
            comandoDineroTotal.CommandText = "SELECT DineroApostadoOver, DineroApostadoUnder FROM mercado;";

            double dineroTotalOver = 0, dineroTotalUnder = 0;

            con.Open();
            MySqlDataReader res = comandoDineroTotal.ExecuteReader();

            while (res.Read())
            {
                dineroTotalOver = res.GetDouble(0);
                dineroTotalUnder = res.GetDouble(1);
            }

            con.Close();



            //Con el dinero del SELECT de arriba, hacer los cálculos del PDF.
            //Guardas en variable resultado de probabilidad

            double probabilidadOver = dineroTotalOver / dineroTotalOver + dineroTotalUnder;

            double probabilidadUnder = dineroTotalUnder / dineroTotalOver + dineroTotalUnder;


            //Calculas en otra variable resultado de cuota nueva

            double cuotaOver = 1 / probabilidadOver * 0.95;

            double cuotaUnder = 1 / probabilidadUnder * 0.95;





            //Actualizar cuota OVER y cuota UNDER

            
            
                MySqlCommand actualizarCuota = con.CreateCommand();
                actualizarCuota.CommandText = "UPDATE mercado SET infocuotaOver = " + cuotaOver +  ", infocuotaUnder = " + cuotaUnder + " WHERE id = " + apuestas.idMercado + " ";
                Debug.WriteLine("comando " + comand.CommandText);

                try
                {
                    con.Open();
                    comand.ExecuteNonQuery();
                    con.Close();
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("se ha producido error de conexion");
                }


           

        }

    }

    

    

  
}



