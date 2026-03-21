using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication
{
    public class PointForce : Force
    {
        public int Quadrant { get; set; }
        public string HorizontalDirection { get; set; }
        public string VerticalDirection { get; set; }

        public PointForce(double intensity, double angle, string direction, string orientation, int quadrant) : base(intensity, angle, direction, orientation)
        {
            this.Quadrant = quadrant;
            this.Orientation = orientation;
            if (direction == "inclined")
                UpdateDirection();
            UpdateAngleComponents(this);
        }

        public PointForce(double intensity, double angle, string direction, string orientation) : base(intensity, angle, direction, orientation)
        {
            if (angle >= 0 && angle <= 90) this.Quadrant = 1;
            if (angle > 90 && angle <= 180) this.Quadrant = 2;
            if (angle > 180 && angle <= 270) this.Quadrant = 3;
            if (angle > 270 && angle <= 360) this.Quadrant = 4;
            this.Orientation = orientation;
            if (direction == "inclined")
                UpdateDirection();
            if (this.HorizontalComponent == 0 || this.VerticalComponent == 0)
                UpdateAngleComponents(this);
        }

        public void UpdateAngleComponents(PointForce force)
        {
            const double constAngle = Math.PI / 180;

            if (this.Quadrant == 2)
            {
                force.VerticalComponent = Math.Round(Math.Sin(-(force.Angle - 180) * constAngle) * force.Intensity, 6);
                force.HorizontalComponent = Math.Round(Math.Cos((force.Angle - 180) * constAngle) * force.Intensity, 6);
            }
            if (this.Quadrant == 3)
            {
                force.VerticalComponent = Math.Round(Math.Sin(-(force.Angle - 180) * constAngle) * force.Intensity, 6);
                force.HorizontalComponent = Math.Round(Math.Cos((force.Angle - 180) * constAngle) * force.Intensity, 6);
            }
            if (this.Quadrant == 4)
            {
                force.VerticalComponent = Math.Round(Math.Sin(-(Math.Abs(force.Angle - 360)) * constAngle) * force.Intensity, 6);
                force.HorizontalComponent = Math.Round(Math.Cos(Math.Abs((force.Angle - 360)) * constAngle) * force.Intensity, 6);
            }
        }

        public void UpdateDirection()
        {
            if (this.Quadrant == 1)
            {
                if (this.Orientation == "Pointing outward")
                { this.VerticalDirection = "up"; this.HorizontalDirection = "right"; }
                else
                { this.VerticalDirection = "down"; this.HorizontalDirection = "left"; }
            }
            if (this.Quadrant == 2)
            {
                if (this.Orientation == "Pointing outward")
                { this.VerticalDirection = "up"; this.HorizontalDirection = "left"; }
                else
                { this.VerticalDirection = "down"; this.HorizontalDirection = "right"; }
            }
            if (this.Quadrant == 3)
            {
                if (this.Orientation == "Pointing outward")
                { this.VerticalDirection = "down"; this.HorizontalDirection = "left"; }
                else
                { this.VerticalDirection = "up"; this.HorizontalDirection = "right"; }
            }
            if (this.Quadrant == 4)
            {
                if (this.Orientation == "Pointing outward")
                { this.VerticalDirection = "down"; this.HorizontalDirection = "right"; }
                else
                { this.VerticalDirection = "up"; this.HorizontalDirection = "left"; }
            }
        }
    }
}