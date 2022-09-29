using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zmija
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] zmija;
        int duzina = 0;
        PictureBox hrana;
        int DIMENZIJA = 12;
        Random rnd;
        int MAX_DUZINA = 100;
        int BRZINA = 10;

        int pravac = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            zmija = new PictureBox[MAX_DUZINA];

            PictureBox glava = new PictureBox();
            glava.Width = DIMENZIJA;
            glava.Height = DIMENZIJA;
            glava.Location = new Point(rnd.Next(0,pictureBox1.Width-DIMENZIJA),rnd.Next(0,pictureBox1.Height-DIMENZIJA));
            glava.BackColor = Color.Orange;
            zmija[0] = glava;
            duzina = 1;
            pictureBox1.Controls.Add(glava);

            hrana = new PictureBox();
            hrana.Width = DIMENZIJA;
            hrana.Height = DIMENZIJA;
            hrana.Location = new Point(rnd.Next(0, pictureBox1.Width - DIMENZIJA), rnd.Next(0, pictureBox1.Height - DIMENZIJA));
            hrana.BackColor = Color.YellowGreen;
            pictureBox1.Controls.Add(hrana);

        }

        private void toolStrip1_KeyDown(object sender, KeyEventArgs e)
        {
            //error
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point poslednji = zmija[duzina-1].Location;

            if (duzina > 1)
            {
                for (int i = duzina - 1; i > 0; i--)
                {
                    zmija[i].Location = zmija[i - 1].Location;

                }
            }

            switch (pravac){
                case 1:
                    zmija[0].Left -= BRZINA;

                    break;
                case 2:
                    zmija[0].Left += BRZINA;
                    break;
                case 3:
                    zmija[0].Top -= BRZINA;
                    break;
                case 4:
                    zmija[0].Top += BRZINA;
                    break;

            }

            if (zmija[0].Left < 0 || zmija[0].Left > pictureBox1.Width - DIMENZIJA || zmija[0].Top < 0 || zmija[0].Top > pictureBox1.Height - DIMENZIJA) {
                timer1.Stop();
                MessageBox.Show("Kraj igre, udario si u ivicu!");
            }

            if (zmija[0].Bounds.IntersectsWith(hrana.Bounds)) {
                hrana.Location = new Point(rnd.Next(0, pictureBox1.Width - DIMENZIJA), rnd.Next(0, pictureBox1.Height - DIMENZIJA));
                PictureBox novi = new PictureBox();
                novi.Location = poslednji;
                novi.Width = DIMENZIJA;
                novi.Height = DIMENZIJA;
                novi.BackColor = Color.YellowGreen;
                pictureBox1.Controls.Add(novi);
                zmija[duzina] = novi;
                duzina++;
            }

            if (duzina > 4) {
                for (int i = 3; i < duzina; i++) {
                    if (zmija[0].Location == zmija[i].Location) {
                        timer1.Stop();
                        zmija[0].BackColor = Color.Red;
                        MessageBox.Show("Kraj igre, ujela se");
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                pravac = 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                pravac = 2;
            }
            if (e.KeyCode == Keys.Up)
            {
                pravac = 3;
            }
            if (e.KeyCode == Keys.Down)
            {
                pravac = 4;
            }
        }
    }
}
