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
        public HiveForm()
        {
            InitializeComponent();
        }

        private void HiveForm_Load(object sender, EventArgs e)
        {

        }

        private void HiveForm_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
        }
    }
}
