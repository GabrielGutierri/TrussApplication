using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication
{
    public class SupportForce : PointForce
    {
        public bool isFixedSupport { get; set; }

        public SupportForce(double intensity, double angle, string direction, string orientation, string supportType) : base(intensity, angle, direction, orientation, 0)
        {
            if (supportType == "fixed")
                isFixedSupport = true;
            else
                isFixedSupport = false;
        }
    }
}