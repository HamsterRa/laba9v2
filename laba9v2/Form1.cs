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
        private void textBoxConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Stack<string> stack = new Stack<string>();
                    string sym = "";
                    bool fl = false;
                    string st = "";
                    foreach (char c in textBoxConsole.Text)
                    {
                        if (c == 'S' || c == 'M' || c == 'I')
                        {
                            stack.Push(c.ToString());
                        }
                        if (c == '[')
                        {
                            fl = true;
                           // stack.Push(c.ToString());
                        }
                        else if (c == ']')
                        {
                            fl = false;
                            st = st.Trim();
                            stack.Push(st);
                            //stack.Push(c.ToString());
                            st = "";
                        }
                        else if (c == ' ')
                        {
                            continue;
                        }
                        else if (c == ';')
                        {
                            st = st.Trim();
                            if (st != "")
                            {
                                stack.Push(st);
                                st = "";
                            }
                            //stack.Push(c.ToString());
                        }
                        else
                        {
                            st += c;
                        }
                    }
                    if (st != "")
                    {
                        st = st.Trim();
                        stack.Push(st);
                    }
                    Stack<string> reversedStack = new Stack<string>();
                    string sym1 = "";
                    for (int i = 0; i < textBoxConsole.Text.Length; i++)
                    {
                        if (textBoxConsole.Text[i] == 'S' || textBoxConsole.Text[i] == 'M' || textBoxConsole.Text[i] == 'I')
                        {
                            stack.Push(textBoxConsole.Text[i].ToString());
                        }
                        if (textBoxConsole.Text[i] == '[')
                        {
                            // stack.Push(c.ToString());
                        }
                        else if (textBoxConsole.Text[i] == ']')
                        {
                            sym = "";
                        }
                        else if (textBoxConsole.Text[i] == ' ')
                        {
                            continue;
                        }
                        else if (textBoxConsole.Text[i] == ';')
                        {
                            sym = "";
                        }
                        else
                        {
                            sym += textBoxConsole.Text[i];
                        }
                    }

                    while (stack.Count > 0)
                    {
                        reversedStack.Push(stack.Pop());
                    }

                    // поменять местами ссылки на первый и второй стеки
                    stack = reversedStack;



                    string sym_of_com = stack.Pop().ToUpper();
                    if ((sym_of_com == "S" || sym_of_com == "M" || sym_of_com == "I"))
                    {
                        // Создание фигуры
                        if (sym_of_com == "S")
                        {
                            Rectengular rectangle = new Rectengular(stack.Pop(), I(stack.Pop()), I(stack.Pop()), I(stack.Pop()));
                            rectangle.Draw();
                            listBoxHistory.Items.Add(textBoxConsole.Text);
                            ShapeContainer.AddFigure(rectangle);
                        }
                        // Перемещение фигуры
                        if (sym_of_com == "M")
                        {
                            Rectengular figyra;
                            for (int i = 0; i < ShapeContainer.figureList.Count; i++)
                            {
                                if (ShapeContainer.figureList[i].name == stack.Pop())
                                {
                                    figyra = ShapeContainer.figureList[i];
                                    int x = I(stack.Pop());
                                    int y = I(stack.Pop());
                                    if (pictureBox1.ClientSize.Width >= figyra.x + x + figyra.width && pictureBox1.ClientSize.Height >= figyra.y + y + figyra.height)
                                    {
                                        if (figyra.y + y >= 0 && figyra.x + x >= 0)
                                        {
                                            figyra.MoveTo(x, y);
                                            listBoxHistory.Items.Add(textBoxConsole.Text);
                                            for (int j = 0; j < ShapeContainer.figureList.Count; j++)
                                            {
                                                ShapeContainer.figureList[j].Draw();
                                            }
                                        }
                                        else
                                        {
                                            listBoxHistory.Items.Add("Невозможно подвинуть.");
                                        }
                                    }
                                    else
                                    {
                                        listBoxHistory.Items.Add("Невозможно подвинуть.");
                                    }
                                }
                            }
                        }
                        // Увеличение фигуры
                        if (sym_of_com == "I")
                        {
                            Rectengular figyra;
                            for (int i = 0; i < ShapeContainer.figureList.Count; i++)
                            {
                                if (ShapeContainer.figureList[i].name == stack.Pop())
                                {
                                    figyra = ShapeContainer.figureList[i];
                                    int scale = I(stack.Pop());
                                    if (scale > 0)
                                    {
                                        figyra.Scale(scale);
                                        listBoxHistory.Items.Add(textBoxConsole.Text);
                                        for (int j = 0; j < ShapeContainer.figureList.Count; j++)
                                        {
                                            ShapeContainer.figureList[j].Draw();
                                        }
                                    }
                                    else
                                    {
                                        listBoxHistory.Items.Add("Неверный коэффициент масштабирования.");
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        listBoxHistory.Items.Add("Неизвестная операция2");
                    }
                }

                catch
                {
                    listBoxHistory.Items.Add("Неизвестная операция1");
                } 
            }
        }
    }
}

