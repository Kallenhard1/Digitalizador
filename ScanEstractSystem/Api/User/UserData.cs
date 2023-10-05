using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEstractSystem.Api.User
{
    // Estrutura para preenchimento da Model do Firebase.
    internal class UserData
    {
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
        [FirestoreProperty]
        public int ZipCode { get; set; }
    }
}
