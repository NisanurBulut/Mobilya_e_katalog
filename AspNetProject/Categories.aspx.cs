using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Configuration;
namespace AspNetProject
{
    public partial class Categories : System.Web.UI.Page
    {
        myClass metotlar = new myClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]==null)
            {
                Response.Redirect("LoginPage.aspx");
            }


            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());

                //string sqlstr = "select * from Product_Category Where UID=1";

                if (myconnection.State == ConnectionState.Closed)
                {
                    myconnection.Open();


                    SqlCommand mycommand = new SqlCommand();
                    mycommand.Connection = myconnection;
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.CommandText = "sp_GetUID";
                    mycommand.Parameters.AddWithValue("@UID",1);
                    SqlDataReader myreader = mycommand.ExecuteReader();


                    myDataList.DataSource = myreader;
                    myDataList.DataBind();
                    if (myconnection.State == ConnectionState.Open)
                    {
                        myconnection.Close();

                    }


                
            }
        }
    }
}