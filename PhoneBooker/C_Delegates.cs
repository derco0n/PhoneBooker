using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBooker
{
    class C_Delegates
    {
    }

    #region delegates
    public delegate void SerialConnectionEventHandler(object sender, SerialConnectionEventArgs e);
    public delegate void SerialDataRecvEventHandler(object sender, SerialDataRecvEventArgs e);
    #endregion

    
}
