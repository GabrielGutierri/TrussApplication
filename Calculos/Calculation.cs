using TrussApplication.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication
{
    public static class Calculation
    {
        public static double sumCounterClockwise = 0;
        public static double sumClockwise = 0;

        public static void CalculateSupportMoment()
        {
            List<SupportForce> fixedSupportForce = new List<SupportForce>();
            SupportForce mobileSupportForce = null;
            Point fixedSupportPoint = null;
            Point mobileSupportPoint = null;

            foreach (var item in Form1.pointList)
            {
                if (item.supportForces.Count == 2) // check if there is a support at this point
                {
                    fixedSupportForce.Add(item.supportForces[0]);
                    fixedSupportForce.Add(item.supportForces[1]);
                    fixedSupportPoint = item;
                }

                if (item.supportForces.Count == 1)
                {
                    mobileSupportForce = item.supportForces[0];
                    mobileSupportPoint = item;
                }
            }

            if (fixedSupportPoint != null)
            {
                foreach (var item in Form1.pointList)
                {
                    if (item.pointForces.Count > 0)
                    {
                        if (item.xValue - fixedSupportPoint.xValue >= 0) // point to the right of the fixed point
                        {
                            if (fixedSupportPoint.yValue - item.yValue >= 0) // higher point to the right
                            {
                                var supportList = MomentCalculationRight.RightPointSupport(item, fixedSupportPoint);
                                sumClockwise += supportList[0];
                                sumCounterClockwise += supportList[1];
                            }
                            if (fixedSupportPoint.yValue - item.yValue < 0) // lower point to the right
                            {
                                var supportList = MomentCalculationRight.RightPointSupportLower(item, fixedSupportPoint);
                                sumClockwise += supportList[0];
                                sumCounterClockwise += supportList[1];
                            }
                        }
                        if (item.xValue - fixedSupportPoint.xValue < 0) // point to the left of the fixed point
                        {
                            if (fixedSupportPoint.yValue - item.yValue >= 0) // higher point to the left
                            {
                                var sumList = MomentCalculationLeft.LeftPointSupport(item, fixedSupportPoint);
                                sumClockwise += sumList[0];
                                sumCounterClockwise += sumList[1];
                            }
                            if (fixedSupportPoint.yValue - item.yValue < 0) // lower point to the left
                            {
                                var supportList = MomentCalculationLeft.LeftPointSupportLower(item, fixedSupportPoint);
                                sumClockwise += supportList[0];
                                sumCounterClockwise += supportList[1];
                            }
                        }
                    }
                }
            }
            CalculateMobileSupportForce(mobileSupportForce, mobileSupportPoint, fixedSupportPoint);
            CalculateFixedSupportForces(fixedSupportForce);
        }

        public static void CalculateMobileSupportForce(SupportForce mobileForce, Point mobileSupportPoint, Point fixedSupportPoint)
        {
            double mobileIntensity;
            if (mobileSupportPoint.xValue > fixedSupportPoint.xValue) // mobile support is to the right of the fixed point
            {
                mobileIntensity = (sumClockwise - sumCounterClockwise) / (mobileSupportPoint.xValue - fixedSupportPoint.xValue);
            }
            else
            {
                mobileIntensity = (sumCounterClockwise - sumClockwise) / (fixedSupportPoint.xValue - mobileSupportPoint.xValue);
            }

            if (mobileIntensity < 0) // swap if adding mobile supports pointing up or down. Corner right = force pointing left
            {
                if (mobileForce.Direction == "horizontal")
                {
                    if (mobileSupportPoint.xValue > fixedSupportPoint.xValue)
                        mobileForce.Orientation = "Pointing outward";
                    else
                        mobileForce.Orientation = "Pointing inward";
                }
                else
                    mobileForce.Orientation = "Pointing inward";
            }
            mobileForce.Intensity = mobileIntensity;
        }

        public static void CalculateFixedSupportForces(List<SupportForce> fixedSupportForce)
        {
            CalculateFixedForces.CalculateVertical(fixedSupportForce[0]);
            CalculateFixedForces.CalculateHorizontal(fixedSupportForce[1]);
        }

        public static double CalculateSum(PointForce force, string orientation, int referencePoint1, double referencePoint2)
        {
            if (orientation == "sin")
            {
                return Math.Abs(force.VerticalComponent * (referencePoint1 - referencePoint2));
            }
            else
            {
                return Math.Abs(force.HorizontalComponent * (referencePoint1 - referencePoint2));
            }
        }

        public static double CalculateSumReferential(PointForce force, string orientation, int referencePoint1, double referencePoint2)
        {
            if (orientation == "sin")
            {
                return Math.Abs(force.VerticalComponent * (referencePoint1 + referencePoint2));
            }
            else
            {
                return Math.Abs(force.HorizontalComponent * (referencePoint1 + referencePoint2));
            }
        }
    }
}
