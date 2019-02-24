using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi
{
    public partial class Form1 : Form
    {
        public double m, n, x;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m = Double.Parse(textBox2.Text);
            n = Double.Parse(textBox1.Text);
            x = m * n;
            label1.Text = "乘积：" + x;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
