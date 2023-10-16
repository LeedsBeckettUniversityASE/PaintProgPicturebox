using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintProgDelete
{
    public partial class Form1 : Form
    {
        int PenWidth = 2;
        Bitmap bitmap;
        Color Colour = Color.Red;
        Pen p;
        bool mouseDown = false;
        public Form1()
        {
            
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //get graphics context of form (which is being displayed)
            g.DrawImageUnscaled(bitmap, 0, 0); //put the off screen bitmap on the form
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
                return;
            p = new Pen(Colour, PenWidth);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(p, e.X, e.Y, e.X+2, e.Y+2);
            p.Dispose();
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //get graphics context of form (which is being displayed)
            g.DrawImageUnscaled(bitmap, 0, 0); //put the off screen bitmap on the form
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown= true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Colour = colorDialog1.Color;
            }
        }
    }
}
