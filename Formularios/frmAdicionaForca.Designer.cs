namespace Software_Trelisa
{
    partial class frmAdicionaForca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdicionaForca));
            this.gbForça = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbQuadrante = new System.Windows.Forms.ComboBox();
            this.cbTipoSentido = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIntensidade = new System.Windows.Forms.TextBox();
            this.btnCriarBarraInclinado = new System.Windows.Forms.Button();
            this.txtAngulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.rbForcaVertical = new System.Windows.Forms.RadioButton();
            this.rbForcaHorizontal = new System.Windows.Forms.RadioButton();
            this.rbForcaInclinada = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbForça.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbForça
            // 
            this.gbForça.Controls.Add(this.label7);
            this.gbForça.Controls.Add(this.label6);
            this.gbForça.Controls.Add(this.label5);
            this.gbForça.Controls.Add(this.cbQuadrante);
            this.gbForça.Controls.Add(this.cbTipoSentido);
            this.gbForça.Controls.Add(this.label3);
            this.gbForça.Controls.Add(this.txtIntensidade);
            this.gbForça.Controls.Add(this.btnCriarBarraInclinado);
            this.gbForça.Controls.Add(this.txtAngulo);
            this.gbForça.Controls.Add(this.label1);
            this.gbForça.Controls.Add(this.label2);
            this.gbForça.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbForça.Location = new System.Drawing.Point(11, 16);
            this.gbForça.Name = "gbForça";
            this.gbForça.Size = new System.Drawing.Size(413, 539);
            this.gbForça.TabIndex = 21;
            this.gbForça.TabStop = false;
            this.gbForça.Text = "Adicionar Força";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(149, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 32);
            this.label7.TabIndex = 27;
            this.label7.Text = "KN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(145, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 46);
            this.label6.TabIndex = 26;
            this.label6.Text = "°";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(29, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 32);
            this.label5.TabIndex = 25;
            this.label5.Text = "Quadrante da Força :";
            // 
            // cbQuadrante
            // 
            this.cbQuadrante.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbQuadrante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuadrante.FormattingEnabled = true;
            this.cbQuadrante.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbQuadrante.Location = new System.Drawing.Point(29, 397);
            this.cbQuadrante.Name = "cbQuadrante";
            this.cbQuadrante.Size = new System.Drawing.Size(321, 39);
            this.cbQuadrante.TabIndex = 24;
            // 
            // cbTipoSentido
            // 
            this.cbTipoSentido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoSentido.FormattingEnabled = true;
            this.cbTipoSentido.Items.AddRange(new object[] {
            "Apontada para fora",
            "Apontada para dentro"});
            this.cbTipoSentido.Location = new System.Drawing.Point(29, 281);
            this.cbTipoSentido.Name = "cbTipoSentido";
            this.cbTipoSentido.Size = new System.Drawing.Size(321, 39);
            this.cbTipoSentido.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(29, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 32);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sentido da Força :";
            // 
            // txtIntensidade
            // 
            this.txtIntensidade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIntensidade.Location = new System.Drawing.Point(29, 183);
            this.txtIntensidade.Name = "txtIntensidade";
            this.txtIntensidade.Size = new System.Drawing.Size(114, 34);
            this.txtIntensidade.TabIndex = 5;
            // 
            // btnCriarBarraInclinado
            // 
            this.btnCriarBarraInclinado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCriarBarraInclinado.Location = new System.Drawing.Point(129, 472);
            this.btnCriarBarraInclinado.Name = "btnCriarBarraInclinado";
            this.btnCriarBarraInclinado.Size = new System.Drawing.Size(136, 44);
            this.btnCriarBarraInclinado.TabIndex = 12;
            this.btnCriarBarraInclinado.Text = "Criar Força";
            this.btnCriarBarraInclinado.UseVisualStyleBackColor = true;
            this.btnCriarBarraInclinado.Click += new System.EventHandler(this.btnCriarBarraInclinado_Click);
            // 
            // txtAngulo
            // 
            this.txtAngulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAngulo.Location = new System.Drawing.Point(29, 96);
            this.txtAngulo.Name = "txtAngulo";
            this.txtAngulo.Size = new System.Drawing.Size(114, 34);
            this.txtAngulo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ângulo  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Intensidade :";
            // 
            // btnAjuda
            // 
            this.btnAjuda.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAjuda.Location = new System.Drawing.Point(591, 515);
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Size = new System.Drawing.Size(103, 40);
            this.btnAjuda.TabIndex = 25;
            this.btnAjuda.Text = "Ajuda";
            this.btnAjuda.UseVisualStyleBackColor = true;
            this.btnAjuda.Click += new System.EventHandler(this.btnAjuda_Click);
            // 
            // rbForcaVertical
            // 
            this.rbForcaVertical.AutoSize = true;
            this.rbForcaVertical.Location = new System.Drawing.Point(11, 132);
            this.rbForcaVertical.Name = "rbForcaVertical";
            this.rbForcaVertical.Size = new System.Drawing.Size(173, 36);
            this.rbForcaVertical.TabIndex = 16;
            this.rbForcaVertical.Text = "Força Vertical";
            this.rbForcaVertical.UseVisualStyleBackColor = true;
            this.rbForcaVertical.CheckedChanged += new System.EventHandler(this.rbForcaVertical_CheckedChanged);
            // 
            // rbForcaHorizontal
            // 
            this.rbForcaHorizontal.AutoSize = true;
            this.rbForcaHorizontal.Location = new System.Drawing.Point(11, 193);
            this.rbForcaHorizontal.Name = "rbForcaHorizontal";
            this.rbForcaHorizontal.Size = new System.Drawing.Size(206, 36);
            this.rbForcaHorizontal.TabIndex = 17;
            this.rbForcaHorizontal.Text = "Força Horizontal";
            this.rbForcaHorizontal.UseVisualStyleBackColor = true;
            this.rbForcaHorizontal.CheckedChanged += new System.EventHandler(this.rbForcaHorizontal_CheckedChanged);
            // 
            // rbForcaInclinada
            // 
            this.rbForcaInclinada.AutoSize = true;
            this.rbForcaInclinada.Checked = true;
            this.rbForcaInclinada.Location = new System.Drawing.Point(11, 75);
            this.rbForcaInclinada.Name = "rbForcaInclinada";
            this.rbForcaInclinada.Size = new System.Drawing.Size(191, 36);
            this.rbForcaInclinada.TabIndex = 15;
            this.rbForcaInclinada.TabStop = true;
            this.rbForcaInclinada.Text = "Força Inclinada";
            this.rbForcaInclinada.UseVisualStyleBackColor = true;
            this.rbForcaInclinada.CheckedChanged += new System.EventHandler(this.rbForcaInclinada_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightGray;
            this.groupBox3.Controls.Add(this.rbForcaInclinada);
            this.groupBox3.Controls.Add(this.rbForcaHorizontal);
            this.groupBox3.Controls.Add(this.rbForcaVertical);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(448, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 249);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de Força:";
            // 
            // frmAdicionaForca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 567);
            this.Controls.Add(this.gbForça);
            this.Controls.Add(this.btnAjuda);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAdicionaForca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adiciona Forca";
            this.gbForça.ResumeLayout(false);
            this.gbForça.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbForça;
        private ComboBox cbTipoSentido;
        private Label label3;
        private TextBox txtIntensidade;
        private Button btnCriarBarraInclinado;
        private TextBox txtAngulo;
        private Label label1;
        private Label label2;
        private Button btnAjuda;
        private RadioButton rbForcaVertical;
        private RadioButton rbForcaHorizontal;
        private RadioButton rbForcaInclinada;
        private GroupBox groupBox3;
        private ComboBox cbQuadranteForca;
        private Label label4;
        private Label label5;
        private ComboBox cbQuadrante;
        private Label label7;
        private Label label6;
    }
}