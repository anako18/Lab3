using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace Edge_detection
{
    public partial class Form1 : Form
    {
        string filepath = "";
        List<Point> edge;
        private Pen pen;
        private Point start;
        bool draw = false;

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = LineCap.Round;

            Image bi = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bi);
            g.Clear(Color.White);
            g.Dispose();
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            pictureBox1.Image = bi;
            saveToolStripMenuItem.Enabled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open...";
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                this.Text = Path.GetFileName(filepath);
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();
                pictureBox1.Image = new Bitmap(ofd.FileName);
                saveToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            string s0 = saveFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string s = saveFileDialog1.FileName;
                if (s.ToUpper() == s0.ToUpper())
                {
                    FileStream fs = File.Create(s0 = Path.GetDirectoryName(s0) + "\\temp.png");
                    fs.Close();
                    pictureBox1.Image.Save(s0);
                    pictureBox1.Image.Dispose();
                    //System.Threading.Thread.Sleep(1000);
                    File.Delete(s);
                    File.Move(s0, s);
                    pictureBox1.Image = new Bitmap(s);
                }
                else
                    pictureBox1.Image.Save(s);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            if(e.Button == MouseButtons.Right)
            {
                contourTrace(e.X, e.Y, bmp.GetPixel(e.X, e.Y));

                Graphics g = Graphics.FromImage(pictureBox1.Image);
                SolidBrush solid = new SolidBrush(Color.DeepPink);

                for (int i = 0; i < edge.Count; ++i)
                    g.FillRectangle(solid, edge[i].X, edge[i].Y, 2, 2);

                solid.Dispose();
                pictureBox1.Invalidate();
            }
        }

        private void contourTrace(int x, int y, Color color)
        {
            Bitmap bmp = pictureBox1.Image as Bitmap;
            Graphics g = Graphics.FromImage(pictureBox1.Image);

            while (color == bmp.GetPixel(x, y))
                ++x;

            // 7 6 5
            // 0   4
            // 1 2 3
            int[,] neighborhood = 
                new int[,] { { -1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 } };

            edge = new List<Point>();
            Point start_point = new Point(x, y);
            edge.Add(start_point);

            int prev_dir = 2;
            Point current_point;
            do
            {
                int dir = Math.Abs((prev_dir - 2 + 8) % 8);
                while (color == bmp.GetPixel(x + neighborhood[dir, 0], y + neighborhood[dir, 1]))
                    dir = (dir + 1) % 8;

                x += neighborhood[dir, 0];
                y += neighborhood[dir, 1];

                current_point = new Point(x, y);
                edge.Add(current_point);

                prev_dir= dir;
            }
            while (current_point != start_point);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image bi = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bi);
            g.Clear(Color.White);
            g.Dispose();
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            pictureBox1.Image = bi;
            saveToolStripMenuItem.Enabled = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null) return;
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.DrawLine(pen, start, e.Location);
                g.Dispose();
                start = e.Location;
                pictureBox1.Invalidate();

            }
        }
    }
}
