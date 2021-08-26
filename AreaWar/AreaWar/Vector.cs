using System;

namespace AreaWar
{
    public class Vector
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public Vector(double angle, int speed = 1)
        {
            var actuaAngle = angle * Math.PI / 180;
            X = Speed * Math.Cos(actuaAngle);
            Y = Speed * Math.Sin(actuaAngle);
            this.Angle = angle;
        }
        public double Angle { get; set; }

        public int Speed => 8;

        public void SetXReBound()
        {
            this.X = 0 - this.X;
        }

        public void SetYReBound()
        {
            this.Y = 0 - this.Y;
        }

    }
}
