
using System.Collections;
using System.IO.Ports;

namespace PhoneBooker
{
    
    public class SerialDataRecvEventArgs
    {

        ArrayList _message;


        public SerialDataRecvEventArgs(ArrayList message)
        {
            this._message = message;

        }
        
        public ArrayList entries
        {
            get
            {
                return this._message;
            }
        }
    }
}