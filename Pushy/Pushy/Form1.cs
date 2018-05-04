using System;
using System.IO;
using System.Windows.Forms;

namespace Pushy
{
    public partial class Form1 : Form
    {
        Speicher speicher;
        string tag;
        public Form1()
        {
            speicher = new Speicher().laden(Directory.GetCurrentDirectory()+@"\Datenbank.txt");
            InitializeComponent();
            Temp_FormClosed(null, null);
            comBox.SelectedIndex = comBox.Items.Count - 1;
        }


        private void btnLevelEditor_Click(object sender, EventArgs e)
        {
            tag = comBox.SelectedItem+"";
           LevelEditor temp= new LevelEditor(speicher,comBox.SelectedIndex, comBox.SelectedItem+"" == "Neues Level");
            temp.FormClosed += Temp_FormClosed;
            temp.Show();
        }

        private void Temp_FormClosed(object sender, FormClosedEventArgs e)
        {
            comBox.Items.Clear();
            for (int f = 0; f < speicher.Length(); f++)
            {
                comBox.Items.Add("Level " + (f + 1)+" - "+speicher.GetName(f));
            }
            comBox.Items.Add("Neues Level");
            if (sender == null) return;
            switch(tag.Split(' ')[1])
            {
                case "Level": comBox.SelectedIndex = comBox.Items.Count - 1; break;
                default: comBox.SelectedIndex = Convert.ToInt32(tag.Split(' ')[1]) - 1; break;
            }
            
        }

        private void btnStarten_Click(object sender, EventArgs e)
        {
            if (comBox.SelectedItem + "" == "Neues Level") return;
            new Level(speicher,comBox.SelectedIndex).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Datei|*.txt";
            openFileDialog1.Title = "Text Datei öffnen";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    speicher.Add(File.ReadAllLines(openFileDialog1.FileName));
                }
                catch (Exception)
                {
                    MessageBox.Show("Text Datei ist keine LevelDatei");
                    return;
                }
            }
            Temp_FormClosed(null, null);
            comBox.SelectedIndex = comBox.Items.Count - 2;

        }
    }
}
