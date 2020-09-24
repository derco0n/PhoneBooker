using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Collections;
using System.Threading;

namespace PhoneBooker
{
  
    public class C_Serial
    {
        private string _portname;
        private int _baudrate, _bits;
        private Parity _parity;
        private StopBits _stopbits;

        private SerialPort _sp = null;

        public event SerialDataRecvEventHandler On_SDReceived;
        public event SerialConnectionEventHandler On_Connected;
        public event SerialConnectionEventHandler On_Disconnected;

        #region properties
        public bool isopen
        {
            get
            {
                if (this._sp!= null)
                {
                    return this._sp.IsOpen;
                }
                return false;
            }            
        }
        #endregion

        public C_Serial(string portname, int baudrate=9600, int bits=8, Parity parity=Parity.None, StopBits stopbits=StopBits.One)
        {
            this._portname = portname;
            this._baudrate = baudrate;
            this._bits = bits;
            this._parity = parity;
            this._stopbits = stopbits;
        }

        ~C_Serial() 
        {
            if (this._sp!=null && this._sp.IsOpen)
            {
                this._sp.Close();
                if (this.On_Disconnected != null)
                {
                    this.On_Disconnected(this, new SerialConnectionEventArgs(false));
                }
            }
        }

        public void open()
        {
            try
            {
                this._sp = new SerialPort(this._portname, this._baudrate, this._parity, this._bits, this._stopbits);
                this._sp.Handshake = Handshake.None;
                this._sp.DataReceived += this.HandleDataReceived;
                this._sp.WriteTimeout = 500;
                this._sp.Open();
                
                if (this.On_Connected != null)
                {
                    this.On_Connected(this, new SerialConnectionEventArgs(true));
                }

            }
            catch {
                if (this.On_Disconnected != null)
                {
                    this.On_Disconnected(this, new SerialConnectionEventArgs(false));
                }
            }
        }

        public void send(byte[] msg)
        {            
            if (this._sp!=null && this._sp.IsOpen)
            {
                //Command
                this._sp.Write(msg, 0, msg.Length);

                //ENTER / new Line
                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                this._sp.Write(newline, 0, newline.Length);

                //Add WAIT-Command
                byte[] wait = Encoding.ASCII.GetBytes("WAIT=1");
                this._sp.Write(wait, 0, wait.Length);

                this._sp.Write(newline, 0, newline.Length); //Another new line
                Thread.Sleep(500);
            }
        }

        public void send(string msg, Encoding enc)
        {
            byte[] data =  enc.GetBytes(msg);
            this.send(data);
        }

        //Forward data received event
        private void HandleDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.On_SDReceived != null)
            {

                string data = this._sp.ReadExisting();

                string[] lines = data.Split('\n');


                ArrayList dataavail = new ArrayList();

                foreach (string line in lines)
                {
                    if (!line.Contains("OK"))
                    {
                        if (!line.Equals("\r"))
                        {
                            if (!line.Equals(""))
                            {
                                C_PBEntry temp = new C_PBEntry(line);
                                dataavail.Add(temp);
                            }
                        }
                    }
                    
                }

                this.On_SDReceived(sender, new SerialDataRecvEventArgs(dataavail));
            }
        }       


    }
}
