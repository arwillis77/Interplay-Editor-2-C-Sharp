
namespace Interplay_Editor_2_C_Sharp
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelApplicationName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelGameCopyright = new System.Windows.Forms.Label();
            this.labelGameCode = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelApplicationName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelVersion, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCopyright, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelGameCopyright, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelGameCode, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.81618F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.036765F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.036765F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.036765F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.036765F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.036765F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 548);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 403);
            this.panel1.TabIndex = 0;
            // 
            // labelApplicationName
            // 
            this.labelApplicationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelApplicationName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelApplicationName.Location = new System.Drawing.Point(3, 409);
            this.labelApplicationName.Name = "labelApplicationName";
            this.labelApplicationName.Size = new System.Drawing.Size(492, 27);
            this.labelApplicationName.TabIndex = 1;
            this.labelApplicationName.Text = "Application Name";
            this.labelApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelVersion.Location = new System.Drawing.Point(3, 436);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(492, 27);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCopyright.Location = new System.Drawing.Point(3, 463);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(492, 27);
            this.labelCopyright.TabIndex = 4;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGameCopyright
            // 
            this.labelGameCopyright.AutoSize = true;
            this.labelGameCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGameCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGameCopyright.Location = new System.Drawing.Point(3, 490);
            this.labelGameCopyright.Name = "labelGameCopyright";
            this.labelGameCopyright.Size = new System.Drawing.Size(492, 27);
            this.labelGameCopyright.TabIndex = 6;
            this.labelGameCopyright.Text = "Game Copyright";
            this.labelGameCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGameCode
            // 
            this.labelGameCode.AutoSize = true;
            this.labelGameCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGameCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGameCode.Location = new System.Drawing.Point(3, 517);
            this.labelGameCode.Name = "labelGameCode";
            this.labelGameCode.Size = new System.Drawing.Size(492, 31);
            this.labelGameCode.TabIndex = 7;
            this.labelGameCode.Text = "Game Code Details";
            this.labelGameCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(498, 548);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.Shown += new System.EventHandler(this.Splash_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelApplicationName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelGameCopyright;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelGameCode;
    }
}