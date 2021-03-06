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
        public static bool JaTemFixo;
        public static bool JaTemMovel;
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
            Form1 formPrincipal = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            //fixo   
            if (rbFixo.Checked)
            {
                if (JaTemFixo != true)
                {
                    JaTemFixo = true;
                    // Criando forças - > intensidade, ang, sentido, tiposentido
                    ForcaApoio forcaApoioV = new ForcaApoio(0, 90, "vertical", "Apontada para fora", "fixo");
                    this._ponto.forcasApoio.Add(forcaApoioV);
                    ForcaApoio forcaApoioH2 = new ForcaApoio(0, 0, "horizontal", "Apontada para fora", "fixo");
                    this._ponto.forcasApoio.Add(forcaApoioH2);
                    //formPrincipal.AdicionaApoios(_ponto, "Fixo");
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Já existe um apoio fixo");
                }

            }
            else
            {
                if (JaTemMovel != true) {
                    JaTemMovel = true;
                    ForcaApoio forcaApoioV = new ForcaApoio(0, 90, "vertical", "Apontada para fora", "movel");
                    this._ponto.forcasApoio.Add(forcaApoioV);
                    //formPrincipal.AdicionaApoios(_ponto, "Movel");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Já existe um apoio móvel");
                }

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rbMovel_CheckedChanged(object sender, EventArgs e)
        {
            //pbFixo.Visible = false;
            //pbMovel.Visible = true;
        }

        private void rbFixo_CheckedChanged(object sender, EventArgs e)
        {
            //pbFixo.Visible = true;
            //pbMovel.Visible = false;
        }
    }
}
