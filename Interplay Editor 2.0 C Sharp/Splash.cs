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
    public partial class Splash : Form
    {
       
        const string version = "Version 2.0 ";
        const string build = "Build 21.1 ";
        const string bdate = "4/28/2021";
        Form MainForm;


        Timer timer;
        public Splash()
        {
            InitializeComponent();
            labelApplicationName.Text = "Interplay Lord of the Rings Resource Editor";

            labelVersion.Text = string.Concat(version, build, bdate);
            labelCopyright.Text = "Copyright (C) 2021 Aaron R. Willis";
            labelGameCopyright.Text = "Lord of the Rings Vol. 1 Copyright (C) 1990 & Lord of the Rings: The Two Towers Copyright (C) 1991 Interplay Productions";
            labelGameCode.Text = "Programming Based on C Source for Lord of the Rings Game Engine by Michael Benes www.wonderland.cz";
            //progressBar1.Visible = false;
        }



        private void Splash_Load(object sender, EventArgs e)
        {
            

        }

    
        private void Splash_Shown(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Start();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            timer.Stop();
            //display mainform
            MainForm = new ProgramForm();

            MainForm.Show();
            //hide this form
            this.Hide();

        }
    }
}
