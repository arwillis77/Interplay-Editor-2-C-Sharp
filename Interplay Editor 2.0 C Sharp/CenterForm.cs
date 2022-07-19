using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interplay_Editor_2_C_Sharp
{
    public partial class CenterForm : Form
    {
        private SplitContainer m_split;
        private TabControl m_tabControl;
        private GDirectory m_gameDirectory;


        public SplitContainer MainFormSplit
        {
            get { return m_split; }
            set { m_split = value; }    
        }
        
        
        public TabControl ResourceTabControl
        {
            get { return this.m_tabControl; }
            set { this.m_tabControl = value; }

        }
        public GDirectory GameHierarchy
        { get { return this.m_gameDirectory; }  
            set { m_gameDirectory = value; }
        
        }




        public CenterForm(SplitContainer transferredSplit, TabControl transferredTC,GDirectory gameDirectory)
        {
            InitializeComponent();
            this.TopLevel = false;
            m_split = transferredSplit;
            m_tabControl = transferredTC;
            m_gameDirectory = gameDirectory;
            //this.splitContainer1.
            //tc = new TabControl();
            //tc.Dock = DockStyle.Fill;
            //this.Controls.Add(tc);
        }

        private void CenterForm_Load(object sender, EventArgs e)
        {
            this.Controls.Add(m_split);
            m_split.Dock = DockStyle.Fill;
            m_split.Panel1.Controls.Add(m_gameDirectory);
            m_split.Panel2.Controls.Add(m_tabControl);
        }
    }
}
