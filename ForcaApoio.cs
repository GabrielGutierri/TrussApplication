using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    internal class ForcaApoio:Forca
    {
        public bool ehApoioFixo { get; set; }
        public ForcaApoio(double intensidade, double angulo, string sentido, string direcao, string tipoApoio) : base(intensidade, angulo, sentido)
        {
            if (tipoApoio == "fixo")
                ehApoioFixo = true;
            else
                ehApoioFixo = false;
        }
    }
}
