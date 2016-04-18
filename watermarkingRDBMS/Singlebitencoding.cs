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
    public class Singlebitencoding
    { 
        //VARIABLE DECLARATIONS
        string dirname = Application.ExecutablePath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
        int[] Delta_Max ={ 1, 2, 5, 3, 4 };
        int[] Delta_Min ={ 5, 1, 3, 4, 2};
        byte[] watermark ={1,0,1};
        watermarkserialization waterserial = new watermarkserialization();
        int i,l,index;
        int x, Add,pvalue;
        string recieve;
        string[] Spliting;
        Hashtable boolHash = new Hashtable();
        string Max, Min;
        Hashtable[] watermark_partition;
        
        //TO ENCODE THE SELECTED TABLE

        public void Encode(Hashtable[] HT, ArrayList PatitionCount, ArrayList TableColumn)
        {
            BufferdTranfer objBuffer = new BufferdTranfer();
            watermark_partition = new Hashtable[HT.Length];

            for (int x = 0; x < HT.Length; x++)
              {
              watermark_partition[x] = new Hashtable();
              }



              for (int k = 0; k < HT.Length; k++)
              {


                           pvalue = HT[k].Count;
                           l = watermark.Length;
                           i = k % l;


                           if (watermark[i] == 1)
                                {
                                    for (int j = 0; j < HT[k].Count; j++)
                                        {
                                            index = j % Delta_Max.Length;
                                            recieve = HT[k][j].ToString();
                                            Spliting = recieve.Split('~');
                                            Add = Delta_Max[index] + int.Parse(Spliting[0].ToString());
                                            watermark_partition[k][j] = Add.ToString() + "~" + HT[k][j].ToString() + "~" + k + "~" + j;
                                        }
                                        boolHash.Add(k, "max");

                                }
                            else
                                {
                                    for (int j = 0; j < HT[k].Count; j++)
                                        {
                                            index = j % Delta_Min.Length;
                                            recieve = HT[k][j].ToString();
                                            Spliting = recieve.Split('~');
                                            Add = Delta_Min[index] + int.Parse(Spliting[0].ToString());
                                            watermark_partition[k][j] = Add.ToString() + "~" + HT[k][j].ToString() + "~" + k + "~" + j;
                                        }
                                        boolHash.Add(k, "min");
                                }
                         }
            objBuffer.boolHash = boolHash;
            objBuffer.TotalRecord = Partition.rowscountStatic;
            objBuffer.arryTableName = TableColumn;
            objBuffer.TableName = Partition.TableN;
            objBuffer.SourceName = MainForm.SourceNa;
            MessageBox.Show("Single Bit Encoding Completed", "Server", MessageBoxButtons.OK);
                         waterserial.createtable(watermark_partition,objBuffer);
        }
    }

}
