using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Trelisa
{
    public partial class frmAdicionaForca : Form
    {
        public Ponto _ponto;
        public frmAdicionaForca(Ponto ponto)
        {
            InitializeComponent();
            _ponto = ponto;
            
        }

        private void rbForcaInclinada_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.ReadOnly = false;
        }

        private void rbForcaVertical_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.Text = "90";
            txtAngulo.ReadOnly = true;
        }

        private void rbForcaHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.Text = "0";
            txtAngulo.ReadOnly = true;
        }

        private void btnCriarBarraInclinado_Click(object sender, EventArgs e)
        {

        }
    }
}
