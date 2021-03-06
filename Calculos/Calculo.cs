using Software_Trelisa.Calculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public static class Calculo
    {
        public static double somaAntiHorario = 0;
        public static double somaHorario = 0;
        public static void CalculaMomentoApoio()
        {
            List<ForcaApoio> forcaApoioFixo = new List<ForcaApoio>();
            ForcaApoio forcaApoioMovel = null;
            Ponto pontoApoioFixo = null;
            Ponto pontoApoioMovel = null;
            
            foreach (var item in Form1.listaPontos)
            {
                if(item.forcasApoio.Count == 2) //verificar se tem apoio nesse ponto
                {
                    forcaApoioFixo.Add(item.forcasApoio[0]);
                    forcaApoioFixo.Add(item.forcasApoio[1]);
                    pontoApoioFixo = item;
                }

                if (item.forcasApoio.Count == 1)
                {
                    forcaApoioMovel = item.forcasApoio[0];
                    pontoApoioMovel = item;
                }
            }

            if (pontoApoioFixo != null)
            {
                foreach (var item in Form1.listaPontos)
                {
                    if (item.forcasPonto.Count > 0)
                    {
                        if (item.valorX - pontoApoioFixo.valorX >= 0) //ponto para a direita do ponto fixo
                        {
                            if (pontoApoioFixo.valorY - item.valorY >= 0) // ponto mais alto para a direita
                            {
                                var listaApoio = CalculoMomentoDireita.PontoDireitaApoio(item, pontoApoioFixo);
                                somaHorario += listaApoio[0];
                                somaAntiHorario += listaApoio[1];
                            }
                            if(pontoApoioFixo.valorY - item.valorY < 0) // ponto mais baixo para a direita
                            {
                                var listaApoio = CalculoMomentoDireita.PontoDireitaApoioMaisBaixo(item, pontoApoioFixo);
                                somaHorario += listaApoio[0];
                                somaAntiHorario += listaApoio[1];
                            }
                        }
                        if(item.valorX - pontoApoioFixo.valorX < 0) //ponto para a esquerda do ponto fixo
                        {
                            if (pontoApoioFixo.valorY - item.valorY >= 0) // ponto mais alto para a esquerda
                            {
                                var listaSoma = CalculoMomentoEsquerda.PontoEsquerdaApoio(item, pontoApoioFixo);
                                somaHorario += listaSoma[0];
                                somaAntiHorario += listaSoma[1];
                            }
                            if (pontoApoioFixo.valorY - item.valorY < 0) // ponto mais baixo para a esquerda
                            {
                                var listaApoio = CalculoMomentoEsquerda.PontoEsquerdaApoioMaisBaixo(item, pontoApoioFixo);
                                somaHorario += listaApoio[0];
                                somaAntiHorario += listaApoio[1];
                            }
                        }
                    }
                }
                
            }
            CalculaForcaApoioMovel(forcaApoioMovel, pontoApoioMovel, pontoApoioFixo);
            CalculaForcasApoioFixo(forcaApoioFixo);
        }
        public static void CalculaForcaApoioMovel(ForcaApoio forcaMovel, Ponto pontoApoioMovel, Ponto pontoApoioFixo)
        {
            double intensidadeMovel;
            if(pontoApoioMovel.valorX > pontoApoioFixo.valorX) //apoio movel está para a direita do ponto fixo
            {
                intensidadeMovel = (somaHorario - somaAntiHorario) / (pontoApoioMovel.valorX - pontoApoioFixo.valorX);
            }
            else
            {
                intensidadeMovel = (somaAntiHorario - somaHorario) / (pontoApoioFixo.valorX - pontoApoioMovel.valorX);
            }

            if(intensidadeMovel < 0) //Trocar se formos fazer a parte de apoios móveis para cima ou embaixo. Para a direita no canto = forca para a esquerda
            {
                if(forcaMovel.Sentido == "horizontal")
                {
                    if (pontoApoioMovel.valorX > pontoApoioFixo.valorX)
                        forcaMovel.Direcao = "Apontada para fora";
                    else
                        forcaMovel.Direcao = "Apontada para dentro";
                }
                else
                    forcaMovel.Direcao = "Apontada para dentro";
            }
            forcaMovel.Intensidade = intensidadeMovel;
        }

        public static void CalculaForcasApoioFixo(List<ForcaApoio> forcaApoioFixo)
        {
            CalculaForcasFixo.CalculaVertical(forcaApoioFixo[0]);
            CalculaForcasFixo.CalculaHorizontal(forcaApoioFixo[1]);
        }
        public static double CalculaSoma(ForcaPonto forca, string orientacao, int pontoReferencia1, double pontoReferencia2)
        {
            if (orientacao == "sen")
            {
                return Math.Abs(forca.ComponenteVertical * (pontoReferencia1 - pontoReferencia2));
            }
            else
            {
                return Math.Abs(forca.ComponenteHorizontal * (pontoReferencia1 - pontoReferencia2));
            }
        }

        public static double CalculaSomaReferencial(ForcaPonto forca, string orientacao, int pontoReferencia1, double pontoReferencia2)
        {
            if (orientacao == "sen")
            {
                return Math.Abs(forca.ComponenteVertical * (pontoReferencia1 + pontoReferencia2));
            }
            else
            {
                return Math.Abs(forca.ComponenteHorizontal * (pontoReferencia1 + pontoReferencia2));
            }
        }
    }
}