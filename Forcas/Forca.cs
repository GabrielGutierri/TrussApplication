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
        
        public Forca(double intensidade, double angulo, string sentido, string direcao)
        {
            this.Sentido = sentido;
            AdicionaComponentesEncontrados(intensidade,angulo, direcao);
        }

        public void AdicionaComponentesEncontrados(double intensidade, double angle, string direcao)
        {
            Direcao = direcao;
            Angulo = angle;

            if (intensidade < 0)
            {
                Intensidade = -intensidade;
            }
            else
            {
                Intensidade = intensidade;
            }
            this.ComponenteVertical = Math.Round(Intensidade * Math.Sin(Angulo * (Math.PI / 180)), 6);
            this.ComponenteHorizontal = Math.Round(Intensidade * Math.Cos(Angulo * (Math.PI / 180)), 6);
        
        
        }
    }
}
