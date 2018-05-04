using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Pushy
{
    [Serializable]
    public class Speicher
    {
        List<string[]> controlCollections;
        public Speicher()
        {
            controlCollections = new List<string[]>();
        }
        public void Add(Control.ControlCollection Controls,Size PanelSize,int Hohe, int Breite, string Name)
        {
            if (Name.Trim() == "" || Name.Trim() == null) Name = "No Name";
            string[] temp = new string[Controls.Count+1];
            temp[0] = Name + "," + Hohe + ";" + Breite+"#"+int.MaxValue;
            for(int f = 1; f < temp.Length; f++)
                temp[f] = Controls[f - 1].Tag + "," + Controls[f - 1].Location.X / (PanelSize.Height / Hohe) + ";" + Controls[f - 1].Location.Y / (PanelSize.Width / Breite);
            controlCollections.Add(temp);
        }
        public void Add(Control.ControlCollection Controls, Size PanelSize, int Hohe, int Breite, string Name,int index)
        {
            string[] temp = new string[Controls.Count+1];
            temp[0] = Name + "," + Hohe + ";" + Breite + "#" + controlCollections[index][0].Split('#')[1];
            for (int f = 1; f < temp.Length; f++)
                temp[f] = Controls[f-1].Tag + "," + Controls[f-1].Location.X / (PanelSize.Height / Hohe) + ";" + Controls[f-1].Location.Y / (PanelSize.Width / Breite);
            controlCollections[index]=(temp);
        }
        public void Add(string[] text) => controlCollections.Add(text);
        public void speichern(string path)
        {
            leeren(path);
            FileStream FS = new FileStream(path, FileMode.Create);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Serialize(FS, this);
            FS.Dispose();
        }
        public Speicher laden(string path)
        {
           if (!File.Exists(path))
            {
                leeren(path);
            }
            Speicher erg = new Speicher();
            FileStream FS = new FileStream(path, FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();
            erg = (Speicher)BF.Deserialize(FS);
            FS.Dispose();
            return erg;
        }
        public void leeren(string path)
        {

            File.Delete(path);
            FileStream FS = new FileStream(path, FileMode.Create);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Serialize(FS, new Speicher());
            FS.Dispose();

        }
        public string[] GetText(int Levelindex) => controlCollections[Levelindex];
        public void Remove(int Levelindex) => controlCollections.RemoveAt(Levelindex);
        public Control[] GetControls(int Levelindex,Size size)//Eine Size
        {
            Control[] erg = new Control[controlCollections[Levelindex].Length-1];
            for (int f = 0; f < erg.Length; f++)
            {
                Console.WriteLine("-----\n"+controlCollections[Levelindex][f+1]);
                erg[f] = new PictureBox
                {
                    Tag = controlCollections[Levelindex][f + 1].Split(',')[0],
                    Location = new Point(Convert.ToInt32(controlCollections[Levelindex][f + 1].Split(',')[1].Split(';')[0]) * size.Height, Convert.ToInt32(controlCollections[Levelindex][f + 1].Split(',')[1].Split(';')[1]) * size.Width),
                    Size = size,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackgroundImage = Properties.Resources.Boden
                };
                switch (controlCollections[Levelindex][f+1].Split(',')[0].Split('.')[0]) //Grafiken hinzufügen
                {
                    case "Mauer": (erg[f] as PictureBox).Image = Properties.Resources.Mauer; erg[f].BackColor = Color.Red; break;
                    case "Kasten": (erg[f] as PictureBox).Image = Properties.Resources.Kasten; erg[f].BackColor = Color.Gray; break;
                    case "Kugel":
                        switch(controlCollections[Levelindex][f + 1].Split(',')[0].Split('.')[1])
                        {
                            case "blau": (erg[f] as PictureBox).Image = Properties.Resources.Kugel_blau; break;
                            case "rot": (erg[f] as PictureBox).Image = Properties.Resources.Kugel_rot; break;
                            case "gruen": (erg[f] as PictureBox).Image = Properties.Resources.Kugel_gruen; break;
                            case "gelb": (erg[f] as PictureBox).Image = Properties.Resources.Kugel_gelb; break;
                        }
                        break;
                    case "KugelZiel":
                        switch (controlCollections[Levelindex][f + 1].Split(',')[0].Split('.')[1])
                        {
                            case "blau": (erg[f] as PictureBox).Image = Properties.Resources.Kugelziel_blau; break;
                            case "rot": (erg[f] as PictureBox).Image = Properties.Resources.Kugelziel_rot; break;
                            case "gruen": (erg[f] as PictureBox).Image = Properties.Resources.Kugelziel_gruen; break;
                            case "gelb": (erg[f] as PictureBox).Image = Properties.Resources.Kugelziel_gelb; break;
                        }
                        break;
                    case "Bariere": (erg[f] as PictureBox).Image = Properties.Resources.Barier; break;
                    case "Haus": (erg[f] as PictureBox).Image = Properties.Resources.Haus;  break;
                    case "Knopf": (erg[f] as PictureBox).Image = Properties.Resources.Knopf; break;
                    case "Teleporter": (erg[f] as PictureBox).Image = Properties.Resources.Teleporter; break;
                    case "Player": (erg[f] as PictureBox).Image = Properties.Resources.Player;  break;
                    case "Farbklecks":
                        switch (controlCollections[Levelindex][f + 1].Split(',')[0].Split('.')[1])
                        {
                            case "blau": (erg[f] as PictureBox).Image = Properties.Resources.Flarbklecks_blau; break;
                            case "rot": (erg[f] as PictureBox).Image = Properties.Resources.Flarbklecks_rot; break;
                            case "gruen": (erg[f] as PictureBox).Image = Properties.Resources.Flarbklecks_gruen; break;
                            case "gelb": (erg[f] as PictureBox).Image = Properties.Resources.Flarbklecks_gelb; break;
                        }
                        break; 
                }
            }
            return erg;
        }
        public int Length() => controlCollections.Count;
        public string GetName(int index) =>controlCollections[index][0].Split(',')[0];
        public int GetHohe(int index) => Convert.ToInt32(controlCollections[index][0].Split(',')[1].Split(';')[0]);
        public int GetBreite(int index) => Convert.ToInt32(controlCollections[index][0].Split(',')[1].Split(';')[1].Split('#')[0]);
        public bool SetHighscore(int index, int time)
        {
            if (time >= Convert.ToInt32(controlCollections[index][0].Split('#')[1])) return false;
            controlCollections[index][0] = controlCollections[index][0].Split('#')[0] + "#" + time;
            speichern(Directory.GetCurrentDirectory() + @"\Datenbank.txt");
            return true;
        }


    }
}
