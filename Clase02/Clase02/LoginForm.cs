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
    public partial class LoginForm : Form
    {


        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txtUsuario.Text, txtContraseña.Text);

            if (txtUsuario.Text.Equals("") || txtContraseña.Text.Equals(""))
            {
                MessageBox.Show("Ingrese nombre de usuario y contraseña", "Login Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string nombreUsuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;

                bool resultado = false;

                // Vamos a intentar hacer esto
                try
                {
                    resultado = ValidarUsuario(nombreUsuario, contraseña);
                    // El usuario existe
                    if (resultado)
                    {
                        Usuario usu = new Usuario(nombreUsuario, contraseña);
                        PrincipalForm principal = new PrincipalForm(usu);
                        principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y contraseña Incorrecta", "Login Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar usuario - " + ex.Message, "Login Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
            }
        }

        /// <summary>
        /// Este método obtiene la cadena de conexion y realiza la consulta a la BD para
        /// obtener el usuario y contraseña. Devuelve true si lo encuentra y false si
        /// no lo encuentra.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        private bool ValidarUsuario(string usuario, string contraseña)
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
    }
}
