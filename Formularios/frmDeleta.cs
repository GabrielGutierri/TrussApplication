using Software_Trelisa.Properties;
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
    public partial class frmDeleta : Form
    {
        public static List<PontoSeta> listaSetas = new List<PontoSeta>();
        public static List<PictureBox> listaDeletaForca = new List<PictureBox>();
        public frmDeleta()
        {
            InitializeComponent();
        }

        private void btnDeletaBarra_Click(object sender, EventArgs e)
        {
            Form1 formPrincipal = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            formPrincipal.DeletarBarraEvent();
            this.Close();
        }

        private void btnDeletaForca_Click(object sender, EventArgs e)
        {
            Form1 formPrincipal = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            formPrincipal.DeletarForcaEvent();
            this.Close();
        }
        
    }
}
