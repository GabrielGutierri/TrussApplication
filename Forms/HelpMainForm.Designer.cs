namespace TrussApplication.Forms
{
    partial class HelpMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpMainForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            // ... (layout/size properties unchanged)
            this.textBox1.Text = "- To create a bar from the selected starting point.\r\n- To create a force acting on the selected point.\r\n- To create a support acting on the selected point.";
            this.textBox2.Text = "- To delete a bar by clicking on the two points that form it.\r\n- To delete a force by clicking the X of that specific force.\r\n- To delete a support by clicking on the specific support.";
            this.textBox3.Text = resources.GetString("textBox3.Text");
            this.groupBox1.Text = "INSTRUCTIONS";
            this.groupBox2.Text = "CLICK CREATE:";
            this.groupBox4.Text = "CLICK CALCULATE:";
            this.groupBox3.Text = "CLICK DELETE:";
            this.Name = "HelpMainForm";
            this.Text = "Help";
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
    }
}