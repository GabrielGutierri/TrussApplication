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
        public string DirecaoHorizontal { get; set; }
        public string DirecaoVertical { get; set; }
        public ForcaPonto(double intensidade, double angulo, string sentido, string direcao, int quadrante) : base(intensidade, angulo, sentido,direcao)
        {
            this.Quadrante = quadrante;
            this.Direcao = direcao;
            if (sentido == "inclinada")
                MudaDirecao();
            MudaComponentesAngulo(this);
        }
        public ForcaPonto(double intensidade, double angulo, string sentido, string direcao) : base(intensidade, angulo, sentido, direcao)
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
            if (sentido == "inclinada")
                MudaDirecao();
            if (this.ComponenteHorizontal == 0 || this.ComponenteVertical == 0)
                MudaComponentesAngulo(this);
        }
        public void MudaComponentesAngulo(ForcaPonto forca)
        {
            const double constAngle = Math.PI / 180;

            if (this.Quadrante == 2)
            {
                forca.ComponenteVertical = Math.Round(Math.Sin(-(forca.Angulo - 180) * constAngle) * forca.Intensidade, 6);
                forca.ComponenteHorizontal = Math.Round(Math.Cos((forca.Angulo - 180) * constAngle) * forca.Intensidade, 6);
            }
            if (this.Quadrante == 3)
            {
                forca.ComponenteVertical = Math.Round(Math.Sin(-(forca.Angulo - 180) * constAngle) * forca.Intensidade, 6);
                forca.ComponenteHorizontal = Math.Round(Math.Cos((forca.Angulo - 180) * constAngle) * forca.Intensidade, 6);

            }
            if (this.Quadrante == 4)
            {
                forca.ComponenteVertical = Math.Round(Math.Sin(-(Math.Abs(forca.Angulo - 360)) * constAngle) * forca.Intensidade, 6);
                forca.ComponenteHorizontal = Math.Round(Math.Cos(Math.Abs((forca.Angulo - 360)) * constAngle) * forca.Intensidade, 6);
            }
        }
        public void MudaDirecao()
        {
            if(this.Quadrante == 1)
            {
                if (this.Direcao == "Apontada para fora")
                {
                    this.DirecaoVertical = "cima";
                    this.DirecaoHorizontal = "direita";
                }
                else
                {
                    this.DirecaoVertical = "baixo";
                    this.DirecaoHorizontal = "esquerda";
                }
            }
            if(this.Quadrante == 2)
            {
                if (this.Direcao == "Apontada para fora")
                {
                    this.DirecaoVertical = "cima";
                    this.DirecaoHorizontal = "esquerda";
                }
                else
                {
                    this.DirecaoVertical = "baixo";
                    this.DirecaoHorizontal = "direita";
                }
            }
            if (this.Quadrante == 3)
            {
                if (this.Direcao == "Apontada para fora")
                {
                    this.DirecaoVertical = "baixo";
                    this.DirecaoHorizontal = "esquerda";
                }
                else
                {
                    this.DirecaoVertical = "cima";
                    this.DirecaoHorizontal = "direita";
                }
            }
            if (this.Quadrante == 4)
            {
                if (this.Direcao == "Apontada para fora")
                {
                    this.DirecaoVertical = "baixo";
                    this.DirecaoHorizontal = "direita";
                }
                else
                {
                    this.DirecaoVertical = "cima";
                    this.DirecaoHorizontal = "esquerda";
                }
            }
        }
    }
}
