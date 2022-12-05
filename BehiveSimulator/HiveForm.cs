using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BehiveSimulator
{
    public partial class HiveForm : Form
    {
        public Renderer Renderer { get; set; }

        public HiveForm()
        {
            InitializeComponent();
            BackgroundImage = Renderer.ResizeImage(Properties.Resources.Hive__inside_, ClientRectangle.Width, ClientRectangle.Height);
        }

        private void HiveForm_Load(object sender, EventArgs e)
        {

        }

        private void HiveForm_MouseClick(object sender, MouseEventArgs e)
        {
            // Just to know the position of the bees
            MessageBox.Show(e.Location.ToString());
        }

        private void HiveForm_Paint(object sender, PaintEventArgs e)
        {
            Renderer.PaintHive(e.Graphics);
        }
    }
}
