using Clase02.AccesoADatos;
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
    public partial class AltaCurso : Form
    {
        public AltaCurso()
        {
            InitializeComponent();
        }

        private void AltaCurso_Load(object sender, EventArgs e)
        {
            CargarFecha();
            ObtenerUltimoCurso();
        }

        private void CargarFecha()
        {
            txtFecha.Text = DateTime.Now.ToShortDateString(); // Devuelve la Fecha en Formato Mes/Dia/Año
        }
        private void ObtenerUltimoCurso()
        {
            int id = AD_Cursos.ObtenerUltimoIdCurso();
            txtNroCurso.Text = (id+1).ToString();
        }

        private void btnBuscarCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tablaResultado = AD_Carreras.ObtenerCarrerasXId(int.Parse(txtNroCarrera.Text));
                if(tablaResultado.Rows.Count > 0 ) 
                {
                    // Obtenemos los resultados la columna Nombre y primera fila que tengamos
                    txtCarrera.Text = tablaResultado.Rows[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado la carrera ingresada", "Alta de nuevo curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNroCarrera.Focus();
                    txtCarrera.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al buscar las carreras. Erorr " + ex.Message, "Alta de nuevo curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscarAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tablaResultado = AD_Personas.ObtenerPersonaXDocumento(txtDni.Text.Trim());
                if(tablaResultado.Rows.Count > 0)
                {
                    txtNombreAlumno.Text = tablaResultado.Rows[0][1].ToString();
                    txtApellidoAlumno.Text = tablaResultado.Rows[0][2].ToString();
                    txtIdPersona.Text = tablaResultado.Rows[0][0].ToString();

                }
                else
                {
                    MessageBox.Show("No se ha encontrado al alumno ingresada", "Alta de nuevo curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDni.Focus();
                    txtAgregarAlumno.Text = "";
                    txtApellidoAlumno.Text = "";
                    txtIdPersona.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al buscar al alumno ingresado. Erorr " + ex.Message, "Alta de nuevo curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtAgregarAlumno_Click(object sender, EventArgs e)
        {
            gdrAlumnos.Rows.Add(txtIdPersona.Text,txtDni.Text, txtNombreAlumno.Text, txtApellidoAlumno.Text);
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<int> listaAlumnos = new List<int>();

            // Obtiene todos los ID de alumnos y se los asigna en la lista "ListaAlumnos"
            for (int i = 0; i < gdrAlumnos.Rows.Count; i++) 
            {
                // Sacamos todos los elementos de la grilla (Agrupados por ID) y se lo
                // Agregamos a la lista
                listaAlumnos.Add(int.Parse(gdrAlumnos.Rows[i].Cells[0].Value.ToString()));
            }

            bool resultado = AD_Cursos.AltaNuevoCurso(int.Parse(txtIdPersona.Text), txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), int.Parse(txtNroCarrera.Text), listaAlumnos);

            if (resultado) 
            {
                MessageBox.Show("Curso dado de alta con éxito", "Alta de nuevo curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al dar de alta nuevo curso", "Alta de nuevo curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
