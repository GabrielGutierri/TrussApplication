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

        public string Sentido { get; set; }
        
        public Forca(double intensidade, double angulo, string sentido)
        {
            Intensidade = intensidade;
            // Esse angulo esta em graus? Talvez tenha que fazer a conversão de graus para radianos.
            Angulo = angulo;
            this.Sentido = sentido;
            this.ComponenteVertical = Intensidade * Math.Sin(Angulo);
            this.ComponenteHorizontal = Intensidade * Math.Cos(Angulo);
        }
    }
}
