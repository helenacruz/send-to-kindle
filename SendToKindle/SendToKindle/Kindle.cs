using System;
using System.IO;
using System.Net.Mail;
using System.Diagnostics;
using System.Collections.Generic;

namespace SendToKindle
{
    class Mail
    {
        private const int maxAttachments = 25;
        private const int maxSize = 26214400;  // 25MB in bytes

        private string kindleMail;
        private string authorizedMail;
        private string password;

        private MailMessage mail;
        private SmtpClient SmtpServer;

        private List<string> attachments;
        private List<string> pdfAttachments;

        public Mail(string kindle, string auth, string pw)
        {
            try
            {
                kindleMail = kindle;
                authorizedMail = auth;
                password = pw;

                SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(authorizedMail, password);
                SmtpServer.EnableSsl = true;

                attachments = new List<string>();
                pdfAttachments = new List<string>();
                mail = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error authenticating. Exiting now.");
                Environment.Exit(0);
            }
        }

        private void CreateMail(string subject)
        {
            mail = new MailMessage();
            mail.From = new MailAddress(authorizedMail);
            mail.To.Add(kindleMail);
            mail.Subject = subject;
            mail.Body = "Sent with \u2665 to your kindle.";
        }

        private void AddAttachment(string name)
        {
            var attachment = new Attachment(name);
            mail.Attachments.Add(attachment);
        }

        private void SendMail(string subject, List<string> files)
        {
            CreateMail(subject);
            foreach (var file in files)
            {
                AddAttachment(file);
            }
            SmtpServer.Send(mail);
        }

        public void AddFile(string name)
        {
            if (!attachments.Contains(name))
            {
                attachments.Add(name);
            }
        }

        public void AddPDFFile(string name)
        {
            if (!pdfAttachments.Contains(name))
            {
                pdfAttachments.Add(name);
            }
        }

        private void CheckLimits(List<string> files, string subject)
        {
            var toSend = new List<string>();
            var totalSize = 0L;
            var attachs = 0;

            foreach (var file in files)
            {
                var f = new FileInfo(file);
                var fileSize = f.Length;

                if (fileSize > maxSize)
                {
                    Console.WriteLine(file + " is too big to send. Maximum size is 25MB.");
                }
                else if (totalSize + fileSize < maxSize && attachs < maxAttachments)
                {
                    toSend.Add(file);
                    totalSize += fileSize;
                    attachs++;
                }
                else
                {
                    totalSize = fileSize;
                    attachs = 1;
                    SendMail(subject, toSend);
                    toSend.Clear();
                    toSend.Add(file);
                }
            }
            if (toSend.Count != 0)
            {
                SendMail(subject, toSend);
            }
        }

        public void SendFiles()
        {
            if (attachments.Count != 0)
            {
                Console.WriteLine("Sending .mobi files...");
                CheckLimits(attachments, "Send To Kindle");
                Console.WriteLine("Done.");
            }

            if (pdfAttachments.Count != 0)
            {
                Console.WriteLine("Sending .pdf files...");
                CheckLimits(pdfAttachments, "convert");
                Console.WriteLine("Done.");
            }
        }
    }

    class Kindle
    {
        private Mail mail;

        public Kindle(string kindleMail, string email, string password)
        {
            mail = new Mail(kindleMail, email, password);
        }

        public void SendFiles(string file)
        {
            var attr = File.GetAttributes(file);

            try
            {
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    Console.WriteLine("Sending files inside " + file + ".");
                    SendFilesDirectory(file);
                }
                else
                {
                    Console.WriteLine("Sending file: " + file + ".");
                    var process = SendFile(file);
                    if (process != null)
                    {
                        process.WaitForExit();
                    }
                }

                mail.SendFiles();
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid file: " + file + ".");
                Console.WriteLine(e);
                Environment.Exit(0);
            }
        }

        // from https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?redirectedfrom=MSDN
        //      &view=netframework-4.7.2#System_IO_Directory_GetFiles_System_String_
        public void SendFilesDirectory(string dir)
        {
            var processes = new List<Process>();

            // Process the list of files found in the directory.
            var files = Directory.GetFiles(dir);
            foreach (var file in files)
            {
                var process = SendFile(Path.GetFullPath(file));
                if (process != null)
                {
                    processes.Add(process);
                }
            }

            // Recurse into subdirectories of this directory.
            var subDirectories = Directory.GetDirectories(dir);
            foreach (var subDirectory in subDirectories)
            {
                SendFilesDirectory(subDirectory);
            }

            foreach (var process in processes)
            {
                process.WaitForExit();
            }
        }

        public Process SendFile(string file)
        {
            var extension = Path.GetExtension(file);

            if (extension == ".epub")
            {
                Console.WriteLine("Detected .epub file: " + file);
                var mobi = Path.Combine(Path.GetDirectoryName(file),
                           Path.GetFileNameWithoutExtension(file)) + ".mobi";

                if (File.Exists(mobi))
                {
                    mail.AddFile(mobi);
                    Console.WriteLine("A .mobi version of this file already exists, it won't be converted.");
                }
                else
                {
                    try
                    {
                        var process = new Process();
                        var startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c ebook-convert \"" + file + "\" \"" + mobi + "\"";
                        process.StartInfo = startInfo;
                        process.Start();

                        Console.WriteLine("Converting " + file + "...");

                        mail.AddFile(mobi);

                        return process;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            else if (extension == ".mobi")
            {
                Console.WriteLine("Detected .mobi file: " + file);
                mail.AddFile(file);
            }
            else if (extension == ".pdf")
            {
                Console.WriteLine("Detected .pdf file: " + file);

                // Comment the following line if you don't want your PDFs to be converted to .mobi
                mail.AddPDFFile(file);

                // Uncomment the following line if you want your PDFs to be converted to .mobi
                //mail.AddFile(file);
            }
            else
            {
                Console.WriteLine(file + " is neither an .epub, a .mobi or a .pdf file.");
            }

            return null;
        }

    }
}
