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
            g.DrawRectangle(Init.pen, this.x, this.y, this.width, this.height);
            Init.pictureBox.Image = Init.bitmap;
        }
        public void Selection()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(new Pen(Color.White, 5), this.x, this.y, this.width, this.height);
            Init.pictureBox.Image = Init.bitmap;
        }
        public void MoveTo(int x, int y)
        {
            this.Selection();
            this.x += x;
            this.y += y;
            this.Draw();
        }
    }
}
}
