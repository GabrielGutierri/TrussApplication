using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class ForcaBarra : Forca
    {
        public List<Ponto> pontosBarras { get; set; }
        public ForcaBarra(double intensidade, double angulo, string sentido, string direcao, List<Ponto> pontos) : base(intensidade, angulo, sentido, direcao)
        {
            this.pontosBarras = pontos;

        }

        public ForcaBarra(double intensidade, double angulo, string sentido, string direcao) : base(intensidade, angulo, sentido, direcao)
        {
            
        }

       

    }
}
