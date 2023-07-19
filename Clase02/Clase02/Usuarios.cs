using Clase02.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase02
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
        private void CargarGrilla()
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

                gdrUsuarios.DataSource = tabla;
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

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombreDeUsuario.Text = "";
            txtContraseña.Text = "";
            txtRepetirContraseña.Text = "";
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            if(txtNombreDeUsuario.Text.Equals(""))
            {
                MessageBox.Show("Ingrese nombre de usuario");
            }
            else
            {
                if(txtContraseña.Text.Equals(txtRepetirContraseña.Text))
                {
                    try
                    {
                        bool resultado = InsertarUsuario(txtNombreDeUsuario.Text, txtContraseña.Text);
                        if(resultado)
                        {
                            MessageBox.Show("Usuario registrado con éxito", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            CargarGrilla();
                            txtNombreDeUsuario.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar usuario", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error al insertar nuevo usuario" + ex.Message);
                        txtNombreDeUsuario.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas ingresadas no coinciden");
                }
            }
        }

        private bool InsertarUsuario(string usuario, string contraseña)
        {
            bool resultado = false;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Usuarios VALUES (@nombreUsuario, @contraseña)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);                
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
