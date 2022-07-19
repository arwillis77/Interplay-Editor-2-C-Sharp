
namespace Interplay_Editor_2_C_Sharp
{
    partial class ProgramForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuLoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlGameResource = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 963);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuLoadGame});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "&File";
            // 
            // FileMenuLoadGame
            // 
            this.FileMenuLoadGame.Name = "FileMenuLoadGame";
            this.FileMenuLoadGame.Size = new System.Drawing.Size(155, 22);
            this.FileMenuLoadGame.Text = "Load Game File";
            this.FileMenuLoadGame.Click += new System.EventHandler(this.FileMenuLoadGame_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlGameResource);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 939);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.TabIndex = 7;
            this.splitContainer1.Visible = false;
            // 
            // tabControlGameResource
            // 
            this.tabControlGameResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlGameResource.Location = new System.Drawing.Point(0, 0);
            this.tabControlGameResource.Name = "tabControlGameResource";
            this.tabControlGameResource.SelectedIndex = 0;
            this.tabControlGameResource.Size = new System.Drawing.Size(839, 939);
            this.tabControlGameResource.TabIndex = 0;
            // 
            // ProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProgramForm";
            this.Text = "Interplay Editor for Lord of the Rings v 2.0";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProgramForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem FileMenuLoadGame;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlGameResource;
    }
}

