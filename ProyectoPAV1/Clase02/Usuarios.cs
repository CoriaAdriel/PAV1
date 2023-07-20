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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            try
            {
                gdrUsuarios.DataSource = AD_Usuarios.ObtenerListadoUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener usuarios: " + ex.Message, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        bool resultado = AD_Usuarios.InsertarUsuario(txtNombreDeUsuario.Text, txtContraseña.Text);
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
    }
}
