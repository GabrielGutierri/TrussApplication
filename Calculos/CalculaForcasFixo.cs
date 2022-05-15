using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public static class CalculaForcasFixo
    {
        public static void CalculaHorizontal(ForcaApoio forcaHorizontal)
        {
            double somaEsquerda = 0;
            double somaDireita = 0;
            foreach (var ponto in Form1.listaPontos)
            {
                if (ponto.forcasPonto.Count > 0)
                {
                    foreach (var forca in ponto.forcasPonto)
                    {
                        if (forca.DirecaoHorizontal == "esquerda")
                            somaEsquerda += forca.Intensidade * Math.Cos((forca.Angulo - 180) * (Math.PI/180));
                        if (forca.DirecaoHorizontal == "direita")
                            somaDireita += forca.Intensidade * Math.Cos((forca.Angulo - 180) * (Math.PI / 180));
                        if (forca.Sentido == "horizontal")
                        {
                            if ((forca.Quadrante == 1 && forca.Direcao == "Apontada para fora") || (forca.Quadrante == 2 && forca.Direcao == "Apontada para dentro"))
                            {
                                somaDireita += forca.Intensidade;
                            }
                            if ((forca.Quadrante == 1 && forca.Direcao == "Apontada para dentro") || (forca.Quadrante == 2 && forca.Direcao == "Apontada para fora"))
                            {
                                somaEsquerda += forca.Intensidade;
                            }
                        }
                    }
                }
                if (ponto.forcasApoio.Count == 1)
                {
                    var forcaApoioMovel = ponto.forcasApoio[0];
                    if (forcaApoioMovel.Sentido == "horizontal")
                    {
                        if (forcaApoioMovel.Direcao == "Apontada para dentro")
                            somaDireita += forcaApoioMovel.Intensidade;
                        else
                            somaEsquerda += forcaApoioMovel.Intensidade;
                    }
                }
            }

            if (forcaHorizontal.Direcao == "Apontada para fora") //está para a esquerda
                forcaHorizontal.Intensidade = somaDireita - somaEsquerda;
            else
                forcaHorizontal.Intensidade = somaEsquerda - somaDireita;
            MessageBox.Show($"Esquerda: {somaEsquerda} - Direita: {somaDireita}");
            ChecaDirecaoHorizontal(forcaHorizontal);
        }
        private static void ChecaDirecaoHorizontal(ForcaApoio forcaHorizontal)
        {
            if (forcaHorizontal.Intensidade < 0)
            {
                if (forcaHorizontal.Direcao == "Apontada para fora")
                {
                    forcaHorizontal.Direcao = "Apontada para dentro";
                }
                else
                    forcaHorizontal.Direcao = "Apontada para fora";
            }
        }
        public static void CalculaVertical(ForcaApoio forcaVertical)
        {
            double somaCima = 0;
            double somaBaixo = 0;
            foreach (var ponto in Form1.listaPontos)
            {
                if (ponto.forcasPonto.Count > 0)
                {
                    foreach (var forca in ponto.forcasPonto)
                    {
                        if (forca.DirecaoVertical == "cima")
                            somaCima += forca.Intensidade * Math.Sin(-(forca.Angulo - 180) * (Math.PI/180));
                        if (forca.DirecaoVertical == "baixo")
                            somaBaixo += forca.Intensidade * Math.Sin(-(forca.Angulo - 180) * (Math.PI / 180));
                        if (forca.Sentido == "vertical")
                        {
                            if ((forca.Quadrante == 1 && forca.Direcao == "Apontada para fora") || (forca.Quadrante == 3 && forca.Direcao=="Apontada para dentro"))
                            {
                                somaCima += forca.Intensidade;
                            }
                            if ((forca.Quadrante == 1 && forca.Direcao == "Apontada para dentro") || (forca.Quadrante == 3 && forca.Direcao == "Apontada para dfora"))
                            {
                                somaBaixo += forca.Intensidade;
                            }
                        }
                    }
                }
                if (ponto.forcasApoio.Count == 1)
                {
                    var forcaApoioMovel = ponto.forcasApoio[0];
                    if (forcaApoioMovel.Sentido == "vertical") //não trabalhei com apoios móvel para cima nas paredes.
                    {
                        somaCima += forcaApoioMovel.Intensidade;
                    }
                }
            }
            forcaVertical.Intensidade = somaBaixo - somaCima; //só considerei força de apoio fixo para cima
            MessageBox.Show($"Cima: {somaCima} - Baixo: {somaBaixo}");
            ChecaDirecaoVertical(forcaVertical);
        }
        public static void ChecaDirecaoVertical(ForcaApoio forcaVertical)
        {
            if (forcaVertical.Intensidade < 0)
            {
                forcaVertical.Direcao = "Apontada para dentro";
            }
        }
    }
}
