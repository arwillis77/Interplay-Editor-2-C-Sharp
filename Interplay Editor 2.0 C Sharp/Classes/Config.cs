using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interplay_Editor_2_C_Sharp.Classes
{
    public class Config
    {

        const string CONFIG_FILE = "lotred.cfg";
        const string ProgramDirectory = "LORDDIRECTORY";
        private string m_gameDirectory;
        private string m_gameExecutable;
        private bool m_configPresent;

        public bool ConfigPresent
        {
            get { return m_configPresent; }
            set { m_configPresent = value; }
        }
        public string GameDirectory
        {
            get { return m_gameDirectory; }
            set { m_gameDirectory = value; }
        }
        public string GameExecutable
        {
            get { return m_gameExecutable; }
            set { m_gameExecutable = value; }
        }

        public Config(string directory, string filename)
        {

            //this.m_scale = scale;
            m_gameDirectory = directory;
            GameExecutable = filename;
        }

        public Config(bool read)
        {
            if (read)
            {
                m_gameDirectory = ConfigGetDirectory();
                m_gameExecutable = ConfigGetFilename();

            }
            else
                return;

        }

        /// <summary>
        /// Checks for existing configuration file.
        /// </summary>
        /// <param name="path">Path where configuration file would be located.</param>
        /// <returns>True is exists, false if not.</returns>
        private bool ConfigExist(string path)
        {
            bool result;
            result = File.Exists(path);
            return result;
        }
        public void WriteConfig(string path, string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Async = true;
            using (XmlWriter confile = XmlWriter.Create(CONFIG_FILE, settings))
            {
                confile.WriteStartDocument();
                confile.WriteStartElement(ProgramDirectory);
                confile.WriteElementString("directory", path);
                confile.WriteElementString("EXECUTABLEFILE", fileName);
                confile.WriteEndElement();
                confile.WriteEndDocument();
                confile.Close();
            }
        }


        private int GetScaleValue()

        {
            int result = 0;
            string val = "";
            string filler;
            using (XmlReader confile = XmlReader.Create(CONFIG_FILE))
            {
                if (confile.ReadToDescendant(ProgramDirectory))
                {
                    confile.ReadStartElement(ProgramDirectory);
                    filler = confile.ReadElementContentAsString();
                    filler = confile.ReadElementContentAsString();
                    val = confile.ReadElementContentAsString();
                }
            }
            result = Convert.ToInt16(val);
            return result;


        }
        /// <summary>
        /// Gets executable filename stored in the config file.
        /// </summary>
        /// <returns>String containing filename.</returns>
        private string ConfigGetFilename()
        {
            string result = null;
            string filler;
            using (XmlReader confile = XmlReader.Create(CONFIG_FILE))
            {
                if (confile.ReadToDescendant(ProgramDirectory))
                {
                    confile.ReadStartElement(ProgramDirectory);
                    filler = confile.ReadElementContentAsString();
                    result = confile.ReadElementContentAsString();
                    //MessageBox.Show(result.ToString(), "Existing GameFileFound!");
                }
            }
            return result;
        }
        private string ConfigGetDirectory()
        {
            string result = null;
            using (XmlReader confile = XmlReader.Create(CONFIG_FILE))
            {
                if (confile.ReadToDescendant(ProgramDirectory))
                {
                    confile.ReadStartElement(ProgramDirectory);
                    GameDirectory = confile.ReadElementContentAsString();
                }
            }
            result = GameDirectory;
            return result;
        }
    }


}









//{   class config
//    {
//        public config()
//        {
//            ConfigPresent = ConfigExist(CONFIG_FILE);

//        }
//        const string CONFIG_FILE = "lotred.cfg";
//        public bool ConfigPresent;

//        private bool ConfigExist(string path)
//        {
//            bool result;
//            result = File.Exists(path);
//            return result;
//        }

//        public static void WriteConfig(string path, string fileName)

//        {
//            XmlWriterSettings settings = new XmlWriterSettings();
//            settings.Async = true;

//            using (XmlWriter confile = XmlWriter.Create(CONFIG_FILE, settings))
//            {
//                confile.WriteStartDocument();
//                confile.WriteStartElement("LORDDIRECTORY");
//                //confile.WriteElementString("directory", path);
//                confile.WriteElementString("EXECUTABLEFILE", fileName);
//                confile.WriteEndElement();
//                confile.WriteEndDocument();
//                confile.Close();
//            }


//        }


//        public static string ConfigGetFilename()
//        {
//            string result = "NULL";
//            string filler;
//            using (XmlReader confile = XmlReader.Create(CONFIG_FILE))
//            {
//                if (confile.ReadToDescendant("LORDDIRECTORY"))
//                {
//                    confile.ReadStartElement("LORDDIRECTORY");
//                    filler = confile.ReadElementContentAsString();
//                    result = confile.ReadElementContentAsString();
//                    //MessageBox.Show(result.ToString(), "Existing GameFileFound!");
//                }

//            }
//            return result;

//        }

//        public static string ReadConfig()
//        {
//            string result = "NULL";
//            using (XmlReader confile = XmlReader.Create(CONFIG_FILE))
//            {
//                if (confile.ReadToDescendant("LORDDIRECTORY"))
//                {
//                    confile.ReadStartElement("LORDDIRECTORY");
//                    result = confile.ReadElementContentAsString();


//                }

//            }
//            return result;
//        }


//    }

class gamefile
{


    public string filename;
    public int type;
    public bool IDX;
    public bool NDX;
    public bool palette;

    public gamefile(string fn, int typ, bool ind, bool nd, bool pal)
    {
        filename = fn;
        type = typ;
        IDX = ind;
        NDX = nd;
        palette = pal;

    }



}

public class Game
{
    public readonly string[] lotrVersions = { "Lord of the Rings Volume 1: Disk Version", "LOTR 1.3", "LOTR CD-Enhanced 1.0", "Lord of the Rings Volume 2: The Two Towers" };
    public readonly int[] lotrFileSizes = { 0, 134321, 140847, 433194 };
    public readonly string[] lotrSaves = { "DATA1.BIN", "DATA2.BIN" };

    public readonly string[] lotrArts = { "ARTS.DAT", "ARTS.PAL", "ARTS.NDX" };
    public readonly string[] lotrBack = { "BACK.DAT", "BACK.PAL" };
    public readonly string[] lotrCart = {"CART2.DAT","CART2.IDX","CART3.DAT","CART3.IDX","CART4.DAT","CART4.IDX","CART5.DAT","CART5.IDX","CART7.DAT",
                                                "CART7.IDX","CART10,DAT","CART10.IDX","CART11.DAT","CART11.IDX"};
    public readonly string[] lotrPortrait = { "PORTRAIT.DAT", "PORTRAIT.NDX" };
    public readonly string[] lotrShapes = { "SHAPES.DAT", "SHAPES.PAL", "SHAPES.NDX" };
    public readonly string[] lotrMaps = { "MAP0.DAT", "MAP0.NDX", "MAP1.DAT", "MAP1.NDX" };

    public string description;
    public string filepath;
    public string filename;
    public bool LOTR_FLAG = false;
    public bool TOWER_FLAG = false;

    // default constructor.
    public Game()
    {


    }
    // overloaded constructor with filename input.
    public Game(string fn)
    {
        description = GetDescription(fn);
        filename = fn;
        filepath = Path.GetDirectoryName(fn);
    }

    private string GetDescription(string filename)
    {
        string result = "Invalid";
        long size;
        size = new FileInfo(filename).Length;

        for (int a = 0; a < 4; a++)
        {
            if (size == lotrFileSizes[a])
            {
                result = lotrVersions[a];
                if (a < 4)
                {
                    LOTR_FLAG = true;

                }
                else
                {
                    TOWER_FLAG = true;
                }
            }
        }
        return result;
    }
}


//}
