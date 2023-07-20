using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase02.AccesoADatos
{
    public static class AD_Usuarios
    {
        /// <summary>
        /// Este método obtiene la cadena de conexion y realiza la consulta a la BD para
        /// obtener el usuario y contraseña. Devuelve true si lo encuentra y false si
        /// no lo encuentra.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public static bool ValidarUsuario(string usuario, string contraseña)
        {
            // Accedemos a la key del archivo AppConfig para obtener la cadena de conexion.
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand();

                // Realizamos la consulta Sql para obtener el usuario y contraseña de la BD
                string consulta = "SELECT * FROM Usuarios WHERE Usuario LIKE @Usuario AND Contraseña LIKE @Contraseña";

                cmd.Parameters.Clear(); // Limpiamos todos los tipos de parámetros
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);


                cmd.CommandType = CommandType.Text; // Estamos diciendo que el comando lo vamos a insertar a mano (Osea desde la sentencia SQL)
                cmd.CommandText = consulta; // Realizamos la consulta definida anteriormente

                cn.Open(); // Abrimos la conexion
                cmd.Connection = cn; // Asignamos al objeto comand la conexion

                DataTable tabla = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla); // Si tiene filas entonces hay algo

                if (tabla.Rows.Count == 1)
                {
                    resultado = true;
                }

                return resultado;
            }
            catch (Exception e)
            {

                throw; // Lo va a devolver al otro método que la invocó
            }
            finally
            {
                cn.Close();
            }
        }
        public static DataTable ObtenerListadoUsuarios()
        {
            // Accedemos a la key del archivo AppConfig para obtener la cadena de conexion.
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();

                // Realizamos la consulta Sql para obtener el usuario y contraseña de la BD
                string consulta = "SELECT * FROM Usuarios";

                cmd.Parameters.Clear(); // Limpiamos todos los tipos de parámetros
                cmd.CommandType = CommandType.Text; // Estamos diciendo que el comando lo vamos a insertar a mano (Osea desde la sentencia SQL)
                cmd.CommandText = consulta; // Realizamos la consulta definida anteriormente

                cn.Open(); // Abrimos la conexion
                cmd.Connection = cn; // Asignamos al objeto comand la conexion

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;
            }
            catch (Exception e)
            {

                throw; // Lo va a devolver al otro método que la invocó
            }
            finally
            {
                cn.Close();
            }
        }
        public static bool InsertarUsuario(string usuario, string contraseña)
        {
            bool resultado = false;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "InsertNuevoUsuario";
                //string consulta = "INSERT INTO Usuarios VALUES (@nombreUsuario, @contraseña)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
    }
}
