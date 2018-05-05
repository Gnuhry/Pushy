using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pushy
{
    public partial class Level : Form
    {
        Control Player,Player2;
        static int Hoch, Seite;
        bool IsBarrier;
        Speicher speicher;
        int level;
        Timer timer;
        Control[] DefaultContol;
        public Level(Speicher speicher,int Level)
        {
            Player = Player2 = null;
            timer = new Timer();
            InitializeComponent();
            this.speicher = speicher;
            level = Level;
            Control[] Controls = speicher.GetControls(Level, new Size( panel1.Width / speicher.GetBreite(Level), panel1.Height / speicher.GetHohe(Level)));
            DefaultContol = Controls;
            /*for (int f = 0; f < Controls.Length; f++)
            {
                panel1.Controls.Add(Controls[f]);
            }*/
            panel1.Controls.AddRange(Controls);
            for (int f = 0; f <panel1.Controls.Count; f++)
            {
                if (panel1.Controls[f].Tag + "" == "Player")
                    Player = panel1.Controls[f];               
                else if (panel1.Controls[f].Tag + "" == "Player2")
                    Player2 = panel1.Controls[f];
                else if ((panel1.Controls[f].Tag + "").Split('.')[0] == "KnopfMauer")
                    panel1.Controls[f].EnabledChanged += KnopfMauer_EnabledChanged;
                //if (panel1.Controls[f].Tag + "" == "Player"|| panel1.Controls[f].Tag + "" == "Player2"||panel1.Controls[f].Tag + "" == "Kasten"||(panel1.Controls[f].Tag + "").Split('.')[0] == "Kugel")
                  //  panel1.Controls[f].BringToFront();
            }
            Hoch = Player.Height;
            Seite = Player.Width;
            IsBarrier = false;
            KeyDown += Form1_KeyDown;
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
            int Player1=0;
            Point temp = Player.Location;
            if (Player != null)
            {            
                if (e.KeyData == Keys.Down) { temp.Offset(0, Player.Height); Player1 = 1; }
                else if (e.KeyData == Keys.Up) { temp.Offset(0, -Player.Height); Player1 = 1; }
                else if (e.KeyData == Keys.Right) { temp.Offset(Player.Width, 0); Player1 = 1; }
                else if (e.KeyData == Keys.Left) { temp.Offset(-Player.Width, 0); Player1 = 1; }
            }
            if (Player2 != null)
            {
                if (e.KeyData == Keys.S) { temp = Player2.Location; temp.Offset(0, Player2.Height); Player1 = 2; }
                else if (e.KeyData == Keys.W) { temp = Player2.Location; temp.Offset(0, -Player2.Height); Player1 = 2; }
                else if (e.KeyData == Keys.D) { temp = Player2.Location; temp.Offset(Player2.Width, 0); Player1 = 2; }
                else if (e.KeyData == Keys.A) { temp = Player2.Location; temp.Offset(-Player2.Width, 0); Player1 = 2; }
            }
            if (Player1 == 0) return;
            if (Player1==1)
            {
                if (Uberprufung(temp, true, Player))
                {
                    Player.Location = temp;
                    Knopf_Aktiv();
                }
            }
            else if(Player1==2)
            {
                if (Uberprufung(temp, true, Player2))
                {
                    Player2.Location = temp;
                    Knopf_Aktiv();
                }
            }
        }
        private void KnopfMauer_EnabledChanged(object sender, EventArgs e)
        {
            if ((sender as Control).Enabled) (sender as PictureBox).Image = Properties.Resources.Mauer;
            else (sender as PictureBox).Image = Properties.Resources.Boden;
        }


        private void Win(Point PlayerLocation,bool IsPlayer1)
        { 
            for (int f = 0; f < panel1.Controls.Count; f++)
            {
                if (panel1.Controls[f].Enabled && panel1.Controls[f].Visible)
                {
                    if (("" + panel1.Controls[f].Tag).Split('.')[0] == "Kugel") { Console.WriteLine("Kugel fehlt noch"); return; }
                    if ("" + panel1.Controls[f].Tag == "Haus"&&Player2!=null&&IsPlayer1)
                    {
                        if ((PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                           panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                           PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                           panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)) { }
                        else
                        {
                            Console.WriteLine(Player.Location.ToString() + "," + panel1.Controls[f].Location.ToString());
                            Console.WriteLine("Player 1 nicht im Haus");
                            return;
                        }
                    }
                    if ("" + panel1.Controls[f].Tag == "Haus" && Player2 != null && !IsPlayer1)
                    {
                        if ((Player.Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                           panel1.Controls[f].Location.X < Player.Location.X + Player.Size.Width &&
                           Player.Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                           panel1.Controls[f].Location.Y < Player.Location.Y + Player.Size.Height)) { }
                        else
                        {
                            Console.WriteLine(Player.Location.ToString() + "," + panel1.Controls[f].Location.ToString());
                            Console.WriteLine("Player 1 nicht im Haus");
                            return;
                        }
                    }
                    if ("" + panel1.Controls[f].Tag == "Haus2" && Player2 != null && IsPlayer1)
                    {
                        if ((Player2.Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                           panel1.Controls[f].Location.X < Player2.Location.X + Player2.Size.Width &&
                           Player2.Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                           panel1.Controls[f].Location.Y < Player2.Location.Y + Player2.Size.Height)) { }
                        else
                        {
                            Console.WriteLine(Player2.Location.ToString() + "," + panel1.Controls[f].Location.ToString());
                            Console.WriteLine("Player 2 nicht im Haus");
                            return;
                        }
                    }
                    if ("" + panel1.Controls[f].Tag == "Haus2" && Player2 != null&&!IsPlayer1)
                    {
                        if ((PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                           panel1.Controls[f].Location.X < PlayerLocation.X + Player2.Size.Width &&
                           PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                           panel1.Controls[f].Location.Y < PlayerLocation.Y + Player2.Size.Height)) { }
                        else
                        {
                            Console.WriteLine(Player2.Location.ToString() + "," + panel1.Controls[f].Location.ToString());
                            Console.WriteLine("Player 2 nicht im Haus");
                            return;
                        }
                    }
                }

            }
            timer.Stop();
            if (speicher.SetHighscore(level, Convert.ToInt32(label1.Text)))
                MessageBox.Show("New Highscore");
            MessageBox.Show("Gewonnen\nZeit: "+label1.Text+" sek");
            Close();
        }
        private bool Uberprufung(Point PlayerLocation, bool IsPlayer, Control Player)
        {
            if (Player2 != null)
            {
                if (Player == this.Player||!IsPlayer)
                {
                    if (PlayerLocation.X < Player2.Location.X + Player2.Width &
                           Player2.Location.X < PlayerLocation.X + Player.Size.Width &&
                           PlayerLocation.Y < Player2.Location.Y + Player2.Height &&
                           Player2.Location.Y < PlayerLocation.Y + Player.Size.Height) { Console.WriteLine("Player2"); return false; }
                }
                if (Player == Player2||!IsPlayer)
                {
                    if (PlayerLocation.X < this.Player.Location.X + this.Player.Width &
                           this.Player.Location.X < PlayerLocation.X + Player.Size.Width &&
                           PlayerLocation.Y < this.Player.Location.Y + this.Player.Height &&
                           this.Player.Location.Y < PlayerLocation.Y + Player.Size.Height) { Console.WriteLine("Player"); return false; }
                }
                
            }
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
                    else if ("" + panel1.Controls[f].Tag == "Haus"|| "" + panel1.Controls[f].Tag == "Haus2")
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Haus");
                            if (!IsPlayer) return false;
                            Win(PlayerLocation,Player==this.Player);
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
                            for (int i = 0; i < panel1.Controls.Count; i++)
                            {
                                if (i != f)
                                    if (("" + panel1.Controls[i].Tag).Split('.')[0] == "Kugel" || ("" + panel1.Controls[i].Tag) == "Kasten")
                                    {
                                        if (panel1.Controls[i].Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                         panel1.Controls[f].Location.X < panel1.Controls[i].Location.X + panel1.Controls[i].Size.Width &&
                         panel1.Controls[i].Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                         panel1.Controls[f].Location.Y < panel1.Controls[i].Location.Y + panel1.Controls[f].Size.Height)
                                        {
                                            if (!IsPlayer) { MessageBox.Show("Ni"); return false; }
                                            else
                                            {
                                                Point point = panel1.Controls[i].Location;
                                                point.Offset((PlayerLocation.X - Player.Location.X), (PlayerLocation.Y - Player.Location.Y));
                                                if (Uberprufung(point, false, panel1.Controls[i]))
                                                {
                                                    panel1.Controls[i].Location = point;
                                                }
                                                else { Uberprufung(PlayerLocation, true, Player); MessageBox.Show("Nope"); return false; }
                                            }
                                        }
                                    }
                            }
                                for(int g = 0; g < panel1.Controls.Count; g++) //Suche nach anderem Teleporter
                                {
                                    if (panel1.Controls[f].Tag + "" == panel1.Controls[g].Tag + "" && f != g)
                                    {
                                        for(int h = 0; h < Controls.Count; h++)
                                        {
                                            if (h != g)
                                                if (("" + panel1.Controls[h].Tag).Split('.')[0] == "Kugel" || ("" + panel1.Controls[h].Tag) == "Kasten"|| panel1.Controls[h]==this.Player|| panel1.Controls[h]==Player2)
                                                {
                                                    if (panel1.Controls[h].Location.X < panel1.Controls[g].Location.X + panel1.Controls[g].Width &
                                     panel1.Controls[g].Location.X < panel1.Controls[h].Location.X + panel1.Controls[h].Size.Width &&
                                     panel1.Controls[h].Location.Y < panel1.Controls[g].Location.Y + panel1.Controls[g].Height &&
                                     panel1.Controls[g].Location.Y < panel1.Controls[h].Location.Y + panel1.Controls[h].Size.Height)
                                                { MessageBox.Show("Yo"); return true; }
                                                }
                                        }
                                    MessageBox.Show("Yep");
                                        Player.Location = panel1.Controls[g].Location;
                                    panel1.Controls[g].SendToBack();
                                        return false;
                                    }
                                }
                            

                                        //       if(IsPlayer)
                                        //       for(int i = 0; i < panel1.Controls.Count; i++)
                                        //       {
                                        //           if(("" + panel1.Controls[i].Tag).Split('.')[0] == "Kugel" || ("" + panel1.Controls[i].Tag) == "Kasten")
                                        //           {
                                        //               if (panel1.Controls[i].Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                                        //panel1.Controls[f].Location.X < panel1.Controls[i].Location.X + panel1.Controls[i].Size.Width &&
                                        //panel1.Controls[i].Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                                        //panel1.Controls[f].Location.Y < panel1.Controls[i].Location.Y + panel1.Controls[f].Size.Height)
                                        //               {
                                        //                   Point point = panel1.Controls[i].Location;
                                        //                   point.Offset((PlayerLocation.X - Player.Location.X), (PlayerLocation.Y - Player.Location.Y));
                                        //                   if (Uberprufung(point, false, panel1.Controls[i]))
                                        //                   {
                                        //                       panel1.Controls[i].Location = point;
                                        //                   }
                                        //                   else { }
                                        //               }
                                        //           }
                                        //       }
                                        //       Console.WriteLine("Teleporter");
                                        //       //if (!IsPlayer) return false;
                                        //       for (int g = 0; g < panel1.Controls.Count; g++)
                                        //       {
                                        //           if (panel1.Controls[g].Tag+"" == panel1.Controls[f].Tag+"" && g != f)
                                        //           {
                                        //               for(int h = 0; h < panel1.Controls.Count; h++)
                                        //               {
                                        //                   if(h!=g)
                                        //                   if (panel1.Controls[g].Location.X < panel1.Controls[h].Location.X + panel1.Controls[h].Size.Width &
                                        // panel1.Controls[h].Location.X < panel1.Controls[g].Location.X + panel1.Controls[g].Size.Width &&
                                        // panel1.Controls[g].Location.Y < panel1.Controls[h].Location.Y + panel1.Controls[h].Size.Height &&
                                        // panel1.Controls[h].Location.Y < panel1.Controls[g].Location.Y + panel1.Controls[g].Size.Height) { Console.WriteLine("Teleporter blockiert"); return true; }
                                        //               }
                                        //               Console.WriteLine("Energie"+ panel1.Controls[g].Location.ToString());
                                        //               Player.Location = panel1.Controls[g].Location;
                                        //               Player.BringToFront();
                                        //           }
                                        //       }
                                        //       if (!IsPlayer) return true;
                                        //       return false;
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
                            Uberprufung(this.Player.Location, true, this.Player);
                            if (Player2 != null)
                                Uberprufung(Player2.Location, true, this.Player2);
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
                                //KugelVersenkt(("" + panel1.Controls[f].Tag).Split('.')[1], panel1.Controls[f]);
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
                                {
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
                    else if (("" + panel1.Controls[f].Tag).Split('.')[0] == "KugelZiel" )
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("KugelZiel");
                            if (Player.Tag + "" != "Kasten" && !IsPlayer)
                            {
                                if ("KugelZiel." + (Player.Tag + "").Split('.')[1] == panel1.Controls[f].Tag+"")
                                {
                                    if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                 panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                 PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                 panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height) { Player.Dispose(); }
                                }
                            }
                            return true;
                        }
                    }
                    else if ( ("" + panel1.Controls[f].Tag).Split('.')[0] == "Farbklecks")
                    {
                        if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                       panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                       PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                       panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                        {
                            Console.WriteLine("Farbklecks");
                            if (Player.Tag + "" != "Kasten" && !IsPlayer)
                            {
                                if (PlayerLocation.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
                panel1.Controls[f].Location.X < PlayerLocation.X + Player.Size.Width &&
                PlayerLocation.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
                panel1.Controls[f].Location.Y < PlayerLocation.Y + Player.Size.Height)
                                {
                                    Player.Tag = "Kugel." + ("" + panel1.Controls[f].Tag).Split('.')[1];
                                    switch (("" + panel1.Controls[f].Tag).Split('.')[1])
                                    {
                                        case "blau": (Player as PictureBox).Image = Properties.Resources.Kugel_blau; break;
                                        case "rot": (Player as PictureBox).Image = Properties.Resources.Kugel_rot; break;
                                        case "gruen": (Player as PictureBox).Image = Properties.Resources.Kugel_gruen; break;
                                        case "gelb": (Player as PictureBox).Image = Properties.Resources.Kugel_gelb; break;
                                    }
                                    panel1.Controls[f].Visible = false;
                                }
                            }
                            return true;
                        }
                    }
                }
            }
            if (PlayerLocation.X < 0 || PlayerLocation.Y < 0 || PlayerLocation.X+Player.Height > panel1.Width || PlayerLocation.Y+Player.Width > panel1.Height)
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
                        if (panel1.Controls[g] == Player || panel1.Controls[g] == Player2 || panel1.Controls[g].Tag + "" == "Kasten" || (panel1.Controls[g].Tag + "").Split('.')[0] == "Kugel")
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
            KeyDown -= Form1_KeyDown;
            panel1.Controls.Clear();
            // Control[] Controls = speicher.GetControls(level, new Size(panel1.Height / speicher.GetHohe(level), panel1.Width / speicher.GetBreite(level)));
            /*for (int f = 0; f < Controls.Length; f++)
            {
                panel1.Controls.Add(Controls[f]);
            }*/
            panel1.Controls.AddRange(speicher.GetControls(level, new Size(panel1.Height / speicher.GetHohe(level), panel1.Width / speicher.GetBreite(level))));
            //panel1.Controls.AddRange(DefaultContol);
            for (int f = 0; f < panel1.Controls.Count; f++)
            {
                if (panel1.Controls[f].Tag + "" == "Player")
                    Player = panel1.Controls[f];
                if (panel1.Controls[f].Tag + "" == "Player2")
                    Player2 = panel1.Controls[f];
                if ((panel1.Controls[f].Tag + "").Split('.')[0] == "KnopfMauer")
                    panel1.Controls[f].EnabledChanged += KnopfMauer_EnabledChanged;
            }
            Hoch = Player.Height;
            Seite = Player.Width;
            IsBarrier = false;
            label1.Text = "0";
            KeyDown += Form1_KeyDown;
        }

        private void Level_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine(Convert.ToInt32(panel1.MinimumSize.Width * (Convert.ToDouble(Width) / MinimumSize.Width)) + "," + Convert.ToInt32(panel1.MinimumSize.Height * (Convert.ToDouble(Height) / MinimumSize.Height)));
            panel1.Size = new Size(Convert.ToInt32(panel1.MinimumSize.Width * (Convert.ToDouble(Width) / MinimumSize.Width)), Convert.ToInt32(panel1.MinimumSize.Height * (Convert.ToDouble(Height) / MinimumSize.Height)));
            pcBReset_Click(null, null);
        }

        private void Level_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        //private void KugelVersenkt(string Farbe, Control Kugel)
        //{
        //    for (int f = 0; f < panel1.Controls.Count; f++)
        //    {
        //        if (("" + panel1.Controls[f].Tag) == ("KugelZiel." + Farbe))
        //        {
        //            if (Kugel.Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
        //          panel1.Controls[f].Location.X < Kugel.Location.X + Kugel.Size.Width &&
        //          Kugel.Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
        //          panel1.Controls[f].Location.Y < Kugel.Location.Y + Kugel.Size.Height) { Kugel.Dispose(); return; }
        //        }
        //        else if (("" + panel1.Controls[f].Tag).Split('.')[0] == "Farbklecks")
        //            if (Kugel.Location.X < panel1.Controls[f].Location.X + panel1.Controls[f].Width &
        //          panel1.Controls[f].Location.X < Kugel.Location.X + Kugel.Size.Width &&
        //          Kugel.Location.Y < panel1.Controls[f].Location.Y + panel1.Controls[f].Height &&
        //          panel1.Controls[f].Location.Y < Kugel.Location.Y + Kugel.Size.Height)
        //            {
        //                Kugel.Tag = "Kugel." + ("" + panel1.Controls[f].Tag).Split('.')[1];
        //                switch(("" + panel1.Controls[f].Tag).Split('.')[1])
        //                {
        //                     case "blau": (Kugel as PictureBox).Image = Properties.Resources.Kugel_blau; break;
        //                    case "rot": (Kugel as PictureBox).Image = Properties.Resources.Kugel_rot; break;
        //                    case "gruen": (Kugel as PictureBox).Image = Properties.Resources.Kugel_gruen; break;
        //                    case "gelb": (Kugel as PictureBox).Image = Properties.Resources.Kugel_gelb; break;
        //                }
        //                panel1.Controls[f].Visible = false;
        //                return;
        //            }
        //    }
        //}
    }
}
