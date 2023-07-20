using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase02.Entidades;

namespace Clase02.AccesoADatos
{
    public class AD_Varios
    {
        public static DataTable ObtenerTabla(string nombreTabla)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "SELECT * FROM " + nombreTabla;

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

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
        public static DataTable ObtenerTiposDocumentos()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "GetTiposDocumentos";

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

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

        public static DataTable ObtenerObtenerCarreras()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "GetCarreras";

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

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

        public static bool AgregarPersonaABD(Persona persona)
        {
            bool resultado = false;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Personas(Nombre, Apellido, FechaNacimiento, IdSexo, IdTipoDocumento, NroDocumento, Calle, NroCasa, Soltero, Casado, Hijos, CantidadHijos, IdCarrera) VALUES (@nombre,@apellido,@fechaNacimiento, @idSexo, @idTipoDocumento, @nroDocumento, @calle, @nroCasa, @soltero, @casado, @hijos, @cantidadHijos, @idCarrera)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", persona.getNombre());
                cmd.Parameters.AddWithValue("@apellido", persona.getApellido());
                cmd.Parameters.AddWithValue("@fechaNacimiento", persona.getFechaNacimiento());
                cmd.Parameters.AddWithValue("@idSexo", persona.getIdSexo());
                cmd.Parameters.AddWithValue("@idTipoDocumento", persona.getIdTipoDocumento());
                cmd.Parameters.AddWithValue("@nroDocumento", persona.getNumeroDocumento());
                cmd.Parameters.AddWithValue("@calle", persona.getCalle());
                cmd.Parameters.AddWithValue("@nroCasa", persona.getNroCasa());
                cmd.Parameters.AddWithValue("@soltero", persona.getSoltero());
                cmd.Parameters.AddWithValue("@casado", persona.getCasado());
                cmd.Parameters.AddWithValue("@hijos", persona.getOtro());
                cmd.Parameters.AddWithValue("@cantidadHijos", persona.getCantidadHijos());
                cmd.Parameters.AddWithValue("@idCarrera", persona.getIdCarrera());
                cmd.CommandType = CommandType.Text;
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
