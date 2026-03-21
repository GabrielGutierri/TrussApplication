using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrussApplication
{
    public class BarForce : Force
    {
        public List<Point> barPoints { get; set; }

        public BarForce(double intensity, double angle, string direction, string orientation, List<Point> points) : base(intensity, angle, direction, orientation)
        {
            this.barPoints = points;
        }

        public BarForce(double intensity, double angle, string direction, string orientation) : base(intensity, angle, direction, orientation)
        {

        }
    }
}