using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACMAN
{
    public partial class Form1 : Form
    {

        bool sus;
        bool jos;
        bool stanga;
        bool dreapta;
        // fantoma3 este fantoma ce se va misca
        int viteza = 5;

        int fantoma1 = 8;
        int fantoma2 = 8;

        int fantoma3x = 8;
        int fantoma3y = 8;

        int scor = 0;
        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;   // arata cand jocul se incheie
        }

     

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                stanga = true;
                pacman.Image = Properties.Resources.Right;
            }
            if (e.KeyCode == Keys.Right)
            {
                dreapta = true;
                pacman.Image = Properties.Resources.Left;
            }
            if (e.KeyCode == Keys.Up)
            {
                sus = true;
                pacman.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                jos = true;
                pacman.Image = Properties.Resources.down;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                stanga = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                dreapta = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                sus = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                jos = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Scor:" + scor;
            if (stanga)
            {
                pacman.Left -= viteza;
            }
            if (dreapta)
            {
                pacman.Left += viteza;
            }
            if (sus)
            {
                pacman.Top -= viteza;
            }
            if (jos)
            {
                pacman.Top += viteza;
            }
            fantomaRosie.Left += fantoma1;
            fantomaGalbena.Left += fantoma2;
            if (fantomaRosie.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                fantoma1 = -fantoma1;
            }
            else if (fantomaRosie.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                fantoma1 = -fantoma1;
            }
            if (fantomaGalbena.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                fantoma2 = -fantoma2;

            }
            else if (fantomaGalbena.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                fantoma2 = -fantoma2;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "prt" || x.Tag == "fnt")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds) || scor == 30)
                    {
                        pacman.Left = 0;
                        pacman.Top = 25;
                        label2.Text = "SFARSIT DE JOC";
                        label2.Visible = true;
                        timer1.Stop();

                    }
                }
                if (x is PictureBox && x.Tag == "ban")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x);
                        scor++;
                    }
                }
            }
            fantomaRoz.Left += fantoma3x;
            fantomaRoz.Top += fantoma3y;
            if(fantomaRoz.Left<1 || 
                fantomaRoz.Left+fantomaRoz.Width>ClientSize.Width-2||
                (fantomaRoz.Bounds.IntersectsWith(pictureBox1.Bounds))||
                (fantomaRoz.Bounds.IntersectsWith(pictureBox2.Bounds))||
                (fantomaRoz.Bounds.IntersectsWith(pictureBox3.Bounds))||
                (fantomaRoz.Bounds.IntersectsWith(pictureBox4.Bounds)))
            {
                fantoma3x = -fantoma3x;
            }
            if(fantomaRoz.Top<1||fantomaRoz.Top+fantomaRoz.Height>ClientSize.Height - 2)
            {
                fantoma3y = -fantoma3y;
            }
        }

       
    }
}
