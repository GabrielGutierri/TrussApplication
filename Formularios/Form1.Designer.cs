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
            this.panelDesenho = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.lbDeletar = new System.Windows.Forms.Label();
            this.btnTeste = new System.Windows.Forms.Button();
            this.btnTeste2 = new System.Windows.Forms.Button();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesenho
            // 
            this.panelDesenho.BackColor = System.Drawing.Color.White;
            this.panelDesenho.Location = new System.Drawing.Point(10, 39);
            this.panelDesenho.Name = "panelDesenho";
            this.panelDesenho.Size = new System.Drawing.Size(1617, 833);
            this.panelDesenho.TabIndex = 0;
            this.panelDesenho.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesenho_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnCriar);
            this.panel3.Controls.Add(this.btnDeletar);
            this.panel3.Controls.Add(this.btnCalcular);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(501, 880);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 107);
            this.panel3.TabIndex = 3;
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(13, 23);
            this.btnCriar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(161, 65);
            this.btnCriar.TabIndex = 7;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click_1);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(181, 23);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(161, 65);
            this.btnDeletar.TabIndex = 8;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalcular.Location = new System.Drawing.Point(347, 23);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(161, 64);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lbMensagem
            // 
            this.lbMensagem.AutoSize = true;
            this.lbMensagem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMensagem.Location = new System.Drawing.Point(682, 4);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(317, 32);
            this.lbMensagem.TabIndex = 4;
            this.lbMensagem.Text = "Selecione um ponto inicial  :";
            this.lbMensagem.Visible = false;
            // 
            // lbDeletar
            // 
            this.lbDeletar.AutoSize = true;
            this.lbDeletar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDeletar.Location = new System.Drawing.Point(451, 4);
            this.lbDeletar.Name = "lbDeletar";
            this.lbDeletar.Size = new System.Drawing.Size(801, 32);
            this.lbDeletar.TabIndex = 5;
            this.lbDeletar.Text = "Selecione os dois pontos de uma barra clicando neles para deletar a barra";
            this.lbDeletar.Visible = false;
            // 
            // btnTeste
            // 
            this.btnTeste.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeste.Location = new System.Drawing.Point(1119, 900);
            this.btnTeste.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTeste.Name = "btnTeste";
            this.btnTeste.Size = new System.Drawing.Size(120, 56);
            this.btnTeste.TabIndex = 6;
            this.btnTeste.Text = "Teste";
            this.btnTeste.UseVisualStyleBackColor = true;
            this.btnTeste.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTeste2
            // 
            this.btnTeste2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeste2.Location = new System.Drawing.Point(1245, 900);
            this.btnTeste2.Name = "btnTeste2";
            this.btnTeste2.Size = new System.Drawing.Size(121, 57);
            this.btnTeste2.TabIndex = 7;
            this.btnTeste2.Text = "Teste 2";
            this.btnTeste2.UseVisualStyleBackColor = true;
            this.btnTeste2.Click += new System.EventHandler(this.btnTeste2_Click);
            // 
            // btnAjuda
            // 
            this.btnAjuda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAjuda.Location = new System.Drawing.Point(1526, 947);
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Size = new System.Drawing.Size(103, 40);
            this.btnAjuda.TabIndex = 21;
            this.btnAjuda.Text = "Ajuda";
            this.btnAjuda.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1641, 999);
            this.Controls.Add(this.btnAjuda);
            this.Controls.Add(this.lbDeletar);
            this.Controls.Add(this.btnTeste2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnTeste);
            this.Controls.Add(this.lbMensagem);
            this.Controls.Add(this.panelDesenho);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Panel panelDesenho;
        private Panel panel3;
        private Button button1;
        private Label lbMensagem;
        private Label lbDeletar;
        private Button btnTeste;
        private Button btnCriar;
        private Button btnDeletar;
        private Button btnCalcular;
        private Button btnTeste2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem novoToolStripMenuItem;
        private Button btnAjuda;
    }
}