
namespace Interplay_Editor_2_C_Sharp
{
    partial class GDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GDirectory));
            this.treeviewGame = new System.Windows.Forms.TreeView();
            this.treeviewImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlSaveGames = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeviewGame
            // 
            this.treeviewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeviewGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeviewGame.ForeColor = System.Drawing.Color.White;
            this.treeviewGame.FullRowSelect = true;
            this.treeviewGame.ImageIndex = 0;
            this.treeviewGame.ImageList = this.treeviewImageList;
            this.treeviewGame.ItemHeight = 16;
            this.treeviewGame.Location = new System.Drawing.Point(0, 0);
            this.treeviewGame.Name = "treeviewGame";
            this.treeviewGame.SelectedImageIndex = 0;
            this.treeviewGame.Size = new System.Drawing.Size(391, 349);
            this.treeviewGame.TabIndex = 3;
            this.treeviewGame.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeviewGame_NodeMouseDoubleClick);
            // 
            // treeviewImageList
            // 
            this.treeviewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.treeviewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeviewImageList.ImageStream")));
            this.treeviewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeviewImageList.Images.SetKeyName(0, "Folder32Icon.png");
            this.treeviewImageList.Images.SetKeyName(1, "folder-outline-with-shadow.png");
            this.treeviewImageList.Images.SetKeyName(2, "binicon32.png");
            this.treeviewImageList.Images.SetKeyName(3, "LRDicon32.png");
            this.treeviewImageList.Images.SetKeyName(4, "dat16.png");
            this.treeviewImageList.Images.SetKeyName(5, "ndxicon32.png");
            this.treeviewImageList.Images.SetKeyName(6, "idxicon32.png");
            this.treeviewImageList.Images.SetKeyName(7, "palicon32.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeviewGame);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tabControlSaveGames);
            this.splitContainer1.Size = new System.Drawing.Size(391, 732);
            this.splitContainer1.SplitterDistance = 349;
            this.splitContainer1.TabIndex = 6;
            // 
            // tabControlSaveGames
            // 
            this.tabControlSaveGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSaveGames.Location = new System.Drawing.Point(0, 0);
            this.tabControlSaveGames.Name = "tabControlSaveGames";
            this.tabControlSaveGames.SelectedIndex = 0;
            this.tabControlSaveGames.Size = new System.Drawing.Size(391, 379);
            this.tabControlSaveGames.TabIndex = 5;
            // 
            // GDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 732);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GDirectory";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "directory";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeviewGame;
        private System.Windows.Forms.ImageList treeviewImageList;
        private System.Windows.Forms.ListView lvwSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlSaveGames;
    }
}