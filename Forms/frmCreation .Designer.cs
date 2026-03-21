namespace TrussApplication
{
    partial class frmCreation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreation));
            this.btnAddBar = new System.Windows.Forms.Button();
            this.btnAddForce = new System.Windows.Forms.Button();
            this.btnAddSupport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.btnAddBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddBar.Location = new System.Drawing.Point(12, 13);
            this.btnAddBar.Name = "btnAddBar";
            this.btnAddBar.Size = new System.Drawing.Size(174, 64);
            this.btnAddBar.TabIndex = 0;
            this.btnAddBar.Text = "Add Bar";
            this.btnAddBar.UseVisualStyleBackColor = true;
            this.btnAddBar.Click += new System.EventHandler(this.btnAddBar_Click);
            this.btnAddForce.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddForce.Location = new System.Drawing.Point(192, 13);
            this.btnAddForce.Name = "btnAddForce";
            this.btnAddForce.Size = new System.Drawing.Size(174, 64);
            this.btnAddForce.TabIndex = 1;
            this.btnAddForce.Text = "Add Force";
            this.btnAddForce.UseVisualStyleBackColor = true;
            this.btnAddForce.Click += new System.EventHandler(this.btnAddForce_Click);
            this.btnAddSupport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddSupport.Location = new System.Drawing.Point(372, 13);
            this.btnAddSupport.Name = "btnAddSupport";
            this.btnAddSupport.Size = new System.Drawing.Size(174, 64);
            this.btnAddSupport.TabIndex = 2;
            this.btnAddSupport.Text = "Add Support";
            this.btnAddSupport.UseVisualStyleBackColor = true;
            this.btnAddSupport.Click += new System.EventHandler(this.btnAddSupport_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 89);
            this.Controls.Add(this.btnAddSupport);
            this.Controls.Add(this.btnAddForce);
            this.Controls.Add(this.btnAddBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create";
            this.ResumeLayout(false);
        }

        #endregion

        private Button btnAddBar;
        private Button btnAddForce;
        private Button btnAddSupport;
    }
}