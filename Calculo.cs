using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public static class Calculo
    {
        public static double CalculaMomentoApoio()
        {
            List<ForcaApoio> forcaApoioFixo = new List<ForcaApoio>();
            ForcaApoio forcaApoioMovel = null;
            Ponto pontoApoioFixo = null;
            Ponto pontoApoioMovel = null;
            
            double somaAntiHorario = 0;
            double somaHorario = 0;
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
                                MessageBox.Show($"{pontoApoioFixo.valorY - item.valorY}");
                                var listaApoio = CalculoMomentoDireita.PontoDireitaApoio(item, pontoApoioFixo);
                                somaHorario += listaApoio[0];
                                somaAntiHorario += listaApoio[1];
                            }
                            if(pontoApoioFixo.valorY - item.valorY < 0) // ponto mais baixo para a direita
                            {
                                MessageBox.Show($"{pontoApoioFixo.valorY + item.valorY}");
                                //var listaApoio = PontoDireitaApoioMaisBaixo(item, pontoApoioFixo);
                                //somaHorario += listaApoio[0];
                                //somaAntiHorario += listaApoio[1];
                            }
                        }
                        if(item.valorX - pontoApoioFixo.valorX < 0) //ponto para a esquerda do ponto fixo
                        {
                            if (pontoApoioFixo.valorY - item.valorY >= 0) // ponto mais alto para a esquerda
                            {
                                var listaSoma = CalculoMomentoDireita.PontoDireitaApoio(pontoApoioFixo, item);
                                somaHorario += listaSoma[0];
                                somaAntiHorario += listaSoma[1];
                            }
                            if (pontoApoioFixo.valorY - item.valorY < 0) // ponto mais baixo para a esquerda
                            {
                            }
                        }
                    }
                }
                
            }
            MessageBox.Show($"{somaAntiHorario} - {somaHorario}");
            MessageBox.Show($"{(somaHorario - somaAntiHorario) / (pontoApoioMovel.valorX - pontoApoioFixo.valorX)}");
            return somaAntiHorario;

        }
        public static double CalculaSoma(double intensidade, string orientacao, int subtracaoQuadrante, double angulo, int pontoReferencia1, double pontoReferencia2)
        {
            double constAngle = 180 / Math.PI;
            if (orientacao == "sen")
            {
                return (intensidade * Math.Sin(-(angulo - subtracaoQuadrante) * constAngle)) * (pontoReferencia1 - pontoReferencia2);
            }
            else
            {
                return (intensidade * Math.Cos((angulo - subtracaoQuadrante) * constAngle)) * (pontoReferencia1 - pontoReferencia2);
            }
        }
    }
}

//Direita 
    //Horizontal
        // Ponto para cima
        // Ponto para baixo
    //Vertical
        //Ponto para cima
        //Ponto para baixo
    //Inclinada
        //Ponto para cima
        //Ponto para baixo
//Esquerda