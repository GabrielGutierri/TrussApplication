using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public abstract class Forca
    {
        public double Intensidade { get; set; }
        public string Direcao { get; set; }
        public double Angulo { get; set; }
        public double ComponenteVertical { get; set; }
        public double ComponenteHorizontal { get; set; }

        public EnumSentido Sentido { get;}
        
        public Forca(double intensidade, double angulo, int sentido, string direcao)
        {
            Intensidade = intensidade; 
            Angulo = angulo;
            this.Sentido = (EnumSentido)sentido;
            this.ComponenteVertical = Intensidade * Math.Sin(Angulo);
            this.ComponenteHorizontal = Intensidade * Math.Cos(Angulo);
            this.Direcao = direcao;
        }
    }
}
