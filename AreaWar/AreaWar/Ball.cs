using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace AreaWar
{
    public class Ball : NotifyObject
    {
        public const int Diameter = 10;

        private double _x;
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                RaisePropertyChanged(nameof(X));
            }
        }
        private double _y;
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }

        private IList<CheckerboardCell> _checkerboards;

        public Vector Vector { get; set; }

        public Side Side { get; set; }

        private object _objLock = new object();

        public SolidColorBrush Color
        {
            get
            {
                return Side == Side.Blue ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.Red);
            }
        }


        public Ball(IList<CheckerboardCell> checkerboard, Side side, double x, double y, double angle)
        {
            this.Vector = new Vector(angle);
            this.X = x;
            this.Y = y;
            _checkerboards = checkerboard;
            this.Side = side;
        }

        public void RefreshPosition()
        {
            lock (_objLock)
            {
                GoToNext();
            }
        }

        private double GetNextX()
        {
            var nextX = this.X + Vector.X;

            if (nextX > 900 - 10)
            {
                nextX = 900 - 10;
                Vector.SetXReBound();
            }
            else if (nextX < 0)
            {
                nextX = 0;
                Vector.SetXReBound();
            }

            return nextX;
        }

        private double GetNextY()
        {
            var nextY = this.Y + Vector.Y;

            if (nextY > 900 - Diameter)
            {
                nextY = 900 - Diameter;
                Vector.SetYReBound();
            }
            else if (nextY < 0)
            {
                nextY = 0;
                Vector.SetYReBound();
            }

            return nextY;
        }

        public void GoToNext()
        {
            //calculate which is next cell
            var nextX = GetNextX();
            var nextY = GetNextY();


            var row = (int)Math.Floor((double)nextY / CheckerboardCell.SideLength);
            var column = (int)Math.Floor((double)nextX / CheckerboardCell.SideLength);

            var nextCell = _checkerboards.FirstOrDefault(it => it.Position.X == column && it.Position.Y == row);
            if (nextCell == null)
                return;


            if (nextCell.Side == this.Side)
            {
                this.X = nextX;
                this.Y = nextY;
                return;
            }

            nextCell.Side = this.Side;

            //judge will hit which side
            var cellLeftX = nextCell.X * CheckerboardCell.SideLength;
            var cellRightX = (nextCell.X + 1) * CheckerboardCell.SideLength;
            if (this.X <= cellLeftX)
            {
                //from left
                this.X = cellLeftX - Diameter;
                Vector.SetXReBound();
            }
            else if (this.X >= cellRightX)
            {
                // from right
                this.X = cellRightX;
                Vector.SetXReBound();
            }



            var cellUpY = nextCell.Y * CheckerboardCell.SideLength;
            var cellBottomY = (nextCell.Y + 1) * CheckerboardCell.SideLength;
            if (this.Y <= cellUpY)
            {
                //from top
                this.Y = cellUpY - Diameter;
                Vector.SetYReBound();
            }
            else if (this.Y >= cellBottomY)
            {
                //from bottom
                this.Y = cellBottomY;
                Vector.SetYReBound();
            }


        }
    }
}
