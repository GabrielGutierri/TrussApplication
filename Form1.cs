using Software_Trelisa.Properties;
using System.Drawing.Drawing2D;

namespace Software_Trelisa
{
    public partial class Form1 : Form
    {
        public static List<Barra> listaBarras = new List<Barra>();
        public static List<Ponto> listaPontos = new List<Ponto>();
        public static List<PontoSeta> listaSetas = new List<PontoSeta>();
        List<PictureBox> listaPictureBox = new List<PictureBox>();
        List<Ponto> listaDeletar = new List<Ponto>();
        List<PictureBox> listaDeletaForca = new List<PictureBox>();
        bool querDeletar = false;

        Ponto pontoTeste { get; set; }

        public  Form1()
        {
            InitializeComponent();
            AdicionaPrimeiroPonto();
       
        }

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

        private void DesenhaForcas()
        {
            Graphics g = panelDesenho.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            Pen p = new Pen(Color.Red, 6.0f);
            p.CustomStartCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5, false);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            foreach (Ponto ponto in listaPontos)
            {
                foreach (var forca in ponto.forcasPonto)
                {
                    var valorXPonto = ponto.valorX + Convert.ToInt32(75 * Math.Cos(forca.Angulo * (Math.PI / 180)));
                    var valorYPonto = ponto.valorY + Convert.ToInt32(75 * Math.Sin(-forca.Angulo * (Math.PI / 180)));
                    if (forca.Direcao == "Apontada para fora")
                    {
                        g.DrawLine(p, valorXPonto, valorYPonto, ponto.valorX, ponto.valorY); //ponto da força é o ponto inicial
                        listaSetas.Add(new PontoSeta(valorXPonto, valorYPonto, ponto.valorX, ponto.valorY, forca.Direcao, forca));
                    }
                    else {
                        g.DrawLine(p, ponto.valorX, ponto.valorY, valorXPonto, valorYPonto); // ponto é o inical
                        listaSetas.Add(new PontoSeta(ponto.valorX, ponto.valorY, valorXPonto, valorYPonto, forca.Direcao, forca));
                    }
                }
            }
            g.Dispose();
            p.Dispose();
        }

        private void DesenhaBarras()
        {
            Graphics g = panelDesenho.CreateGraphics();
            Pen myPen = new Pen(Color.Gray, 8);
            g.Clear(panelDesenho.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            foreach (Barra barras in listaBarras)
            {
                g.DrawLine(myPen, barras.pontoInicialX, barras.pontoInicialY, barras.pontoFinalX, barras.pontoFinalY);
                
            }
            g.Dispose();
            myPen.Dispose();
        }

        private void QuerDeletar(Ponto ponto)
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
          
        private void btnCriar_Click(object sender, EventArgs e)
        {
            lbDeletar.Visible = false;
            lbMensagem.Visible = true;
            foreach (PictureBox imagem in listaPictureBox)
            {
                imagem.Enabled = true;
                imagem.Visible = true;
            }
            foreach (var item in listaDeletaForca)
            {
                item.Enabled = false;
                item.Visible = false;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            ForcaBarra forcaNula1 = new ForcaBarra(0, 79.509, "");
            Barra barra1 = new Barra(75, 500, 125, 230, 79.509, 274.59060, forcaNula1);
            ForcaBarra forcaNula2 = new ForcaBarra(0, 0, "");
            Barra barra2 = new Barra(75, 500, 575, 500, 0, 500, forcaNula2);
            ForcaBarra forcaNula3 = new ForcaBarra(0, 90, "");
            Barra barra3 = new Barra(575, 500, 575, 150, 90, 350, forcaNula3);
            ForcaBarra forcaNula4 = new ForcaBarra(0, 30.96376, "");
            Barra barra4 = new Barra(125, 230, 575, 500, 30.96376, 524.78, forcaNula4);
            ForcaBarra forcaNula5 = new ForcaBarra(0, 10.0806, "");
            Barra barra5 = new Barra(125, 230, 575, 150, 10.0806, 457.06, forcaNula5);
            ForcaBarra forcaNula6 = new ForcaBarra(0, 54.46232, "");
            Barra barra6 = new Barra(575, 150, 825, 500, 54.46232, 430.12, forcaNula6);
            ForcaBarra forcaNula7 = new ForcaBarra(0, 0, "");
            Barra barra7 = new Barra(825, 500, 575, 500, 0, 250, forcaNula7);
            
            listaPontos[0].barrasPonto.Add(barra1);
            listaPontos[0].barrasPonto.Add(barra2);

            this.pontoTeste.forcasApoio.Add(new ForcaApoio(0, 90, "Apontada para fora", "vertical", "fixo"));
            this.pontoTeste.forcasApoio.Add(new ForcaApoio(0, 0, "Apontada para fora","horizontal","fixo"));
            Ponto ponto2 = new Ponto(125, 230);
            ponto2.forcasPonto.Add(new ForcaPonto(12000, 90, "Apontada para dentro", "vertical"));
            ponto2.forcasPonto.Add(new ForcaPonto(15000, 0, "Apontada para dentro", "horizontal"));
            ponto2.barrasPonto.Add(barra1);
            ponto2.barrasPonto.Add(barra4);
            ponto2.barrasPonto.Add(barra5);
            Ponto ponto3 = new Ponto(575, 500);
            ponto3.forcasPonto.Add(new ForcaPonto(8000, 270, "Apontada para dentro", "vertical"));
            ponto3.barrasPonto.Add(barra2);
            ponto3.barrasPonto.Add(barra3);
            ponto3.barrasPonto.Add(barra4);
            ponto3.barrasPonto.Add(barra7);
            Ponto ponto4 = new Ponto(575, 150);
            ponto4.forcasPonto.Add(new ForcaPonto(35000, 120, "Apontada para dentro", "inclinado"));
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
            ponto5.forcasApoio.Add(new ForcaApoio(0, 90, "Apontada para fora", "vertical", "movel"));

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

        private void lbDeletar_Click(object sender, EventArgs e)
        {

        }

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
            foreach (PictureBox pcb in listaDeletaForca)
            {
                pcb.Enabled = false;
                pcb.Visible = false;
                pcb.SendToBack();
            }
        }

        public void deletaForca_Click(object sender, EventArgs e, PontoSeta pontoSeta)
        {
            
            PontoSeta ponto = listaSetas.Find(p => (p.ValorFinalX == pontoSeta.ValorFinalX
                                                && p.ValorFinalY == pontoSeta.ValorFinalY
                                                && p.ValorInicialX == pontoSeta.ValorInicialX
                                                && p.ValorInicialY == pontoSeta.ValorInicialY));
            listaSetas.Remove(ponto);
            if (ponto != null) {
                
                var pontoForca = listaPontos.Find(f => (f.valorX == ponto.ValorInicialX && f.valorY == ponto.ValorInicialY) || (f.valorX == ponto.ValorFinalX && f.valorY == ponto.ValorFinalY));
                pontoForca.forcasPonto.Remove(ponto.ForcaPonto);
                
            }
            //}
            DesenhaBarras();
            DesenhaForcas();
        }
        public void CriaDeletaForca(PontoSeta pontoSeta)
        {
            PictureBox imagemDeleta = new PictureBox();
            imagemDeleta.Image = Resources.iconeDelete;
            imagemDeleta.Name = "delete icon";
            imagemDeleta.SizeMode = PictureBoxSizeMode.StretchImage;
            imagemDeleta.Height = 20;
            imagemDeleta.Width = 20;
            imagemDeleta.Location = new Point((pontoSeta.ValorFinalX + pontoSeta.ValorInicialX) / 2, (pontoSeta.ValorInicialY + pontoSeta.ValorFinalY) / 2);
            imagemDeleta.Visible = true;
            imagemDeleta.Click += new EventHandler((sender, e) => deletaForca_Click(sender, e, pontoSeta));
            listaDeletaForca.Add(imagemDeleta);
            panelDesenho.Controls.Add(imagemDeleta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string teste = "";
            int quantidadeNulos;
            double somatoriaForcasVerticais = 0, somatoriaForcasHorizontais = 0;
            double calculo1, calculo2, calculo3, calculo4;

            List<Barra> encontrouNulo = new List<Barra>();
            do
            {
                foreach (Ponto pontoAnalisado in listaPontos)
                {
                    somatoriaForcasVerticais = 0;
                    somatoriaForcasHorizontais = 0;
                    quantidadeNulos = 0;

                    foreach(Barra barraAnalisado in pontoAnalisado.barrasPonto)
                    {
                        if(barraAnalisado.Forca.Intensidade == 0)
                        {
                            quantidadeNulos++;
                        }
                    }

                    if (quantidadeNulos <= 2)
                    {
                        encontrouNulo = pontoAnalisado.barrasPonto.FindAll(x => x.Forca.Intensidade == 0);

                        if (pontoAnalisado.forcasPonto == null)
                        {
                            continue;
                        }


                        foreach (ForcaPonto forcaPonto in pontoAnalisado.forcasPonto)
                        {
                            if (forcaPonto.Sentido == "vertical" && forcaPonto.Direcao == "Apontada para fora")
                            {
                                somatoriaForcasVerticais += forcaPonto.ComponenteVertical;
                            }
                            else if (forcaPonto.Sentido == "vertical" && forcaPonto.Direcao == "Apontada para dentro")
                            {
                                somatoriaForcasVerticais -= forcaPonto.ComponenteVertical;
                            }
                            
                            if (forcaPonto.Sentido == "horizontal" && forcaPonto.Direcao == "Apontada para fora")
                            {
                                somatoriaForcasHorizontais += forcaPonto.ComponenteHorizontal;
                            }
                            else if (forcaPonto.Sentido == "horizontal" && forcaPonto.Direcao == "Apontada para dentro")
                            {
                                somatoriaForcasHorizontais -= forcaPonto.ComponenteHorizontal;
                            }
                        }

                        foreach(Barra forcaBarra in pontoAnalisado.barrasPonto)
                        {
                            if(forcaBarra.Forca.Intensidade != 0 || forcaBarra.Forca.Intensidade != 0)
                            {
                                if (forcaBarra.Forca.Sentido == "vertical" && forcaBarra.Forca.Direcao == "Apontada para fora")
                                {
                                    somatoriaForcasVerticais += forcaBarra.Forca.ComponenteVertical;
                                }
                                else if (forcaBarra.Forca.Sentido == "vertical" && forcaBarra.Forca.Direcao == "Apontada para dentro")
                                {
                                    somatoriaForcasVerticais -= forcaBarra.Forca.ComponenteVertical;
                                }

                                if (forcaBarra.Forca.Sentido == "horizontal" && forcaBarra.Forca.Direcao == "Apontada para fora")
                                {
                                    somatoriaForcasHorizontais += forcaBarra.Forca.ComponenteHorizontal;
                                }
                                else if (forcaBarra.Forca.Sentido == "horizontal" && forcaBarra.Forca.Direcao == "Apontada para dentro")
                                {
                                    somatoriaForcasHorizontais -= forcaBarra.Forca.ComponenteHorizontal;
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
                            calculo1 = (Math.Sin(encontrouNulo[0].Forca.Angulo * (Math.PI / 180)) * (180/Math.PI) *
                                Math.Cos(encontrouNulo[1].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI)) - 
                                (Math.Cos(encontrouNulo[0].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI) *
                                Math.Sin(encontrouNulo[1].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI));

                            calculo2 = (Math.Sin(encontrouNulo[0].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI) *
                                somatoriaForcasHorizontais) - 
                                (Math.Cos(encontrouNulo[0].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI) *
                                somatoriaForcasVerticais);

                            calculo3 = calculo2 / calculo1;
                            calculo4 = (somatoriaForcasVerticais -
                                (Math.Cos(encontrouNulo[1].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI) * calculo3)
                                / Math.Sin(encontrouNulo[0].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI));



                            encontrouNulo[0].Forca.Intensidade = calculo4;
                            encontrouNulo[0].Forca.AdicionaComponentesEncontrados(calculo4, encontrouNulo[0].angle);
                            teste += " /// " + calculo4;
                            encontrouNulo[1].Forca.Intensidade = calculo3;
                            encontrouNulo[1].Forca.AdicionaComponentesEncontrados(calculo3, encontrouNulo[1].angle);
                            teste += " /// " + calculo3;

                        }
                        else if(quantidadeNulos == 1)
                        {
                            if(encontrouNulo[0].Forca.ComponenteVertical != 0)
                            {
                                calculo1 = somatoriaForcasVerticais /
                                    Math.Sin(encontrouNulo[0].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI);
                            }
                            else if(encontrouNulo[0].Forca.ComponenteHorizontal != 0)
                            {
                                calculo1 = somatoriaForcasHorizontais /
                                    Math.Cos(encontrouNulo[0].Forca.Angulo * (Math.PI / 180)) * (180 / Math.PI);
                            }

                            encontrouNulo[0].Forca.Intensidade = calculo1;
                            encontrouNulo[0].Forca.AdicionaComponentesEncontrados(calculo1, encontrouNulo[0].angle);
                            teste += " /// " + calculo1;
                        }
                    }
                }

                encontrouNulo = listaBarras.FindAll(x => x.Forca.Intensidade == 0);
            }
            while (encontrouNulo != null);

            txtTeste.Text = teste;
            
        }
    

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            listaDeletaForca.RemoveAll(pcb => pcb.Name == "delete icon");

            foreach (var pontoSeta in listaSetas)
            {
                CriaDeletaForca(pontoSeta);
                
            }
        }
    }
}

