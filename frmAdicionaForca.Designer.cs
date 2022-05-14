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
            this.gbForça = new System.Windows.Forms.GroupBox();
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
            this.cbQuadrante = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbForça.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbForça
            // 
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
            this.gbForça.Location = new System.Drawing.Point(12, -13);
            this.gbForça.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbForça.Name = "gbForça";
            this.gbForça.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbForça.Size = new System.Drawing.Size(361, 404);
            this.gbForça.TabIndex = 21;
            this.gbForça.TabStop = false;
            this.gbForça.Text = "Adicionar Força";
            // 
            // cbTipoSentido
            // 
            this.cbTipoSentido.FormattingEnabled = true;
            this.cbTipoSentido.Items.AddRange(new object[] {
            "Apontada para fora",
            "Apontada para dentro"});
            this.cbTipoSentido.Location = new System.Drawing.Point(25, 211);
            this.cbTipoSentido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipoSentido.Name = "cbTipoSentido";
            this.cbTipoSentido.Size = new System.Drawing.Size(281, 33);
            this.cbTipoSentido.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(25, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sentido da Força :";
            // 
            // txtIntensidade
            // 
            this.txtIntensidade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIntensidade.Location = new System.Drawing.Point(25, 137);
            this.txtIntensidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIntensidade.Name = "txtIntensidade";
            this.txtIntensidade.Size = new System.Drawing.Size(182, 29);
            this.txtIntensidade.TabIndex = 5;
            // 
            // btnCriarBarraInclinado
            // 
            this.btnCriarBarraInclinado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCriarBarraInclinado.Location = new System.Drawing.Point(25, 356);
            this.btnCriarBarraInclinado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCriarBarraInclinado.Name = "btnCriarBarraInclinado";
            this.btnCriarBarraInclinado.Size = new System.Drawing.Size(119, 33);
            this.btnCriarBarraInclinado.TabIndex = 12;
            this.btnCriarBarraInclinado.Text = "Criar Força";
            this.btnCriarBarraInclinado.UseVisualStyleBackColor = true;
            this.btnCriarBarraInclinado.Click += new System.EventHandler(this.btnCriarBarraInclinado_Click);
            // 
            // txtAngulo
            // 
            this.txtAngulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAngulo.Location = new System.Drawing.Point(25, 72);
            this.txtAngulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAngulo.Name = "txtAngulo";
            this.txtAngulo.Size = new System.Drawing.Size(182, 29);
            this.txtAngulo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ângulo  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Intensidade :";
            // 
            // btnAjuda
            // 
            this.btnAjuda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAjuda.Location = new System.Drawing.Point(402, 302);
            this.btnAjuda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Size = new System.Drawing.Size(90, 30);
            this.btnAjuda.TabIndex = 25;
            this.btnAjuda.Text = "Ajuda";
            this.btnAjuda.UseVisualStyleBackColor = true;
            // 
            // rbForcaVertical
            // 
            this.rbForcaVertical.AutoSize = true;
            this.rbForcaVertical.Location = new System.Drawing.Point(10, 99);
            this.rbForcaVertical.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbForcaVertical.Name = "rbForcaVertical";
            this.rbForcaVertical.Size = new System.Drawing.Size(144, 29);
            this.rbForcaVertical.TabIndex = 16;
            this.rbForcaVertical.Text = "Força Vertical";
            this.rbForcaVertical.UseVisualStyleBackColor = true;
            this.rbForcaVertical.CheckedChanged += new System.EventHandler(this.rbForcaVertical_CheckedChanged);
            // 
            // rbForcaHorizontal
            // 
            this.rbForcaHorizontal.AutoSize = true;
            this.rbForcaHorizontal.Location = new System.Drawing.Point(10, 145);
            this.rbForcaHorizontal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbForcaHorizontal.Name = "rbForcaHorizontal";
            this.rbForcaHorizontal.Size = new System.Drawing.Size(169, 29);
            this.rbForcaHorizontal.TabIndex = 17;
            this.rbForcaHorizontal.Text = "Força Horizontal";
            this.rbForcaHorizontal.UseVisualStyleBackColor = true;
            this.rbForcaHorizontal.CheckedChanged += new System.EventHandler(this.rbForcaHorizontal_CheckedChanged);
            // 
            // rbForcaInclinada
            // 
            this.rbForcaInclinada.AutoSize = true;
            this.rbForcaInclinada.Checked = true;
            this.rbForcaInclinada.Location = new System.Drawing.Point(10, 56);
            this.rbForcaInclinada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbForcaInclinada.Name = "rbForcaInclinada";
            this.rbForcaInclinada.Size = new System.Drawing.Size(158, 29);
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
            this.groupBox3.Location = new System.Drawing.Point(392, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(213, 187);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de Força:";
            // 
            // cbQuadrante
            // 
            this.cbQuadrante.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbQuadrante.FormattingEnabled = true;
            this.cbQuadrante.Items.AddRange(new object[] {
            "Apontada para fora",
            "Apontada para dentro"});
            this.cbQuadrante.Location = new System.Drawing.Point(25, 298);
            this.cbQuadrante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbQuadrante.Name = "cbQuadrante";
            this.cbQuadrante.Size = new System.Drawing.Size(281, 33);
            this.cbQuadrante.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(25, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Quadrante da Força :";
            // 
            // frmAdicionaForca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 431);
            this.Controls.Add(this.gbForça);
            this.Controls.Add(this.btnAjuda);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmAdicionaForca";
            this.Text = "frmAdicionaForca";
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
    }
}