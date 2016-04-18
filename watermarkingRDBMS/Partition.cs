using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace watermarkingRDBMS
{
    public class Partition
    {
        public static int rowscountStatic;
        public static string TableN;
        //VARIABLE DECLARATIONS
        string dirname = Application.ExecutablePath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
        int pkey, partitionnum;
        Hashtable[] Hashpartition;
        string Query;
        DataTable table;
        DBCON dbconnection1;
        int rowscount, rowscount1;
        int partitionvalue;
        string Name;
        string Age;
        int hash,hash1;
        int a,a1,a2,k;
        int count,partCount;
        ArrayList arryColumnName = new ArrayList();
        Singlebitencoding singlebit = new Singlebitencoding();
        ArrayList PartionArry = new ArrayList();
        StringBuilder strbldr;

        //TO GET ALL DATAS FROM DATABASE
                
        public void assignpartition(string tablename)
        {
         dbconnection1 = new DBCON();
         Query = "select * from " + tablename + "";
         table = dbconnection1.ExecuteQuery(Query);
         TableN = tablename;
         arryColumnName.Clear();
         rowscount = table.Rows.Count;
         rowscountStatic = rowscount;

         using(StreamWriter sw = new StreamWriter(dirname+"\\Txt.txt"))
         {
         foreach (DataRow drow1 in table.Rows)
         {
            
          int j2 = drow1.Table.Columns.Count;
          strbldr = new StringBuilder();
          for (int m = 0; m < j2; m++)
          { 
              strbldr.Append(drow1.ItemArray.GetValue(m).ToString()+" ");
          }
          sw.WriteLine(strbldr);
           
         }

             
         }

         foreach (DataColumn colo in table.Columns)
         {
             arryColumnName.Add(colo+"-"+colo.DataType.Name);
         
         }
        //TO CREATE THE NUMBER OF PARTITION
            
           partitionvalue = rowscount / 3;
            int i = 0;
            Hashpartition = new Hashtable[partitionvalue];
            
            for (i = 0; i < partitionvalue; i++)
            {
               Hashpartition[i] = new Hashtable();
            }
             foreach (DataRow drow in table.Rows)
             {

                 rowscount1 = rowscount1 + 1;
               // pkey = int.Parse(drow.ItemArray.GetValue(0).ToString());

               //TO GET PARTITION NUMBER(PRIMARYKEY,SECRETKEY & NUMBER OF PARTITION)

                 partitionnum = this.getpartitionnum(rowscount1, MainForm.secretkey, partitionvalue);
                   if(!PartionArry.Contains(partitionnum))
                   {
                   PartionArry.Add(partitionnum);
                   }
               // Name = drow.ItemArray.GetValue(1).ToString();
                //Age = drow.ItemArray.GetValue(2).ToString();
                   Hashpartition[partitionnum].Add(Hashpartition[partitionnum].Count, rowscount1+"~"+KeyAdd(drow)+"~"+count);
                   count++;
                }
                partCount =PartionArry.Count;
                ReadWrite(Hashpartition);

                MessageBox.Show("Data Collected", "Server", MessageBoxButtons.OK);
                singlebit.Encode(Hashpartition, PartionArry,arryColumnName); 
             }

         
        //TO ASSIGN PARTITION
        public string KeyAdd(DataRow Drow)
        {
          int j3 = Drow.Table.Columns.Count;
          strbldr = new StringBuilder();
          //Random random = new Random();
          for (int m = 0; m < j3; m++)
          {
              //int num = random.Next();
              //string hexString = num.ToString("X");            
              if (m == j3)
              {
                  strbldr.Append(Drow.ItemArray.GetValue(m).ToString() );
              }
              else 
              {
                  string hex = m.ToString("X");
                  strbldr.Append(Drow.ItemArray.GetValue(m).ToString() + "~"+hex);
              }
          }
          return strbldr.ToString(); 
        }
        public int getpartitionnum(int primarykey, int secretkey, int numofpartition)
        {
            long l;
            string s;
            string s1;
            s = primarykey.ToString() + secretkey.ToString();
            hash = s.GetHashCode();
            s1 =hash.ToString()+secretkey.ToString();
            hash1 = s1.GetHashCode();
            
            a1 = hash1;
            l = a1 % numofpartition;
            a2 = int.Parse(l.ToString());
            return Math.Abs(a2);
        }
        public void ReadWrite(Hashtable[] hashing)
        {

            StreamWriter sw = new StreamWriter(dirname + "\\Encrypt\\Data\\Partition.txt");
            for (int i = 0; i < hashing.Length; i++)
            {
                for (int j = 0; j < hashing[i].Count; j++)
                { 
                    sw.WriteLine(hashing[i][j].ToString());
                }

            
            }
            sw.Close();
        }
    }

}