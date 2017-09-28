using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;

        Color Border_color = Color.Black;

        private Graphics g;
        //Start of drawing 
        int? initX = null;
        int? initY = null;
        bool startDraw = false;
        bool filling = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(draw_panel.Width, draw_panel.Height);
            draw_panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            draw_panel.Image = (Image)bmp;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // g = Graphics.FromHwnd(draw_panel.Handle);
            // g = Graphics.FromImage(bmp);
        }


        //Drawing
        private void draw_panel_MouseMove(object sender, MouseEventArgs e)
        {
            // Border_color = color_button.BackColor;
            bmp = new Bitmap(draw_panel.Image);
            g = Graphics.FromImage(bmp);
            if (startDraw)
            {
                Pen p = new Pen(color_button.BackColor, 4);
                Border_color = color_button.BackColor;
                g.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                initX = e.X;
                initY = e.Y;
            }
            draw_panel.Image = bmp;
        }



        private void draw_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (filling)
            {
                int startx = e.X;
                int starty = e.Y;
                //filling_recursive(e.X, e.Y);
                recursive_serial_fill(startx, starty, color_button.BackColor, bmp.GetPixel(startx, starty));
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
        }


        private void fill_button_Click(object sender, EventArgs e)
        {
            filling = true;
            //draw_panel.Image.Save("picture_box.bmp");
            draw_panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            // bmp.Save("bitmap.bmp"); 
        }



        private void recursive_serial_fill(int startx, int starty, Color fillcolor, Color targetcolor)
        {
            draw_panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save("bitmap.bmp");
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
            if (starty > 0 && bmp.GetPixel(startx, starty - 1).ToArgb().Equals(targetcolor.ToArgb()))
            recursive_serial_fill(startx, starty - 1, fillcolor, targetcolor);

            //Down
            if (starty < bmp.Height-1 && bmp.GetPixel(startx, starty + 1).ToArgb().Equals(targetcolor.ToArgb()))
                recursive_serial_fill(startx, starty + 1, fillcolor, targetcolor);

            draw_panel.Image = bmp;

        }




        private void filling_recursive(int x, int y)
        {
            draw_panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save("bitmap.bmp");

            //Если цвет = цвету границы
          //  if ((bmp.GetPixel(x, y).ToArgb().Equals(Border_color.ToArgb())))
            //    return;


            //Поиск левой границы



            ////Если цвет = цвету границы
            //if (equal_color(bmp.GetPixel(x, y), Border_color))
            //    return;
            //else
            //    //Установка текущего пикселя
            //    bmp.SetPixel(x, y, color_button.BackColor);

            //int i_x = x; //сохранение init x 

            ////До левой границы
            //while ((x > 1) &&
            //  !equal_color(bmp.GetPixel(x - 1, y), Border_color))
            //{
            //    bmp.SetPixel(x - 1, y, color_button.BackColor);
            //    x -= 1;
            //}
            while ((x > 1) &&
            !(bmp.GetPixel(x - 1, y).ToArgb().Equals(Border_color.ToArgb())))
            {
                bmp.SetPixel(x - 1, y, color_button.BackColor);
                x -= 1;
            }

            ////До правой границы
            //while ((i_x < draw_panel.Width - 1) &&
            //!equal_color(bmp.GetPixel(i_x + 1, y), Border_color))
            //{
            //    bmp.SetPixel(i_x + 1, y, color_button.BackColor);
            //    i_x += 1;
            //}

            //if (y > 1)
            //    filling_recursive(startx, y - 1);

            ////if (y < draw_panel.Height)
            ////   filling_recursive(initx, inity + 1);

            //// filling = false;
            //draw_panel.Image = bmp;

        }

    }



}
