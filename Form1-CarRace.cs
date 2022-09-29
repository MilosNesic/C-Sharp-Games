using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trke
{
    public partial class Trke : Form
    {
        public Trke()
        {
            InitializeComponent();
        }

        void inicijalizuj()
        {
            b1.Value = 5;
            b2.Value = 5;
            pictureBox1.Left = 0;
            pictureBox2.Left = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicijalizuj();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (pictureBox1.Left > this.Width - pictureBox1.Width)
            {
                if (pictureBox2.Left > this.Width - pictureBox2.Width)
                {
                    timer1.Stop();
                    MessageBox.Show("Nereseno je");
                    
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Pobedio je gornji auto");
                }
            }
            else if (pictureBox2.Left > this.Width - pictureBox2.Width)
            {
                timer1.Stop();
                MessageBox.Show("Pobedio je donji auto");
            }
            else
            {
                pictureBox1.Left += (int)b1.Value;
                pictureBox2.Left += (int)b2.Value;
            }

        }

        private void pokreni_Click(object sender, EventArgs e)
        {
            inicijalizuj();
            timer1.Start();
        }
    }
}
