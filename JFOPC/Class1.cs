using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPC.Data;
using OPC.Data.Interface;

namespace JFOPC
{
    public class OPC
    {
        public string IPConnection { get; set; }
        public string ServerProgID { get; set; }

        public string Read()
        {
            string s="";
            return s;
        }
    }
}
