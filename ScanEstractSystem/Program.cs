using ScanEstractSystem.Api.Helper; 

namespace ScanEstractSystem
{
    internal static class Program
    {
        internal static string Decrypt(string encrypted)
        {
            throw new NotImplementedException();
        }

        internal static string Encrypt(string encryptMe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            FirestoreHelper.SetEnvinonmentVariable();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}