using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBooker
{
    public static class C__ATCommands
    {
        /// <summary>
        /// Reads a phonebook-entry
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string readPB(int index = -1)
        {
            string myreturn = "AT+CPBR=";
            if (index > 0)
            {
                myreturn = myreturn + index.ToString(); //Read given index
            }
            else {
                myreturn = myreturn + "1,500"; //Read Indexes 1 to 500
            }
            return myreturn;
        }

        /// <summary>
        /// writes a phoneboook-ent´ry
        /// </summary>
        /// <param name=""></param>
        public static string writePB(C_PBEntry entry)
        {
            string myreturn= "AT+CPBW=";
            if (entry.index > 0)
            {
                myreturn = myreturn + entry.index.ToString();
            }
            myreturn= myreturn + ",\"" + entry.number + "\"," + entry.numbertype().ToString() + ",\"" + entry.name + "\"";

            return myreturn;
        }

        public static string deletePB(int index)
        {
            return "AT+CPBW=" + index.ToString();
        }
    }
}
