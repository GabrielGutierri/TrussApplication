using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrussApplication
{
    public class Bar
    {
        // TRUE = UP OR RIGHT
        // FALSE = DOWN OR LEFT
        public int initialPointX, initialPointY, finalPointX, finalPointY;
        public string angleDirection;
        public string initialPointQuadrant, finalPointQuadrant;
        public BarForce Force { get; set; }
        public string Direction { get; set; }
        public bool isInclined = true, verticalDirection = true, horizontalDirection = false;
        public double angle, distance, initialPointAngle, finalPointAngle;

        public Bar(int pointX, int pointY, int pointFX, int pointFY, double angle, double distance, string barDirection)
        {
            initialPointX = pointX;
            initialPointY = pointY;
            finalPointX = pointFX;
            finalPointY = pointFY;
            this.angle = angle;
            this.distance = distance;
            angleDirection = barDirection;

            if (finalPointX - initialPointX > 0)
            {
                horizontalDirection = true;
            }
            if (finalPointY - initialPointY > 0)
            {
                verticalDirection = false;
            }
            if (finalPointX - initialPointX == 0 | finalPointY - initialPointY == 0)
            {
                isInclined = false;
            }

            DefineDirection();
            DefineAngles();
            Force = new BarForce(0, angle, Direction, "Pointing inward");
        }

        public void DefineDirection()
        {
            if (isInclined)
                this.Direction = "inclined";
            if (horizontalDirection && isInclined == false)
                this.Direction = "horizontal";
            if (verticalDirection && isInclined == false)
                this.Direction = "vertical";
        }

        public void DefineAngles()
        {
            if (angleDirection == "Ascending" && initialPointX <= finalPointX && initialPointY >= finalPointY)
            {
                initialPointAngle = angle;
                initialPointQuadrant = "1";
                finalPointAngle = 180 + angle;
                finalPointQuadrant = "3";
            }
            else if (angleDirection == "Ascending" && initialPointX >= finalPointX && initialPointY <= finalPointY)
            {
                initialPointAngle = 180 + angle;
                initialPointQuadrant = "3";
                finalPointAngle = angle;
                finalPointQuadrant = "1";
            }
            else if (angleDirection == "Descending" && initialPointX <= finalPointX && initialPointY <= finalPointY)
            {
                initialPointAngle = -angle;
                initialPointQuadrant = "4";
                finalPointAngle = -180 - angle;
                finalPointQuadrant = "2";
            }
            else if (angleDirection == "Descending" && initialPointX >= finalPointX && initialPointY >= finalPointY)
            {
                initialPointAngle = -180 - angle;
                initialPointQuadrant = "2";
                finalPointAngle = -angle;
                finalPointQuadrant = "4";
            }
        }
    }
}