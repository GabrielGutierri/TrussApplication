namespace TrussApplication
{
    partial class frmDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDelete));
            this.btnDeleteBar = new System.Windows.Forms.Button();
            this.btnDeleteForce = new System.Windows.Forms.Button();
            this.btnDeleteSupport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.btnDeleteBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteBar.Location = new System.Drawing.Point(11, 13);
            this.btnDeleteBar.Name = "btnDeleteBar";
            this.btnDeleteBar.Size = new System.Drawing.Size(174, 64);
            this.btnDeleteBar.TabIndex = 0;
            this.btnDeleteBar.Text = "Delete Bar";
            this.btnDeleteBar.UseVisualStyleBackColor = true;
            this.btnDeleteBar.Click += new System.EventHandler(this.btnDeleteBar_Click);
            this.btnDeleteForce.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteForce.Location = new System.Drawing.Point(192, 13);
            this.btnDeleteForce.Name = "btnDeleteForce";
            this.btnDeleteForce.Size = new System.Drawing.Size(174, 64);
            this.btnDeleteForce.TabIndex = 1;
            this.btnDeleteForce.Text = "Delete Force";
            this.btnDeleteForce.UseVisualStyleBackColor = true;
            this.btnDeleteForce.Click += new System.EventHandler(this.btnDeleteForce_Click);
            this.btnDeleteSupport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteSupport.Location = new System.Drawing.Point(373, 13);
            this.btnDeleteSupport.Name = "btnDeleteSupport";
            this.btnDeleteSupport.Size = new System.Drawing.Size(174, 64);
            this.btnDeleteSupport.TabIndex = 2;
            this.btnDeleteSupport.Text = "Delete Support";
            this.btnDeleteSupport.UseVisualStyleBackColor = true;
            this.btnDeleteSupport.Click += new System.EventHandler(this.btnDeleteSupport_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 89);
            this.Controls.Add(this.btnDeleteSupport);
            this.Controls.Add(this.btnDeleteForce);
            this.Controls.Add(this.btnDeleteBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete";
            this.ResumeLayout(false);
        }

        #endregion

        private Button btnDeleteBar;
        private Button btnDeleteForce;
        private Button btnDeleteSupport;
    }
}