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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCriacao));
            this.btnAdicionaBarra = new System.Windows.Forms.Button();
            this.btnAdicionaForca = new System.Windows.Forms.Button();
            this.btnAdicionaApoio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdicionaBarra
            // 
            this.btnAdicionaBarra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdicionaBarra.Location = new System.Drawing.Point(12, 13);
            this.btnAdicionaBarra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdicionaBarra.Name = "btnAdicionaBarra";
            this.btnAdicionaBarra.Size = new System.Drawing.Size(174, 64);
            this.btnAdicionaBarra.TabIndex = 0;
            this.btnAdicionaBarra.Text = "Adicionar Barra";
            this.btnAdicionaBarra.UseVisualStyleBackColor = true;
            this.btnAdicionaBarra.Click += new System.EventHandler(this.btnAdicionaBarra_Click);
            // 
            // btnAdicionaForca
            // 
            this.btnAdicionaForca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdicionaForca.Location = new System.Drawing.Point(192, 13);
            this.btnAdicionaForca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdicionaForca.Name = "btnAdicionaForca";
            this.btnAdicionaForca.Size = new System.Drawing.Size(174, 64);
            this.btnAdicionaForca.TabIndex = 1;
            this.btnAdicionaForca.Text = "Adicionar Força";
            this.btnAdicionaForca.UseVisualStyleBackColor = true;
            this.btnAdicionaForca.Click += new System.EventHandler(this.btnAdicionaForca_Click);
            // 
            // btnAdicionaApoio
            // 
            this.btnAdicionaApoio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdicionaApoio.Location = new System.Drawing.Point(372, 13);
            this.btnAdicionaApoio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdicionaApoio.Name = "btnAdicionaApoio";
            this.btnAdicionaApoio.Size = new System.Drawing.Size(174, 64);
            this.btnAdicionaApoio.TabIndex = 2;
            this.btnAdicionaApoio.Text = "Adicionar Apoio";
            this.btnAdicionaApoio.UseVisualStyleBackColor = true;
            this.btnAdicionaApoio.Click += new System.EventHandler(this.btnAdicionaApoio_Click);
            // 
            // frmCriacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 89);
            this.Controls.Add(this.btnAdicionaApoio);
            this.Controls.Add(this.btnAdicionaForca);
            this.Controls.Add(this.btnAdicionaBarra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCriacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criacao";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAdicionaBarra;
        private Button btnAdicionaForca;
        private Button btnAdicionaApoio;
    }
}