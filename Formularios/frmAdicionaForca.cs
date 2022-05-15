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
        private string sentido;
        public frmAdicionaForca(Ponto ponto)
        {
            InitializeComponent();
            _ponto = ponto;
            sentido = "inclinada";
        }

        private void rbForcaInclinada_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.ReadOnly = false;
            sentido = "inclinada";
        }

        private void rbForcaVertical_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.Text = "90";
            txtAngulo.ReadOnly = true;
            sentido = "vertical";
        }

        private void rbForcaHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.Text = "0";
            txtAngulo.ReadOnly = true;
            sentido = "horizontal";
        }

        private void btnCriarBarraInclinado_Click(object sender, EventArgs e)
        {
            //defineDirecao();
            MessageBox.Show($"{cbQuadrante.SelectedIndex}");
            ForcaPonto forcaPonto = new ForcaPonto(Convert.ToDouble(txtIntensidade.Text), Convert.ToDouble(txtAngulo.Text), sentido, cbTipoSentido.SelectedItem.ToString());
            this._ponto.forcasPonto.Add(forcaPonto);
            this.Close();
        }

        private void cbQuadranteForca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
