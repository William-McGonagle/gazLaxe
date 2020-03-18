using System;
namespace ryuk
{
    public partial class RemoteLogin : Gtk.Window
    {

        public string action;
        public string username;
        public string password;
        public string domain;

        public RemoteLogin(string Action) : base(Gtk.WindowType.Toplevel) {

            this.Build();
            action = Action;
            button3.Label = "Start " + Action;
            Title = Action + " Starter";

        }

        protected void StartClicked(object sender, EventArgs e)
        {
        
            if (action == "SSH") {

                new SSHTerminal(username, password, domain, false, "", "").Show();
            
            } 
            else if (action == "FTP")
            {

                new FTPTerminal(username, password, domain).Show();

            }
            else if (action == "Key Under Mat Protocol")
            {

                new KUMPResponse(username, password, domain).Show();

            }
            else if (action == "RAT")
            {

                //new SSHTerminal(username, password, domain).Show();

            }

            this.Hide();

        }

        protected void PasswordChanged(object sender, EventArgs e)
        {

            password = entry3.Text;
        
        }

        protected void DomainChanged(object sender, EventArgs e)
        {

            domain = comboboxentry5.ActiveText;

        }

        protected void UsernameChanged(object sender, EventArgs e)
        {

            username = comboboxentry7.ActiveText;

        }
    }
}
