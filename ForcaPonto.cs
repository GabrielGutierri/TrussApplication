using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class ForcaPonto: Forca
    {
        public int Quadrante { get; set; }
        public ForcaPonto(double intensidade, double angulo, string sentido, string direcao, int quadrante) : base(intensidade, angulo, sentido)
        {
            this.Quadrante = quadrante;
            this.Direcao = direcao;
        }
        public ForcaPonto(double intensidade, double angulo, string sentido, string direcao) : base(intensidade, angulo, sentido)
        {
            if (angulo >= 0 && angulo <= 90)
                this.Quadrante = 1;
            if (angulo > 90 && angulo <= 180)
                this.Quadrante = 2;
            if (angulo > 180 && angulo <= 270)
                this.Quadrante = 3;
            if (angulo > 270 && angulo <= 360)
                this.Quadrante = 4;
            this.Direcao = direcao;
        }
    }
}
