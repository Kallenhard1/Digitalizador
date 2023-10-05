using Google.Cloud.Firestore;
using ScanEstractSystem.Api.Helper;
using ScanEstractSystem.Api.User;
using System;
using System.Drawing;
using System.IO;
using SautinSoft.Document;
using System;
using Tesseract;
using WIA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ScanEstractSystem
{
    public partial class Form1 : Form
    {
        FirestoreDb database;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("scanextractfirebase");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        // Tive bastante dificuldade com o funcionamento da autenticação na Firebase, tanto Login, quanto Register.
        // O Metodo abaixo implementa o Login de usario, usando a classe UserData como interface de dados para preenchimento na Firestore
        private void Login_Click(object sender, EventArgs e)
        {
            string email = Email.Text.Trim();
            string password = Senha.Text.Trim();

            var db = FirestoreHelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(email);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

            if (data != null)
            {
                if (password == Security.Decrypt(data.Password))
                {
                    MessageBox.Show("Sucesso!");
                }
                else
                {
                    MessageBox.Show("Falha de Login.");
                }
            }
            else
            {
                MessageBox.Show("Falha de Login.");
            }
        }

        private void Email_Click(object sender, EventArgs e)
        {

        }

        // O metodo abaixo implementa o Registro de um novo usuario no Banco de dados da Firebase
        private void Register_Click(object sender, EventArgs e)
        {
            if (!CheckIfUserAlreadyExist())
            {
                MessageBox.Show("User Already Exist");
                return;
            }

            var db = FirestoreHelper.database;
            var data = GetWriteData();
            DocumentReference docRef = db.Collection("UserData").Document(data.Email);
            docRef.SetAsync(data);
            MessageBox.Show("Succes!");
        }

        private UserData GetWriteData()
        {
            string email = Email.Text.Trim();
            string password = Security.Encrypt(Senha.Text);
            int zip = Convert.ToInt32(password);

            // Retorna uma instancia da classe UserData para criar um novo usuario.
            return new UserData()
            {
                Email = email,
                Password = password,
                ZipCode = zip
            };
        }

        // Este metodo verifica se ja existe um usuario com um Email já cadastrado.
        private bool CheckIfUserAlreadyExist()
        {
            string email = Email.Text.Trim();

            var db = FirestoreHelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(email);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

            if (data != null)
            {
                return true;
            }
            return false;
        }

        private void DigitalizarForm_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form f = new Digitalize();
            f.Show();
        }
    }
}
