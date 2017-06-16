using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetProject
{
    public partial class Anasayfa : System.Web.UI.Page
    {
        myClass metotlar = new myClass();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginbutton_Click(object sender, EventArgs e)
        {


            string UserId = textboxUsername.Text;
            string UserPassword = textboxPassword.Text;

               if ((textboxUsername.Text == null && textboxPassword.Text == null) ||( textboxUsername.Text == "" && textboxPassword.Text == ""))
            {
                LabelAlert.Visible = true;
                LabelAlert.Text = "KUllanıcı Adı ve Parola Girişi Boş Bırakılamaz";
            }

               else  if(textboxUsername.Text==null || textboxUsername.Text=="" )
            {
                LabelAlert.Visible = true;
                LabelAlert.Text = "Kullanıcı adı giriniz";
            }
            else if (textboxUsername.Text == null || textboxPassword.Text=="")
            {
                LabelAlert.Visible = true;
                LabelAlert.Text = "Şifre  giriniz";
            }
               else  if (metotlar.membername(UserId) == metotlar.memberpassword(UserPassword) && metotlar.membername(UserId) != null && metotlar.memberpassword(UserPassword) != null)//hem şifre hem uye adı başarılı ıse catalog sayfası acılcak
               {
                   Session["username"] = UserId;
                   Response.Redirect("Categories.aspx");
               }
           
            else
            {
                LabelAlert.Visible = true;
                LabelAlert.Text = "Kullanıcı adı veya paralo girişi yanlış";

                
            }
        }
    }
}