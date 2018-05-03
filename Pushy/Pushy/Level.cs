using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pushy
{
    public partial class Level : Form
    {
        Control Player;
        static int Hoch, Seite;
        bool IsBarrier;
        Speicher speicher;
        int level;
        Timer timer;
        public Level(Speicher speicher,int Level)
        {
            timer = new Timer();
            InitializeComponent();
            this.speicher = speicher;
            level = Level;
            Control[] Controls = speicher.GetControls(Level, new Size( panel1.Width / speicher.GetBreite(Level), panel1.Height / speicher.GetHohe(Level)));
            for (int f = 0; f < Controls.Length; f++)
            {
                panel1.Controls.Add(Controls[f]);
            }
            KeyDown += Form1_KeyDown;
            for (int f = 0; f <panel1.Controls.Count; f++)
            {
                if (panel1.Controls[f].Tag + "" == "Player")
                    Player = panel1.Controls[f];
                if ((panel1.Controls[f].Tag + "").Split('.')[0] == "KnopfMauer")
                    panel1.Controls[f].EnabledChanged += KnopfMauer_EnabledChanged;
            }
            Hoch = Player.Height;
            Seite = Player.Width;
            IsBarrier = false;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = Convert.ToInt32(label1.Text) + 1 + "";
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
            for (int f = 0; f < panel1.Controls.Count; f++)
            {
                if (panel1.Controls[f].Enabled && panel1.Controls[f].Visible)
                    if (("" + panel1.Controls[f].Tag).Split('.')[0] == "Kugel") return;
            }
            timer.Stop();
            if (speicher.SetHighscore(level, Convert.ToInt32(label1.Text)))
                MessageBox.Show("New Highscore");
            MessageBox.Show("Gewonnen");
        }
        private bool Uberprufung(Point PlayerLocation, bool IsPlayer, Control Player)
        {
            for (int f = 0; f < panel1.Controls.Count; f++)
            {
                if (panel1.Controls[f].Visible)
                {
                    if ("" + panel1.Controls[f].Tag == "Mauer")
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Mauer");
                            return false;
                        }
                    }
                    else if ("" + panel1.Controls[f].Tag == "Haus")
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Haus");
                            if (!IsPlayer) return false;
                            Win();
                            return true;
                        }
                    }
                    else if (("" + panel1.Controls[f].Tag).Split('.')[0] == "Teleporter")
                    {//z.B. Teleporter.1
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Teleporter");
                            if (!IsPlayer) return false;
                            for (int g = 0; g < panel1.Controls.Count; g++)
                                if (panel1.Controls[g].Tag == panel1.Controls[f].Tag && panel1.Controls[g] != panel1.Controls[f])
                                    Player.Location = panel1.Controls[g].Location;
                            return false;
                        }
                    }
                    else if ("" + panel1.Controls[f].Tag == "Kasten")
                    {

                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Kasten");
                            if (!IsPlayer) return false;
                            Point point = panel1.Controls[f].Location;
                            point.Offset((PlayerLocation.X - Player.Location.X), (PlayerLocation.Y - Player.Location.Y));
                            if (Uberprufung(point, false, panel1.Controls[f]))
                            {
                                panel1.Controls[f].Location = point;
                                if (IsBarrier && IsPlayer)
                                {
                                    PictureBox bar = new PictureBox();
                                    bar.Size = Player.Size;
                                    bar.Location = PlayerLocation;
                                    bar.BackColor = Color.Green;
                                    bar.Tag = "Barrier";
                                    panel1.Controls.Add(bar);
                                }
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (("" + panel1.Controls[f].Tag).Split('.')[0] == "Kugel")
                    {

                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Kugel");
                            if (!IsPlayer) return false;
                            Point point = panel1.Controls[f].Location;
                            point.Offset((PlayerLocation.X - Player.Location.X), (PlayerLocation.Y - Player.Location.Y));
                            if (Uberprufung(point, false, panel1.Controls[f]))
                            {
                                panel1.Controls[f].Location = point;
                                KugelVersenkt(("" + panel1.Controls[f].Tag).Split('.')[1], panel1.Controls[f]);
                                if (IsBarrier && IsPlayer)
                                {
                                    PictureBox bar = new PictureBox();
                                    bar.Size = Player.Size;
                                    bar.Location = PlayerLocation;
                                    bar.BackColor = Color.Green;
                                    bar.Tag = "Barrier";
                                    panel1.Controls.Add(bar);
                                }
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (("" + panel1.Controls[f].Tag).Split('.')[0] == "KnopfMauer")
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                   panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                   PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                   panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            if (!panel1.Controls[f].Enabled)
                                return true;
                            Console.WriteLine("KnopfMauer");
                            return false;
                        }
                    }
                    else if (("" + panel1.Controls[f].Tag).Split('.')[0] == "Knopf")
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Knopf");
                            for (int g = 0; g < panel1.Controls.Count; g++)
                                if ("" + panel1.Controls[g].Tag == "KnopfMauer." + ("" + panel1.Controls[f].Tag).Split('.')[1])
                                {//vllt Grafik ändern
                                    panel1.Controls[g].Enabled = false;
                                    panel1.Controls[f].Enabled = false;
                                }
                            return true;
                        }
                    }
                    else if ("" + panel1.Controls[f].Tag == "Barrier")
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Barrier");
                            if (!IsPlayer) return false;
                            IsBarrier = true;
                            return true;
                        }
                    }
                    else if (("" + panel1.Controls[f].Tag).Split('.')[0] == "KugelZiel" || ("" + panel1.Controls[f].Tag).Split('.')[0] == "Farbklecks")
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("KugelZiel/Farbklecks");
                            return true;
                        }
                    }
                }
            }
            if (PlayerLocation.X < 0 || PlayerLocation.Y < 0 || PlayerLocation.X+Player.Height > panel1.Height || PlayerLocation.Y+Player.Width > panel1.Width)
            {
                Console.WriteLine("Außerhalb");
                return false;
            }
            if (IsBarrier && IsPlayer)
            {
                PictureBox bar = new PictureBox();
                bar.Size = Player.Size;
                bar.Location = PlayerLocation;
                bar.BackColor = Color.Green;
                bar.Tag = "Barrier";
                panel1.Controls.Add(bar);
            }
            Console.WriteLine("Frei");
            return true;
        }
        private void Knopf_Aktiv()
        {
            bool aa = true;
            for (int f = 0; f < panel1.Controls.Count; f++)
            {
                if (("" + panel1.Controls[f].Tag).Split('.')[0] == "Knopf" && !panel1.Controls[f].Enabled)
                {
                    aa = true;
                    for (int g = 0; g < panel1.Controls.Count && aa; g++)
                    {
                        if (panel1.Controls[g] == Player || panel1.Controls[g].Tag + "" == "Kasten" || (panel1.Controls[g].Tag + "").Split('.')[0] == "Kugel")
                        {
                            if (panel1.Controls[g].Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                            panel1.Controls[f].Location.X < panel1.Controls[g].Location.X + panel1.Controls[g].Size.Width &&
                            panel1.Controls[g].Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                            panel1.Controls[f].Location.Y < panel1.Controls[g].Location.Y + panel1.Controls[g].Size.Height)
                            {
                                panel1.Controls[f].Enabled = aa = false;
                                for (int h = 0; h < panel1.Controls.Count; h++)
                                {
                                    if (panel1.Controls[h].Tag + "" == "KnopfMauer." + ("" + panel1.Controls[f].Tag).Split('.')[1])
                                    {
                                        panel1.Controls[h].Enabled = false;
                                    }
                                }
                            }
                            else
                            {
                                panel1.Controls[f].Enabled = true;
                                for (int h = 0; h < panel1.Controls.Count; h++)
                                {
                                    if (panel1.Controls[h].Tag + "" == "KnopfMauer." + ("" + panel1.Controls[f].Tag).Split('.')[1])
                                    {
                                        panel1.Controls[h].Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pcBReset_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Control[] Controls = speicher.GetControls(level, new Size(panel1.Width / speicher.GetBreite(level), panel1.Height / speicher.GetHohe(level)));
            for (int f = 0; f < Controls.Length; f++)
            {
                panel1.Controls.Add(Controls[f]);
            }
            for (int f = 0; f < panel1.Controls.Count; f++)
            {
                if (panel1.Controls[f].Tag + "" == "Player")
                    Player = panel1.Controls[f];
                if ((panel1.Controls[f].Tag + "").Split('.')[0] == "KnopfMauer")
                    panel1.Controls[f].EnabledChanged += KnopfMauer_EnabledChanged;
            }
            Hoch = Player.Height;
            Seite = Player.Width;
            IsBarrier = false;
            label1.Text = "0";
        }

        private void KugelVersenkt(string Farbe, Control Kugel)
        {
            for (int f = 0; f < panel1.Controls.Count; f++)
            {
                if (("" + panel1.Controls[f].Tag) == ("KugelZiel." + Farbe))
                {
                    if (Kugel.Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                  panel1.Controls[f].Location.X < Kugel.Location.X + Kugel.Size.Width &&
                  Kugel.Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                  panel1.Controls[f].Location.Y < Kugel.Location.Y + Kugel.Size.Height) { Kugel.Dispose(); return; }
                }
                else if (("" + panel1.Controls[f].Tag).Split('.')[0] == "Farbklecks")
                    if (Kugel.Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                  panel1.Controls[f].Location.X < Kugel.Location.X + Kugel.Size.Width &&
                  Kugel.Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                  panel1.Controls[f].Location.Y < Kugel.Location.Y + Kugel.Size.Height)
                    {
                        Kugel.Tag = "Kugel." + ("" + panel1.Controls[f].Tag).Split('.')[1];
                        panel1.Controls[f].Visible = false;
                        return;
                    }
            }
        }
    }
}
