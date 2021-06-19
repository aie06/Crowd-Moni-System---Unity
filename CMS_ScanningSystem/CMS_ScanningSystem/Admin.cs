﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS_ScanningSystem.Classes;

namespace CMS_ScanningSystem
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RoomChange().ShowDialog();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ScanningSystem().ShowDialog();
        }
    }
}
