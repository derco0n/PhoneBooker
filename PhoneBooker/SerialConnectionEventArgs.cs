using System;
namespace PhoneBooker
{
    public class SerialConnectionEventArgs : EventArgs
    {

        private bool _connect;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connect">If True, Serialconnection has been established. Otherwise False</param>
        public SerialConnectionEventArgs(bool connect)
        {
            this._connect = connect;
        }


        /// <summary>
        /// If True, Serialconnection has been established. Otherwise False
        /// </summary>
        public bool connected 
        {
            get
            {
                return this._connect;
            }
        }
    }
}