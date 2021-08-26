using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Timers;

namespace AreaWar
{
    public class MainWindowViewModel
    {
        public List<CheckerboardCell> Checkerboard { get; set; }

        public Ball BlueBall { get; set; }
        public Ball RedBall { get; set; }

        private Timer _timer;


        public MainWindowViewModel()
        {
            Checkerboard = new List<CheckerboardCell>();
            int width = 30;
            for (int i = 0; i < 900; i++)
            {
                int row = (int)Math.Floor((double)i / width);
                int column = i % width;
                var side = Side.Red;
                if (i < 450)
                    side = Side.Blue;
                Checkerboard.Add(new CheckerboardCell(i, new Point(column, row), side));
            }
            BlueBall = new Ball(Checkerboard, Side.Blue, 0, 0, 30);
            RedBall = new Ball(Checkerboard, Side.Red, 0, 900 - 10, -70);
            _timer = new Timer();
            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = 10;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.BlueBall.RefreshPosition();
            this.RedBall.RefreshPosition();
        }
    }
}
