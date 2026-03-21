using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrussApplication
{
    public partial class frmDelete : Form
    {
        public static List<ArrowPoint> arrowList = new List<ArrowPoint>();
        public static List<PictureBox> deleteForceList = new List<PictureBox>();

        public frmDelete()
        {
            InitializeComponent();
        }

        private void btnDeleteBar_Click(object sender, EventArgs e)
        {
            Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            mainForm.DeleteBarEvent();
            this.Close();
        }

        private void btnDeleteForce_Click(object sender, EventArgs e)
        {
            Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            mainForm.DeleteForceEvent();
            this.Close();
        }

        private void btnDeleteSupport_Click(object sender, EventArgs e)
        {
            Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            mainForm.DeleteSupportEvent();
            this.Close();
        }
    }
}