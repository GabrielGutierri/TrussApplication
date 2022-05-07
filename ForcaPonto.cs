using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class ForcaPonto: Forca
    {
        public ForcaPonto(double intensidade, double angulo, string sentido, string direcao) : base(intensidade, angulo, sentido)
        {
            this.Direcao = direcao;
        }
    }
}
