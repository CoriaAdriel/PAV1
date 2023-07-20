﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase02.Entidades;

namespace Clase02.AccesoADatos
{
    public class AD_Carreras
    {
        public static DataTable ObtenerCarrerasXId(int idCarrera)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "SELECT * FROM Carreras WHERE Id = @id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idCarrera);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;

            }
            catch (Exception)
            {
                throw; 
            }
            finally
            {
                cn.Close();
            }
        }       
    }
}
