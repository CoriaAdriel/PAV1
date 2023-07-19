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
    public partial class AltaPersona : Form
    {
        public AltaPersona()
        {
            InitializeComponent();
        }

        private void AltaPersona_Load(object sender, EventArgs e)
        {
            LimpiarCampos();

            txtCantidadHijos.Enabled = false;

            cmbTipoDocumento.Items.Add("DNI");
            cmbTipoDocumento.Items.Add("Pasaporte");
            cmbTipoDocumento.Items.Add("Libreta Universitaria");

            cmbCarrera.Items.Add("Ingeniería en Sistemas de Información");
            cmbCarrera.Items.Add("Ingeniería Mecánica");
            cmbCarrera.Items.Add("Ingeniería Industrial");
        }

        private void btnGuardarPersona_Click(object sender, EventArgs e)
        {
            string resultado = "";

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string fechaNacimiento = txtFechaNacimiento.Text;
            string sexo = "";

            if(rdMasculino.Checked)
            {
                sexo = "Masculino";
            }
            if(rdFemenino.Checked)
            {
                sexo = "Femenino";
            }
            if(rdOtro.Checked)
            {
                sexo = "Otro";
            }
            string tipoDocumento = cmbTipoDocumento.GetItemText(cmbTipoDocumento.SelectedItem);
            string numeroDocumento = txtNumeroDocumento.Text;
            string calle = txtCalle.Text;
            string numeroCasa = txtNumeroCasa.Text;

            string soltero = "";
            string casado = "";
            string conHijos = "";
            string cantidadHijos = "0";

            if(chkSoltero.Checked)
            {
                soltero = "Soltero";
            }
            else
            {
                soltero = "No es soltero";
            }
            if(chkCasado.Checked)
            {
                casado = "Casado";
            }
            else
            {
                casado = "No es casado";
            }
            if(chkHijos.Checked)
            {
                conHijos = "Si tiene hijos";
            }
            else
            {
                conHijos = "No tiene hijos";
            }
            cantidadHijos = txtCantidadHijos.Text;
            string carrera = cmbCarrera.GetItemText(cmbCarrera.SelectedItem);
            //MessageBox.Show("Los datos de la persona cargado son: \nNombre: " + nombre + "\nApellido: " + apellido + "\nFecha de Nacimiento: " + fechaNacimiento + "\nSexo: " + sexo + "\nTipo de Documento: "+ tipoDocumento + "\nNúmero de Documento: " + numeroDocumento + "\nCalle: " + calle + "\nNúmero de Casa: " + numeroCasa + "\nSoltero: " +soltero + "\nCasado: " + casado + "\nCon Hijos: " + conHijos + "\nCantidad: " + cantidadHijos + "\nCarrera: " + carrera, "Registrar Nueva Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bool tieneNombre = false;
            bool tieneApellido = false;
            bool tieneDocumento = false;
            bool existeEnLaGrilla = false;

            if(txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el campo nombre Por Favor", "Registrar nueva persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
            }
            else
            {
                tieneNombre = true;
            }
            if(txtApellido.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el campo apellido Por Favor", "Registrar nueva persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApellido.Focus();
            }
            else
            {
                tieneApellido = true;
            }
            if(txtNumeroDocumento.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el campo número de documento Por Favor", "Registrar nueva persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumeroDocumento.Focus();
            }
            else
            {
                tieneDocumento = true;
            }

            existeEnLaGrilla = ExisteEnGrilla(numeroDocumento);
            if(existeEnLaGrilla)
            {
                MessageBox.Show("Persona registrada en el sistema previamente", "Registrar nueva persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (tieneNombre && tieneApellido && tieneDocumento && existeEnLaGrilla == false)
            {
                Persona persona = new Persona(nombre, apellido, numeroDocumento);
                AgregarPersona(persona);
            }
            //MessageBox.Show("Datos de la Persona:" + "\nNombre: " + persona.getNombre() + "\nApellido: " + persona.getApellido() + "\nNúmero de Documento: " + persona.getNumeroDocumento());
        }

        public void AgregarPersona(Persona persona)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell celdaDocumento = new DataGridViewTextBoxCell();
            celdaDocumento.Value = persona.getNumeroDocumento();
            fila.Cells.Add(celdaDocumento);

            DataGridViewTextBoxCell celdaNombre = new DataGridViewTextBoxCell();
            celdaNombre.Value = persona.getNombre();
            fila.Cells.Add(celdaNombre);

            DataGridViewTextBoxCell celdaApellido = new DataGridViewTextBoxCell();
            celdaApellido.Value = persona.getApellido();
            fila.Cells.Add(celdaApellido);

            gdrPersonas.Rows.Add(fila);

            MessageBox.Show("Persona Agregada con éxito", "Registrar nueva persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            txtNombre.Focus();
        }

        private void chkHijos_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHijos.Checked)
            {
                txtCantidadHijos.Enabled = true;
            }
            else
            {
                txtCantidadHijos.Enabled = false;
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaNacimiento.Text = "";
            txtNumeroDocumento.Text = "";
            txtCalle.Text = "";
            txtNumeroCasa.Text = "";
            rdMasculino.Checked = false;
            rdFemenino.Checked = false;
            rdOtro.Checked = false;
            chkSoltero.Checked = false;
            chkCasado.Checked = false;
            chkHijos.Checked = false;
            txtCantidadHijos.Text = "";
        }

        private bool ExisteEnGrilla(string criterioABuscar)
        {
            bool resultado = false;

            // Recorremos todas las filas que tiene la grilla.
            for (int i = 0; i < gdrPersonas.Rows.Count; i++)
            {
                // Si cada iteracion de la fila en la columna Documento se encuentra el mismo criterio a buscar, entonces resultado cambia a true.
                if (gdrPersonas.Rows[i].Cells["Documento"].Value.Equals(criterioABuscar))
                {
                    resultado = true;
                    break; // Cortamos
                }
            }
            return resultado;
        }
    }
}
