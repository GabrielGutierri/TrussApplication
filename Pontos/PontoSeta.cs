using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class PontoSeta
    {
        public int ValorInicialX { get; set; }
        public int ValorInicialY { get; set; }
        public int ValorFinalX { get; set; }
        public int ValorFinalY{get; set;}
        public string Direcao { get; set; }
        public ForcaPonto ForcaPonto { get; set; }
        public PontoSeta(int valorInicialX, int valorInicialY, int valorFinalX, int valorFinalY, string direcao, ForcaPonto forca)
        {
            ValorInicialX = valorInicialX;
            ValorInicialY = valorInicialY;
            ValorFinalX = valorFinalX;
            ValorFinalY = valorFinalY;
            Direcao = direcao;
            ForcaPonto = forca;
        }
    }
}
