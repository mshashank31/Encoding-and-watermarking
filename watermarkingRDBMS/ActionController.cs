using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace watermarkingRDBMS
{
public class ActionController
{
Partition objpartition;

    //METHOD TO START THE PARTITION PROCESS FOR THE SELECTED TABLE 

    public void startprocess(string tablename)
    {
        objpartition = new Partition();
        objpartition.assignpartition(tablename);
    }

}
}
