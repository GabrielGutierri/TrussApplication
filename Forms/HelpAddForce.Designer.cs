namespace TrussApplication.Forms
{
    partial class HelpAddForce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpAddForce));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            // ... (layout/size properties unchanged)
            this.groupBox1.Text = "INSTRUCTIONS";
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.Name = "HelpAddForce";
            this.Text = "Help";
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox1;
    }
}