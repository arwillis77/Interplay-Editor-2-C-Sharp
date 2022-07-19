
namespace Interplay_Editor_2_C_Sharp
{
    partial class GameMap
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpLargeTile = new System.Windows.Forms.GroupBox();
            this.panelLargeTile = new System.Windows.Forms.Panel();
            this.lblLargeTileHex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLargeTileHex = new System.Windows.Forms.TextBox();
            this.nbrLargeTileNumber = new System.Windows.Forms.NumericUpDown();
            this.pbLargeTile = new System.Windows.Forms.PictureBox();
            this.groupSmallTile = new System.Windows.Forms.GroupBox();
            this.lblBasicTileHex = new System.Windows.Forms.Label();
            this.lblTileNumber = new System.Windows.Forms.Label();
            this.txtBasicTileHex = new System.Windows.Forms.TextBox();
            this.nbrTileNumber = new System.Windows.Forms.NumericUpDown();
            this.pbBasicTile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpLargeTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrLargeTileNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLargeTile)).BeginInit();
            this.groupSmallTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrTileNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBasicTile)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint_1);
            this.splitContainer1.Size = new System.Drawing.Size(1453, 872);
            this.splitContainer1.SplitterDistance = 640;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer2.Panel2.Controls.Add(this.grpLargeTile);
            this.splitContainer2.Panel2.Controls.Add(this.groupSmallTile);
            this.splitContainer2.Size = new System.Drawing.Size(638, 870);
            this.splitContainer2.SplitterDistance = 500;
            this.splitContainer2.TabIndex = 0;
            // 
            // grpLargeTile
            // 
            this.grpLargeTile.Controls.Add(this.panelLargeTile);
            this.grpLargeTile.Controls.Add(this.lblLargeTileHex);
            this.grpLargeTile.Controls.Add(this.label3);
            this.grpLargeTile.Controls.Add(this.txtLargeTileHex);
            this.grpLargeTile.Controls.Add(this.nbrLargeTileNumber);
            this.grpLargeTile.Controls.Add(this.pbLargeTile);
            this.grpLargeTile.ForeColor = System.Drawing.Color.White;
            this.grpLargeTile.Location = new System.Drawing.Point(290, 20);
            this.grpLargeTile.Name = "grpLargeTile";
            this.grpLargeTile.Size = new System.Drawing.Size(264, 209);
            this.grpLargeTile.TabIndex = 2;
            this.grpLargeTile.TabStop = false;
            this.grpLargeTile.Text = "Large Tile (32x32)";
            // 
            // panelLargeTile
            // 
            this.panelLargeTile.BackColor = System.Drawing.Color.Black;
            this.panelLargeTile.Location = new System.Drawing.Point(134, 34);
            this.panelLargeTile.Name = "panelLargeTile";
            this.panelLargeTile.Size = new System.Drawing.Size(96, 96);
            this.panelLargeTile.TabIndex = 3;
            
            // 
            // lblLargeTileHex
            // 
            this.lblLargeTileHex.AutoSize = true;
            this.lblLargeTileHex.Location = new System.Drawing.Point(27, 172);
            this.lblLargeTileHex.Name = "lblLargeTileHex";
            this.lblLargeTileHex.Size = new System.Drawing.Size(68, 15);
            this.lblLargeTileHex.TabIndex = 4;
            this.lblLargeTileHex.Text = "Tile # (HEX)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tile #";
            // 
            // txtLargeTileHex
            // 
            this.txtLargeTileHex.BackColor = System.Drawing.Color.Gray;
            this.txtLargeTileHex.ForeColor = System.Drawing.Color.White;
            this.txtLargeTileHex.Location = new System.Drawing.Point(117, 169);
            this.txtLargeTileHex.Name = "txtLargeTileHex";
            this.txtLargeTileHex.ReadOnly = true;
            this.txtLargeTileHex.Size = new System.Drawing.Size(65, 23);
            this.txtLargeTileHex.TabIndex = 2;
            // 
            // nbrLargeTileNumber
            // 
            this.nbrLargeTileNumber.BackColor = System.Drawing.Color.Gray;
            this.nbrLargeTileNumber.ForeColor = System.Drawing.Color.White;
            this.nbrLargeTileNumber.Location = new System.Drawing.Point(117, 140);
            this.nbrLargeTileNumber.Name = "nbrLargeTileNumber";
            this.nbrLargeTileNumber.Size = new System.Drawing.Size(65, 23);
            this.nbrLargeTileNumber.TabIndex = 1;
            this.nbrLargeTileNumber.ValueChanged += new System.EventHandler(this.nbrLargeTileNumber_ValueChanged);
            // 
            // pbLargeTile
            // 
            this.pbLargeTile.BackColor = System.Drawing.Color.Black;
            this.pbLargeTile.Location = new System.Drawing.Point(32, 34);
            this.pbLargeTile.Name = "pbLargeTile";
            this.pbLargeTile.Size = new System.Drawing.Size(96, 96);
            this.pbLargeTile.TabIndex = 0;
            this.pbLargeTile.TabStop = false;
            // 
            // groupSmallTile
            // 
            this.groupSmallTile.Controls.Add(this.lblBasicTileHex);
            this.groupSmallTile.Controls.Add(this.lblTileNumber);
            this.groupSmallTile.Controls.Add(this.txtBasicTileHex);
            this.groupSmallTile.Controls.Add(this.nbrTileNumber);
            this.groupSmallTile.Controls.Add(this.pbBasicTile);
            this.groupSmallTile.ForeColor = System.Drawing.Color.White;
            this.groupSmallTile.Location = new System.Drawing.Point(28, 20);
            this.groupSmallTile.Name = "groupSmallTile";
            this.groupSmallTile.Size = new System.Drawing.Size(230, 209);
            this.groupSmallTile.TabIndex = 1;
            this.groupSmallTile.TabStop = false;
            this.groupSmallTile.Text = "Basic Tile (8x8)";
            // 
            // lblBasicTileHex
            // 
            this.lblBasicTileHex.AutoSize = true;
            this.lblBasicTileHex.Location = new System.Drawing.Point(27, 172);
            this.lblBasicTileHex.Name = "lblBasicTileHex";
            this.lblBasicTileHex.Size = new System.Drawing.Size(68, 15);
            this.lblBasicTileHex.TabIndex = 4;
            this.lblBasicTileHex.Text = "Tile # (HEX)";
            // 
            // lblTileNumber
            // 
            this.lblTileNumber.AutoSize = true;
            this.lblTileNumber.Location = new System.Drawing.Point(60, 142);
            this.lblTileNumber.Name = "lblTileNumber";
            this.lblTileNumber.Size = new System.Drawing.Size(35, 15);
            this.lblTileNumber.TabIndex = 3;
            this.lblTileNumber.Text = "Tile #";
            // 
            // txtBasicTileHex
            // 
            this.txtBasicTileHex.BackColor = System.Drawing.Color.Gray;
            this.txtBasicTileHex.ForeColor = System.Drawing.Color.White;
            this.txtBasicTileHex.Location = new System.Drawing.Point(117, 169);
            this.txtBasicTileHex.Name = "txtBasicTileHex";
            this.txtBasicTileHex.ReadOnly = true;
            this.txtBasicTileHex.Size = new System.Drawing.Size(65, 23);
            this.txtBasicTileHex.TabIndex = 2;
            // 
            // nbrTileNumber
            // 
            this.nbrTileNumber.BackColor = System.Drawing.Color.Gray;
            this.nbrTileNumber.ForeColor = System.Drawing.Color.White;
            this.nbrTileNumber.Location = new System.Drawing.Point(117, 140);
            this.nbrTileNumber.Name = "nbrTileNumber";
            this.nbrTileNumber.Size = new System.Drawing.Size(65, 23);
            this.nbrTileNumber.TabIndex = 1;
            this.nbrTileNumber.ValueChanged += new System.EventHandler(this.nbrTileNumber_ValueChanged);
            // 
            // pbBasicTile
            // 
            this.pbBasicTile.BackColor = System.Drawing.Color.Black;
            this.pbBasicTile.Location = new System.Drawing.Point(27, 34);
            this.pbBasicTile.Name = "pbBasicTile";
            this.pbBasicTile.Size = new System.Drawing.Size(24, 24);
            this.pbBasicTile.TabIndex = 0;
            this.pbBasicTile.TabStop = false;
            // 
            // GameMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "GameMap";
            this.Size = new System.Drawing.Size(1453, 872);
            this.Load += new System.EventHandler(this.GameMap_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpLargeTile.ResumeLayout(false);
            this.grpLargeTile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrLargeTileNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLargeTile)).EndInit();
            this.groupSmallTile.ResumeLayout(false);
            this.groupSmallTile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrTileNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBasicTile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grpLargeTile;
        private System.Windows.Forms.Label lblLargeTileHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLargeTileHex;
        private System.Windows.Forms.NumericUpDown nbrLargeTileNumber;
        private System.Windows.Forms.PictureBox pbLargeTile;
        private System.Windows.Forms.GroupBox groupSmallTile;
        private System.Windows.Forms.Label lblBasicTileHex;
        private System.Windows.Forms.Label lblTileNumber;
        private System.Windows.Forms.TextBox txtBasicTileHex;
        private System.Windows.Forms.NumericUpDown nbrTileNumber;
        private System.Windows.Forms.PictureBox pbBasicTile;
        private System.Windows.Forms.Panel panelLargeTile;
    }
}
