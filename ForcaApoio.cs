using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public class ForcaApoio:ForcaPonto
    {
        public bool ehApoioFixo { get; set; }
        public ForcaApoio(double intensidade, double angulo, string sentido, string direcao, string tipoApoio) : base(intensidade, angulo, sentido, direcao)
        {
            if (tipoApoio == "fixo")
                ehApoioFixo = true;
            else
                ehApoioFixo = false;
        }
    }
}
