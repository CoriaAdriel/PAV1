using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtNombre.Text + " " + txtApellido.Text);
        }

        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Equals("") || txtApellido.Text.Equals(""))
            {
                MessageBox.Show("Complete nombre y apellido Por Favor....");
            }
            else
            {
                string nombreCompleto = "";
                nombreCompleto = txtNombre.Text + " " + txtApellido.Text;
                lstPersonas.Items.Add(nombreCompleto);
                MessageBox.Show("Se ha agregado correctamente la persona!");
                LimpiarCampos();
            }
        }
        public void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
        }

        private void btnAgregarPersona2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals("") || txtApellido.Text.Equals(""))
            {
                MessageBox.Show("Complete nombre y apellido Por Favor....");
            }
            else
            {
                string nombreCompleto = "";
                nombreCompleto = txtNombre.Text + " " + txtApellido.Text;
                DialogResult resultado =  MessageBox.Show(nombreCompleto, "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(resultado == DialogResult.OK) 
                {
                    lstPersonas.Items.Add(nombreCompleto);
                    MessageBox.Show("Se ha agregado correctamente la persona!");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se agrega la persona");
                }
            }
        }
    }
}
