using System;
using System.Collections.Generic;
using Gtk;
using ryuk;

namespace ryuk
{
    class MainClass
    {

        public static Gtk.Window[] windows;
        // 0 - Intro Window
        // 1 - SSH Window

        public static void Main(string[] args)
        {

            windows = new Window[2];
            Application.Init();
            windows[0] = new MainWindow();
            windows[0].Show();
            Application.Run();

        }
    }
}
