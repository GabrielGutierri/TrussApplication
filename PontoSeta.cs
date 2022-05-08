using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class PontoSeta : Ponto
    {
        public int ValorFinalX { get; set; }
        public int ValorFinalY{get; set;}
        public string Direcao { get; set; }
        public PontoSeta(int valorInicialX, int valorInicialY, int valorFinalX, int valorFinalY, string direcao) : base(valorInicialX, valorInicialY)
        {
            ValorFinalX = valorFinalX;
            ValorFinalY = valorFinalY;
            Direcao = direcao;
        }
    }
}
