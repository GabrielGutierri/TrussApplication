namespace TrussApplication
{
    partial class AddSupport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupport));
            this.gbSupport = new System.Windows.Forms.GroupBox();
            this.gbSupportType = new System.Windows.Forms.GroupBox();
            this.rbFixed = new System.Windows.Forms.RadioButton();
            this.rbMobile = new System.Windows.Forms.RadioButton();
            this.btnCreateSupport = new System.Windows.Forms.Button();
            this.gbSupport.SuspendLayout();
            this.gbSupportType.SuspendLayout();
            this.SuspendLayout();
            this.gbSupport.Controls.Add(this.gbSupportType);
            this.gbSupport.Controls.Add(this.btnCreateSupport);
            this.gbSupport.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbSupport.Location = new System.Drawing.Point(14, 15);
            this.gbSupport.Name = "gbSupport";
            this.gbSupport.Size = new System.Drawing.Size(258, 301);
            this.gbSupport.TabIndex = 22;
            this.gbSupport.TabStop = false;
            this.gbSupport.Text = "Add Support";
            this.gbSupport.Enter += new System.EventHandler(this.gbForce_Enter);
            this.gbSupportType.BackColor = System.Drawing.Color.LightGray;
            this.gbSupportType.Controls.Add(this.rbFixed);
            this.gbSupportType.Controls.Add(this.rbMobile);
            this.gbSupportType.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbSupportType.Location = new System.Drawing.Point(7, 39);
            this.gbSupportType.Name = "gbSupportType";
            this.gbSupportType.Size = new System.Drawing.Size(243, 192);
            this.gbSupportType.TabIndex = 24;
            this.gbSupportType.TabStop = false;
            this.gbSupportType.Text = "Support Type:";
            this.rbFixed.AutoSize = true;
            this.rbFixed.Checked = true;
            this.rbFixed.Location = new System.Drawing.Point(11, 73);
            this.rbFixed.Name = "rbFixed";
            this.rbFixed.Size = new System.Drawing.Size(78, 36);
            this.rbFixed.TabIndex = 15;
            this.rbFixed.TabStop = true;
            this.rbFixed.Text = "Fixed";
            this.rbFixed.UseVisualStyleBackColor = true;
            this.rbFixed.CheckedChanged += new System.EventHandler(this.rbFixed_CheckedChanged);
            this.rbMobile.AutoSize = true;
            this.rbMobile.Location = new System.Drawing.Point(11, 131);
            this.rbMobile.Name = "rbMobile";
            this.rbMobile.Size = new System.Drawing.Size(102, 36);
            this.rbMobile.TabIndex = 16;
            this.rbMobile.Text = "Mobile";
            this.rbMobile.UseVisualStyleBackColor = true;
            this.rbMobile.CheckedChanged += new System.EventHandler(this.rbMobile_CheckedChanged);
            this.btnCreateSupport.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateSupport.Location = new System.Drawing.Point(58, 248);
            this.btnCreateSupport.Name = "btnCreateSupport";
            this.btnCreateSupport.Size = new System.Drawing.Size(142, 47);
            this.btnCreateSupport.TabIndex = 12;
            this.btnCreateSupport.Text = "Create Support";
            this.btnCreateSupport.UseVisualStyleBackColor = true;
            this.btnCreateSupport.Click += new System.EventHandler(this.btnCreateSupport_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 336);
            this.Controls.Add(this.gbSupport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddSupport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Support";
            this.gbSupport.ResumeLayout(false);
            this.gbSupportType.ResumeLayout(false);
            this.gbSupportType.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private GroupBox gbSupport;
        private Button btnCreateSupport;
        private GroupBox gbSupportType;
        private RadioButton rbFixed;
        private RadioButton rbMobile;
    }
}