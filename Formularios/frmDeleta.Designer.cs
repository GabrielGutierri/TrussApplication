﻿namespace Software_Trelisa
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
            this.btnDeletaBarra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeletaBarra.Location = new System.Drawing.Point(10, 10);
            this.btnDeletaBarra.Name = "btnDeletaBarra";
            this.btnDeletaBarra.Size = new System.Drawing.Size(152, 48);
            this.btnDeletaBarra.TabIndex = 0;
            this.btnDeletaBarra.Text = "Deletar Barra";
            this.btnDeletaBarra.UseVisualStyleBackColor = true;
            this.btnDeletaBarra.Click += new System.EventHandler(this.btnDeletaBarra_Click);
            // 
            // btnDeletaForca
            // 
            this.btnDeletaForca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeletaForca.Location = new System.Drawing.Point(168, 10);
            this.btnDeletaForca.Name = "btnDeletaForca";
            this.btnDeletaForca.Size = new System.Drawing.Size(152, 48);
            this.btnDeletaForca.TabIndex = 1;
            this.btnDeletaForca.Text = "Deletar Força";
            this.btnDeletaForca.UseVisualStyleBackColor = true;
            this.btnDeletaForca.Click += new System.EventHandler(this.btnDeletaForca_Click);
            // 
            // btnDeletaApoio
            // 
            this.btnDeletaApoio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeletaApoio.Location = new System.Drawing.Point(326, 10);
            this.btnDeletaApoio.Name = "btnDeletaApoio";
            this.btnDeletaApoio.Size = new System.Drawing.Size(152, 48);
            this.btnDeletaApoio.TabIndex = 2;
            this.btnDeletaApoio.Text = "Deletar Apoio";
            this.btnDeletaApoio.UseVisualStyleBackColor = true;
            this.btnDeletaApoio.Click += new System.EventHandler(this.btnDeletaApoio_Click);
            // 
            // frmDeleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 67);
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