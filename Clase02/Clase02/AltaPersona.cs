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
            btnActualizar.Enabled = false;
            CargarComboTiposDocumentos();
            CargarComboCarreras();
            CargarGrilla();
        }
        public void CargarGrilla()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();

                
                string consulta = "SELECT Nombre, Apellido, IdTipoDocumento, NroDocumento FROM Personas";

                cmd.Parameters.Clear(); 
                cmd.CommandType = CommandType.Text; 
                cmd.CommandText = consulta; 

                cn.Open(); 
                cmd.Connection = cn; 

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                gdrPersonas.DataSource = tabla;
            }
            catch (Exception e)
            {

                throw; 
            }
            finally
            {
                cn.Close();
            }
        }

        private void CargarComboTiposDocumentos()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();

                
                string consulta = "SELECT * FROM TiposDocumentos";

                cmd.Parameters.Clear(); 
                cmd.CommandType = CommandType.Text; 
                cmd.CommandText = consulta;

                cn.Open(); 
                cmd.Connection = cn; 

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                
                cmbTipoDocumento.DataSource = tabla;
                cmbTipoDocumento.DisplayMember = "Nombre";
                cmbTipoDocumento.ValueMember = "Id";
                cmbTipoDocumento.SelectedIndex = -1;

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
        private void CargarComboCarreras()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "SELECT * FROM Carreras";

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                cmbCarrera.DataSource = tabla;
                cmbCarrera.DisplayMember = "Nombre";
                cmbCarrera.ValueMember = "Id";
                cmbCarrera.SelectedIndex = -1;

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
        private Persona ObtenerDatosPersona()
        {
            Persona p = new Persona();
            p.setNombre(txtNombre.Text.Trim());
            p.setApellido(txtApellido.Text.Trim());
            p.setFechaNacimiento(DateTime.Parse(txtFechaNacimiento.Text));

            if (rdMasculino.Checked)
            {
                p.setIdSexo(1);
            }
            else if (rdFemenino.Checked)
            {
                p.setIdSexo(2);
            }
            else
            {
                p.setIdSexo(3);
            }
            p.setIdTipoDocumento((int)cmbTipoDocumento.SelectedValue);
            p.setNumeroDocumento(txtNumeroDocumento.Text.Trim());
            p.setCalle(txtCalle.Text.Trim());
            p.setNroCasa(txtNumeroCasa.Text.Trim());
            if (chkSoltero.Checked)
            {
                p.setSoltero(true);
            }
            else
            {
                p.setSoltero(false);
            }
            if (chkCasado.Checked)
            {
                p.setCasado(true);
            }
            else
            {
                p.setCasado(false);
            }
            if (chkHijos.Checked)
            {
                p.setOtro(true);
            }
            else
            {
                p.setOtro(false);
            }
            if (txtCantidadHijos.Text.Equals(""))
            {
                p.setCantidadHijos(0);
            }
            else
            {
                p.setCantidadHijos(int.Parse(txtCantidadHijos.Text));
            }
            p.setIdCarrera((int)cmbCarrera.SelectedValue);

            return p;
        }

        private void btnGuardarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                Persona p = ObtenerDatosPersona();
                bool resultado = AgregarPersonaABD(p);
                if (resultado)
                {
                    MessageBox.Show("Persona agregada con éxito", "Registrar nuevo persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarComboCarreras();
                    CargarComboTiposDocumentos();
                    CargarGrilla();
                }
                else
                {
                    MessageBox.Show("Error al agregar a la persona", "Registrar nuevo persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }



        private bool AgregarPersonaABD(Persona persona)
        {
            bool resultado = false;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Personas(Nombre, Apellido, FechaNacimiento, IdSexo, IdTipoDocumento, NroDocumento, Calle, NroCasa, Soltero, Casado, Hijos, CantidadHijos, IdCarrera) VALUES (@nombre,@apellido,@fechaNacimiento, @idSexo, @idTipoDocumento, @nroDocumento, @calle, @nroCasa, @soltero, @casado, @hijos, @cantidadHijos, @idCarrera)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", persona.getNombre());
                cmd.Parameters.AddWithValue("@apellido", persona.getApellido());
                cmd.Parameters.AddWithValue("@fechaNacimiento", persona.getFechaNacimiento());
                cmd.Parameters.AddWithValue("@idSexo", persona.getIdSexo());
                cmd.Parameters.AddWithValue("@idTipoDocumento", persona.getIdTipoDocumento());
                cmd.Parameters.AddWithValue("@nroDocumento", persona.getNumeroDocumento());
                cmd.Parameters.AddWithValue("@calle", persona.getCalle());
                cmd.Parameters.AddWithValue("@nroCasa", persona.getNroCasa());
                cmd.Parameters.AddWithValue("@soltero", persona.getSoltero());
                cmd.Parameters.AddWithValue("@casado", persona.getCasado());
                cmd.Parameters.AddWithValue("@hijos", persona.getOtro());
                cmd.Parameters.AddWithValue("@cantidadHijos", persona.getCantidadHijos());
                cmd.Parameters.AddWithValue("@idCarrera", persona.getIdCarrera());                
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

        private void gdrPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnActualizar.Enabled = true;  
                int indice = e.RowIndex; // De esta forma ya sabemos en qué fila estamos parado
                DataGridViewRow filaSeleccionada = gdrPersonas.Rows[indice]; // Nos posiciona en la fila que queremos modificar
                string documento = filaSeleccionada.Cells["Documento"].Value.ToString(); // Devolvemos el valor del documento que queremos buscar
                Persona p = ObtenerPersona(documento);
                LimpiarCampos();
                CargarCampos(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
            }

        }

        private void CargarCampos(Persona p)
        {
            txtNombre.Text = p.getNombre();
            txtApellido.Text = p.getApellido();
            DateTime fecha = p.getFechaNacimiento();
            string dia = "";
            string mes = "";
            string año = "";
            dia = fecha.Date.Day.ToString();
            if(dia.Length == 1)
            {
                dia = "0" + dia;
            }
            mes = fecha.Date.Month.ToString();
            if(mes.Length == 1)
            {
                mes = "0" + mes;
            }
            año = fecha.Date.Year.ToString();


            txtFechaNacimiento.Text = dia + mes + año;
            if(p.getIdSexo() == 1)
            {
                rdMasculino.Checked = true;
            }
            else if(p.getIdSexo() == 2)
            {
                rdFemenino.Checked = true;
            }
            else
            {
                rdOtro.Checked = true;
            }
            cmbTipoDocumento.SelectedValue = p.getIdTipoDocumento();
            txtNumeroDocumento.Text = p.getNumeroDocumento();
            txtCalle.Text = p.getCalle();
            txtNumeroCasa.Text = p.getNroCasa().ToString();
            if (p.getSoltero())
            {
                chkSoltero.Checked = true;
            }
            else
            {
                chkSoltero.Checked = false;
            }
            if (p.getCasado())
            {
                chkCasado.Checked = true;
            }
            else
            {
                chkCasado.Checked = false;
            }
            if(p.getOtro())
            {
                chkHijos.Checked = true;
            }
            else
            {
                chkHijos.Checked = false;
            }
            if(p.getCantidadHijos() > 0 )
            { 
                txtCantidadHijos.Text = p.getCantidadHijos().ToString();
            }
            else
            {
                txtCantidadHijos.Text = "";
            }

            cmbCarrera.SelectedValue = p.getIdCarrera();
        }


        private Persona ObtenerPersona(string documento)
        {           
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            Persona p = new Persona();

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Personas WHERE NroDocumento LIKE @documento";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader(); // Para poder leerlo


                // Si el dataReader no es nulo && -> Arojame el primer valor que tengas
                if(dr != null && dr.Read())
                {
                    p.setNombre(dr["Nombre"].ToString());
                    p.setApellido(dr["Apellido"].ToString());
                    p.setFechaNacimiento(DateTime.Parse(dr["FechaNacimiento"].ToString()));
                    p.setIdSexo(int.Parse(dr["IdSexo"].ToString()));
                    p.setIdTipoDocumento(int.Parse(dr["IdTipoDocumento"].ToString()));
                    p.setNumeroDocumento(dr["NroDocumento"].ToString());
                    p.setCalle(dr["Calle"].ToString());
                    p.setNroCasa(dr["NroCasa"].ToString());
                    p.setSoltero(bool.Parse(dr["Soltero"].ToString()));
                    p.setCasado(bool.Parse(dr["Casado"].ToString()));
                    p.setOtro(bool.Parse(dr["Hijos"].ToString()));
                    p.setCantidadHijos(int.Parse(dr["CantidadHijos"].ToString()));
                    p.setIdCarrera(int.Parse(dr["IdCarrera"].ToString()));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }            
            return p;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnGuardarPersona.Enabled = false;
            Persona p = ObtenerDatosPersona();
            bool resultado = ActualizarPersona(p);
            if(resultado)
            {
                MessageBox.Show("Persona actualizada con éxito", "Registrar Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarGrilla();
                CargarComboCarreras();
                CargarComboTiposDocumentos();
            }
            else
            {
                MessageBox.Show("Erorr al actualizar Persona", "Registrar Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ActualizarPersona(Persona persona)
        {
            bool resultado = false;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "UPDATE Personas SET Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fechaNacimiento, IdSexo = @idSexo, IdTipoDocumento = @idTipoDocumento, NroDocumento = @nroDocumento, Calle = @calle, NroCasa = @nroCasa, Soltero = @soltero, Casado = @casado, Hijos = @hijos, CantidadHijos = @cantidadHijos, IdCarrera = @idCarrera where NroDocumento LIKE @nroDocumento";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", persona.getNombre());
                cmd.Parameters.AddWithValue("@apellido", persona.getApellido());
                cmd.Parameters.AddWithValue("@fechaNacimiento", persona.getFechaNacimiento());
                cmd.Parameters.AddWithValue("@idSexo", persona.getIdSexo());
                cmd.Parameters.AddWithValue("@idTipoDocumento", persona.getIdTipoDocumento());
                cmd.Parameters.AddWithValue("@nroDocumento", persona.getNumeroDocumento());
                cmd.Parameters.AddWithValue("@calle", persona.getCalle());
                cmd.Parameters.AddWithValue("@nroCasa", persona.getNroCasa());
                cmd.Parameters.AddWithValue("@soltero", persona.getSoltero());
                cmd.Parameters.AddWithValue("@casado", persona.getCasado());
                cmd.Parameters.AddWithValue("@hijos", persona.getOtro());
                cmd.Parameters.AddWithValue("@cantidadHijos", persona.getCantidadHijos());
                cmd.Parameters.AddWithValue("@idCarrera", persona.getIdCarrera());
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
