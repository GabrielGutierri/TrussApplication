using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa.Calculos
{
    public static class CalculoForcasBarras
    {
        static double somatoriaForcasVerticais = 0, somatoriaForcasHorizontais = 0;
        static int quantidadeLoops = 0;

        public static void CalculaForcasBarra()
        {
            int quantidadeNulos;
            List<Barra> encontrouNulo = new List<Barra>();

            do
            {
                foreach (Ponto pontoAnalisado in Form1.listaPontos)
                {
                    if (VerificaPossibilidadeCalculoPonto(pontoAnalisado) == true)
                    {
                        continue;
                    }

                    somatoriaForcasVerticais = 0;
                    somatoriaForcasHorizontais = 0;
                    quantidadeNulos = 0;

                    foreach (Barra barra in pontoAnalisado.barrasPonto)
                    {
                        if (barra.Forca.Intensidade == 0)
                        {
                            quantidadeNulos++;
                        }
                    }

                    if (quantidadeNulos <= 2)
                    {
                        SomatoriaForcasExternas(pontoAnalisado);
                        SomatoriaForcasBarra(pontoAnalisado);

                        encontrouNulo = pontoAnalisado.barrasPonto.FindAll(x => x.Forca.Intensidade == 0);

                        if (quantidadeNulos == 2)
                        {
                            MetodoNinja(pontoAnalisado, encontrouNulo);

                        }
                        else if (quantidadeNulos == 1)
                        {
                            EquacaoSimples(pontoAnalisado, encontrouNulo[0]);
                        }
                    }
                }

                encontrouNulo = Form1.listaBarras.FindAll(x => x.Forca.Intensidade == 0);

                if (VerificaLoop() == true)
                {
                    return;
                }
            }
            while (encontrouNulo.Count != 0);
        }
        private static void SomatoriaForcasExternas(Ponto pontoAnalisado)
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
        }

        private static void SomatoriaForcasBarra(Ponto pontoAnalisado)
        {
            foreach (Barra forcaBarra in pontoAnalisado.barrasPonto)
            {
                if (forcaBarra.Forca.Intensidade != 0)
                {
                    if (forcaBarra.pontoInicialX == pontoAnalisado.valorX
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
        }

        private static void MetodoNinja(Ponto pontoAnalisado, List<Barra> encontrouNulo)
        {
            double calculo1;
            double calculo2;
            double calculo3 = 0;
            double calculo4 = 0;

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

                if(encontrouNulo[0].anguloPontoInicial == 0 || encontrouNulo[0].anguloPontoInicial == 180)
                {
                    calculo4 = (somatoriaForcasHorizontais -
                    Math.Cos(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) * calculo3)
                    / Math.Cos(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                }
                else
                {
                    calculo4 = (somatoriaForcasVerticais -
                    Math.Sin(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) * calculo3)
                    / Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                }
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

                if (encontrouNulo[0].anguloPontoInicial == 0 || encontrouNulo[0].anguloPontoInicial == 180)
                {
                    calculo4 = (somatoriaForcasHorizontais -
                    Math.Cos(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) * calculo3)
                    / Math.Cos(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                }
                else
                {
                    calculo4 = (somatoriaForcasVerticais -
                    Math.Sin(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) * calculo3)
                    / Math.Sin(encontrouNulo[0].anguloPontoInicial * (Math.PI / 180));
                }
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

                if (encontrouNulo[0].anguloPontoFinal == 0 || encontrouNulo[0].anguloPontoFinal == 180)
                {
                    calculo4 = (somatoriaForcasHorizontais -
                    Math.Cos(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) * calculo3)
                    / Math.Cos(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                }
                else
                {
                    calculo4 = (somatoriaForcasVerticais -
                    Math.Sin(encontrouNulo[1].anguloPontoInicial * (Math.PI / 180)) * calculo3)
                    / Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                }
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

                if (encontrouNulo[0].anguloPontoFinal == 0 || encontrouNulo[0].anguloPontoFinal == 180)
                {
                    calculo4 = (somatoriaForcasHorizontais -
                    Math.Cos(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) * calculo3)
                    / Math.Cos(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                }
                else
                {
                    calculo4 = (somatoriaForcasVerticais -
                    Math.Sin(encontrouNulo[1].anguloPontoFinal * (Math.PI / 180)) * calculo3)
                    / Math.Sin(encontrouNulo[0].anguloPontoFinal * (Math.PI / 180));
                }
            }

            AdicionaValoresEncontrados(encontrouNulo[0], calculo4);
            AdicionaValoresEncontrados(encontrouNulo[1], calculo3);
        }

        private static void EquacaoSimples(Ponto pontoAnalisado, Barra encontrouNulo)
        {
            double calculo1;

            if (encontrouNulo.pontoInicialX == pontoAnalisado.valorX
                               && encontrouNulo.pontoInicialY == pontoAnalisado.valorY)
            {
                if (encontrouNulo.Forca.Angulo == 90 || encontrouNulo.Forca.Angulo == 270)
                {
                    calculo1 = somatoriaForcasVerticais /
                        Math.Sin(encontrouNulo.anguloPontoInicial * (Math.PI / 180));
                }
                else if (encontrouNulo.Forca.Angulo == 0 || encontrouNulo.Forca.Angulo == 180)
                {
                    calculo1 = somatoriaForcasHorizontais /
                        Math.Cos(encontrouNulo.anguloPontoInicial * (Math.PI / 180));
                }
                else
                {
                    calculo1 = somatoriaForcasVerticais /
                        Math.Sin(encontrouNulo.anguloPontoInicial * (Math.PI / 180));
                }
            }
            else
            {
                if (encontrouNulo.Forca.Angulo == 90 || encontrouNulo.Forca.Angulo == 270)
                {
                    calculo1 = somatoriaForcasVerticais /
                        Math.Sin(encontrouNulo.anguloPontoFinal * (Math.PI / 180));
                }
                else if (encontrouNulo.Forca.Angulo == 0 || encontrouNulo.Forca.Angulo == 180)
                {
                    calculo1 = somatoriaForcasHorizontais /
                        Math.Cos(encontrouNulo.anguloPontoFinal * (Math.PI / 180));
                }
                else
                {
                    calculo1 = somatoriaForcasVerticais /
                        Math.Sin(encontrouNulo.anguloPontoFinal * (Math.PI / 180));
                }
            }

            AdicionaValoresEncontrados(encontrouNulo, calculo1);
        }

        private static void AdicionaValoresEncontrados(Barra encontrouNulo, double calculo)
        {
            string direcao;

            if (calculo > 0)
            {
                direcao = "Apontada para dentro";
            }
            else
            {
                direcao = "Apontada para fora";
            }

            encontrouNulo.Forca.AdicionaComponentesEncontrados(calculo, encontrouNulo.angle, direcao);

        }

        private static bool VerificaPossibilidadeCalculoPonto(Ponto pontoAnalisado)
        {
            List<Barra> encontrouNulo = pontoAnalisado.barrasPonto.FindAll(x => x.Forca.Intensidade != 0);

            if (pontoAnalisado.forcasPonto.Count == 0 && encontrouNulo.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool VerificaLoop()
        {
            quantidadeLoops++;
            if (quantidadeLoops >= 7)
            {
                MessageBox.Show("Não foi possivel calcular");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
