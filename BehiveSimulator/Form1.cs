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
using System.Runtime.Serialization.Formatters.Binary;

namespace BehiveSimulator
{
    public partial class Form1 : Form
    {
        private World world;
        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int framesRun = 0;

        HiveForm hiveForm = new HiveForm();
        FieldForm fieldForm = new FieldForm();

        public Form1()
        {
            InitializeComponent();
            world = new World(new BeeMessage(SendMessage));

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateStats(new TimeSpan());

            hiveForm.Show(this);
            fieldForm.Show(this);
            
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

        private void openButton_Click(object sender, EventArgs e)
        {
            World currentWorld = world;
            int currentFramesRun = framesRun;

            bool enabled = timer1.Enabled;
            if (enabled)
            {
                timer1.Stop();
            }

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Arquivos de Simulação (*.bees)|*.bees";
            openDialog.CheckPathExists = true;
            openDialog.CheckFileExists = true;
            openDialog.Title = "Escolha um arquivo de simulação para carregar";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream input = File.OpenRead(openDialog.FileName))
                    {
                        world = (World)bf.Deserialize(input);
                        framesRun = (int)bf.Deserialize(input);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível carregar o arquivo\r\n" + ex.Message,
                        "Erro no Simulador de Colméia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    world = currentWorld;
                    framesRun = currentFramesRun;
                }
            }

            world.Hive.MessageSender = new BeeMessage(SendMessage);
            foreach (Bee bee in world.Bees)
            {
                bee.MessageSender = new BeeMessage(SendMessage);
            }

            if (enabled)
            {
                timer1.Start();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool enabled = timer1.Enabled;
            if (enabled)
            {
                timer1.Stop();
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Arquivo de simulação (*.bees)|*.bees";
            saveDialog.CheckPathExists = true;
            saveDialog.Title = "Escolha um arquivo para salvar a simulação atual";
            if ( saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream output = File.OpenWrite(saveDialog.FileName))
                    {
                        bf.Serialize(output, world);
                        bf.Serialize(output, framesRun);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível salvar a simulação\r\n" + ex.Message, 
                        "Erro no Simulador de Colméia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (enabled)
            {
                timer1.Start();
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            // TODO 
        }
    }
}
