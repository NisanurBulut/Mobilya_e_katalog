<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="AspNetProject.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<title>Anasayfa</title>
    <link  rel="stylesheet" type="text/css" href="Css/Anasayfa.css" />
    <link href="Css/hf.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
    <table class="logintable">
        <tr>
            <th colspan="2">Oturum Aç</th>
            
        </tr>
        <tr>
            <td>
                Kullanıcı Adı:
            </td>
            <td>
                <asp:TextBox  CssClass="textbox" ID="textboxUsername" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td style="text-align:center">
                Şifre
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="textboxPassword" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Button CssClass="button" ID="loginbutton" Text="Login" runat="server" OnClick="loginbutton_Click" />
            </td>
        </tr>
        
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Label ID="LabelAlert" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        
    </table>
    </form>
  
    </body>
</html>
