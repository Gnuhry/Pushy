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
    public partial class Level1 : Form
    {
        Control Player;
        static int Hoch, Seite;
        bool IsBarrier;
        public Level1()
        {
            InitializeComponent();
            KeyDown += Form1_KeyDown;
            for (int f = 0; f < Controls.Count; f++)
            {
                if (Controls[f].Tag + "" == "Player")
                    Player = Controls[f];
                if ((Controls[f].Tag + "").Split('.')[0] == "KnopfMauer")
                    Controls[f].EnabledChanged += KnopfMauer_EnabledChanged;
            }
            Hoch = Player.Height;
            Seite = Player.Width;
            IsBarrier = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point temp = Player.Location;
            if (e.KeyData == Keys.Down) temp.Offset(0, Player.Height);
            else if (e.KeyData == Keys.Up) temp.Offset(0, -Player.Height);
            else if (e.KeyData == Keys.Right) temp.Offset(Player.Width, 0);
            else if (e.KeyData == Keys.Left) temp.Offset(-Player.Width, 0);
            else return;
            if (Uberprufung(temp, true, Player))
            {
                Player.Location = temp;
                Knopf_Aktiv();
            }
        }
        private void KnopfMauer_EnabledChanged(object sender, EventArgs e)
        {
            if ((sender as Control).Enabled) (sender as Control).BackColor = Color.Red;
            else (sender as Control).BackColor = Color.Blue;
        }


        private void Win()
        {
            for (int f = 0; f < Controls.Count; f++)
            {
                if (Controls[f].Enabled && Controls[f].Visible)
                    if (("" + Controls[f].Tag).Split('.')[0] == "Kugel") return;
            }
            MessageBox.Show("Gewonnen");
        }
        private bool Uberprufung(Point PlayerLocation, bool IsPlayer, Control Player)
        {
            for (int f = 0; f < Controls.Count; f++)
            {
                if (Controls[f].Visible)
                {
                    if ("" + Controls[f].Tag == "Mauer")
                    {
                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                       Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                       Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Mauer");
                            return false;
                        }
                    }
                    else if ("" + Controls[f].Tag == "Haus")
                    {
                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                       Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                       Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Haus");
                            if (!IsPlayer) return false;
                            Win();
                            return true;
                        }
                    }
                    else if (("" + Controls[f].Tag).Split('.')[0] == "Teleporter")
                    {//z.B. Teleporter.1
                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                       Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                       Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Teleporter");
                            if (!IsPlayer) return false;
                            for (int g = 0; g < Controls.Count; g++)
                                if (Controls[g].Tag == Controls[f].Tag && Controls[g] != Controls[f])
                                    Player.Location = Controls[g].Location;
                            return false;
                        }
                    }
                    else if ("" + Controls[f].Tag == "Kasten")
                    {

                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                       Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                       Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Kasten");
                            if (!IsPlayer) return false;
                            Point point = Controls[f].Location;
                            point.Offset((PlayerLocation.X - Player.Location.X), (PlayerLocation.Y - Player.Location.Y));
                            if (Uberprufung(point, false, Controls[f]))
                            {
                                Controls[f].Location = point;
                                if (IsBarrier && IsPlayer)
                                {
                                    PictureBox bar = new PictureBox();
                                    bar.Size = Player.Size;
                                    bar.Location = PlayerLocation;
                                    bar.BackColor = Color.Green;
                                    bar.Tag = "Barrier";
                                    Controls.Add(bar);
                                }
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (("" + Controls[f].Tag).Split('.')[0] == "Kugel")
                    {

                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                       Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                       Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Kugel");
                            if (!IsPlayer) return false;
                            Point point = Controls[f].Location;
                            point.Offset((PlayerLocation.X - Player.Location.X), (PlayerLocation.Y - Player.Location.Y));
                            if (Uberprufung(point, false, Controls[f]))
                            {
                                Controls[f].Location = point;
                                KugelVersenkt(("" + Controls[f].Tag).Split('.')[1], Controls[f]);
                                if (IsBarrier && IsPlayer)
                                {
                                    PictureBox bar = new PictureBox();
                                    bar.Size = Player.Size;
                                    bar.Location = PlayerLocation;
                                    bar.BackColor = Color.Green;
                                    bar.Tag = "Barrier";
                                    Controls.Add(bar);
                                }
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (("" + Controls[f].Tag).Split('.')[0] == "KnopfMauer")
                    {
                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                   Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                   PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                   Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            if (!Controls[f].Enabled)
                                return true;
                            Console.WriteLine("KnopfMauer");
                            return false;
                        }
                    }
                    else if (("" + Controls[f].Tag).Split('.')[0] == "Knopf")
                    {
                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                       Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                       Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Knopf");
                            for (int g = 0; g < Controls.Count; g++)
                                if ("" + Controls[g].Tag == "KnopfMauer." + ("" + Controls[f].Tag).Split('.')[1])
                                {//vllt Grafik ändern
                                    Controls[g].Enabled = false;
                                    Controls[f].Enabled = false;
                                }
                            return true;
                        }
                    }
                    else if ("" + Controls[f].Tag == "Barrier")
                    {
                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                       Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                       Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Barrier");
                            if (!IsPlayer) return false;
                            IsBarrier = true;
                            return true;
                        }
                    }
                    else if (("" + Controls[f].Tag).Split('.')[0] == "KugelZiel" || ("" + Controls[f].Tag).Split('.')[0] == "Farbklecks")
                    {
                        if (PlayerLocation.X < Controls[f].Location.X + Controls[f].Width &
                       Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < Controls[f].Location.Y + Controls[f].Height &&
                       Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("KugelZiel/Farbklecks");
                            return true;
                        }
                    }
                }
            }
            if (IsBarrier && IsPlayer)
            {
                PictureBox bar = new PictureBox();
                bar.Size = Player.Size;
                bar.Location = PlayerLocation;
                bar.BackColor = Color.Green;
                bar.Tag = "Barrier";
                Controls.Add(bar);
            }
            Console.WriteLine("Frei");
            return true;
        }
        private void Knopf_Aktiv()
        {
            bool aa = true;
            for (int f = 0; f < Controls.Count; f++)
            {
                if (("" + Controls[f].Tag).Split('.')[0] == "Knopf" && !Controls[f].Enabled)
                {
                    aa = true;
                    for (int g = 0; g < Controls.Count && aa; g++)
                    {
                        if (Controls[g] == Player || Controls[g].Tag + "" == "Kasten" || (Controls[g].Tag + "").Split('.')[0] == "Kugel")
                        {
                            if (Controls[g].Location.X < Controls[f].Location.X + Controls[f].Width &
                            Controls[f].Location.X < Controls[g].Location.X + Controls[g].Size.Width &&
                            Controls[g].Location.Y < Controls[f].Location.Y + Controls[f].Height &&
                            Controls[f].Location.Y < Controls[g].Location.Y + Controls[g].Size.Height)
                            {
                                Controls[f].Enabled = aa = false;
                                for (int h = 0; h < Controls.Count; h++)
                                {
                                    if (Controls[h].Tag + "" == "KnopfMauer." + ("" + Controls[f].Tag).Split('.')[1])
                                    {
                                        Controls[h].Enabled = false;
                                    }
                                }
                            }
                            else
                            {
                                Controls[f].Enabled = true;
                                for (int h = 0; h < Controls.Count; h++)
                                {
                                    if (Controls[h].Tag + "" == "KnopfMauer." + ("" + Controls[f].Tag).Split('.')[1])
                                    {
                                        Controls[h].Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pcBRestart_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            for (int f = 0; f < Controls.Count; f++)
            {
                if (Controls[f].Tag + "" == "Player")
                    Player = Controls[f];
                if ((Controls[f].Tag + "").Split('.')[0] == "KnopfMauer")
                    Controls[f].EnabledChanged += KnopfMauer_EnabledChanged;
            }
            IsBarrier = false;
        }



        private void KugelVersenkt(string Farbe, Control Kugel)
        {
            for (int f = 0; f < Controls.Count; f++)
            {
                if (("" + Controls[f].Tag) == ("KugelZiel." + Farbe))
                {
                    if (Kugel.Location.X < Controls[f].Location.X + Controls[f].Width &
                  Controls[f].Location.X < Kugel.Location.X + Kugel.Size.Width &&
                  Kugel.Location.Y < Controls[f].Location.Y + Controls[f].Height &&
                  Controls[f].Location.Y < Kugel.Location.Y + Kugel.Size.Height) { Kugel.Dispose(); return; }
                }
                else if (("" + Controls[f].Tag).Split('.')[0] == "Farbklecks")
                    if (Kugel.Location.X < Controls[f].Location.X + Controls[f].Width &
                  Controls[f].Location.X < Kugel.Location.X + Kugel.Size.Width &&
                  Kugel.Location.Y < Controls[f].Location.Y + Controls[f].Height &&
                  Controls[f].Location.Y < Kugel.Location.Y + Kugel.Size.Height)
                    {
                        Kugel.Tag = "Kugel." + ("" + Controls[f].Tag).Split('.')[1];
                        Controls[f].Visible = false;
                        return;
                    }
            }
        }
    }
}
