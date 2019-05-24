using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquinaTuringDan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AB A = new AB();
            A.Show();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SB b = new SB();
            b.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CB c = new CB();
            c.Show();
            this.Hide();
        }
    }
}
