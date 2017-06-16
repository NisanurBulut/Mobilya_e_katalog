<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="AspNetProject.CustomerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Page</title>
    <link href="Css/CustomerPage.css" rel="stylesheet" />
 
</head>
<body>
   
     <form id="form1" runat="server">

       

   <table  style="padding-left:30%; padding-top:10%" >
        <tr>
            <th colspan="5"  style="text-align:center" >MÜŞTERİ EKLEME
              
            </th>
        </tr>
       <tr>
           <td>

               <b>Müşteri Adı</b></td>
          
           <td class="auto-style1">

               <asp:TextBox ID="TextBox_CustomerName" runat="server" CssClass="textbox"></asp:TextBox>

           </td>
          
       </tr>
       
       <tr>
           <td>

               <b>Müşteri Soyadı</b></td>
          
           <td class="auto-style1">

               <asp:TextBox ID="TextBox_CustomerSurname" runat="server" AutoPostBack="True" EnableTheming="True" CssClass="textbox"></asp:TextBox>

           </td>
          
       </tr>
       <tr>
           <td >

               <b>Adres</b></td>
           <td class="auto-style1">

               <asp:TextBox ID="TextBox_CustomerAddress" runat="server" CssClass="textbox"></asp:TextBox>

           </td>
       </tr>
        <tr>
           <td >

               <b>GSM1</b>
               
           </td>
           <td class="auto-style1">

               <asp:TextBox ID="TextBox_CustomerGSM1" runat="server" CssClass="textbox"></asp:TextBox>

           </td>
            <td>

            </td>
            <td ><b>GSM2</b></td>
            
            <td>

                <asp:TextBox ID="TextBox_CustomerGSM2" runat="server" CssClass="textbox"></asp:TextBox>

            </td>     
            
       </tr>
       <tr>
           <td>
               <br />
           </td>
       </tr>

        <tr>
           <td>
           
           </td>
           <td class="auto-style2">
               &nbsp;</td>
           <td>

           </td>
           <td>
               
               <asp:Button ID="ButtonUpdate" runat="server" Text="Guncelle" Width="66px" OnClick="ButtonUpdate_Click"  />
               
           </td>
            <td style="float:right">
                <asp:Button ID="ButtonKaydet" runat="server" Text="Kaydet"  OnClick="Button_kaydet_Click"/>
            </td>
       </tr>
       
      
       
       
   </table>
       
           <div class="txt">
               
               <asp:Label ID="LabelAlert" runat="server" Text=""> </asp:Label>
           </div>
            
           
        
    </form>
</body>
</html>