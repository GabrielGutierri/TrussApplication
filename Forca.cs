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
            Angulo = angulo;
            this.Sentido = sentido;
            this.ComponenteVertical = Intensidade * Math.Sin(Angulo * (Math.PI / 180));
            this.ComponenteHorizontal = Intensidade * Math.Cos(Angulo * (Math.PI / 180));
        }

        public void AdicionaComponentesEncontrados(double intensidade, double angle)
        {
            Angulo = angle;
            this.ComponenteVertical = intensidade * Math.Sin(Angulo * (Math.PI / 180));
            this.ComponenteHorizontal = Math.Round(intensidade * Math.Cos(Angulo * (Math.PI / 180)), 6);
        }
    }
}
