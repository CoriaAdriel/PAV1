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
    public class AD_Cursos
    {
        public static int ObtenerUltimoIdCurso()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "SELECT MAX(Id) FROM cursos";

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                
                int resultado = (int) cmd.ExecuteScalar(); // Nos devuelve un valor numérico
                return resultado;

            }
            catch (Exception)
            {
                return 0; 
            }
            finally
            {
                cn.Close();
            }
        }
        public static bool AltaNuevoCurso(int idCurso, string nombreCurso, string descripcionCurso, int idCarrera, List<int> listaIdAlumnos)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlTransaction objTransaccion = null;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "INSERT INTO Cursos VALUES(@nombre, @descripcion, @idCarrera)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", nombreCurso);
                cmd.Parameters.AddWithValue("@descripcion", descripcionCurso);
                cmd.Parameters.AddWithValue("@idCarrera", idCarrera);                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                
                cn.Open();

                objTransaccion = cn.BeginTransaction("AltaDeCurso");
                cmd.Transaction = objTransaccion;
                cmd.Connection = cn;                
                cmd.ExecuteNonQuery();

                foreach (var idAlumno in listaIdAlumnos)
                {
                    string consultaCursoXAlumno = "INSERT INTO PersonasXCursos VALUES(@idPersona, @idCurso, @fechaAsociacion)";

                    cmd.Parameters.Clear();                                       
                    cmd.Parameters.AddWithValue("@idPersona", idAlumno);
                    cmd.Parameters.AddWithValue("@idCurso", idCurso);
                    cmd.Parameters.AddWithValue("@fechaAsociacion", DateTime.Now);
                    
                    cmd.CommandText = consultaCursoXAlumno;
                    cmd.ExecuteNonQuery();
                }
                objTransaccion.Commit();
                return true;
            }
            catch (Exception)
            {
                objTransaccion.Rollback();
                return false;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
