using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Configuration;
namespace AspNetProject
{
    public partial class Sepet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
            myconnection.Open();
            SqlCommand sorgu = new SqlCommand();
            sorgu.CommandType = CommandType.StoredProcedure;
            sorgu.CommandText = "sp_SepetCek";
            sorgu.Connection = myconnection;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            mydata.DataSource = dt;
            mydata.DataBind();
            Button addbutton=new Button();
            
        }
        protected void button1_Command(object sender, CommandEventArgs e)
        {
            int BID=Convert.ToInt32(e.CommandArgument);
            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
            myconnection.Open();
            SqlCommand sorgu = new SqlCommand();
            sorgu.CommandType = CommandType.StoredProcedure;
            sorgu.CommandText = "sp_deleteBasket";
            sorgu.Parameters.AddWithValue("@BID", Convert.ToInt32(e.CommandArgument.ToString()));
            sorgu.Connection = myconnection;
            sorgu.ExecuteNonQuery();
            Response.Redirect("Sepet.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categories.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Odeme.aspx");
        }

        



        
        
    }
}