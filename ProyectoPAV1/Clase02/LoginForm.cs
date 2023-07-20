using Clase02.AccesoADatos;
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
                    resultado = AD_Usuarios.ValidarUsuario(nombreUsuario, contraseña);
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
    }
}
