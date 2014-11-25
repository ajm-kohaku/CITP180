using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MurphyAA12
{
    public partial class RobotMain : Form
    {

        public RobotMain()
        {
            InitializeComponent();
        }

        private Robot robot;

        private void RobotMain_Load(object sender, EventArgs e)
        {
            robot = new Robot();
            robot.Crash += new EventHandler(CrashHandler);
            lblCoordinates.Text = robot.Position.ToString();
            lblRobot.Text = Convert.ToChar(233).ToString();
        }

        private void CrashHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Crash!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo1_Click(object sender, EventArgs e)
        {
            this.MoveRobot(1);
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            robot.Direction = RobotDirection.N;
            lblRobot.Text = Convert.ToChar(233).ToString(); //up arrow
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            robot.Direction = RobotDirection.W;
            lblRobot.Text = Convert.ToChar(231).ToString(); //left arrow

        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            robot.Direction = RobotDirection.E;
            lblRobot.Text = Convert.ToChar(232).ToString(); //right arrow
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            robot.Direction = RobotDirection.S;
            lblRobot.Text = Convert.ToChar(234).ToString(); //down arrow
        }

        private void MoveRobot(int units)
        {
            robot.Go(units);
            Point rp = robot.Position;
            lblRobot.Location = new Point(rp.X + 125, -rp.Y + 125);
            lblCoordinates.Text = rp.ToString();
        }

        private void btnGo10_Click(object sender, EventArgs e)
        {
            this.MoveRobot(10);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            robot = new Robot();
            robot.Crash += new EventHandler(CrashHandler);
            lblRobot.Location = new Point(125, 125);
            lblCoordinates.Text = robot.Position.ToString();
            lblRobot.Text = Convert.ToChar(233).ToString();
        }

        
    }
}
