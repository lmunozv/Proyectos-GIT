﻿using Bizagi.Test.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bizagi.Catalogo.Funcionalidades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommonMethods c = new CommonMethods();

            MessageBox.Show(c.ConvertNumbersToLetters("25000000,60", true));
        }
    }
}
