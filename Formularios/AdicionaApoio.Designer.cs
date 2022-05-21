namespace Software_Trelisa
{
    partial class AdicionaApoio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionaApoio));
            this.gbApoio = new System.Windows.Forms.GroupBox();
            this.gbTipoApoio = new System.Windows.Forms.GroupBox();
            this.rbFixo = new System.Windows.Forms.RadioButton();
            this.rbMovel = new System.Windows.Forms.RadioButton();
            this.btnCriarApoio = new System.Windows.Forms.Button();
            this.gbApoio.SuspendLayout();
            this.gbTipoApoio.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbApoio
            // 
            this.gbApoio.Controls.Add(this.gbTipoApoio);
            this.gbApoio.Controls.Add(this.btnCriarApoio);
            this.gbApoio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbApoio.Location = new System.Drawing.Point(14, 15);
            this.gbApoio.Name = "gbApoio";
            this.gbApoio.Size = new System.Drawing.Size(258, 301);
            this.gbApoio.TabIndex = 22;
            this.gbApoio.TabStop = false;
            this.gbApoio.Text = "Adicionar Apoio";
            this.gbApoio.Enter += new System.EventHandler(this.gbForça_Enter);
            // 
            // gbTipoApoio
            // 
            this.gbTipoApoio.BackColor = System.Drawing.Color.LightGray;
            this.gbTipoApoio.Controls.Add(this.rbFixo);
            this.gbTipoApoio.Controls.Add(this.rbMovel);
            this.gbTipoApoio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTipoApoio.Location = new System.Drawing.Point(7, 39);
            this.gbTipoApoio.Name = "gbTipoApoio";
            this.gbTipoApoio.Size = new System.Drawing.Size(243, 192);
            this.gbTipoApoio.TabIndex = 24;
            this.gbTipoApoio.TabStop = false;
            this.gbTipoApoio.Text = "Tipo de Apoio:";
            // 
            // rbFixo
            // 
            this.rbFixo.AutoSize = true;
            this.rbFixo.Checked = true;
            this.rbFixo.Location = new System.Drawing.Point(11, 73);
            this.rbFixo.Name = "rbFixo";
            this.rbFixo.Size = new System.Drawing.Size(78, 36);
            this.rbFixo.TabIndex = 15;
            this.rbFixo.TabStop = true;
            this.rbFixo.Text = "Fixo";
            this.rbFixo.UseVisualStyleBackColor = true;
            this.rbFixo.CheckedChanged += new System.EventHandler(this.rbFixo_CheckedChanged);
            // 
            // rbMovel
            // 
            this.rbMovel.AutoSize = true;
            this.rbMovel.Location = new System.Drawing.Point(11, 131);
            this.rbMovel.Name = "rbMovel";
            this.rbMovel.Size = new System.Drawing.Size(102, 36);
            this.rbMovel.TabIndex = 16;
            this.rbMovel.Text = "Móvel";
            this.rbMovel.UseVisualStyleBackColor = true;
            this.rbMovel.CheckedChanged += new System.EventHandler(this.rbMovel_CheckedChanged);
            // 
            // btnCriarApoio
            // 
            this.btnCriarApoio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCriarApoio.Location = new System.Drawing.Point(58, 248);
            this.btnCriarApoio.Name = "btnCriarApoio";
            this.btnCriarApoio.Size = new System.Drawing.Size(142, 47);
            this.btnCriarApoio.TabIndex = 12;
            this.btnCriarApoio.Text = "Criar Apoio";
            this.btnCriarApoio.UseVisualStyleBackColor = true;
            this.btnCriarApoio.Click += new System.EventHandler(this.btnCriarApoio_Click);
            // 
            // AdicionaApoio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 336);
            this.Controls.Add(this.gbApoio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdicionaApoio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdicionaApoio";
            this.gbApoio.ResumeLayout(false);
            this.gbTipoApoio.ResumeLayout(false);
            this.gbTipoApoio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbApoio;
        private Button btnCriarApoio;
        private GroupBox gbTipoApoio;
        private RadioButton rbFixo;
        private RadioButton rbMovel;
    }
}

        