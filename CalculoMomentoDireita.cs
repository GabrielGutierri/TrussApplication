using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public static class CalculoMomentoDireita
    {
        public static List<double> PontoDireitaApoio(Ponto item, Ponto pontoApoioFixo)
        {
            double somaHorario = 0;
            double somaAntiHorario = 0;
            double pontoY = item.valorY;
            foreach (var forcaPonto in item.forcasPonto)
            {
                MessageBox.Show($"{forcaPonto.Sentido}");
                if (forcaPonto.Direcao == "Apontada para fora")
                {
                    if (forcaPonto.Sentido == "horizontal" && forcaPonto.Quadrante == 1)
                    {
                        somaHorario += forcaPonto.Intensidade * (pontoApoioFixo.valorY - pontoY);
                    }
                    if (forcaPonto.Sentido == "horizontal" && forcaPonto.Quadrante == 2)
                    {
                        somaAntiHorario += forcaPonto.Intensidade * (pontoApoioFixo.valorY - pontoY);
                    }
                    if (forcaPonto.Sentido == "vertical" && forcaPonto.Quadrante == 1)
                    {
                        somaAntiHorario += forcaPonto.Intensidade * (item.valorX - pontoApoioFixo.valorX);
                    }
                    if (forcaPonto.Sentido == "vertical" && forcaPonto.Quadrante == 3)
                    {
                        somaHorario += forcaPonto.Intensidade * (item.valorX - pontoApoioFixo.valorX);
                    }
                    if (forcaPonto.Sentido == "inclinada")
                    {
                        var listaSoma = CalculaInclinadaForaDireita(forcaPonto, pontoApoioFixo, item, forcaPonto.Quadrante, somaAntiHorario, somaHorario, pontoY);
                        somaHorario += listaSoma[0];
                        somaAntiHorario += listaSoma[1];
                    }
                }
                if (forcaPonto.Direcao == "Apontada para dentro")
                {
                    if (forcaPonto.Sentido == "horizontal" && forcaPonto.Quadrante == 1)
                    {
                        somaAntiHorario += forcaPonto.Intensidade * (pontoApoioFixo.valorY - pontoY);
                    }
                    if (forcaPonto.Sentido == "horizontal" && forcaPonto.Quadrante == 2)
                    {
                        somaHorario += forcaPonto.Intensidade * (pontoApoioFixo.valorY - pontoY);
                    }
                    if (forcaPonto.Sentido == "vertical" && forcaPonto.Quadrante == 1)
                    {
                        somaHorario += forcaPonto.Intensidade * (item.valorX - pontoApoioFixo.valorX);
                    }
                    if (forcaPonto.Sentido == "vertical" && forcaPonto.Quadrante == 3)
                    {
                        somaAntiHorario += forcaPonto.Intensidade * (item.valorX - pontoApoioFixo.valorX);
                    }
                    if (forcaPonto.Sentido == "inclinada")
                    {
                        var listaSoma = CalculaInclinadaDentroDireita(forcaPonto, pontoApoioFixo, item, forcaPonto.Quadrante, somaAntiHorario, somaHorario, pontoY);
                        somaHorario = listaSoma[0];
                        somaAntiHorario = listaSoma[1];

                    }
                }
            }
            return new List<double>() { somaHorario, somaAntiHorario };
        }
        public static List<double> PontoDireitaApoioMaisBaixo(Ponto item, Ponto pontoApoioFixo)
        {
            double somaHorario = 0;
            double somaAntiHorario = 0;
            double pontoY = item.valorY;
            foreach (var forcaPonto in item.forcasPonto)
            {
                
                if (forcaPonto.Direcao == "Apontada para fora")
                {
                    if (forcaPonto.Sentido == "horizontal" && forcaPonto.Quadrante == 1)
                    {
                        somaAntiHorario += forcaPonto.Intensidade * (pontoApoioFixo.valorY - pontoY);
                    }
                    if (forcaPonto.Sentido == "horizontal" && forcaPonto.Quadrante == 2)
                    {
                        somaHorario += forcaPonto.Intensidade * (pontoApoioFixo.valorY - pontoY);
                    }
                    if (forcaPonto.Sentido == "vertical" && forcaPonto.Quadrante == 1)
                    {
                        somaAntiHorario += forcaPonto.Intensidade * (item.valorX - pontoApoioFixo.valorX);
                    }
                    if (forcaPonto.Sentido == "vertical" && forcaPonto.Quadrante == 3)
                    {
                        somaHorario += forcaPonto.Intensidade * (item.valorX - pontoApoioFixo.valorX);
                    }
                    if (forcaPonto.Sentido == "inclinada")
                    {
                        var listaSoma = CalculaInclinadaForaDireitaBaixo(forcaPonto, pontoApoioFixo, item, forcaPonto.Quadrante, somaAntiHorario, somaHorario, pontoY);
                        somaHorario += listaSoma[0];
                        somaAntiHorario += listaSoma[1];
                    }
                }
                if (forcaPonto.Direcao == "Apontada para dentro")
                {
                    if (forcaPonto.Sentido == "horizontal" && forcaPonto.Quadrante == 1)
                    {
                        somaHorario += forcaPonto.Intensidade * (pontoApoioFixo.valorY - pontoY);
                    }
                    if (forcaPonto.Sentido == "horizontal" && forcaPonto.Quadrante == 2)
                    {
                        somaAntiHorario += forcaPonto.Intensidade * (pontoApoioFixo.valorY - pontoY);
                    }
                    if (forcaPonto.Sentido == "vertical" && forcaPonto.Quadrante == 1)
                    {
                        somaHorario += forcaPonto.Intensidade * (item.valorX - pontoApoioFixo.valorX);
                    }
                    if (forcaPonto.Sentido == "vertical" && forcaPonto.Quadrante == 3)
                    {
                        somaAntiHorario += forcaPonto.Intensidade * (item.valorX - pontoApoioFixo.valorX);
                    }
                    if (forcaPonto.Sentido == "inclinada")
                    {
                        var listaSoma = CalculaInclinadaDentroDireitaBaixo(forcaPonto, pontoApoioFixo, item, forcaPonto.Quadrante, somaAntiHorario, somaHorario, pontoY);
                        somaHorario = listaSoma[0];
                        somaAntiHorario = listaSoma[1];

                    }
                }
            }

            return new List<double>() { somaHorario, somaAntiHorario };
        }
        
        private static List<double> CalculaInclinadaForaDireita(ForcaPonto forcaPonto, Ponto pontoApoioFixo, Ponto ponto, int quadrante, double somaAntiHorario, double somaHorario, double pontoY)
        {
            switch (quadrante)
            {
                case 1:
                    somaAntiHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "sen", 0, forcaPonto.Angulo, ponto.valorX, pontoApoioFixo.valorX);
                    somaHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "cos", 0, forcaPonto.Angulo, pontoApoioFixo.valorY, pontoY);
                    break;
                case 2:
                    somaAntiHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "sen", 180, forcaPonto.Angulo, ponto.valorX, pontoApoioFixo.valorX)
                        + Calculo.CalculaSoma(forcaPonto.Intensidade, "cos", 180, forcaPonto.Angulo, pontoApoioFixo.valorY, pontoY);
                    break;
                case 3:
                    somaHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "sen", 270, forcaPonto.Angulo, ponto.valorX, pontoApoioFixo.valorX);
                    somaAntiHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "cos", 270, forcaPonto.Angulo, pontoApoioFixo.valorY, pontoY);
                    break;
                case 4:
                    somaHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "sen", 360, forcaPonto.Angulo, ponto.valorX, pontoApoioFixo.valorX)
                        + Calculo.CalculaSoma(forcaPonto.Intensidade, "cos", 360, forcaPonto.Angulo, pontoApoioFixo.valorY, pontoY);
                    break;
                default:
                    break;
            }
            return new List<double>() { somaHorario, somaAntiHorario };
        }
        private static List<double> CalculaInclinadaDentroDireita(ForcaPonto forcaPonto, Ponto pontoApoioFixo, Ponto ponto, int quadrante, double somaAntiHorario, double somaHorario, double pontoY)
        {
            switch (quadrante)
            {
                case 1:
                    somaHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "sen", 0, forcaPonto.Angulo, ponto.valorX, pontoApoioFixo.valorX); ;
                    somaAntiHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "cos", 0, forcaPonto.Angulo, pontoApoioFixo.valorY, pontoY); ;
                    break;
                case 2:
                    somaHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "sen", 180, forcaPonto.Angulo, ponto.valorX, pontoApoioFixo.valorX)
                        + Calculo.CalculaSoma(forcaPonto.Intensidade, "cos", 180, forcaPonto.Angulo, pontoApoioFixo.valorY, pontoY);
                    break;
                case 3:
                    somaAntiHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "sen", 270, forcaPonto.Angulo, ponto.valorX, pontoApoioFixo.valorX); ;
                    somaHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "cos", 270, forcaPonto.Angulo, pontoApoioFixo.valorY, pontoY);
                    break;
                case 4:
                    somaAntiHorario += Calculo.CalculaSoma(forcaPonto.Intensidade, "sen", 360, forcaPonto.Angulo, ponto.valorX, pontoApoioFixo.valorX)
                        + Calculo.CalculaSoma(forcaPonto.Intensidade, "cos", 360, forcaPonto.Angulo, pontoApoioFixo.valorY, pontoY); ;
                    break;
                default:
                    break;
            }
            return new List<double>() { somaHorario, somaAntiHorario };
        }

        public static List<double> CalculaInclinadaForaDireitaBaixo(ForcaPonto forcaPonto, Ponto pontoApoioFixo, Ponto ponto, int quadrante, double somaAntiHorario, double somaHorario, double pontoY)
        {
            double constAngle = 180 / Math.PI;
            switch (quadrante)
            {
                case 1:
                    somaAntiHorario += (forcaPonto.Intensidade * Math.Sin(-forcaPonto.Angulo * constAngle)) * (ponto.valorX - pontoApoioFixo.valorX) +
                        (forcaPonto.Intensidade * Math.Cos(forcaPonto.Angulo * constAngle)) * (pontoApoioFixo.valorY + pontoY);
                    break;
                case 2:
                    somaAntiHorario += ((forcaPonto.Intensidade * Math.Sin(-(forcaPonto.Angulo - 180) * constAngle)) * (ponto.valorX - pontoApoioFixo.valorX));
                    somaHorario = ((forcaPonto.Intensidade * Math.Cos((forcaPonto.Angulo - 180) * constAngle)) * (pontoApoioFixo.valorY + pontoY));
                    break;
                case 3:
                    somaHorario += (forcaPonto.Intensidade * Math.Sin(-(forcaPonto.Angulo - 270) * constAngle)) * (ponto.valorX - pontoApoioFixo.valorX) +
                        (forcaPonto.Intensidade * Math.Cos((forcaPonto.Angulo - 270) * constAngle)) * (pontoApoioFixo.valorY + pontoY);
                    break;
                case 4:
                    somaHorario += (forcaPonto.Intensidade * Math.Sin(-(forcaPonto.Angulo - 360) * constAngle)) * (ponto.valorX - pontoApoioFixo.valorX);
                    somaAntiHorario += (forcaPonto.Intensidade * Math.Cos((forcaPonto.Angulo - 360) * constAngle)) * (pontoApoioFixo.valorY + pontoY);
                    break;
                default:
                    break;
            }
            return new List<double>() { somaHorario, somaAntiHorario };
        }
        public static List<double> CalculaInclinadaDentroDireitaBaixo(ForcaPonto forcaPonto, Ponto pontoApoioFixo, Ponto ponto, int quadrante, double somaAntiHorario, double somaHorario, double pontoY)
        {
            double constAngle = 180 / Math.PI;
            switch (quadrante)
            {
                case 1:
                    somaHorario += (forcaPonto.Intensidade * Math.Sin(-forcaPonto.Angulo * constAngle)) * (ponto.valorX - pontoApoioFixo.valorX) +
                        (forcaPonto.Intensidade * Math.Cos(forcaPonto.Angulo * constAngle)) * (pontoApoioFixo.valorY + pontoY);
                    break;
                case 2:
                    somaHorario += ((forcaPonto.Intensidade * Math.Sin(-(forcaPonto.Angulo - 180) * constAngle)) * (ponto.valorX - pontoApoioFixo.valorX));
                    somaAntiHorario = ((forcaPonto.Intensidade * Math.Cos((forcaPonto.Angulo - 180) * constAngle)) * (pontoApoioFixo.valorY + pontoY));
                    break;
                case 3:
                    somaAntiHorario += (forcaPonto.Intensidade * Math.Sin(-(forcaPonto.Angulo - 270) * constAngle)) * (ponto.valorX - pontoApoioFixo.valorX) +
                        (forcaPonto.Intensidade * Math.Cos((forcaPonto.Angulo - 270) * constAngle)) * (pontoApoioFixo.valorY + pontoY);
                    break;
                case 4:
                    somaAntiHorario += (forcaPonto.Intensidade * Math.Sin(-(forcaPonto.Angulo - 360) * constAngle)) * (ponto.valorX - pontoApoioFixo.valorX);
                    somaHorario += (forcaPonto.Intensidade * Math.Cos((forcaPonto.Angulo - 360) * constAngle)) * (pontoApoioFixo.valorY + pontoY);
                    break;
                default:
                    break;
            }
            return new List<double>() { somaHorario, somaAntiHorario };
        }
    }
}
