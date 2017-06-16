
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailPage.aspx.cs" Inherits="AspNetProject.DetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detail Page</title>
    <link rel="stylesheet" type="text/css" href="Css/hf.css" />
    <link href="Css/DetailPage.css" rel="stylesheet" />
    

</head>
<body>
    <form id="form1" runat="server">
       <div class="header">

            <asp:DataList ID="HeaderDataList" runat="server" CssClass="header">
                <ItemTemplate>


                    <asp:Literal ID="literalheader" runat="server" Text='<%#Eval("Name")%>'></asp:Literal>
                </ItemTemplate>


            </asp:DataList>
        </div>
        <table>
            <tr>
                <td>
                    <asp:DataList ID="yourDataList" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CssClass="table">
                        <ItemTemplate>
                            <asp:Image ID="imagel" runat="server" ImageUrl='<%#Eval("FilePath") %>' Width="400px" Height="400px" />
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                <td>Opsiyon Grubu:<br/>
                    <asp:DropDownList ID="Opsiyongrubu" runat="server" Width="200px" style="border-radius:10px"></asp:DropDownList>
                </td>
                <td>Opsiyon Seçeneği<br/>
                    <asp:DropDownList ID="Opsiyonsecenek" runat="server" Width="200px"  style="border-radius:10px"></asp:DropDownList>
                </td>
                <td>Opsion Rengi<br/>
                    <asp:DropDownList ID="Opsiyonrenk" runat="server" Width="200px"  style="border-radius:10px"></asp:DropDownList>
                </td>
                <td>
                   
                    <asp:Button ID="SepeteAt" runat="server" Text="Sepete At" OnClick="SepeteAt_Click" CssClass="button" />
                </td>
                <td class="auto-style1">
                    <asp:Label ID="Fiyat" runat="server"  Text=""></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" style="border-radius:10px">
                        <asp:ListItem Selected="True">1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Hesap" runat="server" Text="Hesapla" OnClick="Hesap_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataList ID="datalist" runat="server">
                        <ItemTemplate>
                            <asp:Literal ID="Description" runat="server" Text='<%#Eval("Description")%>'></asp:Literal>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
