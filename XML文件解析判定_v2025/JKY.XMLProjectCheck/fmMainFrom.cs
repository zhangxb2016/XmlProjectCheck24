using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JKY.XMLProjectCheck
{
    public partial class fmMainFrom : Form
    {
        public fmMainFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fm = new fmXmlCheckMain();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fm = new fmXmlCheckMainPlus();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fm = new fmXmlCheckMainPro();
            fm.Show();
        }
    }
}
