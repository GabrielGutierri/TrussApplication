using TrussApplication.Calculations;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TrussApplication.Properties;

namespace TrussApplication
{
    public partial class Form1 : Form
    {
        public static List<Bar> barList = new List<Bar>();
        public static List<Point> pointList = new List<Point>();
        public static List<ArrowPoint> arrowList = new List<ArrowPoint>();
        public static List<PictureBox> pictureBoxList = new List<PictureBox>();
        List<Point> deleteList = new List<Point>();
        List<PictureBox> deleteForceList = new List<PictureBox>();
        public static double drawingScale = 1;
        bool wantsToDelete = false;
        Point testPoint { get; set; }

        public Form1()
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            InitializeComponent();
        }

        #region Point Events
        public void newPoint_DoubleClick(object sender, EventArgs e, Point point)
        {
            if (wantsToDelete == true)
            {
                WantsToDelete(point);
            }
            else
            {
                frmCreation f = new frmCreation(point);
                f.ShowDialog();

                foreach (PictureBox image in pictureBoxList)
                {
                    image.Enabled = false;
                    image.Visible = false;
                }
                lbMessage.Visible = false;
            }
            DrawBars();
            DrawForces();
        }

        private void AddFirstPoint()
        {
            Point point = new Point(75, drawingPanel.Height - 100);
            pointList.Add(point);
            CreatePointImage(point);
            this.testPoint = point;
        }

        public void CreatePointImage(Point point)
        {
            System.Windows.Forms.PictureBox newPointImage = new System.Windows.Forms.PictureBox();
            newPointImage.Image = TrussApplication.Properties.Resources.PontoSelecao;
            newPointImage.Name = "Point" + point.xValue.ToString() + point.yValue.ToString();
            newPointImage.SizeMode = PictureBoxSizeMode.StretchImage;
            newPointImage.BackColor = Color.White;
            newPointImage.Width = 20;
            newPointImage.Height = 20;
            newPointImage.Location = new System.Drawing.Point(point.xValue - 10, point.yValue - 10);
            newPointImage.Click += new EventHandler((sender, e) => newPoint_DoubleClick(sender, e, point));
            newPointImage.Enabled = false;
            newPointImage.Visible = false;
            drawingPanel.Controls.Add(newPointImage);
            pictureBoxList.Add(newPointImage);
        }
        #endregion

        #region Test Button
        /*
        private void button2_Click(object sender, EventArgs e)
        {
            Bar bar1 = new Bar(75, 500, 125, 230, 79.509, 274.59060, "Ascending");
            Bar bar2 = new Bar(75, 500, 575, 500, 0, 500, "Ascending");
            Bar bar3 = new Bar(575, 500, 575, 150, 90, 350, "Ascending");
            Bar bar4 = new Bar(125, 230, 575, 500, 30.96376, 524.78, "Descending");
            Bar bar5 = new Bar(125, 230, 575, 150, 10.0806, 457.06, "Ascending");
            Bar bar6 = new Bar(575, 150, 825, 500, 54.46232, 430.12, "Descending");
            Bar bar7 = new Bar(825, 500, 575, 500, 0, 250, "Descending");

            pointList[0].pointBars.Add(bar1);
            pointList[0].pointBars.Add(bar2);
            testPoint.supportForces.Add(new SupportForce(0, 90, "vertical", "Pointing outward", "fixed"));
            testPoint.supportForces.Add(new SupportForce(0, 0, "horizontal", "Pointing outward", "fixed"));

            Point point2 = new Point(125, 230);
            point2.pointForces.Add(new PointForce(12000, 90, "vertical", "Pointing inward", 1));
            point2.pointForces.Add(new PointForce(15000, 0, "horizontal", "Pointing inward", 1));
            point2.pointBars.Add(bar1);
            point2.pointBars.Add(bar4);
            point2.pointBars.Add(bar5);
            Point point3 = new Point(575, 500);
            point3.pointForces.Add(new PointForce(8000, 270, "vertical", "Pointing inward", 3));
            point3.pointBars.Add(bar2);
            point3.pointBars.Add(bar3);
            point3.pointBars.Add(bar4);
            point3.pointBars.Add(bar7);
            Point point4 = new Point(575, 150);
            point4.pointForces.Add(new PointForce(35000, 120, "inclined", "Pointing inward", 2));
            point4.pointBars.Add(bar3);
            point4.pointBars.Add(bar5);
            point4.pointBars.Add(bar6);
            Point point5 = new Point(825, 500);
            point5.pointBars.Add(bar6);
            point5.pointBars.Add(bar7);
            pointList.Add(point2);
            pointList.Add(point3);
            pointList.Add(point4);
            pointList.Add(point5);
            point5.supportForces.Add(new SupportForce(0, 90, "vertical", "Pointing outward", "mobile"));

            CreatePointImage(point2);
            CreatePointImage(point3);
            CreatePointImage(point4);
            CreatePointImage(point5);

            barList.Add(bar1);
            barList.Add(bar2);
            barList.Add(bar3);
            barList.Add(bar4);
            barList.Add(bar5);
            barList.Add(bar6);
            barList.Add(bar7);

            DrawBars();
            DrawForces();

            btnTest.Enabled = false;
        }
        */
        #endregion

        #region Create Button
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (pointList.Count == 0)
            {
                AddFirstPoint();
            }
            lbDelete.Visible = false;
            drawingPanel.Visible = true;
            lbMessage.Visible = true;
            foreach (PictureBox image in pictureBoxList)
            {
                image.Enabled = true;
                image.Visible = true;
            }
            foreach (var pcb in deleteForceList)
            {
                drawingPanel.Controls.Remove(pcb);
            }
            arrowList.Clear();
            DrawBars();
            DrawForces();
        }
        #endregion

        #region Add Support
        public void AddSupports(Point point, string type)
        {
            System.Windows.Forms.PictureBox newPointImage = new System.Windows.Forms.PictureBox();
            newPointImage.SizeMode = PictureBoxSizeMode.StretchImage;
            newPointImage.BorderStyle = BorderStyle.None;
            newPointImage.Width = 100;
            newPointImage.Height = 60;
            newPointImage.Tag = "support";

            newPointImage.Location = new System.Drawing.Point(point.xValue - 50, point.yValue + 6);
            if (type == "fixed")
            {
                newPointImage.Image = Properties.Resources.Apoio_Duplo;
                drawingPanel.Controls.Add(newPointImage);
            }
            else
            {
                newPointImage.Image = Properties.Resources.Apoio_simples;
            }
            drawingPanel.Controls.Add(newPointImage);
            newPointImage.BackColor = Color.Transparent;
        }
        #endregion

        #region Delete Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            lbMessage.Visible = false;
            frmDelete f = new frmDelete();
            f.ShowDialog();
        }
        #endregion

        #region Calculate Button
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show("Is the data entered correct? This action cannot be undone.", "Confirmation",
                MessageBoxButtons.OKCancel))
            {
                return;
            }

            btnCreate.Enabled = false;
            btnDelete.Enabled = false;
            btnCalculate.Enabled = false;

            if (CheckHyperstaticity() == true)
            {
                return;
            }
            Calculation.CalculateSupportMoment();
            foreach (Control support in drawingPanel.Controls)
            {
                if (support.Tag == "support")
                {
                    drawingPanel.Controls.Remove(support);
                }
            }
            foreach (var point in Form1.pointList)
            {
                if (point.supportForces.Count >= 1)
                {
                    foreach (var supportForce in point.supportForces)
                    {
                        point.pointForces.Add(new PointForce(supportForce.Intensity, supportForce.Angle, supportForce.Direction, supportForce.Orientation));
                    }
                    DeleteSupport(point);
                }
            }
            Calculations.CalculateBarForces.CalculateBarForce();
            DrawBars();
            DrawForces();
        }

        private bool CheckHyperstaticity()
        {
            int supportForceCount = 0, unknownCount = 0;
            foreach (Point analyzedPoint in Form1.pointList)
            {
                unknownCount++;
                if (analyzedPoint.supportForces.Count == 2)
                    supportForceCount += 2;
                else if (analyzedPoint.supportForces.Count == 1)
                    supportForceCount += 1;
            }

            unknownCount = (unknownCount * 2) - 3;
            if (supportForceCount < 3 || barList.Count > unknownCount)
            {
                MessageBox.Show("Hyperstatic Truss - Cannot calculate");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Delete Force
        public void deleteForce_Click(object sender, EventArgs e, ArrowPoint arrowPoint)
        {
            arrowList.Clear();
            DrawBars();
            DrawForces();
            ArrowPoint arrow = arrowList.Find(p => (p.FinalXValue == arrowPoint.FinalXValue
                                            && p.FinalYValue == arrowPoint.FinalYValue
                                            && p.InitialXValue == arrowPoint.InitialXValue
                                            && p.InitialYValue == arrowPoint.InitialYValue));
            arrowList.Remove(arrow);
            if (arrow != null)
            {
                var forcePoint = pointList.Find(f => (f.xValue == arrow.InitialXValue && f.yValue == arrow.InitialYValue) || (f.xValue == arrow.FinalXValue && f.yValue == arrow.FinalYValue));
                forcePoint.pointForces.Remove(arrow.PointForce);
            }
            foreach (Control control in deleteForceList)
            {
                drawingPanel.Controls.Remove(control);
            }
            arrowList.Clear();
            DrawBars();
            DrawForces();
        }

        public void CreateDeleteForce(ArrowPoint arrowPoint)
        {
            PictureBox deleteImage = new PictureBox();
            deleteImage.Image = Resources.iconeDelete;
            deleteImage.Name = "deleteIcon";
            deleteImage.SizeMode = PictureBoxSizeMode.StretchImage;
            deleteImage.Height = 20;
            deleteImage.Width = 20;
            deleteImage.Location = new System.Drawing.Point((arrowPoint.FinalXValue + arrowPoint.InitialXValue) / 2, (arrowPoint.InitialYValue + arrowPoint.FinalYValue) / 2);
            deleteImage.Visible = true;
            deleteImage.Click += new EventHandler((sender, e) => deleteForce_Click(sender, e, arrowPoint));
            deleteForceList.Add(deleteImage);
            drawingPanel.Controls.Add(deleteImage);
        }

        public void DeleteForceEvent()
        {
            deleteForceList.RemoveAll(pcb => pcb.Name == "deleteIcon");
            foreach (var arrowPoint in arrowList)
            {
                CreateDeleteForce(arrowPoint);
            }
        }
        #endregion

        #region Delete Bar
        public void WantsToDelete(Point point)
        {
            deleteList.Add(point);

            if (deleteList.Count == 2)
            {
                foreach (PictureBox image in pictureBoxList)
                {
                    image.Enabled = false;
                    image.Visible = false;
                }

                if (barList.Find(x => x.initialPointX == deleteList[0].xValue &
                 x.initialPointY == deleteList[0].yValue & x.finalPointX == deleteList[1].xValue &
                 x.finalPointY == deleteList[1].yValue) != null)
                {
                    Bar barToDelete = barList.Find(x => x.initialPointX == deleteList[0].xValue &
                    x.initialPointY == deleteList[0].yValue & x.finalPointX == deleteList[1].xValue &
                    x.finalPointY == deleteList[1].yValue);

                    barList.Remove(barToDelete);

                    foreach (Point foundPoint in pointList)
                    {
                        if (foundPoint.pointBars.Find(x => x == barToDelete) != null)
                            foundPoint.pointBars.Remove(barToDelete);
                    }

                    foreach (Point imagePoint in pointList)
                    {
                        if (imagePoint.pointBars.Count == 0)
                        {
                            PictureBox pictureBoxRemove = pictureBoxList.Find(x => x.Name == "Point" +
                            imagePoint.xValue.ToString() + imagePoint.yValue.ToString());
                            drawingPanel.Controls.Remove(pictureBoxRemove);
                            pictureBoxList.Remove(pictureBoxRemove);
                        }
                    }

                    pointList.RemoveAll(x => x.pointBars.Count == 0);
                }
                else if (barList.Find(x => x.initialPointX == deleteList[1].xValue &
                 x.initialPointY == deleteList[1].yValue & x.finalPointX == deleteList[0].xValue &
                 x.finalPointY == deleteList[0].yValue) != null)
                {
                    Bar barToDelete = barList.Find(x => x.initialPointX == deleteList[1].xValue &
                    x.initialPointY == deleteList[1].yValue & x.finalPointX == deleteList[0].xValue &
                    x.finalPointY == deleteList[0].yValue);

                    barList.Remove(barToDelete);

                    foreach (Point foundPoint in pointList)
                    {
                        if (foundPoint.pointBars.Find(x => x == barToDelete) != null)
                            foundPoint.pointBars.Remove(barToDelete);
                    }

                    foreach (Point imagePoint in pointList)
                    {
                        if (imagePoint.pointBars.Count == 0)
                        {
                            PictureBox pictureBoxRemove = pictureBoxList.Find(x => x.Name == "Point" +
                            imagePoint.xValue.ToString() + imagePoint.yValue.ToString());
                            drawingPanel.Controls.Remove(pictureBoxRemove);
                            pictureBoxList.Remove(pictureBoxRemove);
                        }
                    }

                    pointList.RemoveAll(x => x.pointBars.Count == 0);
                }
                else if (deleteList[0] == deleteList[1])
                {
                    MessageBox.Show("You selected the same point twice");
                }
                else
                {
                    MessageBox.Show("The selected points do not match any existing bar");
                }

                deleteList.RemoveAt(1);
                deleteList.RemoveAt(0);
                lbDelete.Visible = false;
                wantsToDelete = false;
            }

            if (pointList.Count == 0)
            {
                AddFirstPoint();
            }
        }

        public void DeleteBarEvent()
        {
            if (barList.Count == 0)
            {
                MessageBox.Show("There are no bars to delete");
                return;
            }

            lbMessage.Visible = false;
            lbDelete.Visible = true;
            foreach (PictureBox image in pictureBoxList)
            {
                image.Enabled = true;
                image.Visible = true;
            }
            wantsToDelete = true;
        }
        #endregion

        #region Drawing: Force, Bar, Support and Found Values
        public void DrawForces()
        {
            Graphics g = drawingPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            Pen p = new Pen(Color.Red, 3.0f);
            p.CustomStartCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, false);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            foreach (Point point in pointList)
            {
                foreach (var force in point.pointForces)
                {
                    GetXPointValue(force);
                    double forceAngle = SwapDrawingAngle(force);
                    var xPointValue = point.xValue + Convert.ToInt32(50 * Math.Cos(forceAngle * (Math.PI / 180)));
                    var yPointValue = point.yValue + Convert.ToInt32(50 * Math.Sin(-forceAngle * (Math.PI / 180)));
                    if (force.Orientation == "Pointing outward")
                    {
                        g.DrawLine(p, xPointValue, yPointValue, point.xValue, point.yValue);
                        arrowList.Add(new ArrowPoint(xPointValue, yPointValue, point.xValue, point.yValue, force.Orientation, force));
                        AddForceIntensity(point, xPointValue, yPointValue, force);
                    }
                    else
                    {
                        g.DrawLine(p, point.xValue, point.yValue, xPointValue, yPointValue);
                        arrowList.Add(new ArrowPoint(point.xValue, point.yValue, xPointValue, yPointValue, force.Orientation, force));
                        AddForceIntensity(point, xPointValue, yPointValue, force);
                    }
                }
            }

            g.Dispose();
            p.Dispose();
        }

        public double SwapDrawingAngle(PointForce force)
        {
            if (force.Angle > 90)
                return force.Angle;
            else if (force.Quadrant == 2)
                return force.Angle + 180;
            else if (force.Quadrant == 3)
                return force.Angle + 180;
            else if (force.Quadrant == 4)
                return force.Angle + 270;
            else return force.Angle;
        }

        public int GetXPointValue(PointForce force)
        {
            if (force.Quadrant == 3)
                return Convert.ToInt32(75 * Math.Cos((force.Angle) * (Math.PI / 180)));
            else
                return 1;
        }

        public void DrawBars()
        {
            Font newFont = new Font("Segoe", 12);
            Graphics g = drawingPanel.CreateGraphics();
            Pen myPen = new Pen(Color.Gray, 4);
            Pen myPen2 = new Pen(Color.LightSteelBlue, 4);
            Pen myPen3 = new Pen(Color.DarkSeaGreen, 4);
            g.Clear(drawingPanel.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            foreach (Bar bar in barList)
            {
                if (bar.Force.Intensity == 0)
                {
                    g.DrawLine(myPen, bar.initialPointX, bar.initialPointY, bar.finalPointX, bar.finalPointY);
                }
                else if (bar.Force.Orientation == "Pointing inward")
                {
                    g.DrawLine(myPen3, bar.initialPointX, bar.initialPointY, bar.finalPointX, bar.finalPointY);
                    AddIntensity(bar);
                }
                else if (bar.Force.Orientation == "Pointing outward")
                {
                    g.DrawLine(myPen2, bar.initialPointX, bar.initialPointY, bar.finalPointX, bar.finalPointY);
                    AddIntensity(bar);
                }
            }

            if (btnCalculate.Enabled == false)
            {
                System.Drawing.Point tensionPoint = new System.Drawing.Point(drawingPanel.Width - 320, drawingPanel.Height - 75);
                System.Drawing.Point compressionPoint = new System.Drawing.Point(drawingPanel.Width - 320, drawingPanel.Height - 35);
                g.DrawLine(myPen2, drawingPanel.Width - 170, drawingPanel.Height - 60, drawingPanel.Width - 20, drawingPanel.Height - 60);
                g.DrawString("Tension", newFont, Brushes.Black, tensionPoint);
                g.DrawLine(myPen3, drawingPanel.Width - 170, drawingPanel.Height - 15, drawingPanel.Width - 20, drawingPanel.Height - 15);
                g.DrawString("Compression", newFont, Brushes.Black, compressionPoint);
            }

            foreach (var point in pointList)
            {
                int count = 0;
                if (point.supportForces.Count == 1 && count < 2)
                {
                    AddSupports(point, "mobile");
                    count++;
                }
                if (point.supportForces.Count == 2 && count < 2)
                {
                    AddSupports(point, "fixed");
                    count++;
                }
                if (count == 2)
                    break;
            }
            g.Dispose();
            myPen.Dispose();
            myPen2.Dispose();
            myPen3.Dispose();
        }

        private void AddIntensity(Bar bar)
        {
            System.Drawing.Point newPoint;
            Label lbIntensity = new Label();
            Font newFont = new Font("Segoe", 12);
            lbIntensity.Font = newFont;
            Graphics g = drawingPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (bar.angleDirection == "Ascending" && bar.initialPointX <= bar.finalPointX && bar.initialPointY >= bar.finalPointY)
            {
                newPoint = new System.Drawing.Point(bar.initialPointX + ((bar.finalPointX - bar.initialPointX) / 2)
                    - (lbIntensity.Width / 2), bar.finalPointY + ((bar.initialPointY - bar.finalPointY) / 2)
                    - (lbIntensity.Height / 2));
                g.DrawString(bar.Force.Intensity.ToString("0.00") + " KN", newFont, Brushes.Black, newPoint);
            }
            else if (bar.angleDirection == "Ascending" && bar.initialPointX >= bar.finalPointX && bar.initialPointY <= bar.finalPointY)
            {
                newPoint = new System.Drawing.Point(bar.finalPointX + ((bar.initialPointX - bar.finalPointX) / 2)
                    - (lbIntensity.Width / 2), bar.initialPointY + ((bar.finalPointY - bar.initialPointY) / 2)
                    - (lbIntensity.Height / 2));
                g.DrawString(bar.Force.Intensity.ToString("0.00") + " KN", newFont, Brushes.Black, newPoint);
            }
            else if (bar.angleDirection == "Descending" && bar.initialPointX <= bar.finalPointX && bar.initialPointY <= bar.finalPointY)
            {
                newPoint = new System.Drawing.Point(bar.initialPointX + ((bar.finalPointX - bar.initialPointX) / 2)
                    - (lbIntensity.Width / 2), bar.initialPointY + ((bar.finalPointY - bar.initialPointY) / 2)
                    - (lbIntensity.Height / 2));
                g.DrawString(bar.Force.Intensity.ToString("0.00") + " KN", newFont, Brushes.Black, newPoint);
            }
            else if (bar.angleDirection == "Descending" && bar.initialPointX >= bar.finalPointX && bar.initialPointY >= bar.finalPointY)
            {
                newPoint = new System.Drawing.Point(bar.finalPointX + ((bar.initialPointX - bar.finalPointX) / 2)
                    - (lbIntensity.Width / 2), bar.finalPointY + ((bar.initialPointY - bar.finalPointY) / 2)
                    - (lbIntensity.Height / 2));
                g.DrawString(bar.Force.Intensity.ToString("0.00") + " KN", newFont, Brushes.Black, newPoint);
            }
            g.Dispose();
        }

        private void AddForceIntensity(Point point, int xPointValue, int yPointValue, Force force)
        {
            System.Drawing.Point newPoint;
            Label lbIntensity = new Label();
            Font newFont = new Font("Segoe", 12);
            lbIntensity.Font = newFont;
            Graphics g = drawingPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            newPoint = new System.Drawing.Point(xPointValue + 15, yPointValue);
            g.DrawString(force.Intensity.ToString("0") + " KN", newFont, Brushes.Black, newPoint);
            g.Dispose();
        }
        #endregion

        #region Delete Support
        public void DeleteSupportEvent()
        {
            foreach (Control support in drawingPanel.Controls)
            {
                if (support.Tag == "support")
                {
                    Point point = pointList.Find(p => (p.xValue - 50) == support.Location.X && (p.yValue + 6) == support.Location.Y);
                    support.Click += new EventHandler((sender, e) => deleteSupport_Click(sender, e, point));
                }
            }
        }

        public void deleteSupport_Click(object sender, EventArgs e, Point point)
        {
            DeleteSupport(point);
            pictureBoxList.Clear();
            foreach (Point imagePoint in pointList)
            {
                CreatePointImage(imagePoint);
            }
            DrawBars();
            DrawForces();
        }

        public void DeleteSupport(Point point)
        {
            if (point.supportForces[0].isFixedSupport)
            {
                AddSupport.HasFixed = false;
                point.supportForces.Clear();
            }
            else
            {
                AddSupport.HasMobile = false;
                point.supportForces.Clear();
            }

            foreach (Control control in drawingPanel.Controls)
            {
                if (control.Tag == "support")
                    drawingPanel.Controls.Remove(control);
            }
            drawingPanel.Controls.Clear();
        }
        #endregion

        #region Toolbar
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculation.sumCounterClockwise = 0;
            Calculation.sumClockwise = 0;
            CalculateBarForces.sumVerticalForces = 0;
            CalculateBarForces.sumHorizontalForces = 0;
            drawingPanel.Refresh();
            barList.Clear();
            pointList.Clear();
            arrowList.Clear();
            pictureBoxList.Clear();
            deleteList.Clear();
            deleteForceList.Clear();
            drawingScale = 1;
            btnCreate.Enabled = true;
            btnDelete.Enabled = true;
            btnCalculate.Enabled = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.About f = new Forms.About();
            f.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.HelpMainForm f = new Forms.HelpMainForm();
            f.ShowDialog();
        }
        #endregion

        private void Form1_Resize(object sender, EventArgs e)
        {
            DrawBars();
            DrawForces();
        }
    }
}