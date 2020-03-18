using System;
using EasyEncrypt.RSA;
using Renci.SshNet;

namespace ryuk
{
    public partial class KUMPResponse : Gtk.Window
    {

        ConnectionInfo ConnNfo;
        SshClient sshclient;

        string footprintPath = "";

        string username;
        string password;
        string domain;

        public KUMPResponse(string _username, string _password, string _domain) : base(Gtk.WindowType.Toplevel) {

            this.Build();
            username = _username;
            password = _password;
            domain = _domain;

        }

        protected void runMethod(object sender, EventArgs e)
        {

            ConnNfo = new ConnectionInfo(domain, 22, username,
            new AuthenticationMethod[]{
                new PasswordAuthenticationMethod(username, password)
                }
            );

            sshclient = new SshClient(ConnNfo);
            sshclient.Connect();

            if (combobox2.Active == 0) { 
                // Change Password

                if (combobox4.Active == 0) {
                    // Windows

                    sshclient.CreateCommand("net user \"" + username + "\" " + password);

                    if (checkbutton5.Active)
                    {

                        sshclient.CreateCommand("history -c");

                    }

                }
                else if (combobox4.Active == 1) {
                    // Mac

                    string reply = string.Empty;
                    ShellStream ss = sshclient.CreateShellStream("dumb", 80, 24, 800, 600, 1024);

                    ss.WriteLine("sudo passwd " + username);

                    reply = ss.Expect("Password:");

                    ss.WriteLine(password);

                    reply = ss.Expect("New password:");

                    if (checkbutton3.Active) {

                        ss.WriteLine(entry5.Text);

                    } else {

                        ss.WriteLine("");

                    }

                    reply = ss.Expect("Retype new password:");

                    if (checkbutton3.Active)
                    {

                        ss.WriteLine(entry5.Text);

                    }
                    else
                    {

                        ss.WriteLine("");

                    }

                    if (checkbutton5.Active) {

                        sshclient.CreateCommand("history -c");

                    }

                } else if (combobox4.Active == 2) {

                    // Linux

                    string reply = string.Empty;
                    ShellStream ss = sshclient.CreateShellStream("dumb", 80, 24, 800, 600, 1024);

                    ss.WriteLine("sudo passwd " + username);

                    reply = ss.Expect("Password:");

                    ss.WriteLine(password);

                    reply = ss.Expect("New password:");

                    if (checkbutton3.Active)
                    {

                        ss.WriteLine(entry5.Text);

                    }
                    else
                    {

                        ss.WriteLine("");

                    }

                    reply = ss.Expect("Retype new password:");

                    if (checkbutton3.Active)
                    {

                        ss.WriteLine(entry5.Text);

                    }
                    else
                    {

                        ss.WriteLine("");

                    }

                    if (checkbutton5.Active)
                    {

                        sshclient.CreateCommand("history -c");

                    }

                } else {

                    throw new System.NotImplementedException();
                
                }

            } else if (combobox2.Active == 1) {
                // New User

                throw new System.NotImplementedException();
            
            } else {

                throw new System.NotImplementedException();
            
            }

            sshclient.Disconnect();

            if (checkbutton1.Active && footprintPath != "") {

                using (var sftp = new SftpClient(ConnNfo))
                {
                    string uploadfn = footprintPath;

                    sftp.Connect();
                    sftp.ChangeDirectory("/");
                    using (var uplfileStream = System.IO.File.OpenRead(uploadfn))
                    {

                        sftp.UploadFile(uplfileStream, uploadfn, true);

                    }
                    sftp.Disconnect();
                }

            }

        }

        protected void selectFootprint(object sender, EventArgs e)
        {

            new FilePicker(footprintSelected).Show();

        }

        public void footprintSelected(string path) {

            button9.Sensitive = false;
            footprintPath = path;

        }

        protected void usernameToggled(object sender, EventArgs e)
        {

            entry7.Sensitive = checkbutton3.Active;
            entry5.Sensitive = checkbutton3.Active;
            label9.Sensitive = checkbutton3.Active;
            label11.Sensitive = checkbutton3.Active;

        }

        protected void footprintToggled(object sender, EventArgs e)
        {

            if (footprintPath == "")
            {

                button9.Sensitive = checkbutton1.Active;

            }

        }
    }
}
