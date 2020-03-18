using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Gtk;
using Json.Net;

namespace ryuk
{
    public partial class HeartbreakerLogin : Gtk.Window
    {

        public string domainFile = "";
        public string passwordFile = "";
        public string usernameFile = "";

        public string[] domains = { };
        public string[] usernames = { };
        public string[] passwords = { };

        public string currentStorageMethod = "CSV1";

        public HeartbreakerLogin() : base(Gtk.WindowType.Toplevel)
        {

            this.Build();

        }

        public class csvStandard
        {

            [Index(0)]
            public string rowA;

            [Index(2)]
            public string rowB;

            [Index(3)]
            public string rowC;

        }

        public string[] decodeFile(string path, string format)
        {

            path = path.Replace("file:", "");

            List<string> returnValues = new List<string>();

            if (!string.IsNullOrEmpty(path))
            {

                if (File.Exists(path)) { 
             
                    if (format.StartsWith("CSV", StringComparison.Ordinal))
                    {

                        using (var reader = new StreamReader(path))
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {

                            csvStandard records = (ryuk.HeartbreakerLogin.csvStandard)csv.GetRecords<csvStandard>();

                            if (format == "CSV1")
                            {

                                returnValues.Add(records.rowA);

                            }
                            else if (format == "CSV2")
                            {

                                returnValues.Add(records.rowB);

                            }
                            else if (format == "CSV3")
                            {

                                returnValues.Add(records.rowC);

                            }

                        }

                    }
                    else if (format == "N-LINE")
                    {

                        foreach (string item in File.ReadAllLines(path))
                        {

                            returnValues.Add(item);

                        }

                    }
                    else if (format == "JSON")
                    {

                        string text = File.ReadAllText(path);

                        foreach (string item in JsonNet.Deserialize<String[]>(text))
                        {

                            returnValues.Add(item);

                        }

                    }
                }

            }

            return returnValues.ToArray();

        }

        protected void domainFileChanged(object sender, EventArgs e)
        {

            FilePicker picker = new FilePicker(domainsDelegate);
            picker.Show();

        }

        public void domainsDelegate(string message)
        {

            domainFile = message;
            domains = decodeFile(domainFile, currentStorageMethod);
            button6.Label = "File Selected";
            button6.Sensitive = false;

        }

        protected void usernamesFileChanged(object sender, EventArgs e)
        {

            FilePicker picker = new FilePicker(usernamesDelegate);
            picker.Show();

        }

        public void usernamesDelegate(string message)
        {

            usernameFile = message;
            usernames = decodeFile(usernameFile, currentStorageMethod);
            button7.Label = "File Selected";
            button7.Sensitive = false;

        }

        protected void passwordsFileChanged(object sender, EventArgs e)
        {

            FilePicker picker = new FilePicker(passwordsDelegate);
            picker.Show();

        }

        public void passwordsDelegate(string message)
        {

            passwordFile = message;
            passwords = decodeFile(passwordFile, currentStorageMethod);
            button8.Label = "File Selected";
            button8.Sensitive = false;

        }

        void generateNewPrediction()
        {

            // All of these prediction numbers are just random.
            // They are all here so that the user gets a simple 
            // grip on how long their attack will take

            float estimatedTime = 0.01f;
            estimatedTime *= !checkbutton3.Active ? 0.5f : 3f;
            estimatedTime *= !checkbutton4.Active ? 0.1f : 1f;
            estimatedTime *= !checkbutton6.Active ? 1f : 30f;
            estimatedTime *= !checkbutton1.Active ? 1f : 30f;

            if (combobox3.Active == 0)
            {

                estimatedTime *= 1.2f;

            }
            else if (combobox3.Active == 1)
            {

                estimatedTime *= 2.0f;

            }
            else if (combobox3.Active == 2)
            {

                estimatedTime *= 1.8f;

            }

            estimatedTime *= domains.Length;
            estimatedTime *= usernames.Length;
            estimatedTime *= passwords.Length;

            button4.Label = "Start Heartbreaker\nEstimated Time: " + estimatedTime + " Mins";

        }

        protected void fileFormatChanged(object sender, EventArgs e)
        {

            if (combobox1.Active == 0)
            {

                currentStorageMethod = "CSV1";

            }
            else if (combobox1.Active == 1)
            {

                currentStorageMethod = "CSV2";

            }
            else if (combobox1.Active == 2)
            {

                currentStorageMethod = "CSV3";

            }
            else if (combobox1.Active == 2)
            {

                currentStorageMethod = "N-LINE";

            }
            else
            {

                currentStorageMethod = "JSON";

            }


            domains = decodeFile(domainFile, currentStorageMethod);
            usernames = decodeFile(usernameFile, currentStorageMethod);
            passwords = decodeFile(passwordFile, currentStorageMethod);

            generateNewPrediction();

        }

        protected void algorithmChanged(object sender, EventArgs e)
        {

            generateNewPrediction();

        }

        protected void boolSplitChanged(object sender, EventArgs e)
        {

            generateNewPrediction();

        }

        protected void boolNumsChanged(object sender, EventArgs e)
        {

            generateNewPrediction();

        }

        protected void boolSpecialChanged(object sender, EventArgs e)
        {

            generateNewPrediction();

        }

        protected void boolLettersChanged(object sender, EventArgs e)
        {

            generateNewPrediction();

        }

        protected void startHeartbreaker(object sender, EventArgs e)
        {

            for (int i = 0; i < domains.Length; i++)
            {

                for (int x = 0; x < usernames.Length; x++)
                {

                    for (int y = 0; y < passwords.Length; y++)
                    {

                        //new Gtk.MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Close, "Domains: " + domains[i] + " Usernames: " + usernames[x] + " Passwords: " + passwords[y], null).Show();

                    }

                }

            }

        }
    }
}
