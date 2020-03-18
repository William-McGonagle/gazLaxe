using System;
using Gtk;

namespace ryuk
{
    public partial class KashmirEditor : Gtk.Window
    {

        public KashmirEditor() : base(Gtk.WindowType.Toplevel)
        {
            this.Build();

        }

        protected void encryptCesar(object sender, EventArgs e)
        {

            statusbar3.Push(0, "Encrypted Selected Text Using Cesar");

        }

        protected void decryptCesar(object sender, EventArgs e)
        {

            TextIter A;
            TextIter B;

            if (textview1.Buffer.GetSelectionBounds(out A, out B))
            {

                string currentText = textview1.Buffer.GetText(A, B, true);
                currentText = currentText.ToUpper();
                statusbar3.Push(0, currentText);

            }

        }
    }
}
