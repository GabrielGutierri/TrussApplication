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
    public partial class AdicionaApoio : Form
    {

        public Ponto _ponto;
        public AdicionaApoio(Ponto ponto)
        {
            InitializeComponent();
            _ponto = ponto;
        }


        private void gbForça_Enter(object sender, EventArgs e)
        {

        }

        private void btnCriarApoio_Click(object sender, EventArgs e)
        {
            //fixo   
            if (rbFixo.Checked)
            {
                // Criando forças - > intensidade, ang, sentido, tiposentido
                ForcaApoio forcaApoioV = new ForcaApoio(0, 90, "vertical", "Abaixo", "fixo");
                this._ponto.forcasApoio.Add(forcaApoioV);
                ForcaApoio forcaApoioH2 = new ForcaApoio(0, 0, "horizontal", "Esquerda", "fixo");
                this._ponto.forcasApoio.Add(forcaApoioH2);
                this.Close();

            }
            else
            {
                ForcaApoio forcaApoioV = new ForcaApoio(0, 90, "vertical", "Abaixo", "movel");
                this._ponto.forcasPonto.Add(forcaApoioV);
                this.Close();
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rbMovel_CheckedChanged(object sender, EventArgs e)
        {
            pbFixo.Visible = false;
            pbMovel.Visible = true;
        }

        private void rbFixo_CheckedChanged(object sender, EventArgs e)
        {
            pbFixo.Visible = true;
            pbMovel.Visible = false;
        }
    }
}
