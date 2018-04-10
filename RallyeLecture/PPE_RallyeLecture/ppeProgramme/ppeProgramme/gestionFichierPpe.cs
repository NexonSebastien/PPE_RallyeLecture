using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ppeProgramme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLancer_Click(object sender, EventArgs e)
        {
            if (cbSupression.Checked == true)
            {
                Delete();
            }
        }
    }
}
