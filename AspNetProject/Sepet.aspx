<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sepet.aspx.cs" Inherits="AspNetProject.Sepet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sepet</title>
    <link href="Css/Sepet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <h2 style="color: green; text-align: center; margin: auto">Sepetim</h2>
            </div>
            <table style="height:100%">
                <tr>
                    <td>
                        <asp:DataGrid ID="mydata" runat="server"  BorderColor="Green" CellPadding="40">
                            <Columns>
                                <asp:TemplateColumn HeaderText="Sepetten Çıkar">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="button1" Text="Çıkar" CommandArgument='<%#Eval("BID")%>' OnCommand="button1_Command"  />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                
                            </Columns>
                        </asp:DataGrid>
                        
                    </td>
                </tr>
                <tr>
                   <td>
                      <asp:Button ID="Button2" Text="Kategorilere Dön" runat="server" OnClick="Button2_Click"  />  
                       <asp:Button ID="Button3" Text="Fatura Oluştur" runat="server" OnClick="Button3_Click" />
                   </td>  
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
