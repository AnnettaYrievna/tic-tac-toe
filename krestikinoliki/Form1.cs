using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace krestikinoliki
{
    public partial class Form1 : Form
    {
        Game frm2;
        public Form1()
        {
            InitializeComponent();
            frm2 = new Game(this);
        }
 public int n=1, m=1, q; 
        public string a, nickname2;
        public bool b, c, d, f;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            textBox4.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
                label6.Visible = true;
                textBox4.Visible = true;
            label7.Visible = true;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                d = true;
               
            }
            if (radioButton4.Checked)
            {
                f = true;

            }
            if (radioButton1.Checked)
            {
                b = true;
                c = false;
            }
            else if (radioButton2.Checked)
            {
                c = true;
                b = false;
            }
            n = Convert.ToInt32(textBox1.Text);
            m = Convert.ToInt32(textBox2.Text);
            q = Convert.ToInt32(textBox5.Text);

             if (textBox3.Text != "") a = textBox3.Text;
              else  if (textBox3.Text == "")  a = "Player ";
            if (textBox4.Text != "") nickname2 = textBox4.Text;
            else if (textBox4.Text == "") nickname2 = "Player2 ";
            
            Game game = new Game(this);
            game.Show();
            
        }
    }
}
