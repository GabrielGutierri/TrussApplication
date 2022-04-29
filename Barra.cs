using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class Barra
     {
        int x;
        // TRUE = CIMA OU DIREITA
        // FALSE = BAIXO OU ESQUERDA
        public int pontoInicialX, pontoInicialY, pontoFinalX, pontoFinalY, forca;
        public bool estainclinada = true, sentidoVertical = true, sentidoHorizontal = false;
        public double angle, distancia;

        public Barra(int pontoX, int pontoY, int pontoFX, int pontoFY, double angulo, double distancia)
        {
            pontoInicialX = pontoX;
            pontoInicialY = pontoY;
            pontoFinalX = pontoFX;
            pontoFinalY = pontoFY;
            angle = angulo;
            this.distancia = distancia;

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
        }
    }
}
