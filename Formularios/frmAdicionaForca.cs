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
            cbQuadrante.Items.Clear();
            cbQuadrante.Items.Add("1");
            cbQuadrante.Items.Add("2");
            cbQuadrante.Items.Add("3");
            cbQuadrante.Items.Add("4");
        }

        private void rbForcaVertical_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.Text = "90";
            txtAngulo.ReadOnly = true;
            sentido = "vertical";
            cbQuadrante.Items.Clear();
            cbQuadrante.Items.Add("1");
            cbQuadrante.Items.Add("3");
            
        }

        private void rbForcaHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.Text = "0";
            txtAngulo.ReadOnly = true;
            sentido = "horizontal";
            cbQuadrante.Items.Clear();
            cbQuadrante.Items.Add("1");
            cbQuadrante.Items.Add("2");
        }

        private void btnCriarBarraInclinado_Click(object sender, EventArgs e)
        {
            //Verificar se foi passado um ângulo entre 0 e 90 -> falar pra adicionar horizontal se for 0 e adicionar vertical se for 90
            try
            {
                Convert.ToInt32(txtAngulo.Text);
                Convert.ToInt32(txtIntensidade.Text);
                if (Verificacoes.VerificaAngulo(txtAngulo.Text))
                {
                    ForcaPonto forcaPonto;

                    if (rbForcaInclinada.Checked == true && cbQuadrante.SelectedIndex == 0)
                    {
                        MessageBox.Show("Dados Inválidos");
                        return;
                    }
                    AlteraAngulo();
                    forcaPonto = new ForcaPonto(Convert.ToDouble(txtIntensidade.Text), angulo, sentido, cbTipoSentido.SelectedItem.ToString(), Convert.ToInt32(cbQuadrante.Text));
                    this._ponto.forcasPonto.Add(forcaPonto);
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ângulo e intensidade devem ser números");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AlteraAngulo()
        {
            if (Convert.ToInt32(cbQuadrante.SelectedItem) == 2)
            {
                angulo = (90 * (Convert.ToInt32(cbQuadrante.SelectedItem))) - Convert.ToDouble(txtAngulo.Text);
            }
            else if (Convert.ToInt32(cbQuadrante.SelectedItem) == 4)
            {
                angulo = (90 * (Convert.ToInt32(cbQuadrante.SelectedItem))) - Convert.ToDouble(txtAngulo.Text);
            }
            else if (Convert.ToInt32(cbQuadrante.SelectedItem) == 3)
                angulo = 180 + Convert.ToDouble(txtAngulo.Text);
            else
                angulo = Convert.ToDouble(txtAngulo.Text);
            
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            Formularios.AjudaAdicionaForca f = new Formularios.AjudaAdicionaForca();
            f.ShowDialog();
        }

    }
}
