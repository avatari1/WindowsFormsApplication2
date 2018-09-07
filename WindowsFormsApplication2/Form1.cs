using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using System.Reflection;

namespace WindowsFormsApplication2
{
    
    public partial class Main_form : Form
    {

        public string sourcepath="";
        public string destfile="";
        public Main_form()
        {


            InitializeComponent();

        }
        public bool startpressed;
        private void choose_btn_Click(object sender, EventArgs e)
        {
            var fod = new FolderBrowserDialog();
            if (fod.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folder_field.Text = fod.SelectedPath;
            }
            else
            {
                MessageBox.Show("A folder has not been selected");
            }
        }

        private static FileSystemWatcher _watcher;

        public void settings_save()
        {
            set_settings_value("f", folder_field.Text);
            set_settings_value("a", alphabox.Text);
            set_settings_value("c", Counterbox.Text);
        }
        protected virtual bool IsFileLocked(FileInfo file)
        { 

            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public void set_settings_value(string flag, string value)
        {
            string settings_file = Directory.GetCurrentDirectory() + "\\" + "settings" + "\\" + "settings.ini";
            List<string> items1 = new List<string>();
            string path1 = settings_file;
            try
            {
                FileInfo fi1 = new FileInfo(path1);

                if (!IsFileLocked(fi1))
                {


                    using (StreamReader reader = File.OpenText(path1))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            items1.Add(line);
                        }

                        switch (flag)
                        {
                            case "f":
                                items1[0] = value;
                                break;
                            case "a":
                                items1[1] = value;
                                break;
                            case "c":
                                items1[2] = value;
                                break;
                            case "d":
                                items1[3] = value;
                                break;
                            default:
                                break;
                        }

                        reader.Dispose();
                    }
                    
                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message);

            }
            string filesaver = "";
            foreach (string item in items1)
            {
                filesaver += item + Environment.NewLine;
            }
            try
            {
                string newdir = Directory.GetCurrentDirectory() + "\\" + "settings";
                FileInfo fi1 = new FileInfo(path1);
                if (!IsFileLocked(fi1))
                {
                    if (!Directory.Exists(newdir))
                    {
                        var di = new DirectoryInfo(Directory.GetCurrentDirectory());
                        di.Attributes &= ~FileAttributes.ReadOnly;
                        Directory.CreateDirectory(newdir);
                    }
                    else
                    {
                        var di = new DirectoryInfo(newdir);
                        di.Attributes &= ~FileAttributes.ReadOnly;
                    }
                    using (FileStream fs = File.OpenWrite(settings_file))
                    {

                        Byte[] info = new UTF8Encoding(true).GetBytes(filesaver);

                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                        fs.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not create settings file" + Environment.NewLine + "original message : " + ex.Message);
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (folder_field.Text != "...")
            {
                start_btn.Enabled = false;
                alpha_btn.Enabled = false;
                Counter_btn.Enabled = false;
                choose_btn.Enabled = false;

                stop_btn.Enabled = true;


                var foldername = folder_field.Text;
                string settings_file = Directory.GetCurrentDirectory()+"\\"+"settings";
                settings_save();

                // Create a new FileSystemWatcher and set its properties.
                _watcher = new FileSystemWatcher
                {

                    Path = folder_field.Text,
                    IncludeSubdirectories = true,
                    InternalBufferSize = 400000,
                    NotifyFilter = NotifyFilters.LastWrite
               //     |NotifyFilters.FileName
                    

                };

                _watcher.Filter = "AMP*.xml";
                // Add event handlers
                _watcher.Changed += new FileSystemEventHandler(OnChanged);
                _watcher.Created += new FileSystemEventHandler(OnCreated);
                _watcher.Renamed += new RenamedEventHandler(OnRenamed);
                // Begin watching
                _watcher.EnableRaisingEvents = true;

            }
            else
            {
                MessageBox.Show("Please select a folder first");
            }
        }
        DateTime lastRead = DateTime.MinValue;
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
         //   MessageBox.Show(" oncreated event");
            string source_file = e.FullPath;
            string destination_file = filename_gen();
            go(source_file, destination_file);
        }
       
        private void OnChanged(object source, FileSystemEventArgs e)
        {
          //  MessageBox.Show(" onchanged event");
            string source_file = e.FullPath;
            string destination_file = filename_gen();
            go(source_file, destination_file);
        }


        private void OnRenamed(object source, FileSystemEventArgs e)
        {
         //   MessageBox.Show(" onrenamed event");
            string source_file = e.FullPath;
            string destination_file = filename_gen();
            go(source_file, destination_file);
        }
        public void go(string _source, string _dest)
        {

            // MessageBox.Show("source : "+ source_file +Environment.NewLine + "Destination : " +destination_file);
            try
            {
                System.IO.File.Move(_source, _dest);
                int x= int.Parse(get_counterbox());
                x++;
                set_counterbox(x.ToString());
          //      MessageBox.Show("x is " + x.ToString() + Environment.NewLine + "str is " + str);
                set_settings_value("d", DateTime.Now.Date.ToString());
            }
            catch (Exception ex)
            {
             MessageBox.Show("there was a problem " + ex.Message);                                       ///to be removed
            }
        }
        private void stop_btn_Click(object sender, EventArgs e)
        {
            start_btn.Enabled = true;
            alpha_btn.Enabled = true;
            Counter_btn.Enabled = true;
            choose_btn.Enabled = true;

            stop_btn.Enabled = false;
            _watcher.EnableRaisingEvents = false;
        }

     
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            
            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to Exit the Application?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    this.Dispose();
                    Environment.Exit(0);
                    break;
            }

            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

                
        public string filename_gen()           // create destination filename
        {

            string chosen_folder = get_folderfield();
            string dest_filename = get_alphabox();
            string cntstr = Counterbox.Text.ToString();
         //   string settings_file = Directory.GetCurrentDirectory() + "\\" + "settings";
         //   string path1 = settings_file;
         //   foo foo1 = new foo();
         //   foo1.settings_load(out chosen_folder, out dest_filename, out cntstr);


            string ys = System.DateTime.Now.Year.ToString();
            string ms = System.DateTime.Now.Month.ToString();
            string ds = System.DateTime.Now.Day.ToString();
            // counter needs to be 3 digits
            string s2 = chosen_folder + "\\" + dest_filename + ys + str_dig(ms,2) + str_dig(ds,2) + str_dig(cntstr,3) + "_pain001.xml";
            return s2;
        }



        public string get_folderfield()
        {
            return folder_field.Text;
        }
        public string get_alphabox()
        {
            return alphabox.Text;
        }
        public string get_counterbox()
        {
            return Counterbox.Text;
        }
        

        public void set_counterbox(string _value)
        {
             // running on worker thread
            this.Invoke((MethodInvoker)delegate {
                Counterbox.Text = _value; // runs on UI thread
            });
            
        }

        private void Counter_btn_Click(object sender, EventArgs e)
        {
            string initial_string = "1";
            if (Counterbox.Enabled == false)
            {
                Counterbox.Enabled = true;
                Counter_btn.Text = "Ok";
                initial_string = Counterbox.Text; // save the previous value temporarilly
            }
            else
            {
 
                // bool result = Int32.TryParse(Counterbox.Text.ToString(), out x);
                bool result = System.Text.RegularExpressions.Regex.IsMatch(Counterbox.Text.ToString(), @"^\d+$");
                if (!result)
                {
                    set_counterbox(initial_string); // if the parsing fails return messsage and the previous value
                    MessageBox.Show("This field only accepts numbers");
                }

                Counterbox.Enabled = false;
                Counter_btn.Text = "Edit";
            }
        }
        public string get_settings_value(string flag)
        {
            string settings_file = Directory.GetCurrentDirectory() + "\\" + "settings" + "\\" + "settings.ini";

            string path1 = settings_file;
            try
            {
                using (StreamReader reader = File.OpenText(path1))
                {
                    string line;
                    List<string> items1 = new List<string>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        items1.Add(line);
                    }

                    switch (flag)
                    {
                        case "f":
                            return items1[0];
                        case "a":
                            return items1[1];
                        case "c":
                            return items1[2];
                        case "d":
                            return items1[3];
                        default:
                            return "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load settings file" + Environment.NewLine + "original message : " + ex.Message);
                return "";
            }
        }
        delegate void SetTextCallback(string text);
        public string str_dig(string _input,Int32 digitsneeded)
        {
            Int32 numofaddzeros = 0;
            numofaddzeros = digitsneeded - _input.Length;
            switch (numofaddzeros)
            {
                case 1:
                    return "0" + _input;
                case 2:
                    return "00" + _input;
                default:
                    return _input;
            }
        }



        private void trayicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void alpha_btn_Click(object sender, EventArgs e)
        {
            if (alphabox.Enabled)
            {
                alpha_btn.Text = "Edit";
                alphabox.Enabled = false;
            }
            else
            {
                alpha_btn.Text = "Save";
                alphabox.Enabled = true;
            }

                      }
    }
}
