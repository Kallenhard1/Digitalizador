namespace ScanEstractSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Login = new Button();
            pictureBox1 = new PictureBox();
            Register = new Button();
            Email = new TextBox();
            Senha = new TextBox();
            DigitalizarForm = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Login
            // 
            Login.Location = new Point(341, 277);
            Login.Name = "Login";
            Login.Size = new Size(112, 34);
            Login.TabIndex = 1;
            Login.Text = "Login";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(302, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Register
            // 
            Register.Location = new Point(341, 327);
            Register.Name = "Register";
            Register.Size = new Size(112, 34);
            Register.TabIndex = 4;
            Register.Text = "Register";
            Register.UseVisualStyleBackColor = true;
            Register.Click += Register_Click;
            // 
            // Email
            // 
            Email.Location = new Point(179, 175);
            Email.Name = "Email";
            Email.Size = new Size(450, 31);
            Email.TabIndex = 5;
            Email.Text = "Email";
            // 
            // Senha
            // 
            Senha.Location = new Point(179, 225);
            Senha.Name = "Senha";
            Senha.Size = new Size(450, 31);
            Senha.TabIndex = 6;
            Senha.Text = "Senha";
            Senha.UseSystemPasswordChar = true;
            // 
            // DigitalizarForm
            // 
            DigitalizarForm.Location = new Point(509, 277);
            DigitalizarForm.Name = "DigitalizarForm";
            DigitalizarForm.Size = new Size(120, 84);
            DigitalizarForm.TabIndex = 8;
            DigitalizarForm.Text = "Pular para Digitalização";
            DigitalizarForm.UseVisualStyleBackColor = true;
            DigitalizarForm.Click += DigitalizarForm_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DigitalizarForm);
            Controls.Add(Senha);
            Controls.Add(Email);
            Controls.Add(Register);
            Controls.Add(pictureBox1);
            Controls.Add(Login);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Login;
        private PictureBox pictureBox1;
        private Button Register;
        private TextBox Email;
        private TextBox Senha;
        private Button DigitalizarForm;
    }
}