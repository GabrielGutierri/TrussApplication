namespace Software_Trelisa
{
    partial class frmDeleta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.btnDeletaForca = new System.Windows.Forms.Button();
            this.btnDeletaApoio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeletaBarra
            // 
            this.btnDeletaBarra.Location = new System.Drawing.Point(12, 28);
            this.btnDeletaBarra.Name = "btnDeletaBarra";
            this.btnDeletaBarra.Size = new System.Drawing.Size(90, 46);
            this.btnDeletaBarra.TabIndex = 0;
            this.btnDeletaBarra.Text = "Deletar Barra";
            this.btnDeletaBarra.UseVisualStyleBackColor = true;
            this.btnDeletaBarra.Click += new System.EventHandler(this.btnDeletaBarra_Click);
            // 
            // btnDeletaForca
            // 
            this.btnDeletaForca.Location = new System.Drawing.Point(136, 28);
            this.btnDeletaForca.Name = "btnDeletaForca";
            this.btnDeletaForca.Size = new System.Drawing.Size(91, 46);
            this.btnDeletaForca.TabIndex = 1;
            this.btnDeletaForca.Text = "Deletar Força";
            this.btnDeletaForca.UseVisualStyleBackColor = true;
            this.btnDeletaForca.Click += new System.EventHandler(this.btnDeletaForca_Click);
            // 
            // btnDeletaApoio
            // 
            this.btnDeletaApoio.Location = new System.Drawing.Point(257, 28);
            this.btnDeletaApoio.Name = "btnDeletaApoio";
            this.btnDeletaApoio.Size = new System.Drawing.Size(91, 46);
            this.btnDeletaApoio.TabIndex = 2;
            this.btnDeletaApoio.Text = "Deletar Apoio";
            this.btnDeletaApoio.UseVisualStyleBackColor = true;
            // 
            // frmDeleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 96);
            this.Controls.Add(this.btnDeletaApoio);
            this.Controls.Add(this.btnDeletaForca);
            this.Controls.Add(this.btnDeletaBarra);
            this.Name = "frmDeleta";
            this.Text = "frmDeleta";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnDeletaBarra;
        private Button btnDeletaForca;
        private Button btnDeletaApoio;
    }
}