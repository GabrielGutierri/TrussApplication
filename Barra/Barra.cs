using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class Barra
     {
        // TRUE = CIMA OU DIREITA
        // FALSE = BAIXO OU ESQUERDA
        public int pontoInicialX, pontoInicialY, pontoFinalX, pontoFinalY;
        public string sentidoAngulo;
        public string quadrantePontoInicial, quadrantePontoFinal;
        public ForcaBarra Forca { get; set; }
        public string Sentido { get; set; }
        public bool estainclinada = true, sentidoVertical = true, sentidoHorizontal = false;
        public double angle, distancia, anguloPontoInicial, anguloPontoFinal;

        public Barra(int pontoX, int pontoY, int pontoFX, int pontoFY, double angulo, double distancia, string sentidoBarra)
        {
            pontoInicialX = pontoX;
            pontoInicialY = pontoY;
            pontoFinalX = pontoFX;
            pontoFinalY = pontoFY;
            angle = angulo;
            this.distancia = distancia;
            sentidoAngulo = sentidoBarra;

            if (pontoFinalX - pontoInicialX > 0)
            {
                sentidoHorizontal = true;
            }
            if (pontoFinalY - pontoInicialY > 0)
            {
                sentidoVertical = false;

            }
            if (pontoFinalX - pontoInicialX == 0 | pontoFinalY - pontoInicialY == 0)
            {
                estainclinada = false;
            }
            defineSentido();
            defineAngulos();

            Forca= new ForcaBarra(0, angulo, Sentido, "Apontada para dentro");

        }
        public void defineSentido()
        {
            if (estainclinada)
                this.Sentido = "inclinada";
            if (sentidoHorizontal && estainclinada == false)
                this.Sentido = "horizontal";
            if (sentidoVertical && estainclinada == false)
                this.Sentido = "vertical";
        }

        public void defineAngulos()
        {
            if(sentidoAngulo == "Crescente" && pontoInicialX <= pontoFinalX && pontoInicialY >= pontoFinalY)
            {
                anguloPontoInicial = angle;
                quadrantePontoInicial = "1";
                anguloPontoFinal = 180 + angle;
                quadrantePontoFinal = "3";
            }
            else if(sentidoAngulo == "Crescente" && pontoInicialX >= pontoFinalX && pontoInicialY <= pontoFinalY)
            {
                anguloPontoInicial = 180 + angle;
                quadrantePontoInicial = "3";
                anguloPontoFinal = angle;
                quadrantePontoFinal = "1";
            }
            else if(sentidoAngulo == "Decrescente" && pontoInicialX <= pontoFinalX && pontoInicialY <= pontoFinalY)
            {
                anguloPontoInicial = -angle;
                quadrantePontoInicial = "4";
                anguloPontoFinal = -180 -angle;
                quadrantePontoFinal = "2";
            }
            else if(sentidoAngulo == "Decrescente" && pontoInicialX >= pontoFinalX && pontoInicialY >= pontoFinalY)
            {
                anguloPontoInicial = -180 -angle;
                quadrantePontoInicial = "2";
                anguloPontoFinal = -angle;
                quadrantePontoFinal = "4";
            }
        }
    }
}
