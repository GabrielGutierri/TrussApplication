using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication
{
    public class Point
    {
        public int xValue, yValue;
        public List<Bar> pointBars = new List<Bar>();
        public List<PointForce> pointForces = new List<PointForce>();
        public List<SupportForce> supportForces = new List<SupportForce>();

        public Point(int x, int y)
        {
            xValue = x;
            yValue = y;
        }

        public void CheckBarForces()
        {
            foreach (var item in pointForces)
            {
                Console.WriteLine($"{item.Orientation} - {item.Direction} - {item.Intensity} - {item.Angle}");
            }
        }
    }
}