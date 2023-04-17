using System.Windows.Forms;

namespace laba9v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Pen pen = new Pen(Color.Black, 3);
            Pen penClear = new Pen(Color.White, 3);
            Init.bitmap = bitmap;
            Init.pictureBox = pictureBox1;
            Init.pen = pen;
            ShapeContainer shapeContainer = new ShapeContainer();
        }
        internal class Init
        {
            public static Bitmap bitmap;
            public static Pen pen;
            public static Pen penClear;
            public static PictureBox pictureBox;
        }
        public int I(string a)
        {
            return Convert.ToInt32(a);
        }
        public class ShapeContainer
        {
            public static List<Rectengular> figureList;
            public ShapeContainer()
            {
                figureList = new List<Rectengular>();
            }
            public static void AddFigure(Rectengular figure)
            {
                figureList.Add(figure);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}