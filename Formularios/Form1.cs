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
        bool querDeletar = false;

        Ponto pontoTeste { get; set; }

        public Form1()
        {
            InitializeComponent();
            AdicionaPrimeiroPonto();
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
            Ponto ponto = new Ponto(75, 500);
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

        #region Desenhos de Forca, barra e apoio
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
                    var valorXPonto = ponto.valorX + Convert.ToInt32(75 * Math.Cos(forca.Angulo * (Math.PI / 180)));
                    var valorYPonto = ponto.valorY + Convert.ToInt32(75 * Math.Sin(-forca.Angulo * (Math.PI / 180)));
                    if (forca.Direcao == "Apontada para fora")
                    {
                        g.DrawLine(p, valorXPonto, valorYPonto, ponto.valorX, ponto.valorY); //ponto da força é o ponto inicial
                        listaSetas.Add(new PontoSeta(valorXPonto, valorYPonto, ponto.valorX, ponto.valorY, forca.Direcao, forca));
                    }
                    else {
                        g.DrawLine(p, ponto.valorX, ponto.valorY, valorXPonto, valorYPonto); // ponto é o inicial
                        listaSetas.Add(new PontoSeta(ponto.valorX, ponto.valorY, valorXPonto, valorYPonto, forca.Direcao, forca));
                    }
                }
            }

            g.Dispose();
            p.Dispose();
        }
        public int ValorXPonto(ForcaPonto forca)
        {
            if(forca.Quadrante == 3)
            {
                MessageBox.Show($"{forca.Angulo}");
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
                if(barras.Forca.Intensidade == 0)
                {
                    g.DrawLine(myPen, barras.pontoInicialX, barras.pontoInicialY, barras.pontoFinalX, barras.pontoFinalY);
                }
                else if (barras.Forca.Direcao == "Apontada para dentro")
                {
                    g.DrawLine(myPen3, barras.pontoInicialX, barras.pontoInicialY, barras.pontoFinalX, barras.pontoFinalY);
                    AdicionaIntensidade(barras);
                }
                else if(barras.Forca.Direcao == "Apontada para fora")
                {
                    g.DrawLine(myPen2, barras.pontoInicialX, barras.pontoInicialY, barras.pontoFinalX, barras.pontoFinalY);
                    AdicionaIntensidade(barras);
                }


            }
            if(button1.Enabled == false)
            {
                Point pontoTracao = new Point(1250, 595);
                Point pontoCompressao = new Point(1250, 635);
                g.DrawLine(myPen2, 1400, 610, 1600, 610);
                g.DrawString("Tração", novaFont, Brushes.Black, pontoTracao);
                g.DrawLine(myPen3, 1400, 655, 1600, 655);
                g.DrawString("Compressão", novaFont, Brushes.Black, pontoCompressao);
            }
           
            g.Dispose();
            myPen.Dispose();
            myPen2.Dispose();
            myPen3.Dispose();
        }
        #endregion

        #region Deletar Barra

        public void QuerDeletar(Ponto ponto)
        {
            listaDeletar.Add(ponto);

            if(listaDeletar.Count == 2)
            {
                foreach (PictureBox imagem in listaPictureBox)
                {
                    imagem.Enabled = false;
                    imagem.Visible = false;
                }

                if(listaBarras.Find(x => x.pontoInicialX == listaDeletar[0].valorX &
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
                else if(listaBarras.Find(x => x.pontoInicialX == listaDeletar[1].valorX &
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
        private void btnDeletarBarra_Click(object sender, EventArgs e)
        {
            if(listaBarras.Count == 0)
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
        }
        #endregion

        #region Botao Teste
        private void button2_Click(object sender, EventArgs e)
        {
            //Analisar crescente, decrescente

            Barra barra1 = new Barra(75, 500, 125, 230, 79.509, 274.59060, "Crescente");
            Barra barra2 = new Barra(75, 500, 575, 500, 0, 500, "Crescente");
            Barra barra3 = new Barra(575, 500, 575, 150, 90, 350,"Crescente" );
            Barra barra4 = new Barra(125, 230, 575, 500, 30.96376, 524.78, "Decrescente");
            Barra barra5 = new Barra(125, 230, 575, 150, 10.0806, 457.06, "Crescente");
            Barra barra6 = new Barra(575, 150, 825, 500, 54.46232, 430.12, "Decrescente");
            Barra barra7 = new Barra(825, 500, 575, 500, 0, 250, "Decrescente");
            
            listaPontos[0].barrasPonto.Add(barra1);
            listaPontos[0].barrasPonto.Add(barra2);

            this.pontoTeste.forcasPonto.Add(new ForcaPonto(15870.3, 90, "vertical", "Apontada para fora"));
            this.pontoTeste.forcasPonto.Add(new ForcaPonto(2500, 0, "horizontal", "Apontada para dentro"));
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
            ponto5.forcasPonto.Add(new ForcaPonto(18440.59, 90, "vertical", "Apontada para fora"));

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
        #endregion

        private void btnCriar_Click_1(object sender, EventArgs e)
        {
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
   
        private void button1_Click(object sender, EventArgs e)
        {
            btnCriar.Enabled = false;
            btnDeletar.Enabled = false;
            button1.Enabled = false;
            int quantidadeNulos, quantidadesForcasApoios = 0;
            double somatoriaForcasVerticais = 0, somatoriaForcasHorizontais = 0;
            double calculo1, calculo2, calculo3, calculo4;
            List<Barra> encontrouNulo = new List<Barra>();

            /* Esperar parte de calcular força no apoio
             
            foreach(Ponto pontoAnalisado in listaPontos)
            {
                if(pontoAnalisado.forcasApoio.Count == 2)
                {
                    quantidadesForcasApoios += 2;
                }
                else if(pontoAnalisado.forcasApoio.Count == 1)
                {
                    quantidadesForcasApoios += 1;
                }

            }

            if(quantidadesForcasApoios < 3)
            {
                MessageBox.Show("Treliça Hiperestatica - Não é possivel calcular");
                return;
            }
            */

            do
            {
                foreach (Ponto pontoAnalisado in listaPontos)
                {

                    encontrouNulo = pontoAnalisado.barrasPonto.FindAll(x => x.Forca.Intensidade != 0);
                    
                    if (pontoAnalisado.forcasPonto.Count == 0 && encontrouNulo.Count == 0)
                    {
                            continue;
                    }
                    
                    somatoriaForcasVerticais = 0;
                    somatoriaForcasHorizontais = 0;
                    quantidadeNulos = 0;

                    foreach(Barra barra in pontoAnalisado.barrasPonto)
                    {
                        if(barra.Forca.Intensidade == 0)
                        {
                            quantidadeNulos++;
                        }
                    }

                    if (quantidadeNulos <= 2)
                    {
                        foreach (ForcaPonto forcaPonto in pontoAnalisado.forcasPonto)
                        {
                            if ((forcaPonto.Sentido == "vertical" || forcaPonto.Sentido == "inclinada") && forcaPonto.Direcao == "Apontada para fora")
                            {
                                somatoriaForcasVerticais += forcaPonto.ComponenteVertical;
                            }
                            else if ((forcaPonto.Sentido == "vertical" || forcaPonto.Sentido == "inclinada") && forcaPonto.Direcao == "Apontada para dentro")
                            {
                                somatoriaForcasVerticais -= forcaPonto.ComponenteVertical;
                            }
                            
                            if ((forcaPonto.Sentido == "horizontal" || forcaPonto.Sentido == "inclinada") && forcaPonto.Direcao == "Apontada para fora")
                            {
                                somatoriaForcasHorizontais += forcaPonto.ComponenteHorizontal;
                            }
                            else if ((forcaPonto.Sentido == "horizontal" || forcaPonto.Sentido == "inclinada") && forcaPonto.Direcao == "Apontada para dentro")
                            {
                                somatoriaForcasHorizontais -= forcaPonto.ComponenteHorizontal;
                            }
                        }

                        foreach(Barra forcaBarra in pontoAnalisado.barrasPonto)
                        {
                            if(forcaBarra.Forca.Intensidade != 0)
                            {
                                if(forcaBarra.pontoInicialX == pontoAnalisado.valorX
                                && forcaBarra.pontoInicialY == pontoAnalisado.valorY)
                                {
                                    if ((forcaBarra.quadrantePontoInicial == "1" && forcaBarra.Forca.Direcao == "Apontada para fora") ||
                                        (forcaBarra.quadrantePontoInicial == "3" && forcaBarra.Forca.Direcao == "Apontada para dentro"))
                                    {
                                        somatoriaForcasVerticais += forcaBarra.Forca.ComponenteVertical;
                                        somatoriaForcasHorizontais += forcaBarra.Forca.ComponenteHorizontal;
                                    }
                                    else if ((forcaBarra.quadrantePontoInicial == "1" && forcaBarra.Forca.Direcao == "Apontada para dentro") ||
                                        (forcaBarra.quadrantePontoInicial == "3" && forcaBarra.Forca.Direcao == "Apontada para fora"))
                                    {
                                        somatoriaForcasVerticais -= forcaBarra.Forca.ComponenteVertical;
                                        somatoriaForcasHorizontais -= forcaBarra.Forca.ComponenteHorizontal;
                                    }
                                    else if ((forcaBarra.quadrantePontoInicial == "2" && forcaBarra.Forca.Direcao == "Apontada para fora") ||
                                        (forcaBarra.quadrantePontoInicial == "4" && forcaBarra.Forca.Direcao == "Apontada para dentro"))
                                    {
                                        somatoriaForcasVerticais += forcaBarra.Forca.ComponenteVertical;
                                        somatoriaForcasHorizontais -= forcaBarra.Forca.ComponenteHorizontal;
                                    }
                                    else if ((forcaBarra.quadrantePontoInicial == "2" && forcaBarra.Forca.Direcao == "Apontada para dentro") ||
                                        (forcaBarra.quadrantePontoInicial == "4" && forcaBarra.Forca.Direcao == "Apontada para fora"))
                                    {
                                        somatoriaForcasVerticais -= forcaBarra.Forca.ComponenteVertical;
                                        somatoriaForcasHorizontais += forcaBarra.Forca.ComponenteHorizontal;
                                    }
                                }
                                else
                                {
                                    if ((forcaBarra.quadrantePontoFinal == "1" && forcaBarra.Forca.Direcao == "Apontada para fora") ||
                                        (forcaBarra.quadrantePontoFinal == "3" && forcaBarra.Forca.Direcao == "Apontada para dentro"))
                                    {
                                        somatoriaForcasVerticais += forcaBarra.Forca.ComponenteVertical;
                                        somatoriaForcasHorizontais += forcaBarra.Forca.ComponenteHorizontal;
                                    }
                                    else if ((forcaBarra.quadrantePontoFinal == "1" && forcaBarra.Forca.Direcao == "Apontada para dentro") ||
                                        (forcaBarra.quadrantePontoFinal == "3" && forcaBarra.Forca.Direcao == "Apontada para fora"))
                                    {
                                        somatoriaForcasVerticais -= forcaBarra.Forca.ComponenteVertical;
                                        somatoriaForcasHorizontais -= forcaBarra.Forca.ComponenteHorizontal;
                                    }
                                    else if ((forcaBarra.quadrantePontoFinal == "2" && forcaBarra.Forca.Direcao == "Apontada para fora") ||
                                        (forcaBarra.quadrantePontoFinal == "4" && forcaBarra.Forca.Direcao == "Apontada para dentro"))
                                    {
                                        somatoriaForcasVerticais += forcaBarra.Forca.ComponenteVertical;
                                        somatoriaForcasHorizontais -= forcaBarra.Forca.ComponenteHorizontal;
                                    }
                                    else if ((forcaBarra.quadrantePontoFinal == "2" && forcaBarra.Forca.Direcao == "Apontada para dentro") ||
                                        (forcaBarra.quadrantePontoFinal == "4" && forcaBarra.Forca.Direcao == "Apontada para fora"))
                                    {
                                        somatoriaForcasVerticais -= forcaBarra.Forca.ComponenteVertical;
                                        somatoriaForcasHorizontais += forcaBarra.Forca.ComponenteHorizontal;
                                    }
                                }
                               
                            }
                        }

                        calculo1 = 0;
                        calculo2 = 0;
                        calculo3 = 0;
                        calculo4 = 0;
                        encontrouNulo = pontoAnalisado.barrasPonto.FindAll(x => x.Forca.Intensidade == 0);

                        if (quantidadeNulos == 2)
                        {

                            if (encontrouNulo[0].pontoInicialX == pontoAnalisado.valorX 
                                && encontrouNulo[0].pontoInicialY == pontoAnalisado.valorY 
                                && encontrouNulo[1].pontoInicialX == pontoAnalisado.valorX
                                && encontrouNulo[1].pontoInicialY == pontoAnalisado.valorY)
                            {
                                calculo1 = Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180)) *
                                Math.Cos(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) -
                                Math.Sin(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) *
                                Math.Cos(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                                

                                calculo2 = Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180)) *
                                    somatoriaForcasHorizontais -
                                    Math.Cos(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180)) *
                                    somatoriaForcasVerticais;

                                calculo3 = calculo2 / calculo1;
                                calculo4 = (somatoriaForcasVerticais -
                                    Math.Sin(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180))  * calculo3)
                                    / Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                            }
                            else if (encontrouNulo[0].pontoInicialX == pontoAnalisado.valorX
                                && encontrouNulo[0].pontoInicialY == pontoAnalisado.valorY
                                && encontrouNulo[1].pontoFinalX == pontoAnalisado.valorX
                                && encontrouNulo[1].pontoFinalY == pontoAnalisado.valorY)
                            {
                                calculo1 = Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180)) *
                                Math.Cos(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) -
                                Math.Sin(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) *
                                Math.Cos(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));


                                calculo2 = Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180)) *
                                    somatoriaForcasHorizontais -
                                    Math.Cos(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180)) *
                                    somatoriaForcasVerticais;

                                calculo3 = calculo2 / calculo1;
                                calculo4 = (somatoriaForcasVerticais -
                                    Math.Sin(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) * calculo3)
                                    / Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                            }
                            else if (encontrouNulo[0].pontoFinalX == pontoAnalisado.valorX
                                && encontrouNulo[0].pontoFinalY == pontoAnalisado.valorY
                                && encontrouNulo[1].pontoInicialX == pontoAnalisado.valorX
                                && encontrouNulo[1].pontoInicialY == pontoAnalisado.valorY)
                            {
                                calculo1 = Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180)) *
                                Math.Cos(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) -
                                Math.Sin(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) *
                                Math.Cos(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));


                                calculo2 = Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180)) *
                                    somatoriaForcasHorizontais -
                                    Math.Cos(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180)) *
                                    somatoriaForcasVerticais;

                                calculo3 = calculo2 / calculo1;
                                calculo4 = (somatoriaForcasVerticais -
                                    Math.Sin(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) * calculo3)
                                    / Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                            }
                            else if (encontrouNulo[0].pontoFinalX == pontoAnalisado.valorX
                                && encontrouNulo[0].pontoFinalY == pontoAnalisado.valorY
                                && encontrouNulo[1].pontoFinalX == pontoAnalisado.valorX
                                && encontrouNulo[1].pontoFinalY == pontoAnalisado.valorY)
                            {
                                calculo1 = Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180)) *
                                Math.Cos(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) -
                                Math.Sin(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) *
                                Math.Cos(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));


                                calculo2 = Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180)) *
                                    somatoriaForcasHorizontais -
                                    Math.Cos(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180)) *
                                    somatoriaForcasVerticais;

                                calculo3 = calculo2 / calculo1;
                                calculo4 = (somatoriaForcasVerticais -
                                    Math.Sin(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) * calculo3)
                                    / Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                            }

                            string direcao;

                            if(calculo4 > 0)
                            {
                                direcao = "Apontada para dentro";
                            }
                            else
                            {
                                direcao = "Apontada para fora";
                            }

                            encontrouNulo[0].Forca.AdicionaComponentesEncontrados(calculo4, encontrouNulo[0].angle, direcao);

                            if (calculo3 > 0)
                            {
                                direcao = "Apontada para dentro";
                            }
                            else
                            {
                                direcao = "Apontada para fora";
                            }
                            encontrouNulo[1].Forca.AdicionaComponentesEncontrados(calculo3, encontrouNulo[1].angle, direcao);


                        }
                        else if(quantidadeNulos == 1)
                        {
                            if (encontrouNulo[0].pontoInicialX == pontoAnalisado.valorX
                                && encontrouNulo[0].pontoInicialY == pontoAnalisado.valorY)
                            {
                                if (encontrouNulo[0].Forca.Angulo == 90 || encontrouNulo[0].Forca.Angulo == 270)
                                {
                                    calculo1 = somatoriaForcasVerticais /
                                        Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                                }
                                else if (encontrouNulo[0].Forca.Angulo == 0 || encontrouNulo[0].Forca.Angulo == 180)
                                {
                                    calculo1 = somatoriaForcasHorizontais /
                                        Math.Cos(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                                }
                                else
                                {
                                    calculo1 = somatoriaForcasVerticais /
                                        Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                                }
                            }
                            else
                            {
                                if (encontrouNulo[0].Forca.Angulo == 90 || encontrouNulo[0].Forca.Angulo == 270)
                                {
                                    calculo1 = somatoriaForcasVerticais /
                                        Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                                }
                                else if (encontrouNulo[0].Forca.Angulo == 0 || encontrouNulo[0].Forca.Angulo == 180)
                                {
                                    calculo1 = somatoriaForcasHorizontais /
                                        Math.Cos(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                                }
                                else
                                {
                                    calculo1 = somatoriaForcasVerticais /
                                        Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                                }
                            }
                            

                            string direcao;

                            if (calculo1 > 0)
                            {
                                direcao = "Apontada para dentro";
                            }
                            else
                            {
                                direcao = "Apontada para fora";
                            }
                            encontrouNulo[0].Forca.AdicionaComponentesEncontrados(calculo1, encontrouNulo[0].angle, direcao);

                        }
                    }
                }

                encontrouNulo = listaBarras.FindAll(x => x.Forca.Intensidade == 0);
            }
            while (encontrouNulo.Count != 0);


            DesenhaBarras();
            DesenhaForcas();



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
                g.DrawString(barra.Forca.Intensidade.ToString("0.00"), novaFont, Brushes.Black, novoPonto);
            }
            else if (barra.sentidoAngulo == "Crescente" && barra.pontoInicialX >= barra.pontoFinalX &&
                barra.pontoInicialY <= barra.pontoFinalY)
            {
                novoPonto = new Point(barra.pontoFinalX + ((barra.pontoInicialX - barra.pontoFinalX) / 2)
                    - (lbIntensidade.Width / 2), barra.pontoInicialY + ((barra.pontoFinalY - barra.pontoInicialY) / 2)
                     - (lbIntensidade.Height / 2));
                g.DrawString(barra.Forca.Intensidade.ToString("0.00"), novaFont, Brushes.Black, novoPonto);
            }
            else if (barra.sentidoAngulo == "Decrescente" && barra.pontoInicialX <= barra.pontoFinalX &&
                barra.pontoInicialY <= barra.pontoFinalY)
            {
                novoPonto = new Point(barra.pontoInicialX + ((barra.pontoFinalX - barra.pontoInicialX) / 2)
                    - (lbIntensidade.Width / 2), barra.pontoInicialY + ((barra.pontoFinalY - barra.pontoInicialY) / 2)
                    - (lbIntensidade.Height / 2));
                g.DrawString(barra.Forca.Intensidade.ToString("0.00"), novaFont, Brushes.Black, novoPonto);

            }
            else if (barra.sentidoAngulo == "Decrescente" && barra.pontoInicialX >= barra.pontoFinalX &&
                barra.pontoInicialY >= barra.pontoFinalY)
            {
                novoPonto = new Point(barra.pontoFinalX + ((barra.pontoInicialX - barra.pontoFinalX) / 2)
                    - (lbIntensidade.Width / 2), barra.pontoFinalY + ((barra.pontoInicialY - barra.pontoFinalY) / 2)
                    - (lbIntensidade.Height / 2));
                g.DrawString(barra.Forca.Intensidade.ToString("0.00"), novaFont, Brushes.Black, novoPonto);
            }

            g.Dispose();

        }


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
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            frmDeleta f = new frmDeleta();
            f.ShowDialog();
        }

        public void DeletarForcaEvent()
        {
            listaDeletaForca.RemoveAll(pcb => pcb.Name == "iconeDelete");

            foreach (var pontoSeta in listaSetas)
            {
                CriaDeletaForca(pontoSeta);
            }
        }
      
        
    }
}

