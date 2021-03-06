# Send to Kindle

Send to Kindle is a Windows application for sending .epubs, .mobis and .pdfs to your kindle using its e-mail. It requires [Calibre](https://calibre-ebook.com/) for converting .epubs and uses Windows Credential Manager to save your e-mails and password. StK uses the [Credential Management](https://www.nuget.org/packages/CredentialManagement/) to interact with WCM. Send To Kindle also has a really crappy graphical interface for the authentication. 

## How to use

It receives only one argument, which can be either a folder or a file. 

`sendtokindle.exe file.epub` converts `file.epub` to .mobi and then sends it to your Send To Kindle e-mail.

`sendtokindle.exe file.mobi` sends `file.mobi` to your Send To Kindle e-mail.

For PDFs, you have two options: either send PDFs as PDFs or use Amazon to convert them to .mobi. By sending an e-mail with the subject "convert" to your Send To Kindle e-mail, Amazon converts the PDFs before sending them.

If you don't want to convert your PDF files, comment `mail.AddPDFFile(file);` on the following code snippet and uncomment `//mail.AddFile(file);`.
If you want Amazon to convert your PDF files, leave as is with `mail.AddPDFFile(file);` uncommented and `//mail.AddFile(file);` commented. This code is in the `Kindle.cs` file.

```
    else if (extension == ".pdf")
    {
        Console.WriteLine("Detected .pdf file: " + file);

        // Comment the following line if you don't want your PDFs to be converted to .mobi
        mail.AddPDFFile(file);

        // Uncomment the following line if you want your PDFs to be converted to .mobi
        //mail.AddFile(file);
    }
```

Send with: `sendtokindle.exe file.pdf`.

You can also send all the files inside a folder (and all the files inside the folders inside the folder, and so on):

`sendtokindle.exe folder`

This is the boring way to use this application though, you can just add it to your context menu. The `context.reg` file contains the entries to add Send To Kindle to your context menu of PDFs, .epubs and .mobis, you just need to fix the path (don't forget to escape the backslashes!).

When using for the first time, it will request your e-mails and password. I swear I don't use them for anything else but I recommend the creation of an e-mail just for the purpose. Also, I was feeling lazy when I did this and the password is saved in plain text (I know, it's bad!). Even though I have plans to change this, for now just use a different passowrd and e-mail for this purpose. To authenticate, you'll see the following amazing window:

![alt text](https://github.com/helenacruz/SendToKindle/blob/master/images/auth.png "autho")

That's all that is to it. I really, really wanted an easy way to send books to my Kindle and it might be useful for you. It's not exhaustively tested, of course, so if you find something wrong just let me know and I'll take a look. 

PS: I also have a Python script that does the same thing without the context menu feature [here](https://github.com/helenacruz/awesome-scripts), it's CLI only. Does not use WCM (maybe in the future) but it doesn't make you install VS. 

:cactus::cactus::cactus:
