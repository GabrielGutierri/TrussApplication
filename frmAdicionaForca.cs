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
            
        }

        private void rbForcaInclinada_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.ReadOnly = false;
            cbTipoSentido.Items.Clear();
            cbTipoSentido.Items.Add("Para fora");
            cbTipoSentido.Items.Add("Para dentro");
            sentido = "inclinado";
        }

        private void rbForcaVertical_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.Text = "90";
            txtAngulo.ReadOnly = true;
            cbTipoSentido.Items.Clear();
            cbTipoSentido.Items.Add("Cima");
            cbTipoSentido.Items.Add("Baixo");
            sentido = "vertical";
        }

        private void rbForcaHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            txtAngulo.Text = "";
            txtAngulo.Text = "0";
            txtAngulo.ReadOnly = true;
            cbTipoSentido.Items.Clear();
            cbTipoSentido.Items.Add("Direita");
            cbTipoSentido.Items.Add("Esquerda");
            sentido = "horizontal";
        }

        private void btnCriarBarraInclinado_Click(object sender, EventArgs e)
        {
            //defineDirecao();
            ForcaPonto forcaPonto = new ForcaPonto(Convert.ToDouble(txtIntensidade.Text), Convert.ToDouble(txtAngulo.Text), sentido, cbTipoSentido.SelectedItem.ToString());
            this._ponto.forcasPonto.Add(forcaPonto);
            this.Close();
        }

        // 0 = para fora; 1=para dentro
        // 0 = para direita; 1=para esquerda
        //private string defineDirecao()
        //{
        //    if (rbForcaVertical.Checked && cbTipoSentido.SelectedIndex == 0)
        //        return "Cima";
        //    else if (rbForcaVertical.Checked && cbTipoSentido.SelectedIndex == 1)
        //        return "Baixo";
        //    else if (rbForcaHorizontal.Checked && cbTipoSentido.SelectedIndex == 0)
        //        return "Direita";
        //    else if (rbForcaHorizontal.Checked && cbTipoSentido.SelectedIndex == 1)
        //        return "Esquerda";
        //    else if (rbForcaInclinada.Checked && cbTipoSentido.SelectedIndex == 0)
        //        return "Inclinada para fora";
        //    else
        //        return "Inclinada para dentro";
        //}
    }
}
