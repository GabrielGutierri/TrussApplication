using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication
{
    public abstract class Force
    {
        public double Intensity { get; set; }
        public string Orientation { get; set; }
        public double Angle { get; set; }
        public double VerticalComponent { get; set; }
        public double HorizontalComponent { get; set; }
        public string Direction { get; set; }

        public Force(double intensity, double angle, string direction, string orientation)
        {
            this.Direction = direction;
            AddFoundComponents(intensity, angle, orientation);
        }

        public void AddFoundComponents(double intensity, double angle, string orientation)
        {
            Orientation = orientation;
            Angle = angle;

            if (intensity < 0)
                Intensity = -intensity;
            else
                Intensity = intensity;

            this.VerticalComponent = Math.Round(Intensity * Math.Sin(Angle * (Math.PI / 180)), 6);
            this.HorizontalComponent = Math.Round(Intensity * Math.Cos(Angle * (Math.PI / 180)), 6);
        }
    }
}