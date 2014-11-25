using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MurphyAA12
{
    public enum RobotDirection{N,E,S,W};

    class Robot
    {
        public RobotDirection Direction;
        private int x;
        private int y;
        const int MaxRange = 100;

        public delegate void CrashHandler(Robot robot);
        public event EventHandler Crash;

        public Robot()
        {
            this.x = 0;
            this.y = 0;
            this.Direction = RobotDirection.N;
        }

        public Point Position
        { get { return new Point(x, y); } }

        public void Go(int units)
        {
            switch (this.Direction)
            {
                case RobotDirection.N:
                    y += units;
                    if (y > MaxRange)
                    {
                        y = MaxRange;
                        Crash(this, EventArgs.Empty);
                    }
                    break;
                case RobotDirection.S:
                    y -= units;
                    if (y < -MaxRange)
                    {
                        y = -MaxRange;
                        Crash(this, EventArgs.Empty);
                    }
                    break;
                case RobotDirection.E:
                    x += units;
                    if (x > MaxRange)
                    {
                        x = MaxRange;
                        Crash(this, EventArgs.Empty);
                    }
                    break;
                case RobotDirection.W:
                     x-= units;
                    if (x < -MaxRange)
                    {
                        x = -MaxRange;
                        Crash(this, EventArgs.Empty);
                    }
                    break;
            }
        }
    }
}
