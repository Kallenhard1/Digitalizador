using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEstractSystem.Api.Helper
{
    internal static class FirestoreHelper
    {
        // Seta as configurações de conta do banco de dados da Firestore
        static string fireconfig = @"
        {
          ""type"": ""service_account"",
          ""project_id"": ""scanextractfirebase"",
          ""private_key_id"": ""13bfca58944ab2e23dcfe060031ee13e09b78a42"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDK9cqomp8pcfgs\nhzWWzQo3irAl8jvOx1YDl9XozH7jYJxfMzE9lb+kFo3gwjVX3Lf24eMUiC4LGlBh\nfgdz8FPp5vn5pamwtoUnKFvePVg3VY0/rH4PEvxAFyCnCkTzjtMcsY6kPqiNT2i0\nPYwYqcz/6lVH1EFvRHcint5k883baviYus9o9ugutWa+clNaC2h/5LCUui01LK2A\nKLxSNSoVuZEZYbEJxfWAmOKKtkrnorQ3qAoHgBkDj8814Z3rXingjofa0u4qhafO\nNj9aV97JlbL/WCjPedF8650ezHl8nkZ1FJHYd1vyOougIZ3HiQVFQrRHjnlsaN3z\n7J7LbYtNAgMBAAECggEAKo6rdfsmEJyzOzMGy54m3EqacPqAC/XEVXCLDAuFN8xU\nPaoQUyeJTbDlAxH1+XxwnrXy1aVQckeMP0Ub7vWfwtYJ6I0SLdm3xeQyj0ExtDie\nK5HRxPtoJVA0KpJ+rstt/QBGNq5kzWyvOcwGCk3gjHDofO1G4zvp9zp0y5pLugwu\nhph2bYCZ2BRQDA86KdwsaCrjwzVebYdgMrdSfgu+QIzqiLXHv4Q3QCCvndjRl2wq\nhGd8zpvQcaWkvL0yGW7HGpDq1fcXwMM6/snqNt0Xz/3ymUWKIHja7IRGA2Fc2i6e\nQlCn/KQbXqluF8V2YHEQO+3yX+YHeGpFbey8oxL7CQKBgQDm6GupPplkVJjbsL7+\nHUpU0iQV+3T0Is5SGdTpVZRXmOnnq2XzQkM1f5BJmGWCFlETT6xsj7RdJc78pZ1s\nFkSlSk9dfqs5JtKKD7n2/9u/lpIlV43Zcbp3IPPpsfiYYJa+75lvEm7+zsTrEV/z\nb3O6hAB8buNKEFuqIpvnSPLqkwKBgQDhA+XWu2RFW4sCyz7lvbKwtwrvW+KlGnUN\nYTHcDWPTQ7XI2FlmRfcXs/wx/h5F425H9erTkJkeKbiBvmShe6n+noSDig7vjK3e\nCFBfvKw1m8AuB1E7i3HeE///4pMe2sNgTv4hJbWmmNg8MwkWGJscPQbJMV9ga45E\nZNEY+vD+nwKBgQDdJCi/vOkREogWlq5EFm8yztKqjtmSWqc4L+8dzM02G4egTSFl\nmMdfPB1GroJA1PiuwvZCPlqhfu0+P6qFcsopdwKNaxu2r3yhprAWYzHkyeKLis+a\nOXY4U0HmRYDtBkw47qUGoCPXOtWSv2Aid1Hhhjwk79oT+5ieV2jyV4X1qwKBgDa6\nf/iOc4D7FwCC9rViQkgA/UPikWme2cF7VmkzSIhl+5zyIixh8Atv13NBX5OYEYan\nJYp3rQZNF3dXG5q7PUmUvJ5Rwfg5u0A5vXLLrQcM7t1DIlrdO8DMFIPkU+w5QTP3\ngpAFX/05R768mwUozvE7Vp8wxwXoox23d7QftOX5AoGBALm4CY8rnGclLbTNUT4c\nB7FFL2D6jpTbxCayiG5o1CXfcdT8FaN7aZsGZAT27N2lgeVtRJaBleqmhxSSS8eR\n6j7RZd/cRv5eNVkHesNhG2ARM08t8IA3qzIg03TI7jfcEth17bREDE0THnNVr6+F\npScDvCgBIhF4MeZ5LMkeSgF0\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-lm7f2@scanextractfirebase.iam.gserviceaccount.com"",
          ""client_id"": ""117098899157939481087"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-lm7f2%40scanextractfirebase.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        }";

        static string filepath = "";
        public static FirestoreDb database { get; private set; }

        // A função abaixo serve para colocar algumas variaveis de ambiente e "esconder" arquivos sensiveis da configuração.
        // Sua ultima linha deleta os arquivos sensiveis utilizados.
        public static void SetEnvinonmentVariable() 
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            database = FirestoreDb.Create("scanextractfirebase");
            File.Delete(filepath);
        }
    }
}
