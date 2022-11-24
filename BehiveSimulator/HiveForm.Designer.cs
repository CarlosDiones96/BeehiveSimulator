namespace BehiveSimulator
{
    partial class HiveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 311);
            this.DoubleBuffered = true;
            this.Name = "HiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Colméia";
            this.Load += new System.EventHandler(this.HiveForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HiveForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}