using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace watermarkingRDBMS
{
    public partial class Homelogin : Form
    {
        public Homelogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = DBCON.getconnectrion();
            //SqlCommand cmd = new SqlCommand("select * from login1 where uname=@uname and pwd=@pwd", con);
            //con.Open();
            //{
            //    cmd.Parameters.Add(new SqlParameter("@uname",textBox1.Text));
            //    cmd.Parameters.Add(new SqlParameter("@pwd",textBox2.Text));
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new System.Data.DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            if(textBox1.Text=="Admin" && textBox2.Text=="Admin")
            {
                    this.Hide();
                    MainForm mf = new MainForm();
                    mf.ShowDialog();
            }

                //}
                else 
                {
                    MessageBox.Show("Invalid username and password pls try again");
                }
            }

        private void Homelogin_Load(object sender, EventArgs e)
        {

        }
    }
    }

