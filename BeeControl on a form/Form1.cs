using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeControl_on_a_form
{
    public partial class Form1 : Form
    {
        Bitmap photo = new Bitmap(@"C:\Users\dione\Pictures\csharp.png");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, 0, 0, Width, Height);
            g.DrawImage(photo, 10, 10, trackBar1.Value, trackBar2.Value);
        }

        //test code [to be removed]
        protected override void OnPaint(PaintEventArgs e)
        {
          
            Console.WriteLine("OnPaint "+  DateTime.Now +  e.ClipRectangle.ToString());
            base.OnPaint(e);
        }
    }
}
