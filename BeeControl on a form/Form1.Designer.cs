namespace BeeControl_on_a_form
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.beeControl1 = new BeeControl_on_a_form.BeeControl();
            ((System.ComponentModel.ISupportInitialize)(this.beeControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // beeControl1
            // 
            this.beeControl1.BackColor = System.Drawing.Color.Transparent;
            this.beeControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("beeControl1.BackgroundImage")));
            this.beeControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.beeControl1.Location = new System.Drawing.Point(214, 56);
            this.beeControl1.Name = "beeControl1";
            this.beeControl1.Size = new System.Drawing.Size(120, 104);
            this.beeControl1.TabIndex = 0;
            this.beeControl1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.beeControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.beeControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BeeControl beeControl1;
    }
}

