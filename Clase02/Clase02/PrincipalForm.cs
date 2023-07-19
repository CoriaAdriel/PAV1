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
    public partial class PrincipalForm : Form
    {
        public PrincipalForm(Usuario usuario)
        {
            InitializeComponent();
            lblBienvenido.Text += " " + usuario.getUsuario();
            lblBienvenido.Visible = true;
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {

        }
    }
}
