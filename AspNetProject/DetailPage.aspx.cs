using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace AspNetProject
{
    public partial class DetailPage : System.Web.UI.Page
    {
        double a = 0;
        int b;
      int adet;
       

        myClass metotlar = new myClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            int id;
            string s;
            

            
       

                s = Request.QueryString["CID"];
                id = Convert.ToInt32(s);
                SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
                myconnection.Open();
                SqlCommand mycommand = new SqlCommand();
                mycommand.Connection = myconnection;
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandText = "sp_GetCID";
                mycommand.Parameters.AddWithValue("@CID", id);
                SqlDataReader myreader = mycommand.ExecuteReader();

               
                
                yourDataList.DataSource = myreader;
                yourDataList.DataBind();
                myconnection.Close();

                myconnection.Open();
                SqlCommand yourcommand = new SqlCommand();
                yourcommand.Connection = myconnection;
                yourcommand.CommandType = CommandType.StoredProcedure;
                yourcommand.CommandText = "sp_GetCID";
                yourcommand.Parameters.AddWithValue("@CID", id);


                SqlDataReader yourreader = yourcommand.ExecuteReader();
                datalist.DataSource = yourreader;
                datalist.DataBind();
                myconnection.Close();





                myconnection.Open();
                SqlCommand command = new SqlCommand();
              command.Connection = myconnection;
                command.CommandType = CommandType.StoredProcedure;
               command.CommandText = "sp_GetCID";
             command.Parameters.AddWithValue("@CID", id);




                SqlDataReader rd =command.ExecuteReader();
                HeaderDataList.DataSource = rd;

                HeaderDataList.DataBind();
                myconnection.Close();
            
                myconnection.Open();
                SqlCommand sorgu = new SqlCommand();
                sorgu.CommandType = CommandType.StoredProcedure;
                sorgu.CommandText = "sp_Opsiongrubucek";
                sorgu.Connection = myconnection;
                SqlDataAdapter da = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Opsiyongrubu.DataSource = dt;
                Opsiyongrubu.DataTextField = "Opsion_group";
                Opsiyongrubu.DataValueField = "OID";
                Opsiyongrubu.DataBind();
                myconnection.Close();
                myconnection.Open();
                SqlCommand sorgu1 = new SqlCommand();
                sorgu1.CommandType = CommandType.StoredProcedure;
                sorgu1.CommandText = "sp_OpsiyonsecenekCek";
                sorgu1.Connection = myconnection;
                SqlDataAdapter da1 = new SqlDataAdapter(sorgu1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                Opsiyonsecenek.DataSource = dt1;
                Opsiyonsecenek.DataTextField = "SelectOpsion";
                Opsiyonsecenek.DataValueField = "SCO";
                Opsiyonsecenek.DataBind();
                
                myconnection.Close();
                myconnection.Open();
                SqlCommand sorgu2 = new SqlCommand();
                sorgu2.CommandType = CommandType.StoredProcedure;
                sorgu2.CommandText = "sp_OpsiyonRenkCek";
                sorgu2.Connection = myconnection;
                SqlDataAdapter da2 = new SqlDataAdapter(sorgu2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                Opsiyonrenk.DataSource = dt2;
                Opsiyonrenk.DataTextField = "ColorName";
                Opsiyonrenk.DataValueField = "SC";
                Opsiyonrenk.DataBind();
                myconnection.Close();

                myconnection.Open();
                SqlCommand sorgu3 = new SqlCommand();
                sorgu3.CommandType = CommandType.StoredProcedure;
                sorgu3.CommandText = "sp_FiyatCek";
                sorgu3.Connection = myconnection;
                sorgu3.Parameters.AddWithValue("@CID", id);
                sorgu3.Parameters.AddWithValue("@OID", 1);
                SqlDataReader rd3 = sorgu3.ExecuteReader();
                if(rd3.Read())
                {
                    a = Convert.ToDouble(rd3["fiyat"]);
                }
                Fiyat.Text = a.ToString();
            
                
        }

        
        protected void yourDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void SepeteAt_Click(object sender, EventArgs e)
        {
            int o = Convert.ToInt32(Opsiyongrubu.SelectedItem.Value);
            int s = Convert.ToInt32(Opsiyonsecenek.SelectedItem.Value);
            int c = Convert.ToInt32(Opsiyonrenk.SelectedItem.Value);
            string id = Request.QueryString["CID"].ToString();
            int cid = Convert.ToInt32(id);
            int amount = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
            myconnection.Open();
            SqlCommand sorgu = new SqlCommand();
            sorgu.CommandType = CommandType.StoredProcedure;

            sorgu.CommandText = "sp_SepeteAt";
            sorgu.Connection = myconnection;
            sorgu.Parameters.AddWithValue("@o", o);
            sorgu.Parameters.AddWithValue("@s", s);
            sorgu.Parameters.AddWithValue("@c", c);
            sorgu.Parameters.AddWithValue("@CID", cid);
            sorgu.Parameters.AddWithValue("@amount", amount);
            sorgu.ExecuteNonQuery();
            myconnection.Close();

            Response.Redirect("Sepet.aspx");
        }

        

        

        protected void Hesap_Click(object sender, EventArgs e)
        {
            int adet = int.Parse(DropDownList1.SelectedItem.Value);
            int price = int.Parse(Fiyat.Text);
            Fiyat.Text = (adet * price).ToString();
        }

        

        
       
    }
}
