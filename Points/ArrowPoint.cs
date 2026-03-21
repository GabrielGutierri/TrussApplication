using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication
{
    public class ArrowPoint
    {
        public int InitialXValue { get; set; }
        public int InitialYValue { get; set; }
        public int FinalXValue { get; set; }
        public int FinalYValue { get; set; }
        public string Orientation { get; set; }
        public PointForce PointForce { get; set; }

        public ArrowPoint(int initialXValue, int initialYValue, int finalXValue, int finalYValue, string orientation, PointForce force)
        {
            InitialXValue = initialXValue;
            InitialYValue = initialYValue;
            FinalXValue = finalXValue;
            FinalYValue = finalYValue;
            Orientation = orientation;
            PointForce = force;
        }
    }
}