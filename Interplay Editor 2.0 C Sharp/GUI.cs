using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interplay_Editor_2_C_Sharp.Classes;


namespace Interplay_Editor_2_C_Sharp
{

    /// <summary>
    /// Class for GUI elements of the editor.
    /// </summary>

    class GUI
    {
        const int GUI_COMP_NUM = 16;
        const string Type = "ARTS";
        public int ItemTotal;
        Pixmap []guiComponents;
        Pixmap[] guiFont;
        Pixmap[] guiLifebar;
        Palette pal;

        static readonly int[] guiCompWidths = new int[GUI_COMP_NUM]
        { 5,160,320,8,6,10,8,10,8,8,8,10,8,10,8,256 };
        static readonly string[] guiDescriptions =  {"CHAIN HORIZONTAL","MOUSE","MENU","SCROLL TOP","CHAIN VERT",
            "CHAIN SW","SCROLL SW","CHAIN SE", "SCROLL SE", "SCROLL EMPTY","SCROLL BOTTOM","CHAIN NW","SCROLL NW", 
            "CHAIN NE", "SCROLL NE","FONT", "COMP NUM"};

        public GUI()
        {
            ItemTotal = GUI_COMP_NUM;
            guiComponents  = new Pixmap[GUI_COMP_NUM];
            pal = Palette.GetPalette(Type);
        }




        public static FileSummary ReadGUIFile(string filename, int index)
        {

            Archive archive;
            FileSummary ss1 = new FileSummary();
           
            int a = index;
            int filpost = (4 * index);


            archive = Archive.NDXOpen(Type);

            ss1.ItemNumber = a;
            ss1.ItemName = guiDescriptions[a];
            ss1.ItemOffset = archive.IndexOffsets[a];
            return ss1;
        }




        public static List<GUI> GUIInit()
        {
            int i, j;
            Archive archive;
            GUI gui = new GUI(); ;
            List<GUI> guiCache = new List<GUI>();
            for (i = 0; i < GUI_COMP_NUM; i++)
                gui.guiComponents[i] = null;

            Palette.copyPaletteColors(gui.pal, 0, 0x20, 0x40);

            archive = Archive.NDXOpen(Type);



            for (i=0;i < GUI_COMP_NUM;++i)
            {
                gui.guiComponents[i] = Pixmap.ReadFromNDXArchive(archive, i,guiCompWidths[i]);

            }

            return guiCache;
        }

    }
}
