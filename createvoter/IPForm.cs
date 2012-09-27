using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentVote
{
    public partial class IPForm : Form
    {
        public string IPAdressAndPort;
        public IPForm()
        {
            InitializeComponent();
        }

        private void IPBox_TextChanged(object sender, EventArgs e)
        {
            IPAdressAndPort = IPBox.Text;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
