namespace SendToKindle
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.kindleMailTextBox = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.Label();
            this.kindleMail = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(129, 189);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(92, 32);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(113, 140);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(206, 20);
            this.passwordTextBox.TabIndex = 4;
            // 
            // kindleMailTextBox
            // 
            this.kindleMailTextBox.Location = new System.Drawing.Point(113, 80);
            this.kindleMailTextBox.Name = "kindleMailTextBox";
            this.kindleMailTextBox.Size = new System.Drawing.Size(206, 20);
            this.kindleMailTextBox.TabIndex = 2;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(12, 34);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(262, 17);
            this.description.TabIndex = 3;
            this.description.Text = "Insert your Send To Kindle data, please.";
            // 
            // mail
            // 
            this.mail.AutoSize = true;
            this.mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail.Location = new System.Drawing.Point(13, 116);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(46, 15);
            this.mail.TabIndex = 4;
            this.mail.Text = "E-Mail:";
            // 
            // kindleMail
            // 
            this.kindleMail.AutoSize = true;
            this.kindleMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kindleMail.Location = new System.Drawing.Point(13, 85);
            this.kindleMail.Name = "kindleMail";
            this.kindleMail.Size = new System.Drawing.Size(84, 15);
            this.kindleMail.TabIndex = 5;
            this.kindleMail.Text = "Kindle E-Mail:";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(13, 145);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(64, 15);
            this.password.TabIndex = 6;
            this.password.Text = "Password:";
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(113, 111);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(206, 20);
            this.mailTextBox.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(227, 189);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(92, 32);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AuthForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 233);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.mailTextBox);
            this.Controls.Add(this.password);
            this.Controls.Add(this.kindleMail);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.description);
            this.Controls.Add(this.kindleMailTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.okButton);
            this.Name = "AuthForm";
            this.Text = "Send To Kindle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox kindleMailTextBox;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label kindleMail;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

