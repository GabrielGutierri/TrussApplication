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
    public partial class frmCriacao : Form
    {
        public Ponto _ponto { get; set; } 
        public frmCriacao(Ponto ponto)
        {
            _ponto = ponto;
            InitializeComponent();
        }

        private void btnAdicionaBarra_Click(object sender, EventArgs e)
        {
            AdicionaBarras b = new AdicionaBarras(_ponto);
            b.ShowDialog();
            this.Close();
        }

        private void btnAdicionaForca_Click(object sender, EventArgs e)
        {
            frmAdicionaForca f = new frmAdicionaForca(_ponto);
            f.ShowDialog();
            this.Close();

        }
    }
}
