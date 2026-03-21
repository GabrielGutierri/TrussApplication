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
    public partial class frmAddForce : Form
    {
        public Point _point;
        private string direction;
        private double angle;

        public frmAddForce(Point point)
        {
            InitializeComponent();
            _point = point;
            direction = "inclined";
        }

        private void rbInclinedForce_CheckedChanged(object sender, EventArgs e)
        {
            txtAngle.Text = "";
            txtAngle.ReadOnly = false;
            direction = "inclined";
            cbQuadrant.Items.Clear();
            cbQuadrant.Items.Add("1");
            cbQuadrant.Items.Add("2");
            cbQuadrant.Items.Add("3");
            cbQuadrant.Items.Add("4");
        }

        private void rbVerticalForce_CheckedChanged(object sender, EventArgs e)
        {
            txtAngle.Text = "";
            txtAngle.Text = "90";
            txtAngle.ReadOnly = true;
            direction = "vertical";
            cbQuadrant.Items.Clear();
            cbQuadrant.Items.Add("1");
            cbQuadrant.Items.Add("3");
        }

        private void rbHorizontalForce_CheckedChanged(object sender, EventArgs e)
        {
            txtAngle.Text = "";
            txtAngle.Text = "0";
            txtAngle.ReadOnly = true;
            direction = "horizontal";
            cbQuadrant.Items.Clear();
            cbQuadrant.Items.Add("1");
            cbQuadrant.Items.Add("2");
        }

        private void btnCreateForce_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtAngle.Text);
                Convert.ToInt32(txtIntensity.Text);
                if (Validations.ValidateAngle(txtAngle.Text))
                {
                    PointForce pointForce;

                    if (rbInclinedForce.Checked == true && cbQuadrant.SelectedIndex == -1)
                    {
                        MessageBox.Show("Invalid Data");
                        return;
                    }
                    AdjustAngle();
                    pointForce = new PointForce(Convert.ToDouble(txtIntensity.Text), angle, direction, cbOrientationType.SelectedItem.ToString(), Convert.ToInt32(cbQuadrant.Text));
                    this._point.pointForces.Add(pointForce);
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Angle and intensity must be numbers");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdjustAngle()
        {
            if (Convert.ToInt32(cbQuadrant.SelectedItem) == 2)
                angle = (90 * (Convert.ToInt32(cbQuadrant.SelectedItem))) - Convert.ToDouble(txtAngle.Text);
            else if (Convert.ToInt32(cbQuadrant.SelectedItem) == 4)
                angle = (90 * (Convert.ToInt32(cbQuadrant.SelectedItem))) - Convert.ToDouble(txtAngle.Text);
            else if (Convert.ToInt32(cbQuadrant.SelectedItem) == 3)
                angle = 180 + Convert.ToDouble(txtAngle.Text);
            else
                angle = Convert.ToDouble(txtAngle.Text);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Forms.HelpAddForce f = new Forms.HelpAddForce();
            f.ShowDialog();
        }
    }
}