using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pushy
{
    
    public class Speicher
    {
        List<Control.ControlCollection> controlCollections;
        public Speicher()
        {
            controlCollections = new List<Control.ControlCollection>();
        }
        public void Add(Control.ControlCollection Controls) => controlCollections.Add(Controls);
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
    }
}
