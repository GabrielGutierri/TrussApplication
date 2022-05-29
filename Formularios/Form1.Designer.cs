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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelDesenho = new System.Windows.Forms.Panel();
            this.lbDeletar = new System.Windows.Forms.Label();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnTeste = new System.Windows.Forms.Button();
            this.btnTeste2 = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modoNoturnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDesenho.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesenho
            // 
            this.panelDesenho.BackColor = System.Drawing.Color.White;
            this.panelDesenho.Controls.Add(this.lbDeletar);
            this.panelDesenho.Controls.Add(this.lbMensagem);
            this.panelDesenho.Location = new System.Drawing.Point(11, 42);
            this.panelDesenho.Margin = new System.Windows.Forms.Padding(2);
            this.panelDesenho.Name = "panelDesenho";
            this.panelDesenho.Size = new System.Drawing.Size(1332, 547);
            this.panelDesenho.TabIndex = 0;
            // 
            // lbDeletar
            // 
            this.lbDeletar.AutoSize = true;
            this.lbDeletar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDeletar.Location = new System.Drawing.Point(374, 9);
            this.lbDeletar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDeletar.Name = "lbDeletar";
            this.lbDeletar.Size = new System.Drawing.Size(801, 32);
            this.lbDeletar.TabIndex = 5;
            this.lbDeletar.Text = "Selecione os dois pontos de uma barra clicando neles para deletar a barra";
            this.lbDeletar.Visible = false;
            // 
            // lbMensagem
            // 
            this.lbMensagem.AutoSize = true;
            this.lbMensagem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMensagem.Location = new System.Drawing.Point(621, 9);
            this.lbMensagem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(317, 32);
            this.lbMensagem.TabIndex = 4;
            this.lbMensagem.Text = "Selecione um ponto inicial  :";
            this.lbMensagem.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnCalcular);
            this.panel3.Controls.Add(this.btnCriar);
            this.panel3.Controls.Add(this.btnDeletar);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(243, 593);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 98);
            this.panel3.TabIndex = 3;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalcular.Location = new System.Drawing.Point(348, 18);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(163, 66);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(14, 18);
            this.btnCriar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(163, 66);
            this.btnCriar.TabIndex = 7;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click_1);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(181, 18);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(163, 66);
            this.btnDeletar.TabIndex = 8;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnTeste
            // 
            this.btnTeste.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeste.Location = new System.Drawing.Point(841, 623);
            this.btnTeste.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTeste.Name = "btnTeste";
            this.btnTeste.Size = new System.Drawing.Size(142, 42);
            this.btnTeste.TabIndex = 6;
            this.btnTeste.Text = "Teste";
            this.btnTeste.UseVisualStyleBackColor = true;
            this.btnTeste.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTeste2
            // 
            this.btnTeste2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeste2.Location = new System.Drawing.Point(987, 623);
            this.btnTeste2.Margin = new System.Windows.Forms.Padding(2);
            this.btnTeste2.Name = "btnTeste2";
            this.btnTeste2.Size = new System.Drawing.Size(142, 42);
            this.btnTeste2.TabIndex = 7;
            this.btnTeste2.Text = "Teste 2";
            this.btnTeste2.UseVisualStyleBackColor = true;
            this.btnTeste2.Click += new System.EventHandler(this.btnTeste2_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.temaToolStripMenuItem,
            this.ajudaToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(1358, 29);
            this.menuStrip2.TabIndex = 22;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoArquivoToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.arquivoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(83, 27);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // novoArquivoToolStripMenuItem
            // 
            this.novoArquivoToolStripMenuItem.Name = "novoArquivoToolStripMenuItem";
            this.novoArquivoToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.novoArquivoToolStripMenuItem.Text = "Novo Arquivo";
            this.novoArquivoToolStripMenuItem.Click += new System.EventHandler(this.novoArquivoToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // temaToolStripMenuItem
            // 
            this.temaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modoNoturnoToolStripMenuItem});
            this.temaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
            this.temaToolStripMenuItem.Size = new System.Drawing.Size(64, 27);
            this.temaToolStripMenuItem.Text = "Tema";
            // 
            // modoNoturnoToolStripMenuItem
            // 
            this.modoNoturnoToolStripMenuItem.Name = "modoNoturnoToolStripMenuItem";
            this.modoNoturnoToolStripMenuItem.Size = new System.Drawing.Size(209, 28);
            this.modoNoturnoToolStripMenuItem.Text = "Modo Noturno";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(68, 27);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            this.ajudaToolStripMenuItem.Click += new System.EventHandler(this.ajudaToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(68, 27);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 702);
            this.Controls.Add(this.btnTeste);
            this.Controls.Add(this.btnTeste2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelDesenho);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tremliça";
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.panelDesenho.ResumeLayout(false);
            this.panelDesenho.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
        private MenuStrip menuStrip2;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem novoArquivoToolStripMenuItem;
        private ToolStripMenuItem fecharToolStripMenuItem;
        private ToolStripMenuItem temaToolStripMenuItem;
        private ToolStripMenuItem modoNoturnoToolStripMenuItem;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private ToolStripMenuItem ajudaToolStripMenuItem;
    }
}