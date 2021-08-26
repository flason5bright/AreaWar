using System.ComponentModel;
using System.Drawing;
using System.Windows.Media;

namespace AreaWar
{
    public class NotifyObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CheckerboardCell : NotifyObject
    {
        public static int SideLength = 30;
        public int Id { get; set; }

        public Point Position { get; set; }
        public int X => Position.X;
        public int Y => Position.Y;

        private Side _side;
        public Side Side
        {
            get
            { return _side; }

            set
            {
                _side = value;
                RaisePropertyChanged(nameof(Side));
                RaisePropertyChanged(nameof(Color));
            }
        }

        public SolidColorBrush Color
        {
            get
            {
                return Side == Side.Blue ? new SolidColorBrush(Colors.LightBlue) : new SolidColorBrush(Colors.Pink);
            }
        }

        public CheckerboardCell(int id, Point position, Side side)
        {
            this.Id = id;
            this.Position = position;
            this.Side = side;
        }


    }
}
