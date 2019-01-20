using CredentialManagement;

namespace SendToKindle
{
    class PasswordManager
    {
        public static void SaveCredential(string name, string username, string password)
        {
            using (var credential = new Credential())
            {
                credential.Target = name;
                credential.Password = password;
                credential.Username = username;
                credential.Type = CredentialType.Generic;
                credential.PersistanceType = PersistanceType.LocalComputer;
                credential.Save();
            }
        }

        public static Credential GetCredential(string name)
        {
            var credential = new Credential();
            credential.Target = name;
            credential.Load();

            return credential;
        }
    }
}
