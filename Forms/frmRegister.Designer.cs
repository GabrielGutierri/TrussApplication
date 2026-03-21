namespace TrussApplication
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtRepeatPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            // ... (layout/size properties unchanged)
            this.label2.Text = "Password:";
            this.label1.Text = "Name";
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.label3.Text = "Repeat password:";
            this.label4.Text = "E-mail:";
            this.Name = "frmRegister";
            this.Text = "Register";
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtName;
        private Label label2;
        private Label label1;
        private Button btnRegister;
        private TextBox txtRepeatPassword;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
    }
}