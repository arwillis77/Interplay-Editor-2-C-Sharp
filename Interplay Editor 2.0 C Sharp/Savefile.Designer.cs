
using System;
using System.Windows.Forms;

namespace Interplay_Editor_2_C_Sharp
{
    partial class Savefile
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
            System.Windows.Forms.Label LBLDex;
            this.grpMagic = new System.Windows.Forms.GroupBox();
            this.listMagic = new System.Windows.Forms.ListBox();
            this.nbrHorseShape = new System.Windows.Forms.NumericUpDown();
            this.lblHorseShape = new System.Windows.Forms.Label();
            this.pnlSprite = new System.Windows.Forms.Panel();
            this.nbrShape = new System.Windows.Forms.NumericUpDown();
            this.GroupPortraitPalette = new System.Windows.Forms.GroupBox();
            this.GridViewPortraitPalette = new System.Windows.Forms.DataGridView();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblShape = new System.Windows.Forms.Label();
            this.grpSkills = new System.Windows.Forms.GroupBox();
            this.listSkills = new System.Windows.Forms.ListBox();
            this.txtDirection = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSpriteHeight = new System.Windows.Forms.Label();
            this.txtSpriteHeight = new System.Windows.Forms.TextBox();
            this.txtSpriteWidth = new System.Windows.Forms.TextBox();
            this.lblSpriteWidth = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.groupSilver = new System.Windows.Forms.GroupBox();
            this.txtSilver = new System.Windows.Forms.TextBox();
            this.groupPortrait = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NbrPortrait = new System.Windows.Forms.NumericUpDown();
            this.PBPortrait = new System.Windows.Forms.PictureBox();
            this.groupStats = new System.Windows.Forms.GroupBox();
            this.txtLife = new System.Windows.Forms.TextBox();
            this.lblLife = new System.Windows.Forms.Label();
            this.txtWill = new System.Windows.Forms.TextBox();
            this.lblWill = new System.Windows.Forms.Label();
            this.txtLuck = new System.Windows.Forms.TextBox();
            this.lblLuck = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.LBLEnd = new System.Windows.Forms.Label();
            this.TxtStr = new System.Windows.Forms.TextBox();
            this.LBLStr = new System.Windows.Forms.Label();
            this.TXTDex = new System.Windows.Forms.TextBox();
            this.GroupItems = new System.Windows.Forms.GroupBox();
            this.ListboxItems = new System.Windows.Forms.ListBox();
            this.GroupShapePalette = new System.Windows.Forms.GroupBox();
            this.GridViewShapesPalette = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelSpare = new System.Windows.Forms.Panel();
            LBLDex = new System.Windows.Forms.Label();
            this.grpMagic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrHorseShape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrShape)).BeginInit();
            this.GroupPortraitPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPortraitPalette)).BeginInit();
            this.grpSkills.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupSilver.SuspendLayout();
            this.groupPortrait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NbrPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPortrait)).BeginInit();
            this.groupStats.SuspendLayout();
            this.GroupItems.SuspendLayout();
            this.GroupShapePalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewShapesPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // LBLDex
            // 
            LBLDex.AutoSize = true;
            LBLDex.Location = new System.Drawing.Point(14, 42);
            LBLDex.Name = "LBLDex";
            LBLDex.Size = new System.Drawing.Size(28, 15);
            LBLDex.TabIndex = 0;
            LBLDex.Text = "DEX";
            // 
            // grpMagic
            // 
            this.grpMagic.Controls.Add(this.listMagic);
            this.grpMagic.Location = new System.Drawing.Point(284, 478);
            this.grpMagic.Name = "grpMagic";
            this.grpMagic.Size = new System.Drawing.Size(240, 254);
            this.grpMagic.TabIndex = 14;
            this.grpMagic.TabStop = false;
            this.grpMagic.Text = "Magic";
            // 
            // listMagic
            // 
            this.listMagic.FormattingEnabled = true;
            this.listMagic.ItemHeight = 15;
            this.listMagic.Location = new System.Drawing.Point(29, 35);
            this.listMagic.Name = "listMagic";
            this.listMagic.Size = new System.Drawing.Size(179, 169);
            this.listMagic.TabIndex = 0;
            // 
            // nbrHorseShape
            // 
            this.nbrHorseShape.Location = new System.Drawing.Point(117, 382);
            this.nbrHorseShape.Name = "nbrHorseShape";
            this.nbrHorseShape.Size = new System.Drawing.Size(63, 23);
            this.nbrHorseShape.TabIndex = 8;
            // 
            // lblHorseShape
            // 
            this.lblHorseShape.AutoSize = true;
            this.lblHorseShape.Location = new System.Drawing.Point(23, 384);
            this.lblHorseShape.Name = "lblHorseShape";
            this.lblHorseShape.Size = new System.Drawing.Size(73, 15);
            this.lblHorseShape.TabIndex = 7;
            this.lblHorseShape.Text = "Horse Shape";
            // 
            // pnlSprite
            // 
            this.pnlSprite.BackColor = System.Drawing.Color.Black;
            this.pnlSprite.Location = new System.Drawing.Point(24, 32);
            this.pnlSprite.Name = "pnlSprite";
            this.pnlSprite.Size = new System.Drawing.Size(480, 301);
            this.pnlSprite.TabIndex = 6;
            this.pnlSprite.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSprite_Paint);
            // 
            // nbrShape
            // 
            this.nbrShape.Location = new System.Drawing.Point(117, 353);
            this.nbrShape.Name = "nbrShape";
            this.nbrShape.Size = new System.Drawing.Size(63, 23);
            this.nbrShape.TabIndex = 3;
            this.nbrShape.ValueChanged += new System.EventHandler(this.NbrShape_ValueChanged);
            // 
            // GroupPortraitPalette
            // 
            this.GroupPortraitPalette.Controls.Add(this.GridViewPortraitPalette);
            this.GroupPortraitPalette.Location = new System.Drawing.Point(284, 22);
            this.GroupPortraitPalette.Name = "GroupPortraitPalette";
            this.GroupPortraitPalette.Size = new System.Drawing.Size(240, 450);
            this.GroupPortraitPalette.TabIndex = 16;
            this.GroupPortraitPalette.TabStop = false;
            this.GroupPortraitPalette.Text = "Portrait Palette";
            // 
            // GridViewPortraitPalette
            // 
            this.GridViewPortraitPalette.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.GridViewPortraitPalette.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.GridViewPortraitPalette.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewPortraitPalette.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnValue,
            this.ColumnColor,
            this.ColumnR,
            this.ColumnG,
            this.Column});
            this.GridViewPortraitPalette.Location = new System.Drawing.Point(24, 32);
            this.GridViewPortraitPalette.Name = "GridViewPortraitPalette";
            this.GridViewPortraitPalette.RowHeadersVisible = false;
            this.GridViewPortraitPalette.RowTemplate.Height = 25;
            this.GridViewPortraitPalette.Size = new System.Drawing.Size(179, 400);
            this.GridViewPortraitPalette.TabIndex = 0;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 40;
            // 
            // ColumnColor
            // 
            this.ColumnColor.HeaderText = "Color";
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.Width = 40;
            // 
            // ColumnR
            // 
            this.ColumnR.HeaderText = "R";
            this.ColumnR.Name = "ColumnR";
            this.ColumnR.Width = 30;
            // 
            // ColumnG
            // 
            this.ColumnG.HeaderText = "G";
            this.ColumnG.Name = "ColumnG";
            this.ColumnG.Width = 30;
            // 
            // Column
            // 
            this.Column.HeaderText = "B";
            this.Column.Name = "Column";
            this.Column.Width = 30;
            // 
            // lblShape
            // 
            this.lblShape.AutoSize = true;
            this.lblShape.Location = new System.Drawing.Point(24, 355);
            this.lblShape.Name = "lblShape";
            this.lblShape.Size = new System.Drawing.Size(72, 15);
            this.lblShape.TabIndex = 2;
            this.lblShape.Text = "Sprite Shape";
            // 
            // grpSkills
            // 
            this.grpSkills.Controls.Add(this.listSkills);
            this.grpSkills.Location = new System.Drawing.Point(530, 478);
            this.grpSkills.Name = "grpSkills";
            this.grpSkills.Size = new System.Drawing.Size(240, 254);
            this.grpSkills.TabIndex = 15;
            this.grpSkills.TabStop = false;
            this.grpSkills.Text = "Skills";
            // 
            // listSkills
            // 
            this.listSkills.FormattingEnabled = true;
            this.listSkills.ItemHeight = 15;
            this.listSkills.Location = new System.Drawing.Point(29, 35);
            this.listSkills.Name = "listSkills";
            this.listSkills.Size = new System.Drawing.Size(179, 169);
            this.listSkills.TabIndex = 0;
            // 
            // txtDirection
            // 
            this.txtDirection.Location = new System.Drawing.Point(117, 410);
            this.txtDirection.Name = "txtDirection";
            this.txtDirection.ReadOnly = true;
            this.txtDirection.Size = new System.Drawing.Size(86, 23);
            this.txtDirection.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSpriteHeight);
            this.groupBox1.Controls.Add(this.txtSpriteHeight);
            this.groupBox1.Controls.Add(this.txtSpriteWidth);
            this.groupBox1.Controls.Add(this.lblSpriteWidth);
            this.groupBox1.Controls.Add(this.nbrHorseShape);
            this.groupBox1.Controls.Add(this.lblHorseShape);
            this.groupBox1.Controls.Add(this.pnlSprite);
            this.groupBox1.Controls.Add(this.nbrShape);
            this.groupBox1.Controls.Add(this.lblShape);
            this.groupBox1.Controls.Add(this.txtDirection);
            this.groupBox1.Controls.Add(this.lblDirection);
            this.groupBox1.Location = new System.Drawing.Point(542, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 450);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sprite";
            // 
            // lblSpriteHeight
            // 
            this.lblSpriteHeight.AutoSize = true;
            this.lblSpriteHeight.Location = new System.Drawing.Point(233, 413);
            this.lblSpriteHeight.Name = "lblSpriteHeight";
            this.lblSpriteHeight.Size = new System.Drawing.Size(43, 15);
            this.lblSpriteHeight.TabIndex = 12;
            this.lblSpriteHeight.Text = "Height";
            // 
            // txtSpriteHeight
            // 
            this.txtSpriteHeight.Location = new System.Drawing.Point(279, 410);
            this.txtSpriteHeight.Name = "txtSpriteHeight";
            this.txtSpriteHeight.Size = new System.Drawing.Size(50, 23);
            this.txtSpriteHeight.TabIndex = 11;
            // 
            // txtSpriteWidth
            // 
            this.txtSpriteWidth.Location = new System.Drawing.Point(279, 381);
            this.txtSpriteWidth.Name = "txtSpriteWidth";
            this.txtSpriteWidth.Size = new System.Drawing.Size(50, 23);
            this.txtSpriteWidth.TabIndex = 10;
            // 
            // lblSpriteWidth
            // 
            this.lblSpriteWidth.AutoSize = true;
            this.lblSpriteWidth.Location = new System.Drawing.Point(237, 384);
            this.lblSpriteWidth.Name = "lblSpriteWidth";
            this.lblSpriteWidth.Size = new System.Drawing.Size(39, 15);
            this.lblSpriteWidth.TabIndex = 9;
            this.lblSpriteWidth.Text = "Width";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(41, 413);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(55, 15);
            this.lblDirection.TabIndex = 0;
            this.lblDirection.Text = "Direction";
            // 
            // groupSilver
            // 
            this.groupSilver.Controls.Add(this.txtSilver);
            this.groupSilver.Location = new System.Drawing.Point(29, 410);
            this.groupSilver.Name = "groupSilver";
            this.groupSilver.Size = new System.Drawing.Size(238, 62);
            this.groupSilver.TabIndex = 12;
            this.groupSilver.TabStop = false;
            this.groupSilver.Text = "Silver";
            // 
            // txtSilver
            // 
            this.txtSilver.Location = new System.Drawing.Point(48, 22);
            this.txtSilver.Name = "txtSilver";
            this.txtSilver.Size = new System.Drawing.Size(46, 23);
            this.txtSilver.TabIndex = 3;
            // 
            // groupPortrait
            // 
            this.groupPortrait.Controls.Add(this.label1);
            this.groupPortrait.Controls.Add(this.NbrPortrait);
            this.groupPortrait.Controls.Add(this.PBPortrait);
            this.groupPortrait.Location = new System.Drawing.Point(28, 22);
            this.groupPortrait.Name = "groupPortrait";
            this.groupPortrait.Size = new System.Drawing.Size(240, 231);
            this.groupPortrait.TabIndex = 9;
            this.groupPortrait.TabStop = false;
            this.groupPortrait.Text = "Portrait";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Portrait";
            // 
            // NbrPortrait
            // 
            this.NbrPortrait.Location = new System.Drawing.Point(67, 200);
            this.NbrPortrait.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.NbrPortrait.Name = "NbrPortrait";
            this.NbrPortrait.Size = new System.Drawing.Size(45, 23);
            this.NbrPortrait.TabIndex = 9;
            this.NbrPortrait.ValueChanged += new System.EventHandler(this.NbrPortrait_ValueChanged);
            // 
            // PBPortrait
            // 
            this.PBPortrait.BackColor = System.Drawing.Color.Black;
            this.PBPortrait.Location = new System.Drawing.Point(15, 32);
            this.PBPortrait.Name = "PBPortrait";
            this.PBPortrait.Size = new System.Drawing.Size(204, 162);
            this.PBPortrait.TabIndex = 0;
            this.PBPortrait.TabStop = false;
            this.PBPortrait.Paint += new System.Windows.Forms.PaintEventHandler(this.PBPortrait_Paint);
            // 
            // groupStats
            // 
            this.groupStats.Controls.Add(this.txtLife);
            this.groupStats.Controls.Add(this.lblLife);
            this.groupStats.Controls.Add(this.txtWill);
            this.groupStats.Controls.Add(this.lblWill);
            this.groupStats.Controls.Add(this.txtLuck);
            this.groupStats.Controls.Add(this.lblLuck);
            this.groupStats.Controls.Add(this.txtEnd);
            this.groupStats.Controls.Add(this.LBLEnd);
            this.groupStats.Controls.Add(this.TxtStr);
            this.groupStats.Controls.Add(this.LBLStr);
            this.groupStats.Controls.Add(this.TXTDex);
            this.groupStats.Controls.Add(LBLDex);
            this.groupStats.Location = new System.Drawing.Point(29, 264);
            this.groupStats.Name = "groupStats";
            this.groupStats.Size = new System.Drawing.Size(238, 140);
            this.groupStats.TabIndex = 10;
            this.groupStats.TabStop = false;
            this.groupStats.Text = "Character Stats";
            // 
            // txtLife
            // 
            this.txtLife.Location = new System.Drawing.Point(162, 97);
            this.txtLife.Name = "txtLife";
            this.txtLife.Size = new System.Drawing.Size(46, 23);
            this.txtLife.TabIndex = 9;
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Location = new System.Drawing.Point(128, 100);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(28, 15);
            this.lblLife.TabIndex = 8;
            this.lblLife.Text = "LIFE";
            this.lblLife.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWill
            // 
            this.txtWill.Location = new System.Drawing.Point(162, 68);
            this.txtWill.Name = "txtWill";
            this.txtWill.Size = new System.Drawing.Size(46, 23);
            this.txtWill.TabIndex = 7;
            // 
            // lblWill
            // 
            this.lblWill.AutoSize = true;
            this.lblWill.Location = new System.Drawing.Point(123, 71);
            this.lblWill.Name = "lblWill";
            this.lblWill.Size = new System.Drawing.Size(33, 15);
            this.lblWill.TabIndex = 6;
            this.lblWill.Text = "WILL";
            this.lblWill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLuck
            // 
            this.txtLuck.Location = new System.Drawing.Point(162, 39);
            this.txtLuck.Name = "txtLuck";
            this.txtLuck.Size = new System.Drawing.Size(46, 23);
            this.txtLuck.TabIndex = 3;
            // 
            // lblLuck
            // 
            this.lblLuck.AutoSize = true;
            this.lblLuck.Location = new System.Drawing.Point(120, 42);
            this.lblLuck.Name = "lblLuck";
            this.lblLuck.Size = new System.Drawing.Size(36, 15);
            this.lblLuck.TabIndex = 2;
            this.lblLuck.Text = "LUCK";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(48, 97);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(46, 23);
            this.txtEnd.TabIndex = 5;
            // 
            // LBLEnd
            // 
            this.LBLEnd.AutoSize = true;
            this.LBLEnd.Location = new System.Drawing.Point(14, 100);
            this.LBLEnd.Name = "LBLEnd";
            this.LBLEnd.Size = new System.Drawing.Size(30, 15);
            this.LBLEnd.TabIndex = 4;
            this.LBLEnd.Text = "END";
            // 
            // TxtStr
            // 
            this.TxtStr.Location = new System.Drawing.Point(48, 68);
            this.TxtStr.Name = "TxtStr";
            this.TxtStr.Size = new System.Drawing.Size(46, 23);
            this.TxtStr.TabIndex = 3;
            // 
            // LBLStr
            // 
            this.LBLStr.AutoSize = true;
            this.LBLStr.Location = new System.Drawing.Point(14, 71);
            this.LBLStr.Name = "LBLStr";
            this.LBLStr.Size = new System.Drawing.Size(26, 15);
            this.LBLStr.TabIndex = 2;
            this.LBLStr.Text = "STR";
            // 
            // TXTDex
            // 
            this.TXTDex.Location = new System.Drawing.Point(48, 39);
            this.TXTDex.Name = "TXTDex";
            this.TXTDex.Size = new System.Drawing.Size(46, 23);
            this.TXTDex.TabIndex = 1;
            // 
            // GroupItems
            // 
            this.GroupItems.Controls.Add(this.ListboxItems);
            this.GroupItems.Location = new System.Drawing.Point(29, 478);
            this.GroupItems.Name = "GroupItems";
            this.GroupItems.Size = new System.Drawing.Size(240, 254);
            this.GroupItems.TabIndex = 11;
            this.GroupItems.TabStop = false;
            this.GroupItems.Text = "Items";
            // 
            // ListboxItems
            // 
            this.ListboxItems.FormattingEnabled = true;
            this.ListboxItems.ItemHeight = 15;
            this.ListboxItems.Location = new System.Drawing.Point(29, 35);
            this.ListboxItems.Name = "ListboxItems";
            this.ListboxItems.Size = new System.Drawing.Size(179, 169);
            this.ListboxItems.TabIndex = 0;
            // 
            // GroupShapePalette
            // 
            this.GroupShapePalette.Controls.Add(this.GridViewShapesPalette);
            this.GroupShapePalette.Location = new System.Drawing.Point(1083, 22);
            this.GroupShapePalette.Name = "GroupShapePalette";
            this.GroupShapePalette.Size = new System.Drawing.Size(240, 450);
            this.GroupShapePalette.TabIndex = 17;
            this.GroupShapePalette.TabStop = false;
            this.GroupShapePalette.Text = "Shape Palette";
            // 
            // GridViewShapesPalette
            // 
            this.GridViewShapesPalette.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewShapesPalette.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.ColumnB});
            this.GridViewShapesPalette.Location = new System.Drawing.Point(15, 32);
            this.GridViewShapesPalette.Name = "GridViewShapesPalette";
            this.GridViewShapesPalette.RowHeadersVisible = false;
            this.GridViewShapesPalette.RowTemplate.Height = 25;
            this.GridViewShapesPalette.Size = new System.Drawing.Size(179, 400);
            this.GridViewShapesPalette.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Color";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "R";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 30;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "G";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 30;
            // 
            // ColumnB
            // 
            this.ColumnB.HeaderText = "B";
            this.ColumnB.Name = "ColumnB";
            this.ColumnB.Width = 30;
            // 
            // PanelSpare
            // 
            this.PanelSpare.BackColor = System.Drawing.Color.Black;
            this.PanelSpare.Location = new System.Drawing.Point(789, 478);
            this.PanelSpare.Name = "PanelSpare";
            this.PanelSpare.Size = new System.Drawing.Size(174, 114);
            this.PanelSpare.TabIndex = 18;
            this.PanelSpare.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelSpare_Paint);
            // 
            // Savefile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelSpare);
            this.Controls.Add(this.GroupShapePalette);
            this.Controls.Add(this.grpMagic);
            this.Controls.Add(this.GroupPortraitPalette);
            this.Controls.Add(this.grpSkills);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupSilver);
            this.Controls.Add(this.groupPortrait);
            this.Controls.Add(this.groupStats);
            this.Controls.Add(this.GroupItems);
            this.Name = "Savefile";
            this.Size = new System.Drawing.Size(1321, 757);
            this.Load += new System.EventHandler(this.Savefile_Load);
            this.grpMagic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbrHorseShape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrShape)).EndInit();
            this.GroupPortraitPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPortraitPalette)).EndInit();
            this.grpSkills.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupSilver.ResumeLayout(false);
            this.groupSilver.PerformLayout();
            this.groupPortrait.ResumeLayout(false);
            this.groupPortrait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NbrPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPortrait)).EndInit();
            this.groupStats.ResumeLayout(false);
            this.groupStats.PerformLayout();
            this.GroupItems.ResumeLayout(false);
            this.GroupShapePalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewShapesPalette)).EndInit();
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.GroupBox grpMagic;
        private System.Windows.Forms.ListBox listMagic;
        private System.Windows.Forms.NumericUpDown nbrHorseShape;
        private System.Windows.Forms.Label lblHorseShape;
        private System.Windows.Forms.Panel pnlSprite;
        private System.Windows.Forms.NumericUpDown nbrShape;
        private System.Windows.Forms.GroupBox GroupPortraitPalette;
        private System.Windows.Forms.DataGridView GridViewPortraitPalette;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
        private System.Windows.Forms.Label lblShape;
        private System.Windows.Forms.GroupBox grpSkills;
        private System.Windows.Forms.ListBox listSkills;
        private System.Windows.Forms.TextBox txtDirection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.GroupBox groupSilver;
        private System.Windows.Forms.TextBox txtSilver;
        private System.Windows.Forms.GroupBox groupPortrait;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NbrPortrait;
        private System.Windows.Forms.PictureBox PBPortrait;
        private System.Windows.Forms.GroupBox groupStats;
        private System.Windows.Forms.TextBox txtLife;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.TextBox txtWill;
        private System.Windows.Forms.Label lblWill;
        private System.Windows.Forms.TextBox txtLuck;
        private System.Windows.Forms.Label lblLuck;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label LBLEnd;
        private System.Windows.Forms.TextBox TxtStr;
        private System.Windows.Forms.Label LBLStr;
        private System.Windows.Forms.TextBox TXTDex;
        private System.Windows.Forms.Label LBLDex;
        private System.Windows.Forms.GroupBox GroupItems;
        private System.Windows.Forms.ListBox ListboxItems;
        private System.Windows.Forms.GroupBox GroupShapePalette;
        private System.Windows.Forms.DataGridView GridViewShapesPalette;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnB;
        private System.Windows.Forms.Panel PanelSpare;
        private Label lblSpriteWidth;
        private TextBox txtSpriteWidth;
        private Label lblSpriteHeight;
        private TextBox txtSpriteHeight;
    }
}
