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
        private Control activeControl,Sender;
        private Point previousPosition;
        static int Breite = 20, Hohe = 20;
        private Speicher speicher;

        public LevelEditor()
        {
            InitializeComponent();
            speicher = new Speicher().laden(@"\Datenbank.txt");
        }


        private void Temp_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
            Cursor = Cursors.Default;
            Sender = sender as Control;



            Point temp = (sender as Control).Location;
            Console.WriteLine(temp.ToString());
            Console.WriteLine(temp.Y % (panel1.Width / Breite));
            if (temp.Y % (panel1.Width / Breite) > (panel1.Width / Breite / 2)) temp.Y = (temp.Y / (panel1.Width / Breite) + 1) * (panel1.Width / Breite);
            else temp.Y = temp.Y / (panel1.Width / Breite) * (panel1.Width / Breite);
            if (temp.X % (panel1.Height / Hohe) > (panel1.Height / Hohe / 2)) temp.X = (temp.X / (panel1.Height / Hohe) + 1) * (panel1.Height / Hohe);
            else temp.X = temp.X / (panel1.Height / Hohe) * (panel1.Height / Hohe);
            Console.WriteLine(temp.ToString());
            (sender as Control).Location = temp;
            cBoxIsKnopfMauer.Visible = cBoxFarbe.Visible = numIndex.Visible = false;
            if (((sender as Control).Tag+"").Split('.')[0]=="Kugel"|| ((sender as Control).Tag + "").Split('.')[0] == "KugelZiel")
            {
                cBoxFarbe.Visible = true;
                switch(((sender as Control).Tag + "").Split('.')[1])
                {
                    case "blau": cBoxFarbe.SelectedIndex = 0; break;
                    case "rot": cBoxFarbe.SelectedIndex = 1; break;
                    case "gruen": cBoxFarbe.SelectedIndex = 2; break;
                    case "gelb": cBoxFarbe.SelectedIndex = 3; break;
                }
            }
            else if (((sender as Control).Tag + "").Split('.')[0] == "Teleporter"|| ((sender as Control).Tag + "").Split('.')[0] == "Knopf")
            {
                numIndex.Visible = true;
                numIndex.Value = Convert.ToInt32(((sender as Control).Tag + "").Split('.')[1]);
            }
            else if (((sender as Control).Tag + "").Split('.')[0] == "KnopfMauer")
            {
                numIndex.Visible = true;
                numIndex.Value = Convert.ToInt32(((sender as Control).Tag + "").Split('.')[1]);
                cBoxIsKnopfMauer.Visible = true;
                cBoxIsKnopfMauer.Checked = true;
            }
            else if (((sender as Control).Tag + "") == "Mauer")
            {
                cBoxIsKnopfMauer.Visible = true;
                cBoxIsKnopfMauer.Checked = false;
            }

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
            if (location.X < 0|| location.X + (sender as Control).Width > panel1.Size.Width)
                return false;
            if (location.Y < 0 || location.Y + (sender as Control).Height > panel1.Size.Height)
                return false;
            return true;
        }

        private void label_Click(object sender, EventArgs e)
        {
            PictureBox temp = new PictureBox
            {
                Tag = "" + (sender as Control).Text,
                Size = new Size(panel1.Width / 20, panel1.Height / 20)
            };
            temp.MouseDown += Temp_MouseDown;
            temp.MouseMove += Temp_MouseMove;
            temp.MouseUp += Temp_MouseUp;
            switch (""+temp.Tag)
            {
                case "Mauer": temp.BackColor = Color.Red; break;
                case "Kasten": temp.BackColor = Color.Gray; break;
                case "Kugel": temp.Tag += ".rot"; break;
                case "Kugelziel": temp.Tag = "KugelZiel.rot"; break;
                case "Bariere": temp.Tag = "Barrier"; break;
                case "Haus":  break;
                case "Knopf": temp.Tag += ".1"; break;
                case "Teleporter": temp.Tag = "Barrier"; break;
            }
            panel1.Controls.Add(temp);
            Console.WriteLine(temp.Tag);
        }

        private void cBoxIsKnopfMauer_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIsKnopfMauer.Checked)
            {
                Sender.Tag = "KnopfMauer." + ((int)numIndex.Value);
                numIndex.Visible = true;
            }
            else
            {
                Sender.Tag = "Mauer";
                numIndex.Visible = false;
            }
        }

        private void numIndex_ValueChanged(object sender, EventArgs e)
        {
            Sender.Tag = (Sender.Tag+"").Split('.')[0]+"." + ((int)numIndex.Value);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Sender = null;
            cBoxIsKnopfMauer.Visible = cBoxFarbe.Visible = numIndex.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Sender == null) return;
            Sender.Dispose();
            Sender = null;
            cBoxIsKnopfMauer.Visible = cBoxFarbe.Visible = numIndex.Visible = false;

        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            int PlayerC = 0, HausC = 0, Fehler=0;
            for(int f = 0; f < panel1.Controls.Count; f++)
            {
                switch ((panel1.Controls[f].Tag + "").Split('.')[0])
                {
                    case "Player": PlayerC++; break;
                    case "Haus": HausC++; break;
                }
                if((panel1.Controls[f].Tag + "").Split('.')[0] != "Mauer")
                {
                    for(int g=0;g<panel1.Controls.Count;g++)
                        if (panel1.Controls[f].Location == panel1.Controls[g].Location)
                        {
                            Fehler++;
                            panel1.Controls[f].BackColor = panel1.Controls[g].BackColor = Color.Orange;
                        }
                }
            }
            if (PlayerC != 1) { MessageBox.Show("Nur ein Spieler!"); Fehler++; }
            if (HausC != 1) { MessageBox.Show("Nur ein Haus!"); Fehler++; }
            if (Fehler > 0) return;
            speicher.Add(panel1.Controls);
            speicher.speichern(@"\Datenbank.txt");
            MessageBox.Show("Erfolgreich gespeichert");
        }

        private void btnClearen_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }

        private void cBoxFarbe_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxFarbe.SelectedIndex)
            {
                case 0: Sender.Tag = (Sender.Tag + "").Split('.')[0] + ".blau"; break;
                case 1: Sender.Tag = (Sender.Tag + "").Split('.')[0] + ".rot"; break;
                case 2: Sender.Tag = (Sender.Tag + "").Split('.')[0] + ".gruen"; break;
                case 3: Sender.Tag = (Sender.Tag + "").Split('.')[0] + ".gelb"; break;
            }
        }

        private void Temp_MouseDown(object sender, MouseEventArgs e)
        {
            activeControl = sender as Control;
            previousPosition = e.Location;
            Cursor = Cursors.Hand;
        }
    }
}
