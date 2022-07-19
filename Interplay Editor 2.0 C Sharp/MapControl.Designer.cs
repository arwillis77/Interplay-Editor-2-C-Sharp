
namespace Interplay_Editor_2_C_Sharp
{
    partial class MapControl
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
            this.NbrMapValue = new System.Windows.Forms.NumericUpDown();
            this.LabelMapValue = new System.Windows.Forms.Label();
            this.ButtonUpdateMap = new System.Windows.Forms.Button();
            this.GboxMapDetails = new System.Windows.Forms.GroupBox();
            this.labelMapIndex = new System.Windows.Forms.Label();
            this.textMapIndex = new System.Windows.Forms.TextBox();
            this.labelMapFilename = new System.Windows.Forms.Label();
            this.textMapFilename = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NbrMapValue)).BeginInit();
            this.GboxMapDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // NbrMapValue
            // 
            this.NbrMapValue.Location = new System.Drawing.Point(113, 95);
            this.NbrMapValue.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.NbrMapValue.Name = "NbrMapValue";
            this.NbrMapValue.Size = new System.Drawing.Size(55, 23);
            this.NbrMapValue.TabIndex = 0;
            this.NbrMapValue.ValueChanged += new System.EventHandler(this.NbrMapValue_ValueChanged);
            // 
            // LabelMapValue
            // 
            this.LabelMapValue.AutoSize = true;
            this.LabelMapValue.ForeColor = System.Drawing.Color.White;
            this.LabelMapValue.Location = new System.Drawing.Point(66, 97);
            this.LabelMapValue.Name = "LabelMapValue";
            this.LabelMapValue.Size = new System.Drawing.Size(31, 15);
            this.LabelMapValue.TabIndex = 1;
            this.LabelMapValue.Text = "Map";
            this.LabelMapValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonUpdateMap
            // 
            this.ButtonUpdateMap.Location = new System.Drawing.Point(69, 356);
            this.ButtonUpdateMap.Name = "ButtonUpdateMap";
            this.ButtonUpdateMap.Size = new System.Drawing.Size(131, 33);
            this.ButtonUpdateMap.TabIndex = 2;
            this.ButtonUpdateMap.Text = "Update Map";
            this.ButtonUpdateMap.UseVisualStyleBackColor = true;
            this.ButtonUpdateMap.Click += new System.EventHandler(this.ButtonUpdateMap_Click);
            // 
            // GboxMapDetails
            // 
            this.GboxMapDetails.Controls.Add(this.textMapFilename);
            this.GboxMapDetails.Controls.Add(this.labelMapFilename);
            this.GboxMapDetails.Controls.Add(this.labelMapIndex);
            this.GboxMapDetails.Controls.Add(this.textMapIndex);
            this.GboxMapDetails.Controls.Add(this.NbrMapValue);
            this.GboxMapDetails.Controls.Add(this.LabelMapValue);
            this.GboxMapDetails.ForeColor = System.Drawing.Color.White;
            this.GboxMapDetails.Location = new System.Drawing.Point(12, 12);
            this.GboxMapDetails.Name = "GboxMapDetails";
            this.GboxMapDetails.Size = new System.Drawing.Size(241, 328);
            this.GboxMapDetails.TabIndex = 3;
            this.GboxMapDetails.TabStop = false;
            this.GboxMapDetails.Text = "Map Details";
            // 
            // labelMapIndex
            // 
            this.labelMapIndex.AutoSize = true;
            this.labelMapIndex.Location = new System.Drawing.Point(34, 139);
            this.labelMapIndex.Name = "labelMapIndex";
            this.labelMapIndex.Size = new System.Drawing.Size(63, 15);
            this.labelMapIndex.TabIndex = 3;
            this.labelMapIndex.Text = "Map Index";
            this.labelMapIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textMapIndex
            // 
            this.textMapIndex.Location = new System.Drawing.Point(113, 136);
            this.textMapIndex.Name = "textMapIndex";
            this.textMapIndex.ReadOnly = true;
            this.textMapIndex.Size = new System.Drawing.Size(55, 23);
            this.textMapIndex.TabIndex = 2;
            // 
            // labelMapFilename
            // 
            this.labelMapFilename.AutoSize = true;
            this.labelMapFilename.Location = new System.Drawing.Point(15, 56);
            this.labelMapFilename.Name = "labelMapFilename";
            this.labelMapFilename.Size = new System.Drawing.Size(82, 15);
            this.labelMapFilename.TabIndex = 4;
            this.labelMapFilename.Text = "Map Filename";
            this.labelMapFilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textMapFilename
            // 
            this.textMapFilename.Location = new System.Drawing.Point(113, 53);
            this.textMapFilename.Name = "textMapFilename";
            this.textMapFilename.Size = new System.Drawing.Size(112, 23);
            this.textMapFilename.TabIndex = 5;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.GboxMapDetails);
            this.Controls.Add(this.ButtonUpdateMap);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(274, 410);
            this.Load += new System.EventHandler(this.MapControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NbrMapValue)).EndInit();
            this.GboxMapDetails.ResumeLayout(false);
            this.GboxMapDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NbrMapValue;
        private System.Windows.Forms.Label LabelMapValue;
        private System.Windows.Forms.Button ButtonUpdateMap;
        private System.Windows.Forms.GroupBox GboxMapDetails;
        private System.Windows.Forms.Label labelMapIndex;
        private System.Windows.Forms.TextBox textMapIndex;
        private System.Windows.Forms.TextBox textMapFilename;
        private System.Windows.Forms.Label labelMapFilename;
    }
}
