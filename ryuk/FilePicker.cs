using System;
using Gtk;

namespace ryuk
{
    public partial class FilePicker : Gtk.Window
    {

        public string currentFilePath;

        public delegate void Del(string path);

        public Del callback;

        public FilePicker(Del _callback) : base(Gtk.WindowType.Toplevel) {

            this.Build();
            callback = _callback;

        }

        protected void filePicked(object sender, EventArgs e)
        {

            currentFilePath = filechooserwidget4.CurrentFolderUri + filechooserwidget4.Filename;

        }

        protected void chooseFile(object sender, EventArgs e)
        {

            callback(currentFilePath);
            this.Hide();

        }

        protected void cancelSelection(object sender, EventArgs e)
        {

            this.Hide();

        }
    }
}
