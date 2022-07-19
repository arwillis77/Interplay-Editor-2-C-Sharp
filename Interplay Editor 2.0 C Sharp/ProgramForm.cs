using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interplay_Editor_2_C_Sharp.Classes;


namespace Interplay_Editor_2_C_Sharp
{
   /// <summary>
   /// Interplay Lord of the Rings Editor v2.0
   /// C# Version Last Update 01/24/2021
   /// 
   /// Aaron R. Willis
   /// 
   /// Writen using Microsoft Visual Studio 2019 C# NET using code portions originally written in C and ported by myself to VB Net, VC++, C++.
   /// Converted to OOP program utilizing classes.
   /// Loads Interplay Lord of the Rings games and edits savegame characters, displays graphic resources.
   /// </summary>
    public partial class ProgramForm : Form
    {
        Config cfg;

        public ProgramForm()
        {
            InitializeComponent();
            splitContainer1.Hide();
        }
     
        private void ProgramForm_Load(object sender, EventArgs e)
        {
          
        }

        private void FileMenuLoadGame_Click(object sender, EventArgs e)
        {
            string p_fileName;
            string p_fileDir;
            OpenFileDialog LOTRFileOpen = new OpenFileDialog
            {
                FilterIndex = 0,
                Title = "Select Game you Wish to Edit:>",
                Filter = "*.EXE|*.EXE",
            };
            DialogResult dr = LOTRFileOpen.ShowDialog();
            p_fileName = LOTRFileOpen.SafeFileName;
            p_fileDir = Path.GetDirectoryName(LOTRFileOpen.FileName);
            cfg = new Config(p_fileDir, p_fileName);
            cfg.WriteConfig(cfg.GameDirectory, cfg.GameExecutable);
            LoadGame();
        }

        private void LoadGame()
        {
            //menuStrip1.BringToFront();
            splitContainer1.Show();
            splitContainer1.BringToFront();
            
            GDirectory dirchild = new GDirectory(this);               /* Intializes form displaying game hierarchy */
            //{
            //    MdiParent = cf,
            //    Dock = DockStyle.Left
            //};
            splitContainer1.Panel1.Controls.Add(dirchild);
            
            dirchild.Dock = DockStyle.Fill;
            splitContainer1.SplitterDistance = dirchild.Width + 20;
            dirchild.Show();
        }

        public void AddResourceTab(TabPage tabPage)
        {
            tabControlGameResource.Controls.Add(tabPage);
            
        }




    }
}
