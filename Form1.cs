using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsProject8_2
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Brushes.Black, 3);
        Graphics graphics;
        Point pointStart;
        Point pointEnd;
        Point pointBrush;
        string TypeFigures;


        public Form1()
        {
            InitializeComponent();
            pointStart = new Point();
            pointEnd = new Point();
            pointBrush = new Point();
            TypeFigures = "";
            graphics = CreateGraphics();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";

            openFileDialog.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";

            saveFileDialog.ShowDialog();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeFigures = "rectangle";
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeFigures = "line";
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeFigures = "circle";
        }

        private void brushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeFigures = "brush";
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Blue;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Green;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invalidate();       
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (TypeFigures == "line")
            {
                if (pointStart == Point.Empty)
                {
                    pointStart.X = e.X;
                    pointStart.Y = e.Y;

                    return;
                }

                else if (pointStart != Point.Empty)
                {
                    pointEnd.X = e.X;
                    pointEnd.Y = e.Y;

                    graphics.DrawLine(pen, pointStart, pointEnd);

                    pointStart = Point.Empty;
                    pointEnd = Point.Empty;
                }
            }

            else if (TypeFigures == "rectangle")
            {
                if (pointStart == Point.Empty)
                {
                    pointStart.X = e.X;
                    pointStart.Y = e.Y;

                    return;
                }

                else if (pointStart != Point.Empty)
                {
                    pointEnd.X = e.X;
                    pointEnd.Y = e.Y;


                    Size size = new Size(Math.Abs(pointEnd.X - pointStart.X), Math.Abs(pointEnd.Y - pointStart.Y));

                    Rectangle rectangle = new Rectangle(pointStart, size);

                    graphics.DrawRectangle(pen, rectangle);

                    pointStart = Point.Empty;
                    pointEnd = Point.Empty;
                }
            }

            else if(TypeFigures == "circle")
            {
                if (pointStart == Point.Empty)
                {
                    pointStart.X = e.X;
                    pointStart.Y = e.Y;
                }

                else if (pointStart != Point.Empty)
                {
                    pointEnd.X = e.X;
                    pointEnd.Y = e.Y;

                    Size size = new Size(Math.Abs(pointEnd.X - pointStart.X), Math.Abs(pointEnd.X - pointStart.X));

                    Point point = new Point(pointEnd.X, pointEnd.Y);

                    Rectangle rectangle = new Rectangle(point, size);

                    graphics.DrawEllipse(pen, rectangle);

                    pointStart = Point.Empty;
                    pointEnd = Point.Empty;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (TypeFigures == "brush")
            {
                if (e.Button == MouseButtons.Left)
                {
                    graphics.DrawLine(pen, pointBrush.X, pointBrush.Y, e.X, e.Y);
                }
            }

            Update();
            pointBrush.X = e.X;
            pointBrush.Y = e.Y;
        }
    }
}