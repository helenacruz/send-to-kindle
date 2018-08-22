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
            string kindleMail;
            string mail;
            string password;

            // check if there are credentials. if so, no need to request for them again
            try
            {
                var cred = WindowsCredentialManager.ReadCredential("SendToKindleMail");
                // var cred = WindowsCredentialManager.ReadCredential("TestMail");
                kindleMail = cred.UserName;

                cred = WindowsCredentialManager.ReadCredential("SendToKindleAuthMail");
                // cred = WindowsCredentialManager.ReadCredential("TestAuthMail");
                mail = cred.UserName;
                password = cred.GetSecret(data => Encoding.Unicode.GetString(data));

                Console.WriteLine("Credentials found. Using " + kindleMail + " and " + mail + " to send.");

                if (args.Length == 0)
                {
                    Console.WriteLine("Missing argument.");
                    // Console.ReadKey();
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
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Credentials do not exist. Requesting them...");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AuthForm());

                try
                {
                    var cred = WindowsCredentialManager.ReadCredential("SendToKindleMail");
                    // var cred = WindowsCredentialManager.ReadCredential("TestMail");

                    kindleMail = cred.UserName;

                    cred = WindowsCredentialManager.ReadCredential("SendToKindleAuthMail");
                    // cred = WindowsCredentialManager.ReadCredential("TestAuthMail");
                    mail = cred.UserName;
                    password = cred.GetSecret(data => Encoding.Unicode.GetString(data));

                    Console.WriteLine("Credentials found. Using " + kindleMail + " and " + mail + " to send.");
                    Console.WriteLine("Password: " + password + "len: " + password.Length);

                    if (args.Length == 0)
                    {
                        Console.WriteLine("Missing argument.");
                        // Console.ReadKey();
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
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Missing credentials.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                
            }

            // Console.ReadKey();
        }
    }
}
