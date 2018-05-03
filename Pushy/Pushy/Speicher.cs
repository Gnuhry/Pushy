using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pushy
{
    [Serializable]
    public class Speicher
    {
        List<string[]> controlCollections;
        List<string> Namen;
        List<Point> Hohe_Breite;
        public Speicher()
        {
            controlCollections = new List<string[]>();
            Namen = new List<string>();
            Hohe_Breite = new List<Point>();
        }
        public void Add(Control.ControlCollection Controls,Size PanelSize,int Hohe, int Breite, string Name)
        {
            if (Name.Trim() == "" || Name.Trim() == null) Name = "No Name";
            string[] temp = new string[Controls.Count+1];
            temp[0] = Name + "," + Hohe + ";" + Breite;
            for(int f = 1; f < temp.Length; f++)
                temp[f] = Controls[f - 1].Tag + "," + Controls[f - 1].Location.X / (PanelSize.Height / Hohe) + ";" + Controls[f - 1].Location.Y / (PanelSize.Width / Breite);
            controlCollections.Add(temp);
        }
        public void Add(Control.ControlCollection Controls, Size PanelSize, int Hohe, int Breite, string Name,int index)
        {
            string[] temp = new string[Controls.Count+1];
            temp[0] = Name + "," + Hohe + ";" + Breite;
            for (int f = 1; f < temp.Length; f++)
                temp[f] = Controls[f-1].Tag + "," + Controls[f-1].Location.X / (PanelSize.Height / Hohe) + ";" + Controls[f-1].Location.Y / (PanelSize.Width / Breite);
            controlCollections[index]=(temp);
        }
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
        public Control[] GetControls(int Levelindex,Size size)//Eine Size
        {
            Control[] erg = new Control[controlCollections[Levelindex].Length-1];
            for (int f = 0; f < erg.Length; f++)
            {
                Console.WriteLine("-----\n"+controlCollections[Levelindex][f]);
                erg[f] = new PictureBox
                {
                    Tag = controlCollections[Levelindex][f+1].Split(',')[0],
                    Location = new Point(Convert.ToInt32(controlCollections[Levelindex][f+1].Split(',')[1].Split(';')[0]) * size.Height, Convert.ToInt32(controlCollections[Levelindex][f+1].Split(',')[1].Split(';')[1]) * size.Width),
                    Size = size
                };
                switch (controlCollections[Levelindex][f+1].Split(',')[0].Split('.')[0]) //Garfiken hinzufügen
                {
                    case "Mauer": erg[f].BackColor = Color.Red; break;
                    case "Kasten": erg[f].BackColor = Color.Gray; break;
                    case "Kugel":  break;
                    case "Kugelziel":  break;
                    case "Bariere":  break;
                    case "Haus": erg[f].BackColor = Color.Black; break;
                    case "Knopf":  break;
                    case "Teleporter":  break;
                    case "Player": erg[f].BackColor = Color.Green; break;
                }
            }
            return erg;
        }
        public int Length() => controlCollections.Count;
        public string GetName(int index) =>controlCollections[index][0].Split(',')[0];
        public int GetHohe(int index) => Convert.ToInt32(controlCollections[index][0].Split(',')[1].Split(';')[0]);
        public int GetBreite(int index) => Convert.ToInt32(controlCollections[index][0].Split(',')[1].Split(';')[1]);


    }
}
