using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Interplay_Editor_2_C_Sharp.Classes;

namespace Interplay_Editor_2_C_Sharp
{
    public partial class GDirectory : Form
    {
        ProgramForm m_callingForm;
        TabPage m_resourcePage;

        
        //public ListViewItem lvi;
        //public ListViewItem SaveLVI;
        //public ListViewItem GUILVI;
        //public TabPage resourcePage;
        //public Tiles gmapTile;
        //public Palette gmapPalette;
        //public Archive loadedArchive;
        public enum file_type { SAVE, GRAPHICS, SOUND, NPC};
        /* Default constructor */
        public GDirectory()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            string fullGame;
            Config cfg = new Config(true);
            fullGame = cfg.GameDirectory + "\\" + cfg.GameExecutable;
            Game game = OpenExistingGame(fullGame);
            this.Text = game.description;
            InitializeTreeView(game);
        }


        public GDirectory(ProgramForm callingForm)
        {  
            InitializeComponent();
            this.TopLevel = false;
            string fullGame;
            Game game;
            Config cfg;
            m_callingForm = callingForm;
            cfg = new Config(true);
            fullGame = cfg.GameDirectory + "\\"+cfg.GameExecutable;
            game = OpenExistingGame(fullGame);
            this.Text = game.description;
            InitializeTreeView(game);
        }

        public static Game OpenExistingGame(string gameFile)
        {
            Game Result = new Game(gameFile);
            return Result;
        }

        private int GetImageIndex(string fn)
        {
            int result = 0;
            string str = fn;
            string substr = str.Substring(str.Length - 3);
            //MessageBox.Show(substr);
            for (int o = 0; o < 7; o++)
            {
                if (string.Equals(substr, Constants.extensions[o]))
                {
                    result = o;
                }                
            }
            return result;
        }

        private void TreeEntry(int TreeNode, string path, gamefile g_file, int flag = 1)
        {
            int n = TreeNode;
            string tempFilename;
            string tempFullFilename;
            string indexFile;
            string paletteFile;
            bool t_VerifyFile;
            if (g_file.type == 0)                                       // SAVE
            {
                if (flag == 1)
                    tempFilename = g_file.filename + ".BIN";
               
                else
                    tempFilename = g_file.filename + ".LRD";

                tempFullFilename = path + "\\" + tempFilename;
                t_VerifyFile = VerifySave(tempFullFilename);

                if (t_VerifyFile)
                    treeviewGame.Nodes[0].Nodes[n].Nodes.Add(tempFilename);
            }
            else if(g_file.type==2)
            {
                // Sound File
                tempFilename = g_file.filename + ".ADL";
                AddResourceNode(tempFilename, path, (int)g_file.type);
            }

            else if(g_file.type==3)
            {
                tempFilename = g_file.filename + ".DAT";
                AddResourceNode(tempFilename, path, (int)g_file.type);

            }

            else                                                        // GRAPHICS
            {
                tempFilename = g_file.filename + ".DAT";
                AddGraphicsNode(tempFilename, path,n);
                if (g_file.IDX)
                {
                    indexFile = g_file.filename + ".IDX";
                    AddGraphicsNode(indexFile, path,n);
                }
                if (g_file.NDX)
                {
                    indexFile = g_file.filename + ".NDX";
                    AddGraphicsNode(indexFile, path,n);
                }
                if (g_file.palette)
                {
                    paletteFile = g_file.filename + ".PAL";
                    AddGraphicsNode(paletteFile, path,n);
                }
            }
        }

        private void AddResourceNode(string fname, string path, int node1)
        {
            int n = node1;
            string t_file = fname;
            string t_file2 = path + "\\" + fname;
            bool t_VerifyFile;
            t_VerifyFile = VerifySave(t_file2);
            if (t_VerifyFile)
            {
                int iconValue = GetImageIndex(fname);
                treeviewGame.ImageIndex = iconValue;
                treeviewGame.Nodes[0].Nodes[n].Nodes.Add(t_file);
            }
        }
        private void AddGraphicsNode(string fname,string path, int node)
        {
            int n = node;
            string t_file = fname;
            string t_file2 = path + "\\" + fname;
            bool t_VerifyFile;
            t_VerifyFile = VerifySave(t_file2);
            if (t_VerifyFile)
            {
                int iconValue = GetImageIndex(fname);
                treeviewGame.ImageIndex = iconValue;
                treeviewGame.Nodes[0].Nodes[1].Nodes[n - 1].Nodes.Add(t_file);
                
            }
        }
        private void InitializeTreeView(Game TransGame)
        {
            bool lotr_flag = TransGame.LOTR_FLAG;
            bool tower_flag = TransGame.TOWER_FLAG;
            int gflag=0;
            int savnum=2;
            string temp;
            treeviewGame.BeginUpdate();
            treeviewGame.Nodes.Add(TransGame.filepath);
            treeviewGame.Nodes[0].ImageIndex = 0;
            treeviewGame.Nodes[0].Nodes.Add("SAVE GAMES");
            treeviewGame.Nodes[0].Nodes[0].ImageIndex = 1;
            // Savegame
            if (lotr_flag)
            {
                savnum = 2;
                gflag = 1;
            }
            else if (tower_flag)
            {  
                savnum = 6;
                gflag = 2;
            }

            for (int s = 1; s < (savnum+1); s++)
            {
                temp = Constants.lordSaveFile + s.ToString();
                gamefile Save = new gamefile(temp, (int)file_type.SAVE, false, false, false);
                TreeEntry(0, TransGame.filepath, Save,gflag);
            }
            treeviewGame.Nodes[0].Nodes.Add("GRAPHICS");
            treeviewGame.Nodes[0].Nodes[1].Nodes.Add("ART");                    //CHILD 1


            temp = Constants.lord_graphic_files.ElementAt(0);
            gamefile Arts = new gamefile(temp, (int)file_type.GRAPHICS, false, true, true);
            TreeEntry(1, TransGame.filepath, Arts);
            
            temp = Constants.lord_graphic_files.ElementAt(1);
            treeviewGame.Nodes[0].Nodes[1].Nodes.Add(temp);                   //CHILD 2
            gamefile Back = new gamefile(temp, (int)file_type.GRAPHICS, false, false, true);
            TreeEntry(2, TransGame.filepath, Back);
            
            
            treeviewGame.Nodes[0].Nodes[1].Nodes.Add("CART");                   // CHILD 3

            // Cycle through and add notes for the CART files.
            for (int v = 2; v < 8; v++)
            {
                temp = Constants.lord_graphic_files.ElementAt(v);
                gamefile graphicItem = new gamefile(temp, (int)file_type.GRAPHICS, true, false, false);
                TreeEntry(3, TransGame.filepath, graphicItem);
            }

        
            
            temp = Constants.lord_graphic_files.ElementAt(9);
            treeviewGame.Nodes[0].Nodes[1].Nodes.Add("CURSORS");                   // CHILD 4
            gamefile Cursors = new gamefile(temp, (int)file_type.GRAPHICS, false, false, false);
            TreeEntry(4, TransGame.filepath, Cursors);

            temp = Constants.lord_graphic_files.ElementAt(10);
            treeviewGame.Nodes[0].Nodes[1].Nodes.Add(temp);                   // CHILD 5
            gamefile Portrait = new gamefile(temp, (int)file_type.GRAPHICS, false, true, false);
            TreeEntry(5, TransGame.filepath, Portrait);

            temp = Constants.lord_graphic_files.ElementAt(11);
            treeviewGame.Nodes[0].Nodes[1].Nodes.Add(temp);                   // CHILD 6
            gamefile Shapes = new gamefile(temp, (int)file_type.GRAPHICS, false, true, true);
            TreeEntry(6, TransGame.filepath, Shapes);


            temp = Constants.lord_graphic_files.ElementAt(12);
            treeviewGame.Nodes[0].Nodes[1].Nodes.Add(temp);                   // CHILD 7
            gamefile Map0 = new gamefile(temp, (int)file_type.GRAPHICS, false, true, false);
            TreeEntry(7, TransGame.filepath, Map0);

            temp = Constants.lord_graphic_files.ElementAt(13);
            treeviewGame.Nodes[0].Nodes[1].Nodes.Add(temp);                   // CHILD 8
            gamefile Map1 = new gamefile(temp, (int)file_type.GRAPHICS, false, true, false);
            TreeEntry(8, TransGame.filepath, Map1);
            //treeviewGame.Nodes[0].Nodes[0].ImageIndex = 1;

            treeviewGame.Nodes[0].Nodes.Add("SOUND");
            int totalFiles = Constants.lordSoundFiles.Count;
            for (int g = 1; g < totalFiles; g++)
            {
                temp = Constants.lordSoundFiles[g];
                gamefile tempSND = new gamefile(temp, (int)file_type.SOUND, false, false, false);
                TreeEntry(0, TransGame.filepath, tempSND);
            }


            treeviewGame.Nodes[0].Nodes.Add("NPC");
               
                temp = Constants.lordNPC;
                gamefile NPC = new gamefile(temp, (int)file_type.NPC, false, false, false);
                TreeEntry(0, TransGame.filepath, NPC);
            treeviewGame.ExpandAll();
        }
        private bool VerifySave(string filename)
        {
            bool result;

            if (File.Exists(filename))
            {
                result = true;
            }
            else
                result = false;
            return result;
        }

        /// <summary>
        /// lvwSave_DoubleClick -- Event handler for when listview items for savegame is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwSave_DoubleClick(Object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection sel = this.lvwSave.SelectedItems;
            if (sel.Count <= 0)
            {
                MessageBox.Show("No Item Selected");
                return;
            }
            FileSummary s2 = new FileSummary();
            s2.ItemNumber = Convert.ToInt16(lvwSave.SelectedItems[0].SubItems[0].Text);
            string name = lvwSave.SelectedItems[0].SubItems[1].Text;
            s2.ItemName = name;
            s2.ItemOffset = Convert.ToInt16(lvwSave.SelectedItems[0].SubItems[2].Text);
            if(!m_callingForm.Visible)
                 m_callingForm.Show();
            TabPage tpg = new TabPage(name);
            //m_callingForm.TabPages.Add(tpg);
            //tpg.Text = name;


            if (tabControlSaveGames.SelectedTab.Name == Constants.lord_graphic_files[0] + ".DAT")
            {
                // ARTS.DAT ITEM SELECTED.
                MessageBox.Show("Open Arts Window!");

            }
            else if (tabControlSaveGames.SelectedTab.Name == Constants.vol1SaveFiles[0] ||
                tabControlSaveGames.SelectedTab.Name == Constants.vol1SaveFiles[1])
            {
                Savefile sg = new Savefile(s2, this.tabControlSaveGames.SelectedTab.Text);
                MessageBox.Show("Savegame Selected!!");
                tpg.Controls.Add(sg);
                //lvwSave.SelectedItems.Clear();
                m_callingForm.AddResourceTab(tpg);

            }
            else if (tabControlSaveGames.SelectedTab.Name == Constants.lord_graphic_files[12] + ".DAT" ||
                tabControlSaveGames.SelectedTab.Name == Constants.lord_graphic_files[12] + ".NDX" ||
                tabControlSaveGames.SelectedTab.Name == Constants.lord_graphic_files[13] + ".DAT" ||
               tabControlSaveGames.SelectedTab.Name == Constants.lord_graphic_files[13] + ".NDX")
            {
                
                MessageBox.Show(tabControlSaveGames.SelectedTab.Name.ToString(), "Open MAP Window!");



                //GameMap gm = new GameMap(gmapTile, gmapPalette,loadedArchive);
                //gm.Dock = DockStyle.Fill;
                //tpg.Controls.Add(gm);
                //lvwSave.SelectedItems.Clear();
            }
            //tabControlSaveGames.Controls.Add(tpg);

            //m_callingForm.AddResourceTab(tpg);

        }
        private void treeviewGame_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string title = "";
            if ((e.Node.Text == Constants.lord_graphic_files[12] + ".DAT") ||
                (e.Node.Text == Constants.lord_graphic_files[12] + ".NDX") ||
                (e.Node.Text == Constants.lord_graphic_files[13] + ".DAT") ||
                (e.Node.Text == Constants.lord_graphic_files[13] + ".NDX"))
            {
                title = e.Node.Text;
                m_resourcePage = new TabPage(title);
                m_resourcePage.Name = title;
                tabControlSaveGames.TabPages.Add(m_resourcePage);
                tabControlSaveGames.SelectTab(m_resourcePage);
                MapControl mapControl = new MapControl();
                mapControl.Dock = DockStyle.Fill;

                m_resourcePage.Controls.Add(mapControl);              
                
                //m_callingForm.AddResourceTab(m_resourcePage);
            }
            else
            {
                title = e.Node.Text;
                lvwSave = new ListView();
                lvwSave.Columns.Add("#", 20);
                lvwSave.Columns.Add("Name", 175);
                lvwSave.Columns.Add("Offset", 50);
                lvwSave.FullRowSelect = true;
                lvwSave.View = View.Details;
                lvwSave.Size = new Size(100, 100);
                lvwSave.Dock = DockStyle.Fill;

                lvwSave.DoubleClick += new EventHandler(lvwSave_DoubleClick);

                m_resourcePage = new TabPage(title);
                m_resourcePage.Name = title;
                tabControlSaveGames.TabPages.Add(m_resourcePage);
                tabControlSaveGames.SelectTab(m_resourcePage);
                m_resourcePage.Controls.Add(lvwSave);
                if (e.Node.Text == "DATA1.BIN")
                    ProcessSaveGame(e.Node.Text, lvwSave);
                else if (e.Node.Text == "DATA2.BIN")
                    ProcessSaveGame(e.Node.Text, lvwSave);
                else if (e.Node.Text == "NPCS.DAT")
                    ProcessSaveGame(e.Node.Text, lvwSave);
                else if (e.Node.Text == "ARTS.DAT")
                    ProcessGUI(e.Node.Text, lvwSave);
            }
        }
        void ProcessGUI(string filename, ListView gui)
        {
            ListViewItem guiListItem;
            string graphicFile;
            Config cfg = new Config(true);
            FileSummary guiSummary = new FileSummary();

            GUI arts = new GUI();
            string path = cfg.GameDirectory;
            graphicFile = path + "\\" + filename;
            for (int g = 0; g < arts.ItemTotal; g++)
            {
                guiSummary = GUI.ReadGUIFile(graphicFile, g);
                guiListItem = new ListViewItem();
                guiListItem.Text = (guiSummary.ItemNumber.ToString());
                guiListItem.SubItems.Add(guiSummary.ItemName);
                guiListItem.SubItems.Add(guiSummary.ItemOffset.ToString());
                gui.Items.Add(guiListItem);
            }
        }

        
        void ProcessSaveGame(string filename, ListView tlb)
        {
            ListViewItem SaveLVI;
            
            string savefile;
            Config cfg = new Config(true);
            Character.SaveSummary s1;
            string path = cfg.GameDirectory;
            savefile = path + "\\" + filename;
            int cmax = Character.Constants.SaveCharEntries;
            for (int g = 0; g < cmax;g++)
            {
                s1 = Character.ReadSaveFile(savefile, g);
                SaveLVI = new ListViewItem();
                SaveLVI.Text = (s1.num.ToString());
                SaveLVI.SubItems.Add(s1.CName);
                SaveLVI.SubItems.Add(s1.offset.ToString());
                tlb.Items.Add(SaveLVI);
            }
        }
    }

    static class Constants
    {
        public const string lordSaveFile = "DATA";
        static List<string> vol1SaveFile  = new List<string>(){"DATA1.BIN","DATA2.BIN"};
        public const string lordNPC = "NPCS";
        static List<string> lordGraphics = new List<string>(){"ARTS", "BACK", "CART2", "CART3", "CART4", "CART5", "CART7", "CART10", "CART11",
                                                        "CURSORS","PORTRAIT", "SHAPES", "MAP0", "MAP1","OPENING"};
        
        static List<string> lordSound = new List<string>() { "AHISS", "BEEP", "BMISS","BSWISH","BUZZ","CROW","CRY","DMISS","GALLOP","GROWL",
                                                                  "GRUNT","HHIT","HISS","HIT1","HIT2","HIT3","HIT4","HOWL","IHIT","MAGICF","MAGICS",
                                                                    "MISS1","MISS2","MISS3","MOAN","QHIT","QMISS","SCREECH","SDMISS1","SDMISS2","SDMISS3",
                                                                    "SHRIEK","SNARL","TGRUNT","WHIP","YELL"};
        static List<string> ext = new List<string>() { "NULL", "NULL", "BIN", "LRD", "DAT", "NDX", "IDX", "PAL","ADL" };
        public static ReadOnlyCollection<string> vol1SaveFiles = new ReadOnlyCollection<string>(vol1SaveFile);
        public static ReadOnlyCollection<string> lord_graphic_files = new ReadOnlyCollection<string>(lordGraphics);
        public static ReadOnlyCollection<string> lordSoundFiles = new ReadOnlyCollection<string>(lordSound);
        public static ReadOnlyCollection<string> extensions = new ReadOnlyCollection<string>(ext);
        public static int sizeFactor = 3;
    }
}
