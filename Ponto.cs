using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class Ponto
    {
        public int valorX, valorY;
        public List<Barra> barrasPonto = new List<Barra>();

        public Ponto(int x, int y)
        {
            valorX = x;
            valorY = y;
        }
    }
}
