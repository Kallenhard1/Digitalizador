namespace ScanEstractSystem
{
    partial class Digitalize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Digitalize));
            Digitalizar = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            Scanner = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            Abrir = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // Digitalizar
            // 
            Digitalizar.Location = new Point(12, 85);
            Digitalizar.Name = "Digitalizar";
            Digitalizar.Size = new Size(112, 34);
            Digitalizar.TabIndex = 0;
            Digitalizar.Text = "Digitalizar";
            Digitalizar.UseVisualStyleBackColor = true;
            Digitalizar.Click += Digitalizar_Click;
            // 
            // Scanner
            // 
            Scanner.Location = new Point(12, 25);
            Scanner.Name = "Scanner";
            Scanner.Size = new Size(174, 34);
            Scanner.TabIndex = 1;
            Scanner.Text = "Escolha o Scanner";
            Scanner.UseVisualStyleBackColor = true;
            Scanner.Click += Scanner_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(130, 85);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(192, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(130, 152);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(82, 53);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // Abrir
            // 
            Abrir.Location = new Point(12, 149);
            Abrir.Name = "Abrir";
            Abrir.Size = new Size(112, 59);
            Abrir.TabIndex = 5;
            Abrir.Text = "Abrir Arquivo";
            Abrir.UseVisualStyleBackColor = true;
            Abrir.Click += Abrir_Click;
            // 
            // Digitalize
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Abrir);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Scanner);
            Controls.Add(Digitalizar);
            Name = "Digitalize";
            Text = "Digitalize";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Digitalizar;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button Scanner;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button Abrir;
    }
}