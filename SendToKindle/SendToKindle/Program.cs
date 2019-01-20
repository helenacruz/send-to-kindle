using System;
using System.Text;
using System.Windows.Forms;

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
            var credentialKindle = PasswordManager.GetCredential("SendToKindleMail");
            var credentialAuth = PasswordManager.GetCredential("SendToKindleAuthMail");

            if (credentialKindle.Exists() && credentialAuth.Exists())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Run(string[] args)
        {
            var credential = PasswordManager.GetCredential("SendToKindleMail");
            var kindleMail = credential.Username;

            credential = PasswordManager.GetCredential("SendToKindleAuthMail");
            var mail = credential.Username;
            var password = credential.Password; // unsafe! use a disposable password

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
