<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="AspNetProject.Categories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kategoriler</title>
    <link rel="stylesheet" type="text/css" href="Css/hf.css" />
   
   
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <h>KATEGORİLER</h>
            </div>
            <asp:DataList ID="myDataList" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CssClass="table">
                <ItemTemplate>
                    <tr style="border:solid 1px black">
                        <td style="width:300px;border:solid 1px black" class="td">
                            <asp:Image ID="imagel" runat="server" ImageUrl='<%#Eval("FilePath") %>' Width="300px" Height="300px" />
                        </td>
                        <td class="td">
        <asp:HyperLink ID="myHyperLink" CssClass="myHyperLinks" runat="server" NavigateUrl='<%# Eval("CID","Acategories.aspx?CID={0}")%>' Text='<%#Eval("Name") %>'>
                            </asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:DataList>
            <div class="footer"></div>
        </div>
    </form>
</body>
</html>
