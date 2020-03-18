using System;
using System.Collections.Generic;
using Gtk;

namespace ryuk
{
    public partial class FTPTerminal : Gtk.Window
    {

        List<Button> windowA;
        List<Button> windowB;

        public FTPTerminal(string username, string password, string domain) : base(Gtk.WindowType.Toplevel) {

            this.Build();

            string windowAPath = @"/";
            string windowBPath = @"/Users/William";

            int i = 0;
            foreach (var file in System.IO.Directory.GetFiles(windowAPath))
            {

                Button fileButton = new Button();
                fileButton.Label = file;

                this.vbox9.Add(fileButton);
                Box.BoxChild w4 = ((Box.BoxChild)(this.vbox9[fileButton]));
                w4.Position = i;
                i++;

                System.Diagnostics.Debug.WriteLine(file);
                vbox9.Add(fileButton);

            }

            foreach (var dir in System.IO.Directory.GetDirectories(windowAPath))
            {

                Button fileButton = new Button();
                fileButton.Label = dir;

                this.vbox9.Add(fileButton);
                Box.BoxChild w4 = ((Box.BoxChild)(this.vbox9[fileButton]));
                w4.Position = i;
                i++;

                System.Diagnostics.Debug.WriteLine(dir);
                vbox9.Add(fileButton);

            }

            foreach (var file in System.IO.Directory.GetFiles(windowBPath))
            {

                Button fileButton = new Button(file);
                System.Diagnostics.Debug.WriteLine(file);
                vbox8.Add(fileButton);

            }

            foreach (var dir in System.IO.Directory.GetDirectories(windowBPath))
            {

                Button fileButton = new Button(dir);
                System.Diagnostics.Debug.WriteLine(dir);
                vbox8.Add(fileButton);

            }

        }

    }
}
