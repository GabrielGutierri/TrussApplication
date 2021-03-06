using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Trelisa
{
    public partial class AdicionaBarras : Form
    {
        Barra barra;
        Ponto pontoInicial, pontoFinal;
        int pontoFinalX, pontoFinalY;
        double angulo, distancia ;

        public AdicionaBarras(Ponto ponto)
        {
            InitializeComponent();

            pontoInicial = ponto;
            
        }


        private void VerificaEscala()
        {
            if(Form1.listaBarras.Count == 0 && distancia > 230)
            {
                Form1.escalaDesenho = Math.Round(distancia / 230, 1);
            }
        }
        

        private void rbBarraInclinada_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBarraInclinada.Checked == true)
            {
                gbBarraInclinada.Visible = true;
                gbBarraInclinada.Enabled = true;
            }
            else
            {
                gbBarraInclinada.Enabled = false;
                gbBarraInclinada.Visible = false;
            }
        }

        private void rbBarraVertical_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBarraVertical.Checked == true)
            {
                gbBarraVertical.Visible = true;
                gbBarraVertical.Enabled = true;
            }
            else
            {
                gbBarraVertical.Visible = false;
                gbBarraVertical.Enabled = false;
            }
        }

        private void rbBarraHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBarraHorizontal.Checked == true)
            {
                gbBarraHorizontal.Visible = true;
                gbBarraHorizontal.Enabled = true;
            }
            else
            {
                gbBarraHorizontal.Enabled = false;
                gbBarraHorizontal.Visible = false;
            }
        }

        private void btnCriarBarraVertical_Click(object sender, EventArgs e)
        {
            try
            {
                distancia = Convert.ToDouble(txtDistanciaVertical.Text) / 1 ;
                VerificaEscala();
                angulo = 90;
                distancia = Convert.ToDouble(txtDistanciaVertical.Text) / Form1.escalaDesenho ;
            }
            catch
            {
                MessageBox.Show("Dados Invalidos");
                return;
            }
           

            if (rbCimaVertical.Checked == true)
            {
                pontoFinalX = pontoInicial.valorX;
                pontoFinalY = Convert.ToInt32(pontoInicial.valorY - distancia * Math.Sin(Math.PI * angulo / 180.0));
                VerificaArredondamento();
                pontoFinal = new Ponto(pontoFinalX, pontoFinalY);
                if (VerificaLimitesPanel() == true)
                {
                    return;
                }
                barra = new Barra(pontoInicial.valorX, pontoInicial.valorY, pontoFinalX, pontoFinalY, angulo, distancia, "Crescente");
            }
            else
            {
                
                pontoFinalX = pontoInicial.valorX;
                pontoFinalY = Convert.ToInt32(pontoInicial.valorY + distancia * Math.Sin(Math.PI * angulo / 180.0));
                VerificaArredondamento();
                pontoFinal = new Ponto(pontoFinalX, pontoFinalY);
                if (VerificaLimitesPanel() == true)
                {
                    return;
                }
                barra = new Barra(pontoInicial.valorX, pontoInicial.valorY, pontoFinalX, pontoFinalY, angulo, distancia, "Decrescente");
                
            }

            Form1.listaBarras.Add(barra);
            VerificaPontoExiste(pontoFinal);
            this.Close();
        }

        private void btnCriarBarraHorizontal_Click(object sender, EventArgs e)
        {
            try
            {
                distancia = Convert.ToDouble(txtDistanciaHorizontal.Text) / 1;
                VerificaEscala();
                angulo = 0;
                distancia = Convert.ToDouble(txtDistanciaHorizontal.Text) / Form1.escalaDesenho;
            }
            catch
            {
                MessageBox.Show("Dados Invalidos");
                return;
            }

            if (rbDireitaHorizontal.Checked == true)
            {
                pontoFinalX = Convert.ToInt32(pontoInicial.valorX + distancia * Math.Cos(Math.PI * angulo / 180.0));
                pontoFinalY = pontoInicial.valorY;
                VerificaArredondamento();
                pontoFinal = new Ponto(pontoFinalX, pontoFinalY);
                if (VerificaLimitesPanel() == true)
                {
                    return;
                }
                barra = new Barra(pontoInicial.valorX, pontoInicial.valorY, pontoFinalX, pontoFinalY, angulo, distancia, "Crescente");
            }
            else
            {
                pontoFinalX = Convert.ToInt32(pontoInicial.valorX - distancia * Math.Cos(Math.PI * angulo / 180.0));
                pontoFinalY = pontoInicial.valorY;
                VerificaArredondamento();
                pontoFinal = new Ponto(pontoFinalX, pontoFinalY);
                if (VerificaLimitesPanel() == true)
                {
                    return;
                }
                barra = new Barra(pontoInicial.valorX, pontoInicial.valorY, pontoFinalX, pontoFinalY, angulo, distancia, "Decrescente");
            }

            Form1.listaBarras.Add(barra);
            VerificaPontoExiste(pontoFinal);
            this.Close();
        }

        private void btnCriarBarraInclinado_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDistanciaInclinado.Text == "")
                {
                    distancia = Math.Sqrt(Math.Pow(Convert.ToDouble(txtCatetoAdjacenteInclinado.Text), 2) +
                        Math.Pow(Convert.ToDouble(txtCatetoOpostoInclinado.Text), 2)) / 1;
                }
                else
                {
                    distancia = Convert.ToDouble(txtDistanciaInclinado.Text) / 1;
                }

                VerificaEscala();
                if (txtDistanciaInclinado.Text == "")
                {
                    distancia = Math.Sqrt(Math.Pow(Convert.ToDouble(txtCatetoAdjacenteInclinado.Text), 2) +
                        Math.Pow(Convert.ToDouble(txtCatetoOpostoInclinado.Text), 2)) / Form1.escalaDesenho;
                }
                else
                {
                    distancia = Convert.ToDouble(txtDistanciaInclinado.Text) / Form1.escalaDesenho;
                }
            }
            catch
            {
                MessageBox.Show("Dados Invalidos");
                return;
            }
            
            if(cbTipoInclinacao.SelectedIndex == -1)
            {
                MessageBox.Show("Tipo de inclinação não selecionado");
                return;
            }
            else if (cbTipoInclinacao.SelectedIndex == 0)
            {
                try
                {
                    if (txtAnguloInclinado.Text == "")
                    {
                        angulo = Math.Atan2(Convert.ToDouble(txtCatetoOpostoInclinado.Text), Convert.ToDouble(txtCatetoAdjacenteInclinado.Text)) *
                            (180 / Math.PI);
                    }
                    else
                    {
                        angulo = Convert.ToDouble(txtAnguloInclinado.Text);
                        if(angulo > 90 || angulo < 0)
                        {
                            MessageBox.Show("Angulo precisa estar entre 0 e 90");
                            return;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Dados Invalidos");
                    return;
                }
               
                if (rbSuperiorInclinado.Checked == true)
                {
                    pontoFinalX = Convert.ToInt32(pontoInicial.valorX + distancia * Math.Cos(Math.PI * angulo / 180.0));
                    pontoFinalY = Convert.ToInt32(pontoInicial.valorY - distancia * Math.Sin(Math.PI * angulo / 180.0));
                    VerificaArredondamento();
                    pontoFinal = new Ponto(pontoFinalX, pontoFinalY);
                    if (VerificaLimitesPanel() == true)
                    {
                        return;
                    }
                    barra = new Barra(pontoInicial.valorX, pontoInicial.valorY, pontoFinalX, pontoFinalY, angulo, distancia, "Crescente");
                }
                else
                {
                    pontoFinalX = Convert.ToInt32(pontoInicial.valorX - distancia * Math.Cos(Math.PI * angulo / 180.0));
                    pontoFinalY = Convert.ToInt32(pontoInicial.valorY + distancia * Math.Sin(Math.PI * angulo / 180.0));
                    VerificaArredondamento();
                    pontoFinal = new Ponto(pontoFinalX, pontoFinalY);
                    if (VerificaLimitesPanel() == true)
                    {
                        return;
                    }
                    barra = new Barra(pontoInicial.valorX, pontoInicial.valorY, pontoFinalX, pontoFinalY, angulo, distancia, "Crescente");
                }

            }
            else if (cbTipoInclinacao.SelectedIndex == 1)
            {

                try
                {
                    if (txtAnguloInclinado.Text == "")
                    {
                        angulo = Math.Atan2(Convert.ToDouble(txtCatetoOpostoInclinado.Text), Convert.ToDouble(txtCatetoAdjacenteInclinado.Text)) * (180 / Math.PI);
                    }
                    else
                    {
                        angulo = Convert.ToDouble(txtAnguloInclinado.Text);
                        if (angulo > 90 || angulo < 0)
                        {
                            MessageBox.Show("Angulo precisa estar entre 0 e 90");
                            return;
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Dados Invalidos");
                    return;
                }
                

                if (rbSuperiorInclinado.Checked == true)
                {
                    pontoFinalX = Convert.ToInt32(pontoInicial.valorX - distancia * Math.Cos(Math.PI * angulo / 180.0));
                    pontoFinalY = Convert.ToInt32(pontoInicial.valorY - distancia * Math.Sin(Math.PI * angulo / 180.0));
                    VerificaArredondamento();
                    pontoFinal = new Ponto(pontoFinalX, pontoFinalY);
                    if (VerificaLimitesPanel() == true)
                    {
                        return;
                    }
                    barra = new Barra(pontoInicial.valorX, pontoInicial.valorY, pontoFinalX, pontoFinalY, angulo, distancia, "Decrescente");
                }
                else
                {
                    pontoFinalX = Convert.ToInt32(pontoInicial.valorX + distancia * Math.Cos(Math.PI * angulo / 180.0));
                    pontoFinalY = Convert.ToInt32(pontoInicial.valorY + distancia * Math.Sin(Math.PI * angulo / 180.0));
                    VerificaArredondamento();
                    pontoFinal = new Ponto(pontoFinalX, pontoFinalY);
                    if (VerificaLimitesPanel() == true)
                    {
                        return;
                    }
                    barra = new Barra(pontoInicial.valorX, pontoInicial.valorY, pontoFinalX, pontoFinalY, angulo, distancia, "Decrescente");
                }

            }

            VerificaPontoExiste(pontoFinal);
            var listaPontosBarra = new List<Ponto>() { pontoInicial, pontoFinal };
            barra.Forca = new ForcaBarra(Convert.ToDouble(null), barra.angle, barra.Sentido,"Apontada para dentro", listaPontosBarra);
            Form1.listaBarras.Add(barra);
            this.Close();
        }

        private void VerificaArredondamento()
        {
            foreach (Ponto ponto in Form1.listaPontos)
            {
                if (pontoFinalX <= (ponto.valorX + 3) & pontoFinalX >= (ponto.valorX - 3) &
                    pontoFinalY <= (ponto.valorY + 3) & pontoFinalY >= (ponto.valorY - 3))
                {
                    pontoFinalX = ponto.valorX;
                    pontoFinalY = ponto.valorY;
                    break;
                }
            }
        }
        private bool VerificaLimitesPanel() 
        {
            Form1 formPrincipal = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (pontoFinal.valorX > formPrincipal.panelDesenho.Width | pontoFinal.valorY > formPrincipal.panelDesenho.Height | pontoFinal.valorX < 0 | pontoFinal.valorY < 0)
            {
                MessageBox.Show("Ponto final fora dos limites permitidos. Tente outra vez");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void VerificaPontoExiste(Ponto pontoNovo)
        {
            Form1 formPrincipal = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (Form1.listaPontos.Find(x => x.valorX == pontoInicial.valorX & x.valorY == pontoInicial.valorY) == null)
            {
                Form1.listaPontos.Add(pontoInicial);
                pontoInicial.barrasPonto.Add(barra);
                formPrincipal.CriaPontoImagem(pontoInicial);
            }
            else
            {
                pontoInicial = Form1.listaPontos.Find(x => x.valorX == pontoInicial.valorX & x.valorY == pontoInicial.valorY);
                pontoInicial.barrasPonto.Add(barra);
            }

            if (Form1.listaPontos.Find(x => x.valorX == pontoNovo.valorX & x.valorY == pontoNovo.valorY) == null)
            {
                Form1.listaPontos.Add(pontoNovo);
                pontoNovo.barrasPonto.Add(barra);
                formPrincipal.CriaPontoImagem(pontoNovo);
            }
            else
            {
                pontoNovo = Form1.listaPontos.Find(x => x.valorX == pontoNovo.valorX & x.valorY == pontoNovo.valorY);
                pontoNovo.barrasPonto.Add(barra);
            }
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            Formularios.AjudaAdicionaBarra f = new Formularios.AjudaAdicionaBarra();
            f.ShowDialog();
        }
    }
}
