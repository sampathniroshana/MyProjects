﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCMS_Win
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            // Login Window Close
            this.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        public bool UserLogin(String uName, String pWord)
        {
            return true;
        }
    }
}
