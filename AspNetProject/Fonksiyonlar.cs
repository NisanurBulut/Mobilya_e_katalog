using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AspNetProject
{
    class myClass
    {

        SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
        public void open_connection()
        {
            if (myconnection.State == ConnectionState.Closed)
            {
                myconnection.Open();

            }

        }
        
        public string membername(string sqlstr)
        {
            string myname = "";
            open_connection();
            SqlCommand mykomut = new SqlCommand();
            mykomut.Connection = myconnection;
            
            mykomut.CommandType = CommandType.StoredProcedure;
            mykomut.CommandText = "sp_GetUserID";
            mykomut.Parameters.AddWithValue("@txtbox",sqlstr);
            SqlDataAdapter myadaptor = new SqlDataAdapter(mykomut);
            
            SqlDataReader myreader = mykomut.ExecuteReader();
            

            if (myreader.Read())//sadece tek bir kayıt okuncagı ıcın while dongusu kullanılmadı
            {
                myname = myreader["Userid"].ToString();
            }

            else
                myname = null;
            myconnection.Close();
            return myname;

        }
        public string memberpassword(string sqlstr)
        {
            string mypassword = "";
            open_connection();
            SqlCommand mykomut = new SqlCommand();
            mykomut.Connection = myconnection;
            mykomut.CommandType = CommandType.StoredProcedure;
            mykomut.CommandText = "sp_GetPassword";
            mykomut.Parameters.AddWithValue("@txtbox", sqlstr);
            SqlDataAdapter myadaptor = new SqlDataAdapter(mykomut);
            SqlDataReader myreader = mykomut.ExecuteReader();

            if (myreader.Read())//sadece tek bir kayıt okuncagı ıcın while dongusu kullanılmadı
            {
                mypassword = myreader["Userid"].ToString();
            }

            else
                mypassword = null;
            myconnection.Close();
            return mypassword;


        }
      
       
        
        
    }
}