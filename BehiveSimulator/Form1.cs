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
    public partial class Form1 : Form
    {
        private World world;
        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int framesRun = 0;
        public Form1()
        {
            InitializeComponent();
            world = new World(new BeeMessage(SendMessage));

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateStats(new TimeSpan());
        }

        private void RunFrame(object sender, EventArgs e)
        {
            framesRun++;
            world.Go(random);
            end = DateTime.Now;
            TimeSpan frameDuration = end - start;
            start = end;
            UpdateStats(frameDuration);
        }

        private void UpdateStats(TimeSpan frameDuration)
        {
            beesLabel.Text = world.Bees.Count.ToString();
            flowersLabel.Text = world.Flowers.Count.ToString();
            honeyInHiveLabel.Text = String.Format("{0:f3}", world.Hive.Honey);
            double nectar = 0;
            foreach (Flower flower in world.Flowers)
            {
                nectar += flower.Nectar;
            }
            nectarInFlowersLabel.Text = String.Format("{0:f3}", nectar);
            framesRunLabel.Text = framesRun.ToString(); // framesRunLabel
            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
            {
                frameRate.Text = String.Format("{0:f0} ({1:f1}ms)", 1000 / milliSeconds, milliSeconds);
            }
            else
            {
                frameRate.Text = "Indisponível";
            }
        }

        private void startToolStripButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                toolStrip1.Items[0].Text = "Continuar simulação";
                timer1.Stop();
            }
            else
            {
                toolStrip1.Items[0].Text = "Pausar simulação";
                timer1.Start();
            }
        }

        private void resetToolStripButton_Click(object sender, EventArgs e)
        {
            framesRun = 0;
            world = new World(new BeeMessage(SendMessage));
            if (!timer1.Enabled)
            {
                toolStrip1.Items[0].Text = "Iniciar simulação";
            }
        }

        private void SendMessage(int ID, string Message)
        {
            statusStrip1.Items[0].Text = "Abelha #" + ID + ": " + Message;

            var beeGroups = from bee in world.Bees
                            group bee by bee.CurrentState into beeGroup
                            orderby beeGroup.Key
                            select beeGroup;

            listBox1.Items.Clear();

            foreach (var group in beeGroups)
            {
                string s;
                if (group.Count() == 1)
                {
                    s = "";
                }
                else
                {
                    s = "s";
                }

                listBox1.Items.Add(group.Key.ToString() + ": " + group.Count() + " abelha" + s);

                if (group.Key == BeeState.Idle
                    && group.Count() == world.Bees.Count()
                    && framesRun > 0)
                {
                    listBox1.Items.Add("Simulação encerrada: todas as abelhas estão ociosas");
                    toolStrip1.Items[0].Text = "Simulação encerrada";
                    statusStrip1.Items[0].Text = "Simulação encerrada";
                    timer1.Enabled = false;
                }
            }
        }
    }
}
