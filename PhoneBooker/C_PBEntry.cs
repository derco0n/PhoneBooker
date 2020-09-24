using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBooker
{
    public class C_PBEntry
    {
        private string _number;
        private string _name;
        private bool _international;
        private int _index;

        #region properties
        public string number
        {
            get
            {
                return this._number;
            }
        }

        public string name
        {
            get
            {
                return this._name;
            }
        }

        public int index
        {
            get
            {
                return this._index;
            }
        }

        public string shortnumber
        {
            get; set;
        }
        #endregion

        public C_PBEntry(string number, string name, bool international, int index = -1)
        {
            this._number = number;
            this._name = name;
            this._international = international;
            this._index = index;
        }

        public C_PBEntry(string entry)
        {
            this.parseentry(entry);
        }

        private void parseentry(string entry)
        {
            string[] values = entry.Split(',');
            if (values.Count() > 4)
            {
                //More than for field could indicate that, Name-entry contains ','-chars
            }
            if (values.Count() == 4) 
            {
                try
                {
                    int preindex = values[0].IndexOf("+CPBR:");
                    string nindex = values[0].Substring(preindex+6);
                    this._index = int.Parse(nindex);
                }
                catch
                {
                    this._index = -1;
                }
                char[] trimchars = { '"', '\r', ' ' };

                this._number = values[1].TrimEnd(trimchars).TrimStart(trimchars);
                switch (values[2])
                {
                    case "129":
                        this._international = false;
                        break;

                    case "161":
                        this._international = false;
                        break;

                    case "145":
                        this._international = true;
                        break;

                    default:
                        this._international = false;
                        break;
                }
               
                this._name = values[3].TrimEnd(trimchars).TrimStart(trimchars);
            }
        }

        public int numbertype()
        {
            if (this._international)
            {
                return 145; //International number
            }
            else
            {
                return 129; //National number
            }
        }

        public override string ToString()
        {
            string myreturn = "";
            if (this._index >= 0)
            {
                myreturn = myreturn + this._index.ToString();
            }

            myreturn = myreturn + ",\"" + this._number + "\"," + this.numbertype() + ",\"" + this._name + "\""; //Should craft something like: ,”6187759088",129,”Adam”

            return myreturn;
        }
    }
}
