using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace watermarkingRDBMS
{
   public class DBCON
    {
       
 
       SqlConnection con;
       SqlCommand cmd;
       SqlDataAdapter adp;
       string Sql;
       DataSet ds;
       ArrayList al = new ArrayList();

       //ESTABLISHING SQL CONNECTION TO CONNECT THE DATABASE

       public  DBCON()
       {
           con = new SqlConnection("server=SHASHANK-PC;database=FLGA;Integrated Security=true");
          con.Open(); 
       }


       public static SqlConnection getconnectrion()
       {
           SqlConnection con = new SqlConnection();
           string strcon = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
           con.ConnectionString = strcon;
           return con;
       
       }
       
       //EXECUTE THE CONNECTION QUERY

       public DataTable ExecuteQuery(string Query)
           {
           adp = new SqlDataAdapter(Query, con);
           ds=new DataSet();
          
           adp.Fill(ds, "Temp");
           return ds.Tables["Temp"];
           }
         }
       }
         
    
    


