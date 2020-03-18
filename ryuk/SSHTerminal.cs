using System;
using Gtk;
using Renci.SshNet;

namespace ryuk
{
    public partial class SSHTerminal : Gtk.Window
    {

        ConnectionInfo ConnNfo;
        SshClient sshclient;

        public SSHTerminal(string username, string password, string domain, bool useTunnel, string privateKey, string passphrase) : base(Gtk.WindowType.Toplevel) {

            this.Build();
            this.textview1.Buffer.Text = "Username: " + username + "\n Password: " + password + "\n Domain: " + domain;

            if (useTunnel) {

                ConnNfo = new ConnectionInfo(domain, 22, username,
            new AuthenticationMethod[]{
                new PasswordAuthenticationMethod(username, password),
                new PrivateKeyAuthenticationMethod(username, new PrivateKeyFile[]{
                    new PrivateKeyFile(privateKey,passphrase)
                })
                }
            );

            } else {

                ConnNfo = new ConnectionInfo(domain, 22, username,
                new AuthenticationMethod[]{
                    new PasswordAuthenticationMethod(username, password)
                    }
                );

            }





            sshclient = new SshClient(ConnNfo);
            sshclient.Connect();

        }

        protected void safeClose(object sender, EventArgs e)
        {

            sshclient.Disconnect();
            Dispose();

        }

        protected void commandEntered(object sender, EventArgs e)
        {

            using (var cmd = sshclient.CreateCommand(entry5.Text))
            {
                cmd.Execute();

                textview1.Buffer.Text += "Command>" + cmd.CommandText + "\n";
                textview1.Buffer.Text += cmd.Result + "\n";

                // Need to scroll to the bottom of the page

            }

        }

        public void ScrollToEnd(object sender, Gtk.SizeAllocatedArgs e)
        {

            textview1.ScrollToIter(textview1.Buffer.EndIter, 0, false, 0, 0);

        }

        protected void commandTextEntered(object sender, EventArgs e)
        {

            //using (var cmd = sshclient.CreateCommand(entry5.Text))
            //{
            //    cmd.Execute();

            //    this.textview1.Buffer.Text += "Command>" + cmd.CommandText + "\n";
            //    this.textview1.Buffer.Text += cmd.ExitStatus + "\n";

            //}

        }
    }
}
