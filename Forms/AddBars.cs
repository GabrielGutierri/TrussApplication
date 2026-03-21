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
	public partial class AddBars : Form
	{
		Bar bar;
		Point initialPoint, finalPoint;
		int finalPointX, finalPointY;
		double angle, distance;

		public AddBars(Point point)
		{
			InitializeComponent();
			initialPoint = point;
		}

		private void CheckScale()
		{
			if (Form1.barList.Count == 0 && distance > 230)
			{
				Form1.drawingScale = Math.Round(distance / 230, 1);
			}
		}

		private void rbInclinedBar_CheckedChanged(object sender, EventArgs e)
		{
			if (rbInclinedBar.Checked == true)
			{
				gbInclinedBar.Visible = true;
				gbInclinedBar.Enabled = true;
			}
			else
			{
				gbInclinedBar.Enabled = false;
				gbInclinedBar.Visible = false;
			}
		}

		private void rbVerticalBar_CheckedChanged(object sender, EventArgs e)
		{
			if (rbVerticalBar.Checked == true)
			{
				gbVerticalBar.Visible = true;
				gbVerticalBar.Enabled = true;
			}
			else
			{
				gbVerticalBar.Visible = false;
				gbVerticalBar.Enabled = false;
			}
		}

		private void rbHorizontalBar_CheckedChanged(object sender, EventArgs e)
		{
			if (rbHorizontalBar.Checked == true)
			{
				gbHorizontalBar.Visible = true;
				gbHorizontalBar.Enabled = true;
			}
			else
			{
				gbHorizontalBar.Enabled = false;
				gbHorizontalBar.Visible = false;
			}
		}

		private void btnCreateVerticalBar_Click(object sender, EventArgs e)
		{
			try
			{
				distance = Convert.ToDouble(txtVerticalDistance.Text) / 1;
				CheckScale();
				angle = 90;
				distance = Convert.ToDouble(txtVerticalDistance.Text) / Form1.drawingScale;
			}
			catch
			{
				MessageBox.Show("Invalid Data");
				return;
			}

			if (rbUpVertical.Checked == true)
			{
				finalPointX = initialPoint.xValue;
				finalPointY = Convert.ToInt32(initialPoint.yValue - distance * Math.Sin(Math.PI * angle / 180.0));
				CheckRounding();
				finalPoint = new Point(finalPointX, finalPointY);
				if (CheckPanelLimits() == true) return;
				bar = new Bar(initialPoint.xValue, initialPoint.yValue, finalPointX, finalPointY, angle, distance, "Ascending");
			}
			else
			{
				finalPointX = initialPoint.xValue;
				finalPointY = Convert.ToInt32(initialPoint.yValue + distance * Math.Sin(Math.PI * angle / 180.0));
				CheckRounding();
				finalPoint = new Point(finalPointX, finalPointY);
				if (CheckPanelLimits() == true) return;
				bar = new Bar(initialPoint.xValue, initialPoint.yValue, finalPointX, finalPointY, angle, distance, "Descending");
			}

			Form1.barList.Add(bar);
			CheckPointExists(finalPoint);
			this.Close();
		}

		private void btnCreateHorizontalBar_Click(object sender, EventArgs e)
		{
			try
			{
				distance = Convert.ToDouble(txtHorizontalDistance.Text) / 1;
				CheckScale();
				angle = 0;
				distance = Convert.ToDouble(txtHorizontalDistance.Text) / Form1.drawingScale;
			}
			catch
			{
				MessageBox.Show("Invalid Data");
				return;
			}

			if (rbRightHorizontal.Checked == true)
			{
				finalPointX = Convert.ToInt32(initialPoint.xValue + distance * Math.Cos(Math.PI * angle / 180.0));
				finalPointY = initialPoint.yValue;
				CheckRounding();
				finalPoint = new Point(finalPointX, finalPointY);
				if (CheckPanelLimits() == true) return;
				bar = new Bar(initialPoint.xValue, initialPoint.yValue, finalPointX, finalPointY, angle, distance, "Ascending");
			}
			else
			{
				finalPointX = Convert.ToInt32(initialPoint.xValue - distance * Math.Cos(Math.PI * angle / 180.0));
				finalPointY = initialPoint.yValue;
				CheckRounding();
				finalPoint = new Point(finalPointX, finalPointY);
				if (CheckPanelLimits() == true) return;
				bar = new Bar(initialPoint.xValue, initialPoint.yValue, finalPointX, finalPointY, angle, distance, "Descending");
			}

			Form1.barList.Add(bar);
			CheckPointExists(finalPoint);
			this.Close();
		}

		private void btnCreateInclinedBar_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtInclinedDistance.Text == "")
				{
					distance = Math.Sqrt(Math.Pow(Convert.ToDouble(txtAdjacentLegInclined.Text), 2) +
						Math.Pow(Convert.ToDouble(txtOppositeLegInclined.Text), 2)) / 1;
				}
				else
				{
					distance = Convert.ToDouble(txtInclinedDistance.Text) / 1;
				}

				CheckScale();

				if (txtInclinedDistance.Text == "")
				{
					distance = Math.Sqrt(Math.Pow(Convert.ToDouble(txtAdjacentLegInclined.Text), 2) +
						Math.Pow(Convert.ToDouble(txtOppositeLegInclined.Text), 2)) / Form1.drawingScale;
				}
				else
				{
					distance = Convert.ToDouble(txtInclinedDistance.Text) / Form1.drawingScale;
				}
			}
			catch
			{
				MessageBox.Show("Invalid Data");
				return;
			}

			if (cbInclinationType.SelectedIndex == -1)
			{
				MessageBox.Show("Inclination type not selected");
				return;
			}
			else if (cbInclinationType.SelectedIndex == 0)
			{
				try
				{
					if (txtInclinedAngle.Text == "")
					{
						angle = Math.Atan2(Convert.ToDouble(txtOppositeLegInclined.Text), Convert.ToDouble(txtAdjacentLegInclined.Text)) *
							(180 / Math.PI);
					}
					else
					{
						angle = Convert.ToDouble(txtInclinedAngle.Text);
						if (angle > 90 || angle < 0)
						{
							MessageBox.Show("Angle must be between 0 and 90");
							return;
						}
					}
				}
				catch
				{
					MessageBox.Show("Invalid Data");
					return;
				}

				if (rbUpperInclined.Checked == true)
				{
					finalPointX = Convert.ToInt32(initialPoint.xValue + distance * Math.Cos(Math.PI * angle / 180.0));
					finalPointY = Convert.ToInt32(initialPoint.yValue - distance * Math.Sin(Math.PI * angle / 180.0));
					CheckRounding();
					finalPoint = new Point(finalPointX, finalPointY);
					if (CheckPanelLimits() == true) return;
					bar = new Bar(initialPoint.xValue, initialPoint.yValue, finalPointX, finalPointY, angle, distance, "Ascending");
				}
				else
				{
					finalPointX = Convert.ToInt32(initialPoint.xValue - distance * Math.Cos(Math.PI * angle / 180.0));
					finalPointY = Convert.ToInt32(initialPoint.yValue + distance * Math.Sin(Math.PI * angle / 180.0));
					CheckRounding();
					finalPoint = new Point(finalPointX, finalPointY);
					if (CheckPanelLimits() == true) return;
					bar = new Bar(initialPoint.xValue, initialPoint.yValue, finalPointX, finalPointY, angle, distance, "Ascending");
				}
			}
			else if (cbInclinationType.SelectedIndex == 1)
			{
				try
				{
					if (txtInclinedAngle.Text == "")
					{
						angle = Math.Atan2(Convert.ToDouble(txtOppositeLegInclined.Text), Convert.ToDouble(txtAdjacentLegInclined.Text)) * (180 / Math.PI);
					}
					else
					{
						angle = Convert.ToDouble(txtInclinedAngle.Text);
						if (angle > 90 || angle < 0)
						{
							MessageBox.Show("Angle must be between 0 and 90");
							return;
						}
					}
				}
				catch
				{
					MessageBox.Show("Invalid Data");
					return;
				}

				if (rbUpperInclined.Checked == true)
				{
					finalPointX = Convert.ToInt32(initialPoint.xValue - distance * Math.Cos(Math.PI * angle / 180.0));
					finalPointY = Convert.ToInt32(initialPoint.yValue - distance * Math.Sin(Math.PI * angle / 180.0));
					CheckRounding();
					finalPoint = new Point(finalPointX, finalPointY);
					if (CheckPanelLimits() == true) return;
					bar = new Bar(initialPoint.xValue, initialPoint.yValue, finalPointX, finalPointY, angle, distance, "Descending");
				}
				else
				{
					finalPointX = Convert.ToInt32(initialPoint.xValue + distance * Math.Cos(Math.PI * angle / 180.0));
					finalPointY = Convert.ToInt32(initialPoint.yValue + distance * Math.Sin(Math.PI * angle / 180.0));
					CheckRounding();
					finalPoint = new Point(finalPointX, finalPointY);
					if (CheckPanelLimits() == true) return;
					bar = new Bar(initialPoint.xValue, initialPoint.yValue, finalPointX, finalPointY, angle, distance, "Descending");
				}
			}

			CheckPointExists(finalPoint);
			var barPointList = new List<Point>() { initialPoint, finalPoint };
			bar.Force = new BarForce(Convert.ToDouble(null), bar.angle, bar.Direction, "Pointing inward", barPointList);
			Form1.barList.Add(bar);
			this.Close();
		}

		private void CheckRounding()
		{
			foreach (Point point in Form1.pointList)
			{
				if (finalPointX <= (point.xValue + 3) & finalPointX >= (point.xValue - 3) &
					finalPointY <= (point.yValue + 3) & finalPointY >= (point.yValue - 3))
				{
					finalPointX = point.xValue;
					finalPointY = point.yValue;
					break;
				}
			}
		}

		private bool CheckPanelLimits()
		{
			Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
			if (finalPoint.xValue > mainForm.drawingPanel.Width | finalPoint.yValue > mainForm.drawingPanel.Height | finalPoint.xValue < 0 | finalPoint.yValue < 0)
			{
				MessageBox.Show("Final point out of allowed limits. Please try again.");
				return true;
			}
			else
			{
				return false;
			}
		}

		private void CheckPointExists(Point newPoint)
		{
			Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
			if (Form1.pointList.Find(x => x.xValue == initialPoint.xValue & x.yValue == initialPoint.yValue) == null)
			{
				Form1.pointList.Add(initialPoint);
				initialPoint.pointBars.Add(bar);
				mainForm.CreatePointImage(initialPoint);
			}
			else
			{
				initialPoint = Form1.pointList.Find(x => x.xValue == initialPoint.xValue & x.yValue == initialPoint.yValue);
				initialPoint.pointBars.Add(bar);
			}

			if (Form1.pointList.Find(x => x.xValue == newPoint.xValue & x.yValue == newPoint.yValue) == null)
			{
				Form1.pointList.Add(newPoint);
				newPoint.pointBars.Add(bar);
				mainForm.CreatePointImage(newPoint);
			}
			else
			{
				newPoint = Form1.pointList.Find(x => x.xValue == newPoint.xValue & x.yValue == newPoint.yValue);
				newPoint.pointBars.Add(bar);
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			Forms.HelpAddBar f = new Forms.HelpAddBar();
			f.ShowDialog();
		}
	}
}