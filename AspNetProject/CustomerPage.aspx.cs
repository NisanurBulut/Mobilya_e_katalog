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
namespace AspNetProject
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        myClass metotlar = new myClass();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Session["username"]==null)
           {
               Response.Redirect("LoginPage.aspx");
           }
        }

        protected void Button_kaydet_Click(object sender, EventArgs e)
        {
            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
                

                if (myconnection.State == ConnectionState.Closed)
                {
                    SqlCommand mycommandara = new SqlCommand();
                 
                    myconnection.Open();
                    mycommandara.CommandType = CommandType.StoredProcedure;
                    mycommandara.Connection = myconnection;
                    mycommandara.CommandText = "sp_controlCustomer";

                    mycommandara.Parameters.AddWithValue("@GSM1", TextBox_CustomerGSM1.Text.ToString());
                    mycommandara.Parameters.AddWithValue("@GSM2", TextBox_CustomerGSM2.Text.ToString());
                    SqlDataReader myreader = mycommandara.ExecuteReader();
                 
              //müşteri kayda varsa uyarı vericek
                    if(myreader.Read())
                    {
                        Response.Write("<script lang='JavaScript'>alert('Bu müşteri Kaydı mevcuttur');</script>");
                        myreader.Dispose();
                        myreader.Close();
                        myconnection.Close();

                        TextBox_CustomerAddress.Text = "";
                        TextBox_CustomerGSM1.Text = "";
                        TextBox_CustomerGSM2.Text = "";
                        TextBox_CustomerName.Text = "";
                        TextBox_CustomerSurname.Text = "";
                        ButtonKaydet.Visible = false;
                    }
                  
                    else
                    {
                        myreader.Close();
                         SqlCommand mycommand = new SqlCommand();
               
                    mycommand.CommandType=CommandType.StoredProcedure;
                    mycommand.Connection=myconnection;
                    mycommand.CommandText="sp_insertCustomer";


                    mycommand.Parameters.AddWithValue("@CN",TextBox_CustomerName.Text.ToString());
                    mycommand.Parameters.AddWithValue("@CS",TextBox_CustomerSurname.Text.ToString());
                    mycommand.Parameters.AddWithValue("@CA",TextBox_CustomerAddress.Text.ToString());
                    mycommand.Parameters.AddWithValue("@GSM1",TextBox_CustomerGSM1.Text.ToString());
                    mycommand.Parameters.AddWithValue("@GSM2",TextBox_CustomerGSM2.Text.ToString());
                    mycommand.ExecuteNonQuery();
                    TextBox_CustomerAddress.Text = "";
                    TextBox_CustomerGSM1.Text = "";
                    TextBox_CustomerGSM2.Text = "";
                    TextBox_CustomerName.Text = "";
                    TextBox_CustomerSurname.Text = "";
                   
                    Response.Redirect("Odeme.aspx");

                    }
                   
                 

                }
                myconnection.Close();
               

              

            
           

        }

  
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AspNetProject"].ToString());
            myconnection.Open();
            SqlCommand updatecommand = new SqlCommand();
            updatecommand.CommandType = CommandType.StoredProcedure;
            updatecommand.CommandText = "sp_updateCustomer";
            updatecommand.Connection = myconnection;
            updatecommand.Parameters.AddWithValue("@CN", TextBox_CustomerName.Text);
            updatecommand.Parameters.AddWithValue("@CS", TextBox_CustomerSurname.Text);
            updatecommand.Parameters.AddWithValue("@CA", TextBox_CustomerAddress.Text);
            updatecommand.Parameters.AddWithValue("@GSM1", TextBox_CustomerGSM1.Text);
            updatecommand.Parameters.AddWithValue("@GSM2", TextBox_CustomerGSM2.Text);
            updatecommand.ExecuteNonQuery();

            myconnection.Close();

            TextBox_CustomerAddress.Text = "";
            TextBox_CustomerGSM1.Text = "";
            TextBox_CustomerGSM2.Text = "";
            TextBox_CustomerName.Text = "";
            TextBox_CustomerSurname.Text = "";

            Response.Redirect("Odeme.aspx");

           
        }
    }}
