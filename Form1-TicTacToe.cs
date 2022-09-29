using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_O
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[,] dugmici;
        char na_redu;
        int broj_popunjenih_polja;

        private void Form1_Load(object sender, EventArgs e)
        {
            napravi_dugmice();
            na_redu = 'X';
            broj_popunjenih_polja = 0;
        }

        private void napravi_dugmice() {
            dugmici = new Button[3, 3];
            int i, j;
            int x, y;
            x = 40;
            y = 40;
            int sirina = 40;
            int visina = 40;

            for (i=0;i<3;i++) {
                for (j=0;j<3;j++) {
                    dugmici[i, j] = new Button();
                    dugmici[i, j].Location = new Point(x, y);
                    dugmici[i, j].Height = 40;
                    dugmici[i, j].Width = 40;

                    this.Controls.Add(dugmici[i, j]);

                    x += (sirina + 10);
                    dugmici[i, j].Click += klik_na_dugme;
                    dugmici[i, j].Tag = new Tuple<int, int>(i, j);
                }
                x = 40;
                y += (visina + 10);
            }
        }

        private void klik_na_dugme(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            b.Text = na_redu.ToString();
            b.Enabled = false; 
            broj_popunjenih_polja++;

            Tuple<int, int> tacno_polje = (Tuple<int, int>)b.Tag;
            if (proveri_vrstu(tacno_polje.Item1) || proveri_kolonu(tacno_polje.Item2) || proveri_glavnu_dijagonalu() || proveri_sporednu_dijagonalu()) {
                MessageBox.Show("Pobedio je "+na_redu);
                return;
            }

            if (broj_popunjenih_polja == 9) {
                MessageBox.Show("Nereseno");
                return;
            }

            if (na_redu == 'X')
            {
                na_redu = 'O';
            }
            else {
                na_redu = 'X';
            }

            
        }

        private bool proveri_vrstu(int i) {
            if (dugmici[i, 0].Text == dugmici[i, 1].Text && dugmici[i, 1].Text == dugmici[i, 2].Text && dugmici[i, 0].Text == na_redu.ToString())
            {
                return true;
            }
            else {
                return false;
            }
        }

        private bool proveri_kolonu(int j)
        {
            if (dugmici[0,j].Text == dugmici[1,j].Text && dugmici[1,j].Text == dugmici[2,j].Text && dugmici[0,j].Text == na_redu.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool proveri_glavnu_dijagonalu()
        {
            if (dugmici[0, 0].Text == dugmici[1, 1].Text && dugmici[1, 1].Text == dugmici[2, 2].Text && dugmici[0, 0].Text == na_redu.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool proveri_sporednu_dijagonalu()
        {
            if (dugmici[0, 2].Text == dugmici[1, 1].Text && dugmici[1, 1].Text == dugmici[2, 0].Text && dugmici[2, 0].Text == na_redu.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void restart() {
            int i, j;
            for (i = 0; i <3; i++) {
                for (j = 0; j < 3; j++) {
                    dugmici[i, j].Enabled = true;
                    dugmici[i, j].Text = "";
                }
            }
            na_redu = 'X';
            broj_popunjenih_polja = 0;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (na_redu == 'X')
            {
                na_redu = 'O';
            }
            else
            {
                na_redu = 'X';
            }
        }
    }
}
