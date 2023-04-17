using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static laba9v2.Form1; 

namespace laba9v2
{
    public class Rectengular
    {
        public int x, y, width, height;
        public string name;
        public double scaleFactor = 1.0;

        public Rectengular(string name, int x, int y, int width)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = width;
            this.name = name;
        }

        public void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, this.x, this.y, (int)(this.width * this.scaleFactor), (int)(this.height * this.scaleFactor));
            Init.pictureBox.Image = Init.bitmap;
        }

        public void Selection()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(new Pen(Color.White, (int)(5 * this.scaleFactor)), this.x, this.y, (int)(this.width * this.scaleFactor), (int)(this.height * this.scaleFactor));
            Init.pictureBox.Image = Init.bitmap;
        }

        public void MoveTo(int x, int y)
        {
            this.Selection();
            this.x += x;
            this.y += y;
            this.Draw();
        }

        public void Scale(double factor)
        {
            this.Selection();
            this.width = (int)(this.width * factor);
            this.height = (int)(this.height * factor);
            this.scaleFactor *= factor;
            this.Draw();
        }
    }

}

