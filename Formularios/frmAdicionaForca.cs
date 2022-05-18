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
        private double angulo;
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
            //Verificar se foi passado um ângulo entre 0 e 90 -> falar pra adicionar horizontal se for 0 e adicionar vertical se for 90
            ForcaPonto forcaPonto;

            try
            {
                AlteraAngulo();
                forcaPonto = new ForcaPonto(Convert.ToDouble(txtIntensidade.Text), angulo, sentido, cbTipoSentido.SelectedItem.ToString(), cbQuadrante.SelectedIndex + 1);
                this._ponto.forcasPonto.Add(forcaPonto);
            }
            catch
            {
                MessageBox.Show("Dados Invalidos");
                return;
            }

            MessageBox.Show($"{forcaPonto.Angulo} = Cos: {forcaPonto.ComponenteHorizontal} - Sen {forcaPonto.ComponenteVertical}");
            this.Close();
        }
        private void AlteraAngulo()
        {
            if (cbQuadrante.SelectedIndex + 1 == 2 || cbQuadrante.SelectedIndex + 1 == 4)
            {
                angulo = (90 * (cbQuadrante.SelectedIndex + 1)) - Convert.ToDouble(txtAngulo.Text);
            }
            else if (cbQuadrante.SelectedIndex + 1 == 3)
                angulo = 180 + Convert.ToDouble(txtAngulo.Text);
            else
                angulo = Convert.ToDouble(txtAngulo.Text);
        }
    }
}
