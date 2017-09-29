using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Graphics3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;

        Bitmap image;

		Bitmap input;

        string filename = "";

        Color Border_color = Color.Black;

		Pen p;

        private Graphics g;
        //Start of drawing 
        int? initX = null;
        int? initY = null;
        bool startDraw = false;
        bool filling = false;
        bool fill_pic = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			bmp = new Bitmap(draw_panel.Width, draw_panel.Height);
			draw_panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
			draw_panel.Image = (Image)bmp;
			p = new Pen(color_button.BackColor, 4);
			p.StartCap = p.EndCap = LineCap.Round;
		}

        //Drawing
        private void draw_panel_MouseMove(object sender, MouseEventArgs e)
        {
            //bmp = new Bitmap(draw_panel.Image);
            g = Graphics.FromImage(bmp);
            if (startDraw)
            {
                
                g.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                initX = e.X;
                initY = e.Y;
            }
            draw_panel.Image = bmp;
            Border_color = color_button.BackColor;
        }

        private void draw_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (filling)
            {
                int startx = e.X;
                int starty = e.Y;
                recursive_serial_fill(startx, starty, color_button.BackColor, bmp.GetPixel(startx, starty));
                return;
            }
            else if (fill_pic)
            {
                int startx = e.X;
                int starty = e.Y;
                serial_fill_picture(startx, starty, image, bmp.GetPixel(startx, starty));
                return;
            }
            startDraw = true;
        }

        private void draw_panel_MouseUp(object sender, MouseEventArgs e)
        {
            startDraw = false;
            initX = null;
            initY = null;
        }

        private void color_button_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                color_button.BackColor = c.Color;
            }
            //filling = false;
            //fill_pic = false;
        }


        private void fill_button_Click(object sender, EventArgs e)
        {
            filling = true;
            //draw_panel.Image.Save("picture_box.bmp");
            draw_panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            // bmp.Save("bitmap.bmp"); 
        }


        //Flood fill with color
        private void recursive_serial_fill(int startx, int starty, Color fillcolor, Color targetcolor)
        {
            //draw_panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            //bmp.Save("bitmap.bmp");
            targetcolor = bmp.GetPixel(startx, starty);
            if (targetcolor.ToArgb().Equals(fillcolor.ToArgb()))
                return;

            bmp.SetPixel(startx, starty, fillcolor);

            //Left border search
            int leftborder = startx;
            while ((leftborder > 0) && (bmp.GetPixel(leftborder - 1, starty).ToArgb().Equals(targetcolor.ToArgb())))
            {
                bmp.SetPixel(leftborder - 1, starty, fillcolor);
                leftborder -= 1;
            }

            //Right border search
            int rightborder = startx;
            while ((rightborder < draw_panel.Width - 1) && (bmp.GetPixel(rightborder + 1, starty).ToArgb().Equals(targetcolor.ToArgb())))
            {
                bmp.SetPixel(rightborder + 1, starty, fillcolor);
                rightborder += 1;
            }

            //Up
            for (int i = leftborder; i <= rightborder; i++)
                if (starty > 0 && bmp.GetPixel(i, starty - 1).ToArgb().Equals(targetcolor.ToArgb()))
                recursive_serial_fill(i, starty - 1, fillcolor, targetcolor);

            //Down
            for (int i = leftborder; i <= rightborder; i++)
                if (starty < bmp.Height - 1 && bmp.GetPixel(i, starty + 1).ToArgb().Equals(targetcolor.ToArgb()))
                    recursive_serial_fill(i, starty + 1, fillcolor, targetcolor);

            draw_panel.Image = bmp;
            filling = false;
        }

        
        private void picture_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK);
			{
				filename = openFileDialog1.FileName;
				if (filename != "")
				{
					input = new Bitmap(filename);
					image = new Bitmap(draw_panel.Image as Bitmap);

					for (int y = 0; y < image.Height; y++)
					{
						for (int x = 0; x < image.Width; x++)
						{
							int ix = x % input.Width;
							int iy = y % input.Height;
							image.SetPixel(x, y, input.GetPixel(ix, iy));
						}
					}

					//if ((image.Height < bmp.Height) || (image.Width < bmp.Width))
					//{
					//	MessageBox.Show("Choose a different one.", "The image is too small!",
					//	MessageBoxButtons.OK, MessageBoxIcon.Error);
					//	image.Dispose();
					//	fill_pic = false;
					//	return;
					//}
					image.Save("text.bmp");
					fill_pic = true;
				}
			}
        }

        private void serial_fill_picture(int startx, int starty, Bitmap image, Color targetcolor)
        {
            //draw_panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            //bmp.Save("bitmap.bmp");
            targetcolor = bmp.GetPixel(startx, starty);
            //if (targetcolor.ToArgb().Equals(fillcolor.ToArgb()))
            //    return;

            bmp.SetPixel(startx, starty, image.GetPixel(startx, starty));

            //Left border search
            int leftborder = startx;
            while ((leftborder > 0) && (bmp.GetPixel(leftborder - 1, starty).ToArgb().Equals(targetcolor.ToArgb())))
            {
                bmp.SetPixel(leftborder - 1, starty, image.GetPixel(leftborder - 1, starty));
                leftborder -= 1;
            }

            //Right border search
            int rightborder = startx;
            while ((rightborder < draw_panel.Width - 1) && (bmp.GetPixel(rightborder + 1, starty).ToArgb().Equals(targetcolor.ToArgb())))
            {
                bmp.SetPixel(rightborder + 1, starty, image.GetPixel(rightborder + 1, starty));
                rightborder += 1;
            }

            //Up
            for (int i = leftborder; i <= rightborder; i++)
                if (starty > 0 && bmp.GetPixel(i, starty - 1).ToArgb().Equals(targetcolor.ToArgb()))
                    serial_fill_picture(i, starty - 1, image, targetcolor);

            //Down
            for (int i = leftborder; i <= rightborder; i++)
                if (starty < bmp.Height - 1 && bmp.GetPixel(i, starty + 1).ToArgb().Equals(targetcolor.ToArgb()))
                    serial_fill_picture(i, starty + 1, image, targetcolor);

            draw_panel.Image = bmp;
            fill_pic = false;
        }

		private void button1_Click(object sender, EventArgs e)
		{
			bmp = new Bitmap(draw_panel.Width, draw_panel.Height);
			draw_panel.Image = (Image)bmp;
		}

		private void draw_panel_SizeChanged(object sender, EventArgs e)
		{
			Bitmap b = new Bitmap(bmp, draw_panel.Size);
			bmp = b;
			draw_panel.Image = (Image)bmp;
		}
	}



}
