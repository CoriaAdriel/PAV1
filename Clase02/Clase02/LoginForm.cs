using Clase02.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            
            // Datos Arcodiados
            string usuarioCorrecto = "Adriel";
            string contraseniaCorrecta = "123456";

            if (txtUsuario.Text.Equals(usuarioCorrecto) && txtContraseña.Text.Equals(contraseniaCorrecta))
            {
                //MessageBox.Show("Bienvenido " + txtUsuario.Text + " al sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrincipalForm principal = new PrincipalForm(usuario);
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y contraseña incorrectos ...", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
