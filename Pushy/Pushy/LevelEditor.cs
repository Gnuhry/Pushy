using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Pushy
{
    public partial class LevelEditor : Form
    {
        private Control activeControl,Sender,ASender;
        private Point previousPosition;
        private int Breite, Hohe;
        private Speicher speicher;
        private bool beatbeiten;
        private int Level;

        public LevelEditor(Speicher speicher,int Level, bool Bearbeiten)
        {
            this.Level = Level;
            beatbeiten = Bearbeiten;
            InitializeComponent();
            this.speicher = speicher;
            Breite = Hohe = 20;
            if (Bearbeiten) return;
            numHohe.Value=Breite = speicher.GetBreite(Level);
            numBreite.Value=Hohe = speicher.GetHohe(Level);
            Control[] Controls = speicher.GetControls(Level, new Size( panel1.Width / Breite, panel1.Height / Hohe));
            for (int f = 0; f < Controls.Length; f++)
            {
                Console.WriteLine(Controls[f].Tag);
                Controls[f].MouseDown += Temp_MouseDown;
                Controls[f].MouseMove += Temp_MouseMove;
                Controls[f].MouseUp += Temp_MouseUp;
                panel1.Controls.Add(Controls[f]);
            }
            txBName.Text = speicher.GetName(Level);
            if (txBName.Text == "No Name") txBName.Text = null;
            button1.Visible =button2.Visible= true;
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
            // MessageBox.Show((((sender as Control).Tag + "").Split('.')[0] ) + "");
            if (ASender != null)
            {
                ASender.BackColor = Color.Empty;
                ASender.BackgroundImage = Properties.Resources.Boden;
            }
            ASender = sender as Control;
            (sender as Control).BackColor = Color.Orange;
            (sender as Control).BackgroundImage = null;
            
            if (((sender as Control).Tag+"").Split('.')[0]=="Kugel"|| ((sender as Control).Tag + "").Split('.')[0] == "KugelZiel" || ((sender as Control).Tag + "").Split('.')[0] == "Farbklecks")
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
            //(sender as Control).KeyDown += LevelEditor_KeyDown;

        }

        private void LevelEditor_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("yea");
            Point temp = (sender as Control).Location;
            switch (e.KeyData)
            {
                case Keys.D: temp.Offset(0, (sender as Control).Size.Width); break;
                case Keys.A: temp.Offset(0, -(sender as Control).Size.Width); break;
                case Keys.W: temp.Offset(-(sender as Control).Size.Height,0); break;
                case Keys.S: temp.Offset((sender as Control).Size.Height,0); break;
            }
            if (Randuerberprufung(temp, sender))
                (sender as Control).Location = temp;
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
                Size = new Size(panel1.Width / Breite, panel1.Height / Hohe),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackgroundImage = Properties.Resources.Boden
            };
            temp.MouseDown += Temp_MouseDown;
            temp.MouseMove += Temp_MouseMove;
            temp.MouseUp += Temp_MouseUp;
            switch (""+temp.Tag) //Garfiken hinzufügen
            {
                case "Mauer":  temp.Image = Properties.Resources.Mauer;break;
                case "Kasten": temp.Image = Properties.Resources.Kasten;  break;
                case "Kugel": temp.Image = Properties.Resources.Kugel_rot; temp.Tag += ".rot"; break;
                case "Kugelziel": temp.Image = Properties.Resources.Kugelziel_rot; temp.Tag = "KugelZiel.rot"; break;
                case "Bariere": temp.Image = Properties.Resources.Barier; temp.Tag = "Barrier"; break;
                case "Haus": temp.Image = Properties.Resources.Haus; break;
                case "Knopf": temp.Image = Properties.Resources.Knopf; temp.Tag += ".1"; break;
                case "Teleporter": temp.Image = Properties.Resources.Teleporter; temp.Tag += ".1"; break;
                case "Player": temp.Image = Properties.Resources.Player; break;
                case "Farbklecks": temp.Image = Properties.Resources.Flarbklecks_rot; temp.Tag += ".rot"; break;
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
            if (ASender != null)
            {
                ASender.BackColor = Color.Empty;
                ASender.BackgroundImage = Properties.Resources.Boden;
            }
            ASender = null;
            cBoxIsKnopfMauer.Visible = cBoxFarbe.Visible = numIndex.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Sender == null) return;
            Sender.Dispose();
            Sender = null;
            ASender = null;
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
                        if (panel1.Controls[f].Location == panel1.Controls[g].Location&&panel1.Controls[f]!=panel1.Controls[g])
                        {
                            Fehler++;
                            panel1.Controls[f].BackColor = panel1.Controls[g].BackColor = Color.Orange;
                        }
                }
            }
            if (PlayerC != 1) { MessageBox.Show("Nur ein Spieler!"); Fehler++; }
            if (HausC != 1) { MessageBox.Show("Nur ein Haus!"); Fehler++; }
            if (Fehler > 0) return;
            if (!beatbeiten)
                speicher.Add(panel1.Controls, panel1.Size, Hohe, Breite, txBName.Text,Level);
            else
                speicher.Add(panel1.Controls,panel1.Size,Hohe,Breite,txBName.Text);
            speicher.speichern(Directory.GetCurrentDirectory()+@"\Datenbank.txt");
            MessageBox.Show("Erfolgreich gespeichert");
            button1.Visible =button2.Visible= true;
        }

        private void btnClearen_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }

        private void numBreite_ValueChanged(object sender, EventArgs e)
        {
            Aktualisieren(new Size((int)numBreite.Value,Hohe));
        }

        private void Aktualisieren(Size neu)
        {
            for(int f = 0; f < panel1.Controls.Count; f++)
            {
                panel1.Controls[f].Location = new Point(panel1.Controls[f].Location.X / (panel1.Height / Hohe) * (panel1.Height / neu.Height), panel1.Controls[f].Location.Y / (panel1.Width / Breite) * (panel1.Width / neu.Width));
                panel1.Controls[f].Size = new Size( panel1.Height / neu.Height, panel1.Width / neu.Width);
                Console.WriteLine(panel1.Controls[f].Tag + "," + panel1.Controls[f].Location.ToString()+","+panel1.Controls[f].Size.ToString());
                if (panel1.Controls[f].Location.X + panel1.Controls[f].Size.Height > panel1.Height || panel1.Controls[f].Location.Y + panel1.Controls[f].Size.Width > panel1.Width)
                    panel1.Controls[f].Location = new Point(0, 0);
            }
            Hohe = neu.Height;Breite = neu.Width;
        }

        private void numHohe_ValueChanged(object sender, EventArgs e)
        {
            Aktualisieren(new Size(Breite, (int)numHohe.Value));
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text-Datei|*.txt";
            saveFileDialog1.Title = "Text Datei speichern";
            saveFileDialog1.FileName = txBName.Text;
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllLines(saveFileDialog1.FileName, speicher.GetText(Level));
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            speicher.Remove(Level);
            Close();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void cBoxFarbe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Sender.Tag + "").Split('.')[0] == "Kugel")
                switch (cBoxFarbe.SelectedIndex)
                {
                    case 0: Sender.Tag="Kugel.blau"; (Sender as PictureBox).Image = Properties.Resources.Kugel_blau; break;
                    case 1: Sender.Tag = "Kugel.rot"; (Sender as PictureBox).Image = Properties.Resources.Kugel_rot; break;
                    case 2: Sender.Tag = "Kugel.gruen"; (Sender as PictureBox).Image = Properties.Resources.Kugel_gruen; break;
                    case 3: Sender.Tag = "Kugel.gelb"; (Sender as PictureBox).Image = Properties.Resources.Kugel_gelb; break;
                }
            else if ((Sender.Tag + "").Split('.')[0] == "KugelZiel")
                switch (cBoxFarbe.SelectedIndex)
                {
                    case 0: Sender.Tag = "KugelZiel.blau"; (Sender as PictureBox).Image = Properties.Resources.Kugelziel_blau; break;
                    case 1: Sender.Tag = "KugelZiel.rot"; (Sender as PictureBox).Image = Properties.Resources.Kugelziel_rot; break;
                    case 2: Sender.Tag = "KugelZiel.gruen"; (Sender as PictureBox).Image = Properties.Resources.Kugelziel_gruen; break;
                    case 3: Sender.Tag = "KugelZiel.gelb"; (Sender as PictureBox).Image = Properties.Resources.Kugelziel_gelb; break;
                }
            else if ((Sender.Tag + "").Split('.')[0] == "Farbklecks")
                switch (cBoxFarbe.SelectedIndex)
                {
                    case 0: Sender.Tag = "Farbklecks.blau"; (Sender as PictureBox).Image = Properties.Resources.Flarbklecks_blau; break;
                    case 1: Sender.Tag = "Farbklecks.rot"; (Sender as PictureBox).Image = Properties.Resources.Flarbklecks_rot; break;
                    case 2: Sender.Tag = "Farbklecks.gruen"; (Sender as PictureBox).Image = Properties.Resources.Flarbklecks_gruen; break;
                    case 3: Sender.Tag = "Farbklecks.gelb"; (Sender as PictureBox).Image = Properties.Resources.Flarbklecks_gelb; break;
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
