<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acategories.aspx.cs" Inherits="AspNetProject.Acategories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Kategoriler</title>
    <link rel="stylesheet" type="text/css" href="Css/hf.css" />
    
</head>
<body>
   <form id="form1" runat="server">
      
       <div class="header" id="MyheaderDiv">
          
           <asp:DataList ID="yourDataList" runat="server" CssClass="header">
               <ItemTemplate>


                   <asp:Literal ID="LiteralHeader" runat="server" Text='<%#Eval("Name")%>'></asp:Literal>
               </ItemTemplate>
                  
                   
           </asp:DataList>
                 
  
            </div>

     
        <div>
            <asp:DataList ID="myDataList" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CssClass="table">
                <ItemTemplate>
                    <tr style="border:solid 1px black">
                        <td style="width:300px;border:solid 1px black" class="td">
                            <asp:Image ID="imagel" runat="server" ImageUrl='<%#Eval("FilePath") %>' Width="300px" Height="300px" />
                        </td>
                        <td class="td">
          <asp:HyperLink ID="myHyperLink" CssClass="myHyperLinks" runat="server" NavigateUrl='<%# Eval("CID","DetailPage.aspx?CID={0}")%>' Text='<%#Eval("Name")  %>'>
                            </asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:DataList>
            

        </div>
    </form>
</body>
</html>
