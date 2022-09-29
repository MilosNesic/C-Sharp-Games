using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pingvin2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd;
        bool levo,desno,gore,dole;
        int BRZINA = 15;
        int MAX_RIBA=5;
        int MAX_POBEGLIH_UZASTOPNO = 3;
        int trenutno_riba = 0;
        int pojedeno_riba = 0;
        int pobeglo = 0;
        PictureBox[] ribe; 


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                levo = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                desno =false;
            }

            if (e.KeyCode == Keys.Up)
            {
                gore = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                dole = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < trenutno_riba; i++) {
                int trenutno_trajanje = (int)ribe[i].Tag;
                if (trenutno_trajanje == 3)
                {

                    PictureBox pomocni = ribe[i];
                    ribe[i] = ribe[trenutno_riba - 1];
                    ribe[trenutno_riba - 1] = pomocni;
                    Controls.Remove(ribe[trenutno_riba - 1]);
                    trenutno_riba--;
                    i--;
                    pobeglo++;

                    if (pobeglo == MAX_POBEGLIH_UZASTOPNO) {
                        timer1.Stop();
                        timer2.Stop();
                        MessageBox.Show("Pobeglo previse riba");
                    }
                }
                else {
                    ribe[i].Tag = trenutno_trajanje+1;
                    
                }
            }

            if (trenutno_riba < MAX_RIBA) {
                PictureBox nova_riba = new PictureBox();
                nova_riba.BackgroundImage = Properties.Resources.riba;
                nova_riba.BackgroundImageLayout = ImageLayout.Stretch;
                nova_riba.Height = 50;
                nova_riba.Width = 50;
                nova_riba.Tag = 0;
                nova_riba.Location = new Point(rnd.Next(0, this.Width - nova_riba.Width), rnd.Next(toolStrip1.Height, this.Height - nova_riba.Height));
                //dodajemo ribu na formu
                Controls.Add(nova_riba);
                //dodajemo je i u niz
                ribe[trenutno_riba] = nova_riba;
                trenutno_riba++;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < trenutno_riba; i++) {
                Controls.Remove(ribe[i]);
            }
            trenutno_riba = 0;
            pobeglo = 0;
            pojedeno_riba = 0;
            label1.Text = "0";
            timer1.Start();
            timer2.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            levo = false;
            desno = false;
            gore = false;
            dole = false;

            pingvin.Left = rnd.Next(0,this.Width-pingvin.Width);
            pingvin.Top = rnd.Next(toolStrip1.Height,this.Height-pingvin.Height);

            ribe = new PictureBox[MAX_RIBA];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (levo == true) {
                pingvin.Left -= BRZINA;
            }

            if(desno == true) {
                pingvin.Left += BRZINA;
            }

            if(gore == true) {
                pingvin.Top -= BRZINA;
            }

            if (dole == true)
            {
                pingvin.Top += BRZINA;
            }

            for (int i = 0; i < trenutno_riba; i++) {

                if (pingvin.Bounds.IntersectsWith(ribe[i].Bounds)) {
                    PictureBox pomocni = ribe[i];
                    ribe[i] = ribe[trenutno_riba - 1];
                    ribe[trenutno_riba - 1] = pomocni;
                    Controls.Remove(ribe[trenutno_riba-1]);
                    trenutno_riba--;
                    i--;
                    pojedeno_riba++;
                    pobeglo = 0;
                    label1.Text = pojedeno_riba.ToString();
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) {
                levo = true;
            }

            if (e.KeyCode == Keys.Right) {
                desno = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                gore = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                dole = true;
            }
        }
    }
}
