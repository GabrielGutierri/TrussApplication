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
            this.pbFixo = new System.Windows.Forms.PictureBox();
            this.pbMovel = new System.Windows.Forms.PictureBox();
            this.gbTipoApoio = new System.Windows.Forms.GroupBox();
            this.rbFixo = new System.Windows.Forms.RadioButton();
            this.rbMovel = new System.Windows.Forms.RadioButton();
            this.btnCriarApoio = new System.Windows.Forms.Button();
            this.gbApoio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFixo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMovel)).BeginInit();
            this.gbTipoApoio.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbApoio
            // 
            this.gbApoio.Controls.Add(this.pbFixo);
            this.gbApoio.Controls.Add(this.pbMovel);
            this.gbApoio.Controls.Add(this.gbTipoApoio);
            this.gbApoio.Controls.Add(this.btnCriarApoio);
            this.gbApoio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbApoio.Location = new System.Drawing.Point(12, 11);
            this.gbApoio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbApoio.Name = "gbApoio";
            this.gbApoio.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbApoio.Size = new System.Drawing.Size(374, 226);
            this.gbApoio.TabIndex = 22;
            this.gbApoio.TabStop = false;
            this.gbApoio.Text = "Adicionar Apoio";
            this.gbApoio.Enter += new System.EventHandler(this.gbForça_Enter);
            // 
            // pbFixo
            // 
            this.pbFixo.Image = ((System.Drawing.Image)(resources.GetObject("pbFixo.Image")));
            this.pbFixo.Location = new System.Drawing.Point(238, 41);
            this.pbFixo.Name = "pbFixo";
            this.pbFixo.Size = new System.Drawing.Size(111, 143);
            this.pbFixo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFixo.TabIndex = 25;
            this.pbFixo.TabStop = false;
            this.pbFixo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbMovel
            // 
            this.pbMovel.Image = ((System.Drawing.Image)(resources.GetObject("pbMovel.Image")));
            this.pbMovel.Location = new System.Drawing.Point(238, 41);
            this.pbMovel.Name = "pbMovel";
            this.pbMovel.Size = new System.Drawing.Size(111, 143);
            this.pbMovel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMovel.TabIndex = 26;
            this.pbMovel.TabStop = false;
            // 
            // gbTipoApoio
            // 
            this.gbTipoApoio.BackColor = System.Drawing.Color.LightGray;
            this.gbTipoApoio.Controls.Add(this.rbFixo);
            this.gbTipoApoio.Controls.Add(this.rbMovel);
            this.gbTipoApoio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTipoApoio.Location = new System.Drawing.Point(6, 29);
            this.gbTipoApoio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTipoApoio.Name = "gbTipoApoio";
            this.gbTipoApoio.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTipoApoio.Size = new System.Drawing.Size(213, 144);
            this.gbTipoApoio.TabIndex = 24;
            this.gbTipoApoio.TabStop = false;
            this.gbTipoApoio.Text = "Tipo de Apoio:";
            // 
            // rbFixo
            // 
            this.rbFixo.AutoSize = true;
            this.rbFixo.Checked = true;
            this.rbFixo.Location = new System.Drawing.Point(10, 55);
            this.rbFixo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbFixo.Name = "rbFixo";
            this.rbFixo.Size = new System.Drawing.Size(64, 29);
            this.rbFixo.TabIndex = 15;
            this.rbFixo.TabStop = true;
            this.rbFixo.Text = "Fixo";
            this.rbFixo.UseVisualStyleBackColor = true;
            this.rbFixo.CheckedChanged += new System.EventHandler(this.rbFixo_CheckedChanged);
            // 
            // rbMovel
            // 
            this.rbMovel.AutoSize = true;
            this.rbMovel.Location = new System.Drawing.Point(10, 98);
            this.rbMovel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbMovel.Name = "rbMovel";
            this.rbMovel.Size = new System.Drawing.Size(82, 29);
            this.rbMovel.TabIndex = 16;
            this.rbMovel.Text = "Móvel";
            this.rbMovel.UseVisualStyleBackColor = true;
            this.rbMovel.CheckedChanged += new System.EventHandler(this.rbMovel_CheckedChanged);
            // 
            // btnCriarApoio
            // 
            this.btnCriarApoio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCriarApoio.Location = new System.Drawing.Point(34, 177);
            this.btnCriarApoio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCriarApoio.Name = "btnCriarApoio";
            this.btnCriarApoio.Size = new System.Drawing.Size(140, 45);
            this.btnCriarApoio.TabIndex = 12;
            this.btnCriarApoio.Text = "Criar Apoio";
            this.btnCriarApoio.UseVisualStyleBackColor = true;
            this.btnCriarApoio.Click += new System.EventHandler(this.btnCriarApoio_Click);
            // 
            // AdicionaApoio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 252);
            this.Controls.Add(this.gbApoio);
            this.Name = "AdicionaApoio";
            this.Text = "AdicionaApoio";
            this.gbApoio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFixo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMovel)).EndInit();
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
        private PictureBox pbFixo;
        private PictureBox pbMovel;
    }
}

        