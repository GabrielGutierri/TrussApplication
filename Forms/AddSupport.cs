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
    public partial class AddSupport : Form
    {
        public Point _point;
        public static bool HasFixed;
        public static bool HasMobile;

        public AddSupport(Point point)
        {
            InitializeComponent();
            _point = point;
        }

        private void gbForce_Enter(object sender, EventArgs e) { }

        private void btnCreateSupport_Click(object sender, EventArgs e)
        {
            Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (rbFixed.Checked)
            {
                if (HasFixed != true)
                {
                    HasFixed = true;
                    SupportForce verticalSupportForce = new SupportForce(0, 90, "vertical", "Pointing outward", "fixed");
                    this._point.supportForces.Add(verticalSupportForce);
                    SupportForce horizontalSupportForce = new SupportForce(0, 0, "horizontal", "Pointing outward", "fixed");
                    this._point.supportForces.Add(horizontalSupportForce);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A fixed support already exists");
                }
            }
            else
            {
                if (HasMobile != true)
                {
                    HasMobile = true;
                    SupportForce verticalSupportForce = new SupportForce(0, 90, "vertical", "Pointing outward", "mobile");
                    this._point.supportForces.Add(verticalSupportForce);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A mobile support already exists");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void rbMobile_CheckedChanged(object sender, EventArgs e) { }

        private void rbFixed_CheckedChanged(object sender, EventArgs e) { }
    }
}