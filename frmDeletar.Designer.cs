namespace Software_Trelisa
{
    partial class frmDeletar
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDeletaBarra = new System.Windows.Forms.Button();
            this.btnDeletaForça = new System.Windows.Forms.Button();
            this.btnDeletaApoio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeletaBarra
            // 
            this.btnDeletaBarra.Location = new System.Drawing.Point(12, 19);
            this.btnDeletaBarra.Name = "btnDeletaBarra";
            this.btnDeletaBarra.Size = new System.Drawing.Size(115, 47);
            this.btnDeletaBarra.TabIndex = 0;
            this.btnDeletaBarra.Text = "Delatar Barra";
            this.btnDeletaBarra.UseVisualStyleBackColor = true;
            this.btnDeletaBarra.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeletaForça
            // 
            this.btnDeletaForça.Location = new System.Drawing.Point(150, 19);
            this.btnDeletaForça.Name = "btnDeletaForça";
            this.btnDeletaForça.Size = new System.Drawing.Size(107, 47);
            this.btnDeletaForça.TabIndex = 1;
            this.btnDeletaForça.Text = "Deletar Força";
            this.btnDeletaForça.UseVisualStyleBackColor = true;
            this.btnDeletaForça.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDeletaApoio
            // 
            this.btnDeletaApoio.Location = new System.Drawing.Point(285, 19);
            this.btnDeletaApoio.Name = "btnDeletaApoio";
            this.btnDeletaApoio.Size = new System.Drawing.Size(97, 47);
            this.btnDeletaApoio.TabIndex = 2;
            this.btnDeletaApoio.Text = "Deletar Apoio";
            this.btnDeletaApoio.UseVisualStyleBackColor = true;
            this.btnDeletaApoio.Click += new System.EventHandler(this.btnDeletaApoio_Click);
            // 
            // frmDeleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 78);
            this.Controls.Add(this.btnDeletaApoio);
            this.Controls.Add(this.btnDeletaForça);
            this.Controls.Add(this.btnDeletaBarra);
            this.Name = "frmDeleta";
            this.Text = "frmDeleta";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnDeletaBarra;
        private Button btnDeletaForça;
        private Button btnDeletaApoio;
    }
}