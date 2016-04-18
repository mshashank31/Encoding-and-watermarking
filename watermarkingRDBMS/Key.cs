using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace watermarkingRDBMS
{
    //[Serializable]

    public class Key
    {
        public string filename;
        public string key;
        public byte[] buffer;

        //public byte[] setfilename(string filename,string key)
        //{
        //    this.filename = filename;
        //    this.key = key;


            
        //}
    }

}
