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
        public ForcaBarra(double intensidade, double angulo, string sentido, List<Ponto> pontos) : base(intensidade, angulo, sentido)
        {
            this.pontosBarras = pontos;
        }


    }
}
