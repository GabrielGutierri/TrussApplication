namespace TrussApplication
{
    partial class frmAddForce
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddForce));
            this.gbForce = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbQuadrant = new System.Windows.Forms.ComboBox();
            this.cbOrientationType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIntensity = new System.Windows.Forms.TextBox();
            this.btnCreateForce = new System.Windows.Forms.Button();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.rbVerticalForce = new System.Windows.Forms.RadioButton();
            this.rbHorizontalForce = new System.Windows.Forms.RadioButton();
            this.rbInclinedForce = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            // ... (layout/size properties unchanged)
            this.gbForce.Text = "Add Force";
            this.label5.Text = "Force Quadrant:";
            this.cbQuadrant.Items.AddRange(new object[] { "1", "2", "3", "4" });
            this.cbOrientationType.Items.AddRange(new object[] { "Pointing outward", "Pointing inward" });
            this.label3.Text = "Force Orientation:";
            this.btnCreateForce.Text = "Create Force";
            this.btnCreateForce.Click += new System.EventHandler(this.btnCreateForce_Click);
            this.label1.Text = "Angle:";
            this.label2.Text = "Intensity:";
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            this.rbVerticalForce.Text = "Vertical Force";
            this.rbVerticalForce.CheckedChanged += new System.EventHandler(this.rbVerticalForce_CheckedChanged);
            this.rbHorizontalForce.Text = "Horizontal Force";
            this.rbHorizontalForce.CheckedChanged += new System.EventHandler(this.rbHorizontalForce_CheckedChanged);
            this.rbInclinedForce.Text = "Inclined Force";
            this.rbInclinedForce.Checked = true;
            this.rbInclinedForce.CheckedChanged += new System.EventHandler(this.rbInclinedForce_CheckedChanged);
            this.groupBox3.Text = "Force Type:";
            this.Name = "frmAddForce";
            this.Text = "Add Force";
        }

        #endregion

        private GroupBox gbForce;
        private ComboBox cbOrientationType;
        private Label label3;
        private TextBox txtIntensity;
        private Button btnCreateForce;
        private TextBox txtAngle;
        private Label label1;
        private Label label2;
        private Button btnHelp;
        private RadioButton rbVerticalForce;
        private RadioButton rbHorizontalForce;
        private RadioButton rbInclinedForce;
        private GroupBox groupBox3;
        private Label label5;
        private ComboBox cbQuadrant;
        private Label label7;
        private Label label6;
    }
}