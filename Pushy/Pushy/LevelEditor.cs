using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pushy
{
    public partial class LevelEditor : Form
    {
        private Control activeControl;
        private Point previousPosition;

        public LevelEditor()
        {
            InitializeComponent();
        }

        private void lbMauer_Click(object sender, EventArgs e)
        {
            PictureBox temp = new PictureBox();
            temp.BackColor = Color.Red;
            temp.Tag = "Mauer";
            temp.MouseDown += Temp_MouseDown;
            temp.MouseMove += Temp_MouseMove;
            temp.MouseUp += Temp_MouseUp;
            temp.Location = tableLayoutPanel1.Location;
            temp.Focus();
            Controls.Add(temp);
        }

        private void Temp_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
            Cursor = Cursors.Default;
        }

        private void Temp_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender)
                return;
            else
            {
                Point location = (sender as Control).Location;
                location.Offset(e.Location.X - previousPosition.X, e.Location.Y - previousPosition.Y);
                if (Randuerberprufung(location, sender))
                    (sender as Control).Location = location;
            }
        }

        private bool Randuerberprufung(Point location, object sender)
        {
            if (location.X < tableLayoutPanel1.Location.X || location.X + (sender as Control).Width > tableLayoutPanel1.Location.X+tableLayoutPanel1.Size.Width)
                return false;
            if (location.Y < tableLayoutPanel1.Location.Y || location.Y + (sender as Control).Height > tableLayoutPanel1.Location.Y + tableLayoutPanel1.Size.Height)
                return false;
            return true;
        }

        private void Temp_MouseDown(object sender, MouseEventArgs e)
        {
            activeControl = sender as Control;
            previousPosition = e.Location;
            Cursor = Cursors.Hand;
        }
    }
}
