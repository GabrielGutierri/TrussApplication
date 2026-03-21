using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrussApplication;

namespace TrussApplication
{
    public static class CalculateFixedForces
    {
        public static void CalculateHorizontal(SupportForce horizontalForce)
        {
            double sumLeft = 0;
            double sumRight = 0;
            foreach (var point in Form1.pointList)
            {
                if (point.pointForces.Count > 0)
                {
                    foreach (var force in point.pointForces)
                    {
                        if (force.HorizontalDirection == "left")
                            sumLeft += Math.Abs(force.HorizontalComponent);
                        if (force.HorizontalDirection == "right")
                            sumRight += Math.Abs(force.HorizontalComponent);
                        if (force.Direction == "horizontal")
                        {
                            if ((force.Quadrant == 1 && force.Orientation == "Pointing outward") || (force.Quadrant == 2 && force.Orientation == "Pointing inward"))
                            {
                                sumRight += force.Intensity;
                            }
                            if ((force.Quadrant == 1 && force.Orientation == "Pointing inward") || (force.Quadrant == 2 && force.Orientation == "Pointing outward"))
                            {
                                sumLeft += force.Intensity;
                            }
                        }
                    }
                }
                if (point.supportForces.Count == 1)
                {
                    var mobileSupportForce = point.supportForces[0];
                    if (mobileSupportForce.Direction == "horizontal")
                    {
                        if (mobileSupportForce.Orientation == "Pointing inward")
                            sumRight += mobileSupportForce.Intensity;
                        else
                            sumLeft += mobileSupportForce.Intensity;
                    }
                }
            }

            if (horizontalForce.Orientation == "Pointing outward") // pointing left
                horizontalForce.Intensity = sumLeft - sumRight;
            else
                horizontalForce.Intensity = sumRight - sumLeft;
            CheckHorizontalDirection(horizontalForce);
        }

        private static void CheckHorizontalDirection(SupportForce horizontalForce)
        {
            if (horizontalForce.Intensity < 0)
            {
                if (horizontalForce.Orientation == "Pointing outward")
                    horizontalForce.Orientation = "Pointing inward";
                else
                    horizontalForce.Orientation = "Pointing outward";
            }
        }

        public static void CalculateVertical(SupportForce verticalForce)
        {
            double sumUp = 0;
            double sumDown = 0;
            foreach (var point in Form1.pointList)
            {
                if (point.pointForces.Count > 0)
                {
                    foreach (var force in point.pointForces)
                    {
                        if (force.VerticalDirection == "up")
                            sumUp += Math.Abs(force.VerticalComponent);
                        if (force.VerticalDirection == "down")
                            sumDown += Math.Abs(force.VerticalComponent);
                        if (force.Direction == "vertical")
                        {
                            if ((force.Quadrant == 1 && force.Orientation == "Pointing outward") || (force.Quadrant == 3 && force.Orientation == "Pointing inward"))
                            {
                                sumUp += force.Intensity;
                            }
                            if ((force.Quadrant == 1 && force.Orientation == "Pointing inward") || (force.Quadrant == 3 && force.Orientation == "Pointing outward"))
                            {
                                sumDown += force.Intensity;
                            }
                        }
                    }
                }
                if (point.supportForces.Count == 1)
                {
                    var mobileSupportForce = point.supportForces[0];
                    if (mobileSupportForce.Direction == "vertical") // mobile supports pointing upward on walls not handled
                    {
                        sumUp += mobileSupportForce.Intensity;
                    }
                }
            }
            verticalForce.Intensity = sumDown - sumUp; // only considered fixed support force pointing upward
            CheckVerticalDirection(verticalForce);
        }

        public static void CheckVerticalDirection(SupportForce verticalForce)
        {
            if (verticalForce.Intensity < 0)
            {
                verticalForce.Orientation = "Pointing inward";
            }
        }
    }
}
