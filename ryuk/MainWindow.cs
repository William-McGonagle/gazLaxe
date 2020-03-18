using System;
using Gtk;
using ryuk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        MainClass.windows[0].Hide();
        a.RetVal = true;
    }

    protected void openSSH(object sender, EventArgs args)
    {

        new RemoteLogin("SSH").Show();

    }

    protected void openRAT(object sender, EventArgs args)
    {

        new RemoteLogin("RAT").Show();

    }

    protected void openFTP(object sender, EventArgs args)
    {

        new RemoteLogin("FTP").Show();

    }

    protected void openBuzzer(object sender, EventArgs e)
    {

        //new RemoteLogin("Buzzer").Show();

    }

    //Key Under Mat Protocol
    protected void openKUMP(object sender, EventArgs e)
    {

        new RemoteLogin("Key Under Mat Protocol").Show();

    }

    protected void openHeartbreaker(object sender, EventArgs e)
    {

        new HeartbreakerLogin().Show();

    }

    protected void openKasmir(object sender, EventArgs e)
    {

        new KashmirEditor().Show();

    }
}
