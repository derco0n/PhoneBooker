using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Collections;

namespace PhoneBooker
{
    public partial class PhoneBooker : Form
    {
        private C_Serial _serialconnection;
        public PhoneBooker()
        {
            InitializeComponent();
        }

        private void PhoneBooker_Load(object sender, EventArgs e)
        {
            this.addSerialPorts();            
        }

        private void addSerialPorts()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                this.cboPort.Items.Add(port);
            }
            if (this.cboPort.Items.Count > 0)
            {
                this.cboPort.SelectedIndex = 0;
            }
        }

        private void HandleSerialConnectionChange(object sender, SerialConnectionEventArgs e)
        {   
            this.grpJobs.Enabled = e.connected;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this._serialconnection = new C_Serial((String)this.cboPort.SelectedItem);
            this._serialconnection.On_Connected += this.HandleSerialConnectionChange;
            this._serialconnection.On_Disconnected += this.HandleSerialConnectionChange;
           // this._serialconnection.On_SDReceived += this.HandleSerialDataReceived;
            this._serialconnection.open();
        }

        private void InvokeIfRequired(Control target, Delegate methodToInvoke)
        {
            /* Mit Hilfe von InvokeRequired wird geprüft ob der Aufruf direkt an die UI gehen kann oder
             * ob ein Invokeing hier von Nöten ist
             */
            if (target.InvokeRequired)
            {
                // Das Control muss per Invoke geändert werden, weil der aufruf aus einem Backgroundthread kommt
                target.Invoke(methodToInvoke);
            }
            else
            {
                // Die Änderung an der UI kann direkt aufgerufen werden.
                methodToInvoke.DynamicInvoke();


            }
        }

        private void HandleSerialDataReceived(object sender, SerialDataRecvEventArgs e)
        {

            InvokeIfRequired(this.lstEntries, (MethodInvoker)delegate ()
            {                
                foreach (C_PBEntry entry in e.entries)
                {
                    this.lstEntries.Items.Add(entry);
                }
                
            });

            
        }

        private void uploadContacts()
        {
            char csvseperator = ',';

            //Select file
            OpenFileDialog csvselector = new OpenFileDialog();
            csvselector.Title = ".csv-Datei mit Adressbuchdaten auswählen";
            csvselector.Filter = csvseperator+"-getrennt csv-Dateien (*.csv)|*.csv|Textdateien|*.txt";
            csvselector.InitialDirectory="C:\\";
            csvselector.ShowDialog();
            
            String sourcefile = csvselector.FileName;
            
            if (sourcefile == null || sourcefile.Equals(""))
            {
                return;
            }

            //Open and read file
            ArrayList lines = new ArrayList();            
            using (var reader = new StreamReader(sourcefile))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }

            //fieldindexes
            int index_name = -1;
            int index_number = -1;
            int index_shortnumber = -1;           


            int linecount = 0;
            ArrayList values = new ArrayList();
            foreach (String line in lines)
            {
                string[] seperated = line.Split(csvseperator);

                if (linecount == 0)
                {
                    //find-fields
                    int fieldindex = 0;
                    foreach (String field in seperated)
                    {
                        switch (field)
                        {
                            case "Name":
                                index_name = fieldindex;
                                break;
                            case "Sofortige Umleitung":
                                index_number = fieldindex;
                                break;
                            case "Interne Rufnummern":
                                index_shortnumber = fieldindex;
                                break;
                        }
                        fieldindex++;
                    }
                }
                values.Add(seperated);
                linecount++;
            }

            if (index_number==-1 || index_name ==-1 || index_shortnumber == -1)
            {
                return;
            }

            //Craft a new phonebook
            ArrayList Phonebook = new ArrayList();
            linecount = 0;
            foreach (String[] value in values)
            {
                if (linecount > 0)
                {
                    C_PBEntry temp = new C_PBEntry(value[index_number], value[index_name], true, linecount);
                    temp.shortnumber = value[index_shortnumber];
                    Phonebook.Add(temp);
                }
                linecount++;
            }

            /*
            //Delete existing entries on the device
            for (int i=0; i<500; i++)
            {
                string command = C__ATCommands.deletePB(i);
                this._serialconnection.send(command, Encoding.ASCII);
            }
            */

            this.toolStripProgressBar1.Visible = true;
            this.toolStripProgressBar1.Maximum = Phonebook.Count;
            this.toolStripProgressBar1.Value = 0;

            toolStripStatusLabel1.Visible = true;

            //int counter = 0;

            //Write Entries to the device
            foreach (C_PBEntry entry in Phonebook)
            {
                toolStripStatusLabel1.Text = "Schreibe Datensatz " + entry.index.ToString() + "/" + Phonebook.Count.ToString();
                string command = C__ATCommands.writePB(entry);
                this._serialconnection.send(command, Encoding.ASCII);
                this.toolStripProgressBar1.Value = entry.index;                

            }
            this.toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Visible = false;
        }
        

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (this.rdbWritePB.Checked)
            {
                this._serialconnection.On_SDReceived -= this.HandleSerialDataReceived;
                this.uploadContacts();
                MessageBox.Show("Fertig.");
            }
            else {

                String command = "";

                this._serialconnection.On_SDReceived += this.HandleSerialDataReceived;

                if (this.rdbReadPB.Checked)
                { //Read Phone Book
                    command = C__ATCommands.readPB();
                }

                this.lstEntries.Items.Clear();

                this._serialconnection.send(command, Encoding.ASCII);
            }
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
