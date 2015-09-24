using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp4560Lab
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The size of the squares
        /// </summary>
        int s = 25;
        /// <summary>
        /// The gap between the squares
        /// </summary>
        int g = 25;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.Clear(this.BackColor);
            this.drawSideSquare(true);
            this.drawSideSquare(false);
        }
        private void drawSideSquare(bool drawLeft)
        {
            Graphics graphics = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Green);
            int w = this.Width;
            int h = this.Height;
            int startX = w / 2;
            startX = drawLeft ? startX - s : startX + s;
            int startY = (2*s) + g;
            int endY = h - ((2 * s) + g);
            int direction = drawLeft ? -s - g : s + g;
            while (drawLeft ? (startX > (2* g + s)) : (startX < w - (2*g +s)))
            {
                int tempY = startY;
                while(tempY < endY)
                {
                    graphics.FillRectangle(brush, new Rectangle(startX, tempY, s, s));
                    tempY += s + g;
                }
                startX += direction;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.Clear(this.BackColor);
            drawSideSquare(true);
            drawSideSquare(false);
        }
    }
}
