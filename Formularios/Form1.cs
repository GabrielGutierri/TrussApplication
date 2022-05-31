using Software_Trelisa.Calculos;
using Software_Trelisa.Properties;
using System.Drawing.Drawing2D;

namespace Software_Trelisa
{
    public partial class Form1 : Form
    {
        public static List<Barra> listaBarras = new List<Barra>();
        public static List<Ponto> listaPontos = new List<Ponto>();
        public static List<PontoSeta> listaSetas = new List<PontoSeta>();
        public static List<PictureBox> listaPictureBox = new List<PictureBox>();
        List<Ponto> listaDeletar = new List<Ponto>();
        List<PictureBox> listaDeletaForca = new List<PictureBox>();
        public static double escalaDesenho = 1;
        bool querDeletar = false;
        Ponto pontoTeste { get; set; }

        public Form1()
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            InitializeComponent();
        }

        #region Eventos Ponto
        public void novoPonto_DoubleClick(object sender, EventArgs e, Ponto ponto)
        {
            if (querDeletar == true)
            {
                QuerDeletar(ponto);
            }
            else
            {
                frmCriacao f = new frmCriacao(ponto);
                f.ShowDialog();

                foreach (PictureBox imagem in listaPictureBox)
                {
                    imagem.Enabled = false;
                    imagem.Visible = false;
                }
                lbMensagem.Visible = false;
            }
            DesenhaBarras();
            DesenhaForcas();
        }

        private void AdicionaPrimeiroPonto()
        {
            Ponto ponto = new Ponto(75, panelDesenho.Height - 100);
            listaPontos.Add(ponto);
            CriaPontoImagem(ponto);
            this.pontoTeste = ponto;
        }

        public void CriaPontoImagem(Ponto ponto)
        {
            System.Windows.Forms.PictureBox novoPontoImagem = new System.Windows.Forms.PictureBox();
            novoPontoImagem.Image = Properties.Resources.PontoSelecao;
            novoPontoImagem.Name = "Ponto" + ponto.valorX.ToString() + ponto.valorY.ToString();
            novoPontoImagem.SizeMode = PictureBoxSizeMode.StretchImage;
            novoPontoImagem.BackColor = Color.White;
            novoPontoImagem.Width = 20;
            novoPontoImagem.Height = 20;
            novoPontoImagem.Location = new Point(ponto.valorX - 10, ponto.valorY - 10);
            novoPontoImagem.Click += new EventHandler((sender, e) => novoPonto_DoubleClick(sender, e, ponto));
            novoPontoImagem.Enabled = false;
            novoPontoImagem.Visible = false;
            panelDesenho.Controls.Add(novoPontoImagem);
            listaPictureBox.Add(novoPontoImagem);
        }
        #endregion

        #region Botao Teste

        /*
        private void button2_Click(object sender, EventArgs e)
        {
            Barra barra1 = new Barra(75, 500, 125, 230, 79.509, 274.59060, "Crescente");
            Barra barra2 = new Barra(75, 500, 575, 500, 0, 500, "Crescente");
            Barra barra3 = new Barra(575, 500, 575, 150, 90, 350,"Crescente" );
            Barra barra4 = new Barra(125, 230, 575, 500, 30.96376, 524.78, "Decrescente");
            Barra barra5 = new Barra(125, 230, 575, 150, 10.0806, 457.06, "Crescente");
            Barra barra6 = new Barra(575, 150, 825, 500, 54.46232, 430.12, "Decrescente");
            Barra barra7 = new Barra(825, 500, 575, 500, 0, 250, "Decrescente");
            
            listaPontos[0].barrasPonto.Add(barra1);
            listaPontos[0].barrasPonto.Add(barra2);
            pontoTeste.forcasApoio.Add(new ForcaApoio(0, 90, "vertical", "Apontada para fora", "fixo"));
            pontoTeste.forcasApoio.Add(new ForcaApoio(0, 0, "horizontal", "Apontada para fora", "fixo"));
          
            Ponto ponto2 = new Ponto(125, 230);
            ponto2.forcasPonto.Add(new ForcaPonto(12000, 90, "vertical", "Apontada para dentro", 1));
            ponto2.forcasPonto.Add(new ForcaPonto(15000, 0, "horizontal", "Apontada para dentro", 1));
            ponto2.barrasPonto.Add(barra1);
            ponto2.barrasPonto.Add(barra4);
            ponto2.barrasPonto.Add(barra5);
            Ponto ponto3 = new Ponto(575, 500);
            ponto3.forcasPonto.Add(new ForcaPonto(8000, 270, "vertical", "Apontada para dentro", 3));
            ponto3.barrasPonto.Add(barra2);
            ponto3.barrasPonto.Add(barra3);
            ponto3.barrasPonto.Add(barra4);
            ponto3.barrasPonto.Add(barra7);
            Ponto ponto4 = new Ponto(575, 150);
            ponto4.forcasPonto.Add(new ForcaPonto(35000, 120, "inclinada", "Apontada para dentro", 2));
            ponto4.barrasPonto.Add(barra3);
            ponto4.barrasPonto.Add(barra5);
            ponto4.barrasPonto.Add(barra6);
            Ponto ponto5 = new Ponto(825, 500);
            ponto5.barrasPonto.Add(barra6);
            ponto5.barrasPonto.Add(barra7);
            listaPontos.Add(ponto2);
            listaPontos.Add(ponto3);
            listaPontos.Add(ponto4);
            listaPontos.Add(ponto5);
            ponto5.forcasApoio.Add(new ForcaApoio(0, 90, "vertical", "Apontada para fora", "movel"));

            CriaPontoImagem(ponto2);
            CriaPontoImagem(ponto3);
            CriaPontoImagem(ponto4);
            CriaPontoImagem(ponto5);


            listaBarras.Add(barra1);
            listaBarras.Add(barra2);
            listaBarras.Add(barra3);
            listaBarras.Add(barra4);
            listaBarras.Add(barra5);
            listaBarras.Add(barra6);
            listaBarras.Add(barra7);

            DesenhaBarras();
            DesenhaForcas();

            btnTeste.Enabled = false;
        }
        */
        #endregion

        #region Botao Teste2

        /*
        private void btnTeste2_Click(object sender, EventArgs e)
        {
            Barra barra1 = new Barra(75, 500, 175, 250, 68.199, 269.258, "Crescente");
            Barra barra2 = new Barra(75, 500, 325, 500, 0, 250, "Crescente");
            Barra barra3 = new Barra(175, 250, 375, 0, 51.34, 320.156, "Crescente");
            Barra barra4 = new Barra(175, 250, 325, 500, 59.036, 291.547, "Decrescente");
            Barra barra5 = new Barra(375, 0, 575, 500, 68.199, 538.516, "Decrescente");
            Barra barra6 = new Barra(325, 500, 375, 0, 84.289, 502.494, "Crescente");
            Barra barra7 = new Barra(325, 500, 575, 500, 0, 250, "Crescente");

            listaPontos[0].barrasPonto.Add(barra1);
            listaPontos[0].barrasPonto.Add(barra2);
            pontoTeste.forcasApoio.Add(new ForcaApoio(0, 90, "vertical", "Apontada para fora", "fixo"));
            pontoTeste.forcasApoio.Add(new ForcaApoio(0, 0, "horizontal", "Apontada para fora", "fixo"));
            

            Ponto ponto2 = new Ponto(175, 250);
            ponto2.forcasPonto.Add(new ForcaPonto(50000, 0, "horizontal", "Apontada para dentro", 2));
            ponto2.barrasPonto.Add(barra1);
            ponto2.barrasPonto.Add(barra3);
            ponto2.barrasPonto.Add(barra4);
            Ponto ponto3 = new Ponto(375, 0);
            ponto3.forcasPonto.Add(new ForcaPonto(30000, 90, "vertical", "Apontada para dentro", 1));
            ponto3.forcasPonto.Add(new ForcaPonto(26000, 0, "horizontal", "Apontada para dentro", 1));
            ponto3.barrasPonto.Add(barra3);
            ponto3.barrasPonto.Add(barra5);
            ponto3.barrasPonto.Add(barra6);
            Ponto ponto4 = new Ponto(575, 500);
            ponto4.barrasPonto.Add(barra5);
            ponto4.barrasPonto.Add(barra7);
            ponto4.forcasApoio.Add(new ForcaApoio(0, 90, "vertical", "Apontada para fora", "movel"));
            Ponto ponto5 = new Ponto(325, 500);
            ponto5.barrasPonto.Add(barra2);
            ponto5.barrasPonto.Add(barra7);
            ponto5.barrasPonto.Add(barra4);
            ponto5.barrasPonto.Add(barra6);
            ponto5.forcasPonto.Add(new ForcaPonto(22000, 90, "vertical", "Apontada para fora", 3));
            listaPontos.Add(ponto2);
            listaPontos.Add(ponto3);
            listaPontos.Add(ponto4);
            listaPontos.Add(ponto5);


            CriaPontoImagem(ponto2);
            CriaPontoImagem(ponto3);
            CriaPontoImagem(ponto4);
            CriaPontoImagem(ponto5);


            listaBarras.Add(barra1);
            listaBarras.Add(barra2);
            listaBarras.Add(barra3);
            listaBarras.Add(barra4);
            listaBarras.Add(barra5);
            listaBarras.Add(barra6);
            listaBarras.Add(barra7);

            DesenhaBarras();
            DesenhaForcas();
            

            btnTeste2.Enabled = false;
        }
        */
        #endregion

        #region Botão Criar
        private void btnCriar_Click_1(object sender, EventArgs e)
        {
            if(listaPontos.Count == 0)
            {
                AdicionaPrimeiroPonto();
            }
            lbDeletar.Visible = false;
            panelDesenho.Visible = true;
            lbMensagem.Visible = true;
            foreach (PictureBox imagem in listaPictureBox)
            {
                imagem.Enabled = true;
                imagem.Visible = true;
            }
            foreach (var pcb in listaDeletaForca)
            {
                panelDesenho.Controls.Remove(pcb);
            }
            listaSetas.Clear();
            DesenhaBarras();
            DesenhaForcas();
        }
        #endregion

        #region Adiciona Apoio
        public void AdicionaApoios(Ponto ponto, string tipo)
        {
            System.Windows.Forms.PictureBox novoPontoImagem = new System.Windows.Forms.PictureBox();
            novoPontoImagem.SizeMode = PictureBoxSizeMode.StretchImage;
            novoPontoImagem.BorderStyle = BorderStyle.None;
            novoPontoImagem.Width = 100;
            novoPontoImagem.Height = 60;
            novoPontoImagem.Tag = "apoio";

            novoPontoImagem.Location = new Point(ponto.valorX - 50, ponto.valorY + 6);
            if (tipo == "fixo")
            {
                novoPontoImagem.Image = Properties.Resources.Apoio_Duplo;
                panelDesenho.Controls.Add(novoPontoImagem);
            }
            else
            {
                novoPontoImagem.Image = Properties.Resources.Apoio_simples;
            }
            panelDesenho.Controls.Add(novoPontoImagem);
            novoPontoImagem.BackColor = Color.Transparent;
        }

        #endregion

        #region Botão Deletar
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            lbMensagem.Visible = false;
            frmDeleta f = new frmDeleta();
            f.ShowDialog();
        }

        #endregion

        #region Botão Calcular
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show("Os dados informados estão corretos? Essa ação não poderá ser desfeita", "Confirmação",
                MessageBoxButtons.OKCancel))
            {
                return;
            }

            btnCriar.Enabled = false;
            btnDeletar.Enabled = false;
            btnCalcular.Enabled = false;
            if (VerificaHiperasticidade() == true)
            {
                return;
            }
            Calculo.CalculaMomentoApoio();
            foreach (Control apoio in panelDesenho.Controls)
            {
                if (apoio.Tag == "apoio")
                {
                    panelDesenho.Controls.Remove(apoio);
                }
            }
            foreach (var ponto in Form1.listaPontos)
            {
                if (ponto.forcasApoio.Count >= 1)
                {
                    foreach (var forcaApoio in ponto.forcasApoio)
                    {
                        ponto.forcasPonto.Add(new ForcaPonto(forcaApoio.Intensidade, forcaApoio.Angulo, forcaApoio.Sentido, forcaApoio.Direcao));
                    }
                    DeletaApoio(ponto);
                }
            }
            Calculos.CalculoForcasBarras.CalculaForcasBarra();
            DesenhaBarras();
            DesenhaForcas();
        }


        private bool VerificaHiperasticidade()
        {
            int quantidadesForcasApoios = 0, quantidadeIncognitas = 0;
            foreach (Ponto pontoAnalisado in Form1.listaPontos)
            {
                quantidadeIncognitas++;
                if (pontoAnalisado.forcasApoio.Count == 2)
                {
                    quantidadesForcasApoios += 2;
                }
                else if (pontoAnalisado.forcasApoio.Count == 1)
                {
                    quantidadesForcasApoios += 1;
                }
            }

            quantidadeIncognitas = (quantidadeIncognitas * 2) - 3;
            if (quantidadesForcasApoios < 3 || listaBarras.Count > quantidadeIncognitas)
            {
                MessageBox.Show("Treliça Hiperestatica - Não é possivel calcular");
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region Deletar Forca
        public void deletaForca_Click(object sender, EventArgs e, PontoSeta pontoSeta)
            {
                listaSetas.Clear();
                DesenhaBarras();
                DesenhaForcas();
                PontoSeta ponto = listaSetas.Find(p => (p.ValorFinalX == pontoSeta.ValorFinalX
                                                && p.ValorFinalY == pontoSeta.ValorFinalY
                                                && p.ValorInicialX == pontoSeta.ValorInicialX
                                                && p.ValorInicialY == pontoSeta.ValorInicialY));
                listaSetas.Remove(ponto);
            if (ponto != null)
            {

                var pontoForca = listaPontos.Find(f => (f.valorX == ponto.ValorInicialX && f.valorY == ponto.ValorInicialY) || (f.valorX == ponto.ValorFinalX && f.valorY == ponto.ValorFinalY));
                pontoForca.forcasPonto.Remove(ponto.ForcaPonto);
            }
            foreach (Control control in listaDeletaForca)
            {
                panelDesenho.Controls.Remove(control);
            }
            listaSetas.Clear();
            DesenhaBarras();
            DesenhaForcas();
        }

        public void CriaDeletaForca(PontoSeta pontoSeta)
        {
            PictureBox imagemDeleta = new PictureBox();
            imagemDeleta.Image = Resources.iconeDelete;
            imagemDeleta.Name = "iconeDelete";
            imagemDeleta.SizeMode = PictureBoxSizeMode.StretchImage;
            imagemDeleta.Height = 20;
            imagemDeleta.Width = 20;
            imagemDeleta.Location = new Point((pontoSeta.ValorFinalX + pontoSeta.ValorInicialX) / 2, (pontoSeta.ValorInicialY + pontoSeta.ValorFinalY) / 2);
            imagemDeleta.Visible = true;
            imagemDeleta.Click += new EventHandler((sender, e) => deletaForca_Click(sender, e, pontoSeta));
            listaDeletaForca.Add(imagemDeleta);
            panelDesenho.Controls.Add(imagemDeleta);
        }

        public void DeletarForcaEvent()
        {
            listaDeletaForca.RemoveAll(pcb => pcb.Name == "iconeDelete");

            foreach (var pontoSeta in listaSetas)
            {
                CriaDeletaForca(pontoSeta);
            }
        }

        #endregion

        #region Deletar Barra

        public void QuerDeletar(Ponto ponto)
        {
            listaDeletar.Add(ponto);

            if (listaDeletar.Count == 2)
            {
                foreach (PictureBox imagem in listaPictureBox)
                {
                    imagem.Enabled = false;
                    imagem.Visible = false;
                }

                if (listaBarras.Find(x => x.pontoInicialX == listaDeletar[0].valorX &
                 x.pontoInicialY == listaDeletar[0].valorY & x.pontoFinalX == listaDeletar[1].valorX &
                 x.pontoFinalY == listaDeletar[1].valorY) != null)
                {
                    Barra barraDeletar = listaBarras.Find(x => x.pontoInicialX == listaDeletar[0].valorX &
                    x.pontoInicialY == listaDeletar[0].valorY & x.pontoFinalX == listaDeletar[1].valorX &
                    x.pontoFinalY == listaDeletar[1].valorY);

                    listaBarras.Remove(barraDeletar);

                    foreach (Ponto pontoAcha in listaPontos)
                    {
                        if (pontoAcha.barrasPonto.Find(x => x == barraDeletar) != null)
                        {
                            pontoAcha.barrasPonto.Remove(barraDeletar);
                        }
                    }

                    foreach (Ponto pontoImagem in listaPontos)
                    {
                        if (pontoImagem.barrasPonto.Count == 0)
                        {
                            PictureBox pictureBoxRemove = listaPictureBox.Find(x => x.Name == "Ponto" +
                            pontoImagem.valorX.ToString() + pontoImagem.valorY.ToString());
                            panelDesenho.Controls.Remove(pictureBoxRemove);
                            listaPictureBox.Remove(pictureBoxRemove);
                        }
                    }

                    listaPontos.RemoveAll(x => x.barrasPonto.Count == 0);
                }
                else if (listaBarras.Find(x => x.pontoInicialX == listaDeletar[1].valorX &
                 x.pontoInicialY == listaDeletar[1].valorY & x.pontoFinalX == listaDeletar[0].valorX &
                 x.pontoFinalY == listaDeletar[0].valorY) != null)
                {
                    Barra barraDeletar = listaBarras.Find(x => x.pontoInicialX == listaDeletar[1].valorX &
                    x.pontoInicialY == listaDeletar[1].valorY & x.pontoFinalX == listaDeletar[0].valorX &
                    x.pontoFinalY == listaDeletar[0].valorY);

                    listaBarras.Remove(barraDeletar);

                    foreach (Ponto pontoAcha in listaPontos)
                    {
                        if (pontoAcha.barrasPonto.Find(x => x == barraDeletar) != null)
                        {
                            pontoAcha.barrasPonto.Remove(barraDeletar);
                        }
                    }

                    foreach (Ponto pontoImagem in listaPontos)
                    {
                        if (pontoImagem.barrasPonto.Count == 0)
                        {
                            PictureBox pictureBoxRemove = listaPictureBox.Find(x => x.Name == "Ponto" +
                            pontoImagem.valorX.ToString() + pontoImagem.valorY.ToString());
                            panelDesenho.Controls.Remove(pictureBoxRemove);
                            listaPictureBox.Remove(pictureBoxRemove);
                        }
                    }

                    listaPontos.RemoveAll(x => x.barrasPonto.Count == 0);
                }
                else if (listaDeletar[0] == listaDeletar[1])
                {
                    MessageBox.Show("Selecionou o mesmo ponto duas vezes");
                }
                else
                {
                    MessageBox.Show("Os pontos selecionados não correspondem aos ponto de alguma barra já criada");
                }

                listaDeletar.RemoveAt(1);
                listaDeletar.RemoveAt(0);
                lbDeletar.Visible = false;
                querDeletar = false;

            }

            if (listaPontos.Count == 0)
            {
                AdicionaPrimeiroPonto();
            }
        }

        public void DeletarBarraEvent()
        {
            if (listaBarras.Count == 0)
            {
                MessageBox.Show("Não há barras para deletar");
                return;
            }

            lbMensagem.Visible = false;
            lbDeletar.Visible = true;
            foreach (PictureBox imagem in listaPictureBox)
            {
                imagem.Enabled = true;
                imagem.Visible = true;
            }
            querDeletar = true;


            /*Pra que isso?
            foreach (var item in listaPontos)
            {
                Point novoPonto = new Point(item.valorX, item.valorY);
                PictureBox encontrouImagem = listaPictureBox.Find(x => x.Location == novoPonto);
                if(encontrouImagem == null)
                {
                    CriaPontoImagem(item);
                }
            }
            */

        }

        #endregion

        #region Desenhos de Forca, Barra, Apoio e Valores Encontrados
        public void DesenhaForcas()
        {
            Graphics g = panelDesenho.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            Pen p = new Pen(Color.Red, 4.0f);
            p.CustomStartCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5, false);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            foreach (Ponto ponto in listaPontos)
            {
                foreach (var forca in ponto.forcasPonto)
                {

                    ValorXPonto(forca);
                    double anguloForca = TrocaAnguloDesenho(forca);
                    var valorXPonto = ponto.valorX + Convert.ToInt32(75 * Math.Cos(anguloForca * (Math.PI / 180)));
                    var valorYPonto = ponto.valorY + Convert.ToInt32(75 * Math.Sin(-anguloForca * (Math.PI / 180)));
                    if (forca.Direcao == "Apontada para fora")
                    {
                        g.DrawLine(p, valorXPonto, valorYPonto, ponto.valorX, ponto.valorY); //ponto da força é o ponto inicial
                        listaSetas.Add(new PontoSeta(valorXPonto, valorYPonto, ponto.valorX, ponto.valorY, forca.Direcao, forca));
                        AdicionaIntensidadeForca(ponto,valorXPonto, valorYPonto, forca);
                    }
                    else
                    {
                        g.DrawLine(p, ponto.valorX, ponto.valorY, valorXPonto, valorYPonto); // ponto é o inicial
                        listaSetas.Add(new PontoSeta(ponto.valorX, ponto.valorY, valorXPonto, valorYPonto, forca.Direcao, forca));
                        AdicionaIntensidadeForca(ponto, valorXPonto, valorYPonto, forca);
                    }
                }
            }

            g.Dispose();
            p.Dispose();
        }
        public double TrocaAnguloDesenho(ForcaPonto forca)
        {
            if (forca.Angulo > 90)
                return forca.Angulo;
            else if (forca.Quadrante == 2) //210 - 30 = 180
            {
                return forca.Angulo + 180;
            }
            else if (forca.Quadrante == 3)
            {
                return forca.Angulo + 180;
            }
            else if (forca.Quadrante == 4)
            {
                return forca.Angulo + 270;
            }
            else return forca.Angulo;

        }
        public int ValorXPonto(ForcaPonto forca)
        {
            if (forca.Quadrante == 3)
            {
                return Convert.ToInt32(75 * Math.Cos((forca.Angulo) * (Math.PI / 180)));
            }
            else
            {
                return 1;
            }
        }
        public void DesenhaBarras()
        {
            Font novaFont = new Font("Segoe", 14);
            Graphics g = panelDesenho.CreateGraphics();
            Pen myPen = new Pen(Color.Gray, 6);
            Pen myPen2 = new Pen(Color.LightSteelBlue, 6);
            Pen myPen3 = new Pen(Color.DarkSeaGreen, 6);
            g.Clear(panelDesenho.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            foreach (Barra barras in listaBarras)
            {
                if (barras.Forca.Intensidade == 0)
                {
                    g.DrawLine(myPen, barras.pontoInicialX, barras.pontoInicialY, barras.pontoFinalX, barras.pontoFinalY);
                }
                else if (barras.Forca.Direcao == "Apontada para dentro")
                {
                    g.DrawLine(myPen3, barras.pontoInicialX, barras.pontoInicialY, barras.pontoFinalX, barras.pontoFinalY);
                    AdicionaIntensidade(barras);
                }
                else if (barras.Forca.Direcao == "Apontada para fora")
                {
                    g.DrawLine(myPen2, barras.pontoInicialX, barras.pontoInicialY, barras.pontoFinalX, barras.pontoFinalY);
                    AdicionaIntensidade(barras);
                }


            }
            if (btnCalcular.Enabled == false)
            {
                Point pontoTracao = new Point(panelDesenho.Width - 320, panelDesenho.Height - 75);
                Point pontoCompressao = new Point(panelDesenho.Width - 320, panelDesenho.Height - 35);
                g.DrawLine(myPen2, panelDesenho.Width - 170, panelDesenho.Height - 60, panelDesenho.Width - 20, panelDesenho.Height - 60);
                g.DrawString("Tração", novaFont, Brushes.Black, pontoTracao);
                g.DrawLine(myPen3, panelDesenho.Width - 170, panelDesenho.Height - 15, panelDesenho.Width - 20, panelDesenho.Height - 15);
                g.DrawString("Compressão", novaFont, Brushes.Black, pontoCompressao);
            }

            foreach (var ponto in listaPontos)
            {
                int count = 0;
                if(ponto.forcasApoio.Count == 1 && count < 2 )
                {
                    AdicionaApoios(ponto, "movel");
                    count++;
                }
                if(ponto.forcasApoio.Count == 2 && count < 2 )
                {
                    AdicionaApoios(ponto, "fixo");
                    count++;
                }
                if (count == 2)
                    break;
            }
            g.Dispose();
            myPen.Dispose();
            myPen2.Dispose();
            myPen3.Dispose();
        }

        private void AdicionaIntensidade(Barra barra)
        {
            Point novoPonto;
            Label lbIntensidade = new Label();
            Font novaFont = new Font("Segoe", 14);
            lbIntensidade.Font = novaFont;
            Graphics g = panelDesenho.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (barra.sentidoAngulo == "Crescente" && barra.pontoInicialX <= barra.pontoFinalX
                && barra.pontoInicialY >= barra.pontoFinalY)
            {

                novoPonto = new Point(barra.pontoInicialX + ((barra.pontoFinalX - barra.pontoInicialX) / 2)
                    - (lbIntensidade.Width / 2), barra.pontoFinalY + ((barra.pontoInicialY - barra.pontoFinalY) / 2)
                    - (lbIntensidade.Height / 2));
                g.DrawString(barra.Forca.Intensidade.ToString("0.00") + " KN", novaFont, Brushes.Black, novoPonto);
            }
            else if (barra.sentidoAngulo == "Crescente" && barra.pontoInicialX >= barra.pontoFinalX &&
                barra.pontoInicialY <= barra.pontoFinalY)
            {
                novoPonto = new Point(barra.pontoFinalX + ((barra.pontoInicialX - barra.pontoFinalX) / 2)
                    - (lbIntensidade.Width / 2), barra.pontoInicialY + ((barra.pontoFinalY - barra.pontoInicialY) / 2)
                     - (lbIntensidade.Height / 2));
                g.DrawString(barra.Forca.Intensidade.ToString("0.00") + " KN", novaFont, Brushes.Black, novoPonto);
            }
            else if (barra.sentidoAngulo == "Decrescente" && barra.pontoInicialX <= barra.pontoFinalX &&
                barra.pontoInicialY <= barra.pontoFinalY)
            {
                novoPonto = new Point(barra.pontoInicialX + ((barra.pontoFinalX - barra.pontoInicialX) / 2)
                    - (lbIntensidade.Width / 2), barra.pontoInicialY + ((barra.pontoFinalY - barra.pontoInicialY) / 2)
                    - (lbIntensidade.Height / 2));
                g.DrawString(barra.Forca.Intensidade.ToString("0.00") + " KN", novaFont, Brushes.Black, novoPonto);

            }
            else if (barra.sentidoAngulo == "Decrescente" && barra.pontoInicialX >= barra.pontoFinalX &&
                barra.pontoInicialY >= barra.pontoFinalY)
            {
                novoPonto = new Point(barra.pontoFinalX + ((barra.pontoInicialX - barra.pontoFinalX) / 2)
                    - (lbIntensidade.Width / 2), barra.pontoFinalY + ((barra.pontoInicialY - barra.pontoFinalY) / 2)
                    - (lbIntensidade.Height / 2));
                g.DrawString(barra.Forca.Intensidade.ToString("0.00") + " KN", novaFont, Brushes.Black, novoPonto);
            }

            g.Dispose();

        }

        private void AdicionaIntensidadeForca(Ponto ponto, int valorXponto, int valorYponto, Forca forca)
        {
            Point novoPonto;
            Label lbIntensidade = new Label();
            Font novaFont = new Font("arial", 14);
            lbIntensidade.Font = novaFont;
            Graphics g = panelDesenho.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (forca.Direcao == "Apontada para fora")
            {
                novoPonto = new Point(valorXponto + 15, valorYponto);
                g.DrawString(forca.Intensidade.ToString("0") + " KN", novaFont, Brushes.Black, novoPonto);
            }
            else
            {
                novoPonto = new Point(valorXponto + 15, valorYponto);
                g.DrawString(forca.Intensidade.ToString("0") + " KN", novaFont, Brushes.Black, novoPonto);
            }
        }
        #endregion

        #region Deletar Apoio
        public void DeletarApoioEvent()
        {
            foreach (Control apoio in panelDesenho.Controls)
            {
                if(apoio.Tag == "apoio")
                {
                    Ponto ponto = listaPontos.Find(p => (p.valorX - 50) == apoio.Location.X && (p.valorY + 6) == apoio.Location.Y);
                    apoio.Click += new EventHandler((sender, e) => deletaApoio_Click(sender, e, ponto));
                }
            }
        }
        public void deletaApoio_Click(object sender, EventArgs e, Ponto ponto)
        {
            DeletaApoio(ponto);
            listaPictureBox.Clear();
            foreach(Ponto pontoImagem in listaPontos)
            {
                CriaPontoImagem(pontoImagem);
            }
            DesenhaBarras();
            DesenhaForcas();
           
        }

        public void DeletaApoio(Ponto ponto)
        {
            if (ponto.forcasApoio[0].ehApoioFixo)
            {
                AdicionaApoio.JaTemFixo = false;
                ponto.forcasApoio.Clear();
            }
            else
            {
                AdicionaApoio.JaTemMovel = false;
                ponto.forcasApoio.Clear();
            }

            foreach (Control control in panelDesenho.Controls)
            {
                if(control.Tag == "apoio")
                    panelDesenho.Controls.Remove(control);
            }
            panelDesenho.Controls.Clear();
        }
        #endregion

        #region Toolbar
        private void novoArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculo.somaAntiHorario = 0;
            Calculo.somaHorario = 0;
            CalculoForcasBarras.somatoriaForcasVerticais = 0;
            CalculoForcasBarras.somatoriaForcasHorizontais = 0;
            panelDesenho.Refresh();
            listaBarras.Clear();
            listaPontos.Clear();
            listaSetas.Clear();
            listaPictureBox.Clear();
            listaDeletar.Clear();
            listaDeletaForca.Clear();
            escalaDesenho = 1;
            btnCriar.Enabled = true;
            btnDeletar.Enabled = true;
            btnCalcular.Enabled = true;
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Sobre f = new Formularios.Sobre();
            f.ShowDialog();
        }


        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.AjudaFormPrincipal f = new Formularios.AjudaFormPrincipal();
            f.ShowDialog();
        }
        #endregion

        private void Form1_Resize(object sender, EventArgs e)
        {
            DesenhaBarras();
            DesenhaForcas();
        }
    }
}

