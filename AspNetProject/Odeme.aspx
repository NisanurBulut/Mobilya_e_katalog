<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Odeme.aspx.cs" Inherits="AspNetProject.Odeme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>
<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="Css/calendar-blue.css" rel="stylesheet" />
    <link href="Css/Odeme.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=textboxtemin.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%Y/%m/%d %H:%M",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
</script>

    <style type="text/css">
        .button {}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        
        <div  class="table">
            <table>
                <tr>
                    <th colspan="5"  style="text-align:center" class="divHeader">Ödeme Tamamlama</th>
                </tr>
                <tr>
                    <td style="text-align: right">Müşteri:</td>
                    <td>
                        
                         <asp:DropDownList ID="DropDownListCustomer" runat="server" Height="20px" Width="170px" CssClass="textbox">
                        </asp:DropDownList>

                        <asp:Button ID="textboxmusteriekle" runat="server" Text="+" CssClass="button" Width="64px" OnClick="textboxmusteriekle_Click"/>

                    </td>
                    
                </tr>
                <tr>
                    <td style="text-align:right">
                        Temin Tarihi:
                    </td>
                    <td>
                        <asp:TextBox ID="textboxtemin" runat="server" style="border-radius:10px" > </asp:TextBox>
                        <img src="images/calender.png" />
                     </td>
                </tr>

                <tr>
                    <td style="text-align:right">
                        Vade Kodu
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListVadeKodu" runat="server" Height="20px" Width="170px" CssClass="textbox">
                        </asp:DropDownList>
                     </td>
                </tr>

                <tr>
                    <td style="text-align:right">
                        <asp:Label ID="LabelSevkiyat" runat="server" Text="Sevkiyat Yöntemi" ></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListSevkiyatYontem" runat="server" Height="20px" Width="170px" CssClass="textbox">
                        </asp:DropDownList>
                        <asp:Button ID="btnSave" runat="server" Text="Tamamla" onclick="btnSave_Click" Width="64px" />
                     </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
