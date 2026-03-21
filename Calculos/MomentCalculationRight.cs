using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication
{
    public static class MomentCalculationRight
    {
        public static List<double> RightPointSupport(Point item, Point fixedSupportPoint)
        {
            double sumClockwise = 0;
            double sumCounterClockwise = 0;
            double pointY = item.yValue;

            foreach (var pointForce in item.pointForces)
            {
                if (pointForce.Orientation == "Pointing outward")
                {
                    if (pointForce.Direction == "horizontal" && pointForce.Quadrant == 1)
                    {
                        sumClockwise += pointForce.Intensity * (fixedSupportPoint.yValue - pointY);
                    }
                    if (pointForce.Direction == "horizontal" && pointForce.Quadrant == 2)
                    {
                        sumCounterClockwise += pointForce.Intensity * (fixedSupportPoint.yValue - pointY);
                    }
                    if (pointForce.Direction == "vertical" && pointForce.Quadrant == 1)
                    {
                        sumCounterClockwise += pointForce.Intensity * (item.xValue - fixedSupportPoint.xValue);
                    }
                    if (pointForce.Direction == "vertical" && pointForce.Quadrant == 3)
                    {
                        sumClockwise += pointForce.Intensity * (item.xValue - fixedSupportPoint.xValue);
                    }
                    if (pointForce.Direction == "inclined")
                    {
                        var sumList = CalculateInclinedOutwardRight(pointForce, fixedSupportPoint, item, pointForce.Quadrant, sumCounterClockwise, sumClockwise, pointY);
                        sumClockwise += sumList[0];
                        sumCounterClockwise += sumList[1];
                    }
                }
                if (pointForce.Orientation == "Pointing inward")
                {
                    if (pointForce.Direction == "horizontal" && pointForce.Quadrant == 1)
                    {
                        sumCounterClockwise += pointForce.Intensity * (fixedSupportPoint.yValue - pointY);
                    }
                    if (pointForce.Direction == "horizontal" && pointForce.Quadrant == 2)
                    {
                        sumClockwise += pointForce.Intensity * (fixedSupportPoint.yValue - pointY);
                    }
                    if (pointForce.Direction == "vertical" && pointForce.Quadrant == 1)
                    {
                        sumClockwise += pointForce.Intensity * (item.xValue - fixedSupportPoint.xValue);
                    }
                    if (pointForce.Direction == "vertical" && pointForce.Quadrant == 3)
                    {
                        sumCounterClockwise += pointForce.Intensity * (item.xValue - fixedSupportPoint.xValue);
                    }
                    if (pointForce.Direction == "inclined")
                    {
                        var sumList = CalculateInclinedInwardRight(pointForce, fixedSupportPoint, item, pointForce.Quadrant, sumCounterClockwise, sumClockwise, pointY);
                        sumClockwise = sumList[0];
                        sumCounterClockwise = sumList[1];
                    }
                }
            }
            return new List<double>() { sumClockwise, sumCounterClockwise };
        }

        public static List<double> RightPointSupportLower(Point item, Point fixedSupportPoint)
        {
            double sumClockwise = 0;
            double sumCounterClockwise = 0;
            double pointY = item.yValue;

            foreach (var pointForce in item.pointForces)
            {
                if (pointForce.Orientation == "Pointing outward")
                {
                    if (pointForce.Direction == "horizontal" && pointForce.Quadrant == 1)
                    {
                        sumCounterClockwise += pointForce.Intensity * (fixedSupportPoint.yValue - pointY);
                    }
                    if (pointForce.Direction == "horizontal" && pointForce.Quadrant == 2)
                    {
                        sumClockwise += pointForce.Intensity * (fixedSupportPoint.yValue - pointY);
                    }
                    if (pointForce.Direction == "vertical" && pointForce.Quadrant == 1)
                    {
                        sumCounterClockwise += pointForce.Intensity * (item.xValue - fixedSupportPoint.xValue);
                    }
                    if (pointForce.Direction == "vertical" && pointForce.Quadrant == 3)
                    {
                        sumClockwise += pointForce.Intensity * (item.xValue - fixedSupportPoint.xValue);
                    }
                    if (pointForce.Direction == "inclined")
                    {
                        var sumList = CalculateInclinedOutwardRightLower(pointForce, fixedSupportPoint, item, pointForce.Quadrant, sumCounterClockwise, sumClockwise, pointY);
                        sumClockwise += sumList[0];
                        sumCounterClockwise += sumList[1];
                    }
                }
                if (pointForce.Orientation == "Pointing inward")
                {
                    if (pointForce.Direction == "horizontal" && pointForce.Quadrant == 1)
                    {
                        sumClockwise += pointForce.Intensity * (fixedSupportPoint.yValue - pointY);
                    }
                    if (pointForce.Direction == "horizontal" && pointForce.Quadrant == 2)
                    {
                        sumCounterClockwise += pointForce.Intensity * (fixedSupportPoint.yValue - pointY);
                    }
                    if (pointForce.Direction == "vertical" && pointForce.Quadrant == 1)
                    {
                        sumClockwise += pointForce.Intensity * (item.xValue - fixedSupportPoint.xValue);
                    }
                    if (pointForce.Direction == "vertical" && pointForce.Quadrant == 3)
                    {
                        sumCounterClockwise += pointForce.Intensity * (item.xValue - fixedSupportPoint.xValue);
                    }
                    if (pointForce.Direction == "inclined")
                    {
                        var sumList = CalculateInclinedInwardRightLower(pointForce, fixedSupportPoint, item, pointForce.Quadrant, sumCounterClockwise, sumClockwise, pointY);
                        sumClockwise = sumList[0];
                        sumCounterClockwise = sumList[1];
                    }
                }
            }
            return new List<double>() { sumClockwise, sumCounterClockwise };
        }

        private static List<double> CalculateInclinedOutwardRight(PointForce pointForce, Point fixedSupportPoint, Point point, int quadrant, double sumCounterClockwise, double sumClockwise, double pointY)
        {
            switch (quadrant)
            {
                case 1:
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue);
                    sumClockwise += Calculation.CalculateSum(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 2:
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue)
                        + Calculation.CalculateSum(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 3:
                    sumClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue);
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 4:
                    sumClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue)
                        + Calculation.CalculateSum(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                default:
                    break;
            }
            return new List<double>() { sumClockwise, sumCounterClockwise };
        }

        private static List<double> CalculateInclinedInwardRight(PointForce pointForce, Point fixedSupportPoint, Point point, int quadrant, double sumCounterClockwise, double sumClockwise, double pointY)
        {
            switch (quadrant)
            {
                case 1:
                    sumClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue);
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 2:
                    sumClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue)
                        + Calculation.CalculateSum(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 3:
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue);
                    sumClockwise += Calculation.CalculateSum(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 4:
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue)
                        + Calculation.CalculateSum(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                default:
                    break;
            }
            return new List<double>() { sumClockwise, sumCounterClockwise };
        }

        public static List<double> CalculateInclinedOutwardRightLower(PointForce pointForce, Point fixedSupportPoint, Point point, int quadrant, double sumCounterClockwise, double sumClockwise, double pointY)
        {
            switch (quadrant)
            {
                case 1:
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue) +
                        Calculation.CalculateSumReferential(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 2:
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue);
                    sumClockwise += Calculation.CalculateSumReferential(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 3:
                    sumClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue) +
                        Calculation.CalculateSumReferential(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 4:
                    sumClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue);
                    sumCounterClockwise += Calculation.CalculateSumReferential(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                default:
                    break;
            }
            return new List<double>() { sumClockwise, sumCounterClockwise };
        }

        public static List<double> CalculateInclinedInwardRightLower(PointForce pointForce, Point fixedSupportPoint, Point point, int quadrant, double sumCounterClockwise, double sumClockwise, double pointY)
        {
            switch (quadrant)
            {
                case 1:
                    sumClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue) +
                        Calculation.CalculateSumReferential(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 2:
                    sumClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue);
                    sumCounterClockwise = Calculation.CalculateSumReferential(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 3:
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue) +
                        Calculation.CalculateSumReferential(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                case 4:
                    sumCounterClockwise += Calculation.CalculateSum(pointForce, "sin", point.xValue, fixedSupportPoint.xValue);
                    sumClockwise += Calculation.CalculateSumReferential(pointForce, "cos", fixedSupportPoint.yValue, pointY);
                    break;
                default:
                    break;
            }
            return new List<double>() { sumClockwise, sumCounterClockwise };
        }
    }
}
