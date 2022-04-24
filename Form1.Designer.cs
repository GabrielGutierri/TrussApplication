namespace Software_Trelisa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbDeletar = new System.Windows.Forms.RadioButton();
            this.rbCriar = new System.Windows.Forms.RadioButton();
            this.btnCriarBarra = new System.Windows.Forms.Button();
            this.rbBarras = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDeletarBarra = new System.Windows.Forms.Button();
            this.btnCriarForcas = new System.Windows.Forms.Button();
            this.btnCriarApoios = new System.Windows.Forms.Button();
            this.rbApoios = new System.Windows.Forms.RadioButton();
            this.rbForcas = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.lbDeletar = new System.Windows.Forms.Label();
            this.btnTeste = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(208, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 732);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.rbDeletar);
            this.panel2.Controls.Add(this.rbCriar);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(11, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 169);
            this.panel2.TabIndex = 0;
            // 
            // rbDeletar
            // 
            this.rbDeletar.AutoSize = true;
            this.rbDeletar.Location = new System.Drawing.Point(24, 92);
            this.rbDeletar.Name = "rbDeletar";
            this.rbDeletar.Size = new System.Drawing.Size(96, 32);
            this.rbDeletar.TabIndex = 1;
            this.rbDeletar.TabStop = true;
            this.rbDeletar.Text = "Deletar";
            this.rbDeletar.UseVisualStyleBackColor = true;
            this.rbDeletar.CheckedChanged += new System.EventHandler(this.rbDeletar_CheckedChanged);
            // 
            // rbCriar
            // 
            this.rbCriar.AutoSize = true;
            this.rbCriar.Checked = true;
            this.rbCriar.Location = new System.Drawing.Point(26, 35);
            this.rbCriar.Name = "rbCriar";
            this.rbCriar.Size = new System.Drawing.Size(74, 32);
            this.rbCriar.TabIndex = 0;
            this.rbCriar.TabStop = true;
            this.rbCriar.Text = "Criar";
            this.rbCriar.UseVisualStyleBackColor = true;
            this.rbCriar.CheckedChanged += new System.EventHandler(this.rbCriar_CheckedChanged);
            // 
            // btnCriarBarra
            // 
            this.btnCriarBarra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCriarBarra.Location = new System.Drawing.Point(14, 245);
            this.btnCriarBarra.Name = "btnCriarBarra";
            this.btnCriarBarra.Size = new System.Drawing.Size(149, 51);
            this.btnCriarBarra.TabIndex = 1;
            this.btnCriarBarra.Text = "Criar Barras";
            this.btnCriarBarra.UseVisualStyleBackColor = true;
            this.btnCriarBarra.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // rbBarras
            // 
            this.rbBarras.AutoSize = true;
            this.rbBarras.Checked = true;
            this.rbBarras.Location = new System.Drawing.Point(26, 35);
            this.rbBarras.Name = "rbBarras";
            this.rbBarras.Size = new System.Drawing.Size(86, 32);
            this.rbBarras.TabIndex = 2;
            this.rbBarras.TabStop = true;
            this.rbBarras.Text = "Barras";
            this.rbBarras.UseVisualStyleBackColor = true;
            this.rbBarras.CheckedChanged += new System.EventHandler(this.rbBarras_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnDeletarBarra);
            this.panel3.Controls.Add(this.btnCriarForcas);
            this.panel3.Controls.Add(this.btnCriarApoios);
            this.panel3.Controls.Add(this.btnCriarBarra);
            this.panel3.Controls.Add(this.rbApoios);
            this.panel3.Controls.Add(this.rbForcas);
            this.panel3.Controls.Add(this.rbBarras);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(11, 221);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 355);
            this.panel3.TabIndex = 3;
            // 
            // btnDeletarBarra
            // 
            this.btnDeletarBarra.Enabled = false;
            this.btnDeletarBarra.Location = new System.Drawing.Point(14, 245);
            this.btnDeletarBarra.Name = "btnDeletarBarra";
            this.btnDeletarBarra.Size = new System.Drawing.Size(149, 51);
            this.btnDeletarBarra.TabIndex = 6;
            this.btnDeletarBarra.Text = "Deletar Barra";
            this.btnDeletarBarra.UseVisualStyleBackColor = true;
            this.btnDeletarBarra.Visible = false;
            this.btnDeletarBarra.Click += new System.EventHandler(this.btnDeletarBarra_Click);
            // 
            // btnCriarForcas
            // 
            this.btnCriarForcas.Enabled = false;
            this.btnCriarForcas.Location = new System.Drawing.Point(14, 245);
            this.btnCriarForcas.Name = "btnCriarForcas";
            this.btnCriarForcas.Size = new System.Drawing.Size(149, 51);
            this.btnCriarForcas.TabIndex = 0;
            this.btnCriarForcas.Text = "Criar Forças";
            this.btnCriarForcas.UseVisualStyleBackColor = true;
            this.btnCriarForcas.Visible = false;
            // 
            // btnCriarApoios
            // 
            this.btnCriarApoios.Enabled = false;
            this.btnCriarApoios.Location = new System.Drawing.Point(14, 245);
            this.btnCriarApoios.Name = "btnCriarApoios";
            this.btnCriarApoios.Size = new System.Drawing.Size(149, 51);
            this.btnCriarApoios.TabIndex = 4;
            this.btnCriarApoios.Text = "Criar Apoios";
            this.btnCriarApoios.UseVisualStyleBackColor = true;
            this.btnCriarApoios.Visible = false;
            // 
            // rbApoios
            // 
            this.rbApoios.AutoSize = true;
            this.rbApoios.Location = new System.Drawing.Point(24, 171);
            this.rbApoios.Name = "rbApoios";
            this.rbApoios.Size = new System.Drawing.Size(95, 32);
            this.rbApoios.TabIndex = 3;
            this.rbApoios.Text = "Apoios";
            this.rbApoios.UseVisualStyleBackColor = true;
            this.rbApoios.CheckedChanged += new System.EventHandler(this.rbApoios_CheckedChanged);
            // 
            // rbForcas
            // 
            this.rbForcas.AutoSize = true;
            this.rbForcas.Location = new System.Drawing.Point(26, 105);
            this.rbForcas.Name = "rbForcas";
            this.rbForcas.Size = new System.Drawing.Size(89, 32);
            this.rbForcas.TabIndex = 0;
            this.rbForcas.Text = "Forças";
            this.rbForcas.UseVisualStyleBackColor = true;
            this.rbForcas.CheckedChanged += new System.EventHandler(this.rbForcas_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(35, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbMensagem
            // 
            this.lbMensagem.AutoSize = true;
            this.lbMensagem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMensagem.Location = new System.Drawing.Point(355, 12);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(633, 32);
            this.lbMensagem.TabIndex = 4;
            this.lbMensagem.Text = "Selecione um ponto inicial clicando duas vezes sobre ele :";
            this.lbMensagem.Visible = false;
            // 
            // lbDeletar
            // 
            this.lbDeletar.AutoSize = true;
            this.lbDeletar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDeletar.Location = new System.Drawing.Point(258, 16);
            this.lbDeletar.Name = "lbDeletar";
            this.lbDeletar.Size = new System.Drawing.Size(794, 28);
            this.lbDeletar.TabIndex = 5;
            this.lbDeletar.Text = "Selecione os dois pontos de uma barra clicando duas vezes sobre eles para deletar" +
    " a barra";
            this.lbDeletar.Visible = false;
            // 
            // btnTeste
            // 
            this.btnTeste.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeste.Location = new System.Drawing.Point(35, 692);
            this.btnTeste.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTeste.Name = "btnTeste";
            this.btnTeste.Size = new System.Drawing.Size(120, 56);
            this.btnTeste.TabIndex = 6;
            this.btnTeste.Text = "Teste";
            this.btnTeste.UseVisualStyleBackColor = true;
            this.btnTeste.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 767);
            this.Controls.Add(this.btnTeste);
            this.Controls.Add(this.lbDeletar);
            this.Controls.Add(this.lbMensagem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private RadioButton rbBarras;
        private Panel panel3;
        private RadioButton rbApoios;
        private RadioButton rbForcas;
        private Button button1;
        private Button btnCriarBarra;
        private RadioButton rbCriar;
        private RadioButton rbDeletar;
        private Label lbMensagem;
        private Button btnCriarApoios;
        private Button btnCriarForcas;
        private Button btnDeletarBarra;
        private Label lbDeletar;
        private Button btnTeste;
    }
}