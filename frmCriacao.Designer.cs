namespace Software_Trelisa
{
    partial class frmCriacao
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
            this.btnAdicionaBarra = new System.Windows.Forms.Button();
            this.btnAdicionaForca = new System.Windows.Forms.Button();
            this.btnAdicionaApoio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdicionaBarra
            // 
            this.btnAdicionaBarra.Location = new System.Drawing.Point(4, 26);
            this.btnAdicionaBarra.Name = "btnAdicionaBarra";
            this.btnAdicionaBarra.Size = new System.Drawing.Size(114, 45);
            this.btnAdicionaBarra.TabIndex = 0;
            this.btnAdicionaBarra.Text = "Adicionar Barra";
            this.btnAdicionaBarra.UseVisualStyleBackColor = true;
            this.btnAdicionaBarra.Click += new System.EventHandler(this.btnAdicionaBarra_Click);
            // 
            // btnAdicionaForca
            // 
            this.btnAdicionaForca.Location = new System.Drawing.Point(124, 26);
            this.btnAdicionaForca.Name = "btnAdicionaForca";
            this.btnAdicionaForca.Size = new System.Drawing.Size(114, 45);
            this.btnAdicionaForca.TabIndex = 1;
            this.btnAdicionaForca.Text = "Adicionar Força";
            this.btnAdicionaForca.UseVisualStyleBackColor = true;
            this.btnAdicionaForca.Click += new System.EventHandler(this.btnAdicionaForca_Click);
            // 
            // btnAdicionaApoio
            // 
            this.btnAdicionaApoio.Location = new System.Drawing.Point(244, 26);
            this.btnAdicionaApoio.Name = "btnAdicionaApoio";
            this.btnAdicionaApoio.Size = new System.Drawing.Size(114, 45);
            this.btnAdicionaApoio.TabIndex = 2;
            this.btnAdicionaApoio.Text = "Adicionar Apoio";
            this.btnAdicionaApoio.UseVisualStyleBackColor = true;
            // 
            // frmCriacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 89);
            this.Controls.Add(this.btnAdicionaApoio);
            this.Controls.Add(this.btnAdicionaForca);
            this.Controls.Add(this.btnAdicionaBarra);
            this.Name = "frmCriacao";
            this.Text = "frmCriacao";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAdicionaBarra;
        private Button btnAdicionaForca;
        private Button btnAdicionaApoio;
    }
}