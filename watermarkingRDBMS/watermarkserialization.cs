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
using System.IO;
using Bufferd;

namespace watermarkingRDBMS
{
    public class watermarkserialization
    {
        //VARIABLE DECLARATION

         hash objhash = new hash();
         Encryption objencrypt;
         Hashtable table = new Hashtable();
         Hashtable[] HT;
         Hashtable hash = new Hashtable();
         string filename;
         string dirname = Application.ExecutablePath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
         int count;

        public void createtable(Hashtable[] waterpartition,object Buffer)
         {
          StreamWriter sw = new StreamWriter(dirname + "\\Encrypt\\Data\\Data1.txt", true);
          filename = dirname + "\\Encrypt\\Data\\Data1.txt";
          count = waterpartition.Length;
          objencrypt = new Encryption();
          for (int i = 0; i < count; i++)
          {
            for (int j = 0; j < waterpartition[i].Count; j++)
                {
                    table.Add(i + "," + j, waterpartition[i][j]);

                    sw.WriteLine(waterpartition[i][j].ToString());

                }

          }
        // serialization(filename,Buffer);
          sw.Close();
          objencrypt.encryption(filename, Buffer);
          filename = "";
          sw.Close();


        }
        
       // TO SERIALIZE THE CONTENTS IN HASHTABLE AND THE BUFFER WHICH HAS BE ENCODED

        public void serialization(string filename,object buffer)
        {
            string filename1,str;
            filename1 = dirname + "\\Encrypt\\Data\\Data.txt";

            using (StreamWriter sw = new StreamWriter(filename1, true))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    str = sr.ReadLine();
                    sw.WriteLine(str);
                }
                sw.Close();
            }

            
            objencrypt.encryption(filename1,buffer);
        }
    }
}

