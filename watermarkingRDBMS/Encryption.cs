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
using Bufferd;


namespace watermarkingRDBMS
  {
   public class Encryption
     {
        string dirname = Application.ExecutablePath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
        string key = GenerateKey();
        string filename, filename1, Keyname, sOutputFilename, SerializedOutputFile;
        DirectoryInfo dir;
        Hashtable hash = new Hashtable();
      
       
       //TO ENCRYPT THE WATERMARK SERIALIZED FILE WITH KEY VALIDATION CONTROL
        public void encryption(string sInputFilename,object Buffer)
         {
            Key objkey = new Key();
            BufferdTranfer objBuffer = new BufferdTranfer();
            objBuffer = (BufferdTranfer)Buffer;
            sOutputFilename = dirname + "\\Encrypt\\Data\\EncryptWithkey.txt";
            Keyname = dirname + "\\Encrypt\\Data\\key.txt";
            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            //AGAIN SERIALIZING THE WATERMARK SERIALIZED FILE
            SerializedOutputFile = dirname + "\\Encrypt\\Data\\Serialized.txt";
            Stream filestream1 = File.OpenRead(sOutputFilename);
            byte[] filebuffer1 = new byte[filestream1.Length];
            filestream1.Read(filebuffer1, 0, (int)filestream1.Length);
            filestream1.Close();
            MessageBox.Show("WaterMarking Completed", "Server", MessageBoxButtons.OK);

            SerializedOutputFile = dirname + "\\Encrypt\\Data\\Serialized.txt";
            Stream s = File.Open(SerializedOutputFile, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter b = new BinaryFormatter();
            
            objBuffer.buffer = filebuffer1;
            objBuffer.key = key;
            b.Serialize(s, objBuffer);
            s.Close();

            MessageBox.Show("Serialization Completed", "Server", MessageBoxButtons.OK);

            //Stream filestream2 = File.OpenRead(SerializedOutputFile);
            //byte[] filebuffer2 = new byte[filestream2.Length];
            //filestream2.Read(filebuffer2, 0, (int)filestream2.Length);
            //filestream2.Close();
            //TcpClient clientsocket = new TcpClient(MainForm.Destination, 8080);
            //NetworkStream networkstream = clientsocket.GetStream();
            //networkstream.Write(filebuffer2, 0, filebuffer2.GetLength(0));
            //networkstream.Close();
            //MessageBox.Show("Data Transfered to " + MainForm.Destination, "Server", MessageBoxButtons.OK);
           
          }

         //METHOD TO GENERATE THE KEY AT RUNTIME
            static string GenerateKey()
             {
              // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
              DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
              // Use the Automatically generated key for Encryption. 
              return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
             }
           }
         }

