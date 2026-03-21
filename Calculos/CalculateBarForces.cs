using TrussApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication.Calculations
{
    public static class CalculateBarForces
    {
        public static double sumVerticalForces = 0, sumHorizontalForces = 0;
        public static int loopCount = 0;

        public static void CalculateBarForce()
        {
            int nullCount;
            List<Bar> foundNull = new List<Bar>();

            do
            {
                foreach (Point analyzedPoint in Form1.pointList)
                {
                    if (CheckPointCalculationPossibility(analyzedPoint) == true)
                    {
                        continue;
                    }

                    sumVerticalForces = 0;
                    sumHorizontalForces = 0;
                    nullCount = 0;

                    foreach (Bar bar in analyzedPoint.pointBars)
                    {
                        if (bar.Force.Intensity == 0)
                        {
                            nullCount++;
                        }
                    }

                    if (nullCount <= 2)
                    {
                        SumExternalForces(analyzedPoint);
                        SumBarForces(analyzedPoint);

                        foundNull = analyzedPoint.pointBars.FindAll(x => x.Force.Intensity == 0);

                        if (nullCount == 2)
                        {
                            NinjaMethod(analyzedPoint, foundNull);
                        }
                        else if (nullCount == 1)
                        {
                            SimpleEquation(analyzedPoint, foundNull[0]);
                        }
                    }
                }

                foundNull = Form1.barList.FindAll(x => x.Force.Intensity == 0);

                if (CheckLoop() == true)
                {
                    return;
                }
            }
            while (foundNull.Count != 0);
        }

        private static void SumExternalForces(Point analyzedPoint)
        {
            foreach (PointForce pointForce in analyzedPoint.pointForces)
            {
                PointForce newPointForce = new PointForce(pointForce.Intensity, pointForce.Angle,
                    pointForce.Direction, pointForce.Orientation, 1);

                if ((newPointForce.Direction == "vertical" || newPointForce.Direction == "inclined") && newPointForce.Orientation == "Pointing outward")
                {
                    sumVerticalForces += newPointForce.VerticalComponent;
                }
                else if ((newPointForce.Direction == "vertical" || newPointForce.Direction == "inclined") && newPointForce.Orientation == "Pointing inward")
                {
                    sumVerticalForces -= newPointForce.VerticalComponent;
                }

                if ((newPointForce.Direction == "horizontal" || newPointForce.Direction == "inclined") && newPointForce.Orientation == "Pointing outward")
                {
                    sumHorizontalForces += newPointForce.HorizontalComponent;
                }
                else if ((newPointForce.Direction == "horizontal" || newPointForce.Direction == "inclined") && newPointForce.Orientation == "Pointing inward")
                {
                    sumHorizontalForces -= newPointForce.HorizontalComponent;
                }
            }
        }

        private static void SumBarForces(Point analyzedPoint)
        {
            foreach (Bar barForce in analyzedPoint.pointBars)
            {
                if (barForce.Force.Intensity != 0)
                {
                    if (barForce.initialPointX == analyzedPoint.xValue
                    && barForce.initialPointY == analyzedPoint.yValue)
                    {
                        if ((barForce.initialPointQuadrant == "1" && barForce.Force.Orientation == "Pointing outward") ||
                            (barForce.initialPointQuadrant == "3" && barForce.Force.Orientation == "Pointing inward"))
                        {
                            sumVerticalForces += barForce.Force.VerticalComponent;
                            sumHorizontalForces += barForce.Force.HorizontalComponent;
                        }
                        else if ((barForce.initialPointQuadrant == "1" && barForce.Force.Orientation == "Pointing inward") ||
                            (barForce.initialPointQuadrant == "3" && barForce.Force.Orientation == "Pointing outward"))
                        {
                            sumVerticalForces -= barForce.Force.VerticalComponent;
                            sumHorizontalForces -= barForce.Force.HorizontalComponent;
                        }
                        else if ((barForce.initialPointQuadrant == "2" && barForce.Force.Orientation == "Pointing outward") ||
                            (barForce.initialPointQuadrant == "4" && barForce.Force.Orientation == "Pointing inward"))
                        {
                            sumVerticalForces += barForce.Force.VerticalComponent;
                            sumHorizontalForces -= barForce.Force.HorizontalComponent;
                        }
                        else if ((barForce.initialPointQuadrant == "2" && barForce.Force.Orientation == "Pointing inward") ||
                            (barForce.initialPointQuadrant == "4" && barForce.Force.Orientation == "Pointing outward"))
                        {
                            sumVerticalForces -= barForce.Force.VerticalComponent;
                            sumHorizontalForces += barForce.Force.HorizontalComponent;
                        }
                    }
                    else
                    {
                        if ((barForce.finalPointQuadrant == "1" && barForce.Force.Orientation == "Pointing outward") ||
                            (barForce.finalPointQuadrant == "3" && barForce.Force.Orientation == "Pointing inward"))
                        {
                            sumVerticalForces += barForce.Force.VerticalComponent;
                            sumHorizontalForces += barForce.Force.HorizontalComponent;
                        }
                        else if ((barForce.finalPointQuadrant == "1" && barForce.Force.Orientation == "Pointing inward") ||
                            (barForce.finalPointQuadrant == "3" && barForce.Force.Orientation == "Pointing outward"))
                        {
                            sumVerticalForces -= barForce.Force.VerticalComponent;
                            sumHorizontalForces -= barForce.Force.HorizontalComponent;
                        }
                        else if ((barForce.finalPointQuadrant == "2" && barForce.Force.Orientation == "Pointing outward") ||
                            (barForce.finalPointQuadrant == "4" && barForce.Force.Orientation == "Pointing inward"))
                        {
                            sumVerticalForces += barForce.Force.VerticalComponent;
                            sumHorizontalForces -= barForce.Force.HorizontalComponent;
                        }
                        else if ((barForce.finalPointQuadrant == "2" && barForce.Force.Orientation == "Pointing inward") ||
                            (barForce.finalPointQuadrant == "4" && barForce.Force.Orientation == "Pointing outward"))
                        {
                            sumVerticalForces -= barForce.Force.VerticalComponent;
                            sumHorizontalForces += barForce.Force.HorizontalComponent;
                        }
                    }
                }
            }
        }

        private static void NinjaMethod(Point analyzedPoint, List<Bar> foundNull)
        {
            double calc1;
            double calc2;
            double calc3 = 0;
            double calc4 = 0;

            if (foundNull[0].initialPointX == analyzedPoint.xValue
                && foundNull[0].initialPointY == analyzedPoint.yValue
                && foundNull[1].initialPointX == analyzedPoint.xValue
                && foundNull[1].initialPointY == analyzedPoint.yValue)
            {
                calc1 = Math.Sin(foundNull[0].initialPointAngle * (Math.PI / 180)) *
                Math.Cos(foundNull[1].initialPointAngle * (Math.PI / 180)) -
                Math.Sin(foundNull[1].initialPointAngle * (Math.PI / 180)) *
                Math.Cos(foundNull[0].initialPointAngle * (Math.PI / 180));

                calc2 = Math.Sin(foundNull[0].initialPointAngle * (Math.PI / 180)) *
                    sumHorizontalForces -
                    Math.Cos(foundNull[0].initialPointAngle * (Math.PI / 180)) *
                    sumVerticalForces;

                calc3 = calc2 / calc1;

                if (foundNull[0].initialPointAngle == 0 || foundNull[0].initialPointAngle == 180)
                {
                    calc4 = (sumHorizontalForces -
                    Math.Cos(foundNull[1].initialPointAngle * (Math.PI / 180)) * calc3)
                    / Math.Cos(foundNull[0].initialPointAngle * (Math.PI / 180));
                }
                else
                {
                    calc4 = (sumVerticalForces -
                    Math.Sin(foundNull[1].initialPointAngle * (Math.PI / 180)) * calc3)
                    / Math.Sin(foundNull[0].initialPointAngle * (Math.PI / 180));
                }
            }
            else if (foundNull[0].initialPointX == analyzedPoint.xValue
                && foundNull[0].initialPointY == analyzedPoint.yValue
                && foundNull[1].finalPointX == analyzedPoint.xValue
                && foundNull[1].finalPointY == analyzedPoint.yValue)
            {
                calc1 = Math.Sin(foundNull[0].initialPointAngle * (Math.PI / 180)) *
                Math.Cos(foundNull[1].finalPointAngle * (Math.PI / 180)) -
                Math.Sin(foundNull[1].finalPointAngle * (Math.PI / 180)) *
                Math.Cos(foundNull[0].initialPointAngle * (Math.PI / 180));

                calc2 = Math.Sin(foundNull[0].initialPointAngle * (Math.PI / 180)) *
                    sumHorizontalForces -
                    Math.Cos(foundNull[0].initialPointAngle * (Math.PI / 180)) *
                    sumVerticalForces;

                calc3 = calc2 / calc1;

                if (foundNull[0].initialPointAngle == 0 || foundNull[0].initialPointAngle == 180)
                {
                    calc4 = (sumHorizontalForces -
                    Math.Cos(foundNull[1].finalPointAngle * (Math.PI / 180)) * calc3)
                    / Math.Cos(foundNull[0].initialPointAngle * (Math.PI / 180));
                }
                else
                {
                    calc4 = (sumVerticalForces -
                    Math.Sin(foundNull[1].finalPointAngle * (Math.PI / 180)) * calc3)
                    / Math.Sin(foundNull[0].initialPointAngle * (Math.PI / 180));
                }
            }
            else if (foundNull[0].finalPointX == analyzedPoint.xValue
                && foundNull[0].finalPointY == analyzedPoint.yValue
                && foundNull[1].initialPointX == analyzedPoint.xValue
                && foundNull[1].initialPointY == analyzedPoint.yValue)
            {
                calc1 = Math.Sin(foundNull[0].finalPointAngle * (Math.PI / 180)) *
                Math.Cos(foundNull[1].initialPointAngle * (Math.PI / 180)) -
                Math.Sin(foundNull[1].initialPointAngle * (Math.PI / 180)) *
                Math.Cos(foundNull[0].finalPointAngle * (Math.PI / 180));

                calc2 = Math.Sin(foundNull[0].finalPointAngle * (Math.PI / 180)) *
                    sumHorizontalForces -
                    Math.Cos(foundNull[0].finalPointAngle * (Math.PI / 180)) *
                    sumVerticalForces;

                calc3 = calc2 / calc1;

                if (foundNull[0].finalPointAngle == 0 || foundNull[0].finalPointAngle == 180)
                {
                    calc4 = (sumHorizontalForces -
                    Math.Cos(foundNull[1].initialPointAngle * (Math.PI / 180)) * calc3)
                    / Math.Cos(foundNull[0].finalPointAngle * (Math.PI / 180));
                }
                else
                {
                    calc4 = (sumVerticalForces -
                    Math.Sin(foundNull[1].initialPointAngle * (Math.PI / 180)) * calc3)
                    / Math.Sin(foundNull[0].finalPointAngle * (Math.PI / 180));
                }
            }
            else if (foundNull[0].finalPointX == analyzedPoint.xValue
                && foundNull[0].finalPointY == analyzedPoint.yValue
                && foundNull[1].finalPointX == analyzedPoint.xValue
                && foundNull[1].finalPointY == analyzedPoint.yValue)
            {
                calc1 = Math.Sin(foundNull[0].finalPointAngle * (Math.PI / 180)) *
                Math.Cos(foundNull[1].finalPointAngle * (Math.PI / 180)) -
                Math.Sin(foundNull[1].finalPointAngle * (Math.PI / 180)) *
                Math.Cos(foundNull[0].finalPointAngle * (Math.PI / 180));

                calc2 = Math.Sin(foundNull[0].finalPointAngle * (Math.PI / 180)) *
                    sumHorizontalForces -
                    Math.Cos(foundNull[0].finalPointAngle * (Math.PI / 180)) *
                    sumVerticalForces;

                calc3 = calc2 / calc1;

                if (foundNull[0].finalPointAngle == 0 || foundNull[0].finalPointAngle == 180)
                {
                    calc4 = (sumHorizontalForces -
                    Math.Cos(foundNull[1].finalPointAngle * (Math.PI / 180)) * calc3)
                    / Math.Cos(foundNull[0].finalPointAngle * (Math.PI / 180));
                }
                else
                {
                    calc4 = (sumVerticalForces -
                    Math.Sin(foundNull[1].finalPointAngle * (Math.PI / 180)) * calc3)
                    / Math.Sin(foundNull[0].finalPointAngle * (Math.PI / 180));
                }
            }

            AddFoundValues(foundNull[0], calc4);
            AddFoundValues(foundNull[1], calc3);
        }

        private static void SimpleEquation(Point analyzedPoint, Bar foundNull)
        {
            double calc1;

            if (foundNull.initialPointX == analyzedPoint.xValue
                && foundNull.initialPointY == analyzedPoint.yValue)
            {
                if (foundNull.Force.Angle == 90 || foundNull.Force.Angle == 270)
                {
                    calc1 = sumVerticalForces /
                        Math.Sin(foundNull.initialPointAngle * (Math.PI / 180));
                }
                else if (foundNull.Force.Angle == 0 || foundNull.Force.Angle == 180)
                {
                    calc1 = sumHorizontalForces /
                        Math.Cos(foundNull.initialPointAngle * (Math.PI / 180));
                }
                else
                {
                    calc1 = sumVerticalForces /
                        Math.Sin(foundNull.initialPointAngle * (Math.PI / 180));
                }
            }
            else
            {
                if (foundNull.Force.Angle == 90 || foundNull.Force.Angle == 270)
                {
                    calc1 = sumVerticalForces /
                        Math.Sin(foundNull.finalPointAngle * (Math.PI / 180));
                }
                else if (foundNull.Force.Angle == 0 || foundNull.Force.Angle == 180)
                {
                    calc1 = sumHorizontalForces /
                        Math.Cos(foundNull.finalPointAngle * (Math.PI / 180));
                }
                else
                {
                    calc1 = sumVerticalForces /
                        Math.Sin(foundNull.finalPointAngle * (Math.PI / 180));
                }
            }

            AddFoundValues(foundNull, calc1);
        }

        private static void AddFoundValues(Bar foundNull, double calculation)
        {
            string orientation;

            if (calculation > 0)
            {
                orientation = "Pointing inward";
            }
            else
            {
                orientation = "Pointing outward";
            }

            foundNull.Force.AddFoundComponents(calculation, foundNull.angle, orientation);
        }

        private static bool CheckPointCalculationPossibility(Point analyzedPoint)
        {
            List<Bar> foundNull = analyzedPoint.pointBars.FindAll(x => x.Force.Intensity != 0);

            if (analyzedPoint.pointForces.Count == 0 && foundNull.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckLoop()
        {
            loopCount++;
            if (loopCount >= 7)
            {
                MessageBox.Show("Could not calculate");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
