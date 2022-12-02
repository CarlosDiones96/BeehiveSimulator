using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Printing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = document;
            preview.ShowDialog();
        }

        bool firstPage = true;
        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            //TODO: create DrawBee method
            DrawBee(e.Graphics, new Rectangle(0, 0, 300, 300));
            using (Font font = new Font("Arial", 36, FontStyle.Bold))
            {
                if (firstPage)
                {
                    e.Graphics.DrawString("Primeira página", font, Brushes.Black, 0, 0);
                    e.HasMorePages = true;
                    firstPage = false;
                }
                else
                {
                    e.Graphics.DrawString("Segunda página", font, Brushes.Black, 0, 0);
                    firstPage = true;
                }
            }
        }
    }
}
