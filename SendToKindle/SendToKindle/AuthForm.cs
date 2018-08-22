using System;
using System.Windows.Forms;
using vaultsharp;
using vaultsharp.native;

namespace GUISendToKindle
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (kindleMailTextBox.Text.Length == 0 ||
                mailTextBox.Text.Length == 0 ||
                passwordTextBox.Text.Length == 0)
            {
                return; // missing info, either cancel or exit
            }

            var kindleMail = kindleMailTextBox.Text;
            var mail = mailTextBox.Text; 
            var password = passwordTextBox.Text;

            WindowsCredentialManager.WriteCredentials("SendToKindleMail", kindleMail, mail, (int) CredentialPersistence.LocalMachine);
            WindowsCredentialManager.WriteCredentials("SendToKindleAuthMail", mail, password, (int) CredentialPersistence.LocalMachine);

            // WindowsCredentialManager.WriteCredentials("TestMail", kindleMail, mail, (int) CredentialPersistence.LocalMachine);
            // WindowsCredentialManager.WriteCredentials("TestAuthMail", mail, password, (int) CredentialPersistence.LocalMachine);

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
