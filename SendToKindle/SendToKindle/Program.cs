using System;
using System.Text;
using System.Windows.Forms;
using vaultsharp;

namespace SendToKindle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (CheckCredentials())
            {
                Run(args);
            }
            else
            {
                Console.WriteLine("Credentials do not exist. Requesting them...");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AuthForm()); // request credentials

                if (CheckCredentials())
                {
                    Run(args);
                }
                else
                {
                    Console.WriteLine("Missing credentials.");
                    Environment.Exit(0);
                }
            }
        }

        static bool CheckCredentials()
        {
            try
            {
                var cred = WindowsCredentialManager.ReadCredential("SendToKindleMail");
                cred = WindowsCredentialManager.ReadCredential("SendToKindleAuthMail");

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void Run(string[] args)
        {
            string kindleMail;
            string mail;
            string password;

            var cred = WindowsCredentialManager.ReadCredential("SendToKindleMail");
            kindleMail = cred.UserName;

            cred = WindowsCredentialManager.ReadCredential("SendToKindleAuthMail");
            mail = cred.UserName;
            password = cred.GetSecret(data => Encoding.Unicode.GetString(data));

            if (args.Length == 0)
            {
                Console.WriteLine("Missing argument.");
                Environment.Exit(0);
            }

            var file = args[0];
            var kindle = new Kindle(kindleMail, mail, password);

            try
            {
                kindle.SendFiles(file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(0);
            }
        }
    }
}
