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
    public partial class frmCreation : Form
    {
        public Point _point { get; set; }

        public frmCreation(Point point)
        {
            _point = point;
            InitializeComponent();
        }

        private void btnAddBar_Click(object sender, EventArgs e)
        {
            AddBars b = new AddBars(_point);
            b.ShowDialog();
            this.Close();
        }

        private void btnAddForce_Click(object sender, EventArgs e)
        {
            frmAddForce f = new frmAddForce(_point);
            f.ShowDialog();
            this.Close();
        }

        private void btnAddSupport_Click(object sender, EventArgs e)
        {
            AddSupport f = new AddSupport(_point);
            f.ShowDialog();
            this.Close();
        }
    }
}