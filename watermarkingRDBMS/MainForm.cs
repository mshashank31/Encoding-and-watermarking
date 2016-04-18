using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Net;

namespace watermarkingRDBMS
{
    public partial class MainForm : Form
    {
        //TO CREATE THE SECRET KEY

        public static int secretkey =5;
        public static string SourceNa;
        //VARIABLE DECLARATIONS
        string dirname = Application.ExecutablePath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
        DataSet dataset;
        ActionController actc;
        public string Query;
        int partitionvalue;
        string tablename;
        int rowscount;
        ArrayList arraylist = new ArrayList();
        DBCON Dbconnection;
        DataTable table;
        public static string Destination;
        DBCON dbconnection1;
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            SourceNa = Dns.GetHostName();
            
            webBrowser1.ShowPageSetupDialog();
            webBrowser1.ShowSaveAsDialog();
            Dbconnection = new DBCON();
        
            //RETRIEVE TABLES THROUGH QUERY
            Query ="select table_name from INFORMATION_SCHEMA.Tables order by Table_type"; //TO READ DATABASES AND SUB-DATABASES
            dataset = new DataSet();
            table = Dbconnection.ExecuteQuery(Query);
            actc = new ActionController();
           // textBox1.Text = "machine16";
            foreach (DataRow drow in table.Rows)
            {
                comboTablename.Items.Add(drow.ItemArray.GetValue(0).ToString());
            }

            }
        
            //TO CLOSE THE FORM
        
           private void button2_Click(object sender, EventArgs e)
           {
               Application.Exit();

           // this.Close();
           }

           //TO SELECT THE DUMPED TABLE IN THE FORM

           private void button1_Click(object sender, EventArgs e)
            {

                //try
                //{
                    DirectoryInfo dir = new DirectoryInfo(dirname + "\\Encrypt\\Data");

                    foreach (FileInfo file in dir.GetFiles())
                    {
                        file.Delete();

                    } 

                    tablename = comboTablename.SelectedItem.ToString();
                    Destination = textBox1.Text;
                    actc.startprocess(tablename);
                //}
                //catch { MessageBox.Show("Select Destination"); }
            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboTablename_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            webBrowser2.Visible = false;
            dataGridView1.Visible = true;
            dbconnection1 = new DBCON();
            Query = "select * from " + comboTablename.SelectedItem.ToString() + "";
            table = dbconnection1.ExecuteQuery(Query);
            dataGridView1.DataSource = table.DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
           // webBrowser2.Visible = false;
            dataGridView1.Visible = false;
            webBrowser1.Navigate(new Uri(dirname + "\\Encrypt\\Data\\Partition.txt"));
        }

        private void toolStripSplitButton4_ButtonClick(object sender, EventArgs e)
        {
            //webBrowser2.Visible = false;
            dataGridView1.Visible = false;
            webBrowser1.Navigate(new Uri(dirname + "\\Encrypt\\Data\\EncryptWithkey.txt"));

        }

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {
            //webBrowser2.Visible = false;
            dataGridView1.Visible = false;
            webBrowser1.Navigate(new Uri(dirname + "\\Encrypt\\Data\\Data1.txt"));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void DeleteExistFolder()
        {
      
        DirectoryInfo dir =new DirectoryInfo(dirname + "\\Encrypt\\Data");

        foreach (FileInfo file in dir.GetFiles())
        {
            file.Delete();
        
        }
        }

      
        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboTablename_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
     
             
        }
   
      }