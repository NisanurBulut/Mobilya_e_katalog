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
    public partial class Odeme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["ad"] != null)
            {
                DropDownListSevkiyatYontem.DataTextField = Session["ad"].ToString() + " " + Session["soyad"].ToString();
            }
            else if(Session["username"]==null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }
            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
            myconnection.Open();
           
            SqlCommand sqlcommandCustomer = new SqlCommand();
            sqlcommandCustomer.CommandType = CommandType.StoredProcedure;
            sqlcommandCustomer.CommandText = "sp_GetCustomer";

            sqlcommandCustomer.Connection = myconnection;
            SqlDataReader rdr = sqlcommandCustomer.ExecuteReader();


           
            
           while(rdr.Read())
           {
              
               DropDownListCustomer.Items.Add(rdr["Customer_Name"].ToString() + " " + rdr["Customer_Surname"].ToString() + " " + rdr["Customer_GSM1"].ToString());
              

               DropDownListCustomer.DataValueField = "id";

               DropDownListCustomer.DataBind();

           }
           myconnection.Close();

         

            SqlCommand sqlcommandCode = new SqlCommand();
            sqlcommandCode.CommandType = CommandType.StoredProcedure;
            sqlcommandCode.CommandText = "sp_GetVadeCode";
            sqlcommandCode.Connection = myconnection;
            SqlDataAdapter da2 = new SqlDataAdapter(sqlcommandCode);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            DropDownListVadeKodu.DataSource = dt2;
            DropDownListVadeKodu.DataTextField = "Credit_Code";
            DropDownListVadeKodu.DataValueField = "Tid";
            DropDownListVadeKodu.DataBind();


            myconnection.Close();

            myconnection.Open();

            SqlCommand sqlcommandMethod = new SqlCommand();
            sqlcommandCode.CommandType = CommandType.StoredProcedure;
            sqlcommandCode.CommandText = "sp_GetSupplyMethod";
            sqlcommandCode.Connection = myconnection;
            SqlDataAdapter da3 = new SqlDataAdapter(sqlcommandCode);
            DataTable dt3 = new DataTable();
            da2.Fill(dt3);
            DropDownListSevkiyatYontem.DataSource = dt3;
            DropDownListSevkiyatYontem.DataTextField = "Supply_Method";
            DropDownListSevkiyatYontem.DataValueField = "Sid";
            DropDownListSevkiyatYontem.DataBind();


            myconnection.Close();

               
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           DateTime dob = DateTime.Parse(Request.Form[textboxtemin.UniqueID]);//temin tarihini dob'a kaydeder

            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
         
         
            //ad soyada gore müşteri id sini bulup databsede sipariş tablosunda yerine yazalım
            myconnection.Open();
            SqlCommand sqlcommandCid = new SqlCommand();
            sqlcommandCid.CommandType = CommandType.StoredProcedure;
            sqlcommandCid.Connection = myconnection;
            sqlcommandCid.CommandText = "sp_finCustomerCid";
           
                int Cid =(int) sqlcommandCid.ExecuteScalar();
                string drpdwnCode = DropDownListVadeKodu.SelectedItem.ToString();
            //drpdownda seçilen değerin id si alıncak ve verıtabanına kyıt edilicek
                SqlCommand sqlcommandCode = new SqlCommand();
                sqlcommandCode.CommandType = CommandType.StoredProcedure;
                sqlcommandCode.Connection = myconnection;
                sqlcommandCode.CommandText = "sp_findTid";
                sqlcommandCode.Parameters.Add("@Vcode", drpdwnCode);
                int Tid = (int)sqlcommandCode.ExecuteScalar();

                string drpdwnSupplyMethod = DropDownListSevkiyatYontem.SelectedItem.ToString();
                SqlCommand sqlcommandSupply = new SqlCommand();
                sqlcommandSupply.CommandType = CommandType.StoredProcedure;
                sqlcommandSupply.Connection = myconnection;
                sqlcommandSupply.CommandText = "sp_findSid";
                sqlcommandSupply.Parameters.Add("@Smethod", drpdwnSupplyMethod);

                int Sid = (int)sqlcommandSupply.ExecuteScalar();

                SqlCommand sqlcommandAddCustomerPayment = new SqlCommand();
                sqlcommandAddCustomerPayment.CommandType = CommandType.StoredProcedure;
                sqlcommandAddCustomerPayment.Connection = myconnection;
                sqlcommandAddCustomerPayment.CommandText = "sp_insertCustomerPayment";
                sqlcommandAddCustomerPayment.Parameters.Add("@Cid",Cid);
                sqlcommandAddCustomerPayment.Parameters.Add("@Supply_Date",dob);
                sqlcommandAddCustomerPayment.Parameters.Add("@Sid",Sid);
                sqlcommandAddCustomerPayment.Parameters.Add("@Tid",Tid);
                sqlcommandAddCustomerPayment.ExecuteNonQuery();
                
               
                
                myconnection.Close();
                myconnection.Open();
                string a = DropDownListCustomer.SelectedItem.Text;
                string[]dizi=a.Split(' ');
                SqlCommand sorgu = new SqlCommand();
                sorgu.CommandType = CommandType.StoredProcedure;
                sorgu.CommandText = "sp_findid";
                sorgu.Connection = myconnection;
                sorgu.Parameters.AddWithValue("@GSM1", dizi[2]);
                int id=(Int32)sorgu.ExecuteScalar();
                myconnection.Close();
                myconnection.Open();
                SqlCommand sorgu2 = new SqlCommand();
                sorgu2.CommandType = CommandType.StoredProcedure;
                sorgu2.CommandText = "sp_insertBasketid";
                sorgu2.Connection = myconnection;
                sorgu2.Parameters.AddWithValue("@id", id);
                sorgu2.ExecuteNonQuery();
                myconnection.Close();
                Response.Redirect("Categories.aspx");
        }

        protected void textboxmusteriekle_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerPage.aspx");
 }

      
        
    }
}