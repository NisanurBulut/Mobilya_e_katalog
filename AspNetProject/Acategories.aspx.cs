using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace AspNetProject
{
    public partial class Acategories : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]==null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            int id;
            string s;
           
           s = Request.QueryString["CID"];
                id = Convert.ToInt32(s);
                SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());


                myconnection.Open();
                SqlCommand yourcommand = new SqlCommand();
                yourcommand.Connection = myconnection;
                yourcommand.CommandType = CommandType.StoredProcedure;
                yourcommand.CommandText = "sp_GetCID";
                yourcommand.Parameters.AddWithValue("@CID", id);


                SqlDataReader yourreader = yourcommand.ExecuteReader();
                yourDataList.DataSource = yourreader;
                yourDataList.DataBind();
                myconnection.Close();


                myconnection.Open();
                SqlCommand mycommand = new SqlCommand();
                mycommand.Connection = myconnection;
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandText = "sp_GetUID";
                mycommand.Parameters.AddWithValue("@UID", id);




                SqlDataReader myreader = mycommand.ExecuteReader();
                myDataList.DataSource = myreader;

                myDataList.DataBind();
                myconnection.Close();
               
              
               
               


                
        }
    }
}