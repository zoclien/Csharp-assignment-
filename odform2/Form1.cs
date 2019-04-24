using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odform2
{

    public class datalist : BindingList<orders>
    {
        
    }
    public partial class Form1 : Form
    {       orderservice ods = new orderservice();
            ListBox lb=new ListBox ();
            Button b1=new Button ();
            Button b2=new Button();
            Button b3=new Button ();
            TextBox tb1=new TextBox();
            TextBox tb2 = new TextBox();
            TextBox tb3 = new TextBox();
            TextBox tb = new TextBox();
        int k = 0;
        public Form1()
        {
            
            InitializeComponent();
           
            
            b1.Location = new Point(30, 30);
            b1.Size = new Size(20,70);
            b1.Text = "check";
            b1.Click += new EventHandler(this.button1_Click);
            b2.Location = new Point(60, 30);
            b2.Size = new Size(20,70);
            b2.Text = "create";
            b2.Click += new EventHandler(this.button2_Click);
            b3.Location = new Point(90, 30);
            b3.Size = new Size(20,70);
            b3.Text = "delete";
            b3.Click += new EventHandler(this.button3_Click);
            lb.Location = new Point(30, 120);
            lb.Size = new Size(80,40);
            tb1.Location = new Point(120,30);
            tb1.Size = new Size(20,70);
            tb2.Location = new Point(150,30);
            tb2.Size = new Size(20,70);
            tb3.Location = new Point(180,30);
            tb3.Size = new Size(20,70);
            tb.Location = new Point(120, 110);
            tb.Size = new Size(20,70);
            tb1.Text = "goods1?";
            tb2.Text = "goods2?";
            tb3.Text = "goods3?";
            tb.Text = "client";
            this.ClientSize = new Size(200,200);
            this.Controls.Add(lb);
            this.Controls.Add(b1);
            this.Controls.Add(b2);
            this.Controls.Add(b3);
            this.Controls.Add(tb1);
            this.Controls.Add(tb2);
            this.Controls.Add(tb3);
            this.Controls.Add(tb);
         

           
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            lb.Text=ods.checkord(tb.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ods.creatorder(new orders(tb.Text, k, tb1.Text, tb2.Text, tb3.Text));
            k++;
            
   
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ods.delete(tb.Text);
        }

       
    }
}
