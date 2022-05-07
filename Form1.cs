using Software_Trelisa.Properties;
using System.Drawing.Drawing2D;

namespace Software_Trelisa
{
    public partial class Form1 : Form
    {
        public static List<Barra> listaBarras = new List<Barra>();
        public static List<Ponto> listaPontos = new List<Ponto>();
        List<PictureBox> listaPictureBox = new List<PictureBox>();
        
        List<Ponto> listaDeletar = new List<Ponto>();
        bool querDeletar = false;
        string teste = "teste";

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
            Ponto ponto = new Ponto(125, 250);
            listaPontos.Add(ponto);
            CriaPontoImagem(ponto);
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

        private static Bitmap RotateImg(Bitmap bmp, float angle, Ponto ponto)
        {
            int w = bmp.Width;
            int h = bmp.Height;
            Bitmap tempImg = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(tempImg);
            g.TranslateTransform(w / 2, h / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-w/2, -h / 2);
            Point newPoint = new Point(ponto.valorX, ponto.valorY);
            g.DrawImage(bmp, new Point(0,0));
            return tempImg;
        }

        private int PosicaoXDesenhoForca(int quadrante, double angulo)
        {
            switch (quadrante) {
                case 1:
                    return -20 + (Convert.ToInt32((5 / 15) * angulo));
                case 2:
                    return -20 - (Convert.ToInt32((5 / 15) * (0 - angulo)));
                case 3:
                    return -20 - (Convert.ToInt32((5 / 15) * angulo));
                default:
                    return -20 + (Convert.ToInt32((5 / 15) * (0 - angulo)));
            }
        }

        private int PosicaoYDesenhoForca(int quadrante, double angulo)
        {
            switch (quadrante)
            {
                case 1:
                    return -35 + (Convert.ToInt32((5 / 30) * angulo));
                case 2:
                    return -35 - (Convert.ToInt32((5 / 30) * (0 - angulo)));
                case 3:
                    return -10 + Convert.ToInt32((-5 / 30) * angulo);
                default:
                    return -10 + Convert.ToInt32((-5 / 30) * (0 - angulo));
            }
        }
        public void DesenhaForca(Image imagem, Ponto ponto, Forca forca)
        {
            int quadrante = 1;
            int valorX = PosicaoXDesenhoForca(quadrante, forca.Angulo);
            int valorY = PosicaoYDesenhoForca(quadrante, forca.Angulo);
            MessageBox.Show($"X:{ponto.valorX + valorX} - {ponto.valorY + valorY}");
            float angulo = (float)AnguloQuadrante(quadrante, forca.Angulo);
            System.Windows.Forms.PictureBox novoPontoImagem = new System.Windows.Forms.PictureBox();
            novoPontoImagem.Image = imagem;
            novoPontoImagem.SizeMode = PictureBoxSizeMode.StretchImage;
            novoPontoImagem.BackColor = Color.White;
            novoPontoImagem.Width = 60;
            novoPontoImagem.Height = 60;
            novoPontoImagem.Location = new Point(ponto.valorX + valorX +20, ponto.valorY + valorY); // mudar a posicao de acordo com o quadrante da força
            panelDesenho.Controls.Add(novoPontoImagem);
            Bitmap bitmap = (Bitmap)novoPontoImagem.Image;
            
            novoPontoImagem.Image = (Image)(RotateImg(bitmap, angulo, ponto));
        }
        private double AnguloQuadrante(int quadrante, double angulo)
        {
            if (quadrante == 1 )
                return 90 - angulo;
            if (quadrante == 2)
                return 0 - (90 - angulo);
            if (quadrante == 3)
                return 270 - angulo;
            else
                return  (180 - angulo);
        }
        private void DesenhaForcas()
        {
            foreach (Ponto ponto in listaPontos)
            {
                foreach (var forca in ponto.forcasPonto)
                {
                    DesenhaForca(Resources.setaForcaBaixo, ponto, forca); //Cima virou baixo e baixo virou cima
                }
            }
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
            Barra barra1 = new Barra(75, 500, 125, 230, 79.509, 274.59060);
            Barra barra2 = new Barra(75, 500, 575, 500, 0, 500);
            Barra barra3 = new Barra(575, 500, 575, 150, 90, 350);
            Barra barra4 = new Barra(125, 230, 575, 500, 30.96376, 524.78);
            Barra barra5 = new Barra(125, 230, 575, 150, 10.0806, 457.06);
            Barra barra6 = new Barra(575, 150, 825, 500, 54.46232, 430.12);
            Barra barra7 = new Barra(825, 500, 575, 500, 0, 250);
            
            listaPontos[0].barrasPonto.Add(barra1);
            listaPontos[0].barrasPonto.Add(barra2);
            Ponto ponto2 = new Ponto(125, 230);
            ponto2.barrasPonto.Add(barra1);
            ponto2.barrasPonto.Add(barra4);
            ponto2.barrasPonto.Add(barra5);
            Ponto ponto3 = new Ponto(575, 500);
            ponto3.barrasPonto.Add(barra2);
            ponto3.barrasPonto.Add(barra3);
            ponto3.barrasPonto.Add(barra4);
            ponto3.barrasPonto.Add(barra7);
            Ponto ponto4 = new Ponto(575, 150);
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
        }
    }
}

