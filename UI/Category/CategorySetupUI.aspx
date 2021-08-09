<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySetupUI.aspx.cs" Inherits="StockManagementSystem.UI.CategorySetupUI"  EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Category Set Up</title>
    <link  type="text/css" href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="categoryForm" runat="server">
    <div id="namediv">
        <table>
            <tr>  
                <td>
                    <asp:Label  ID="Label1" runat="server" Text="Name"></asp:Label></td>
                <td><asp:TextBox ID="nameTextBox"  runat="server"></asp:TextBox> </td>
                
            </tr>
        </table>
        <asp:Button ID="saveButton" runat="server" cssclass="button" Text="Save" OnClick="saveButton_Click" /> 
        
    </div> 

        <section>
            <asp:GridView ID="categoryGridView"  DataKeyNames="Id" AutoGenerateColumns="false"  runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="categoryGridView_SelectedIndexChanged" OnRowDataBound="categoryGridView_RowDataBound" OnRowCommand="categoryGridView_RowCommand">

                <Columns>

                     <asp:TemplateField HeaderText="SL No">
                        <ItemTemplate> <%# Container.DataItemIndex+1%> </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField  DataField="Name" HeaderText="Name" />

                    <asp:CommandField SelectText="Select" ShowSelectButton="true" Visible="false" />
                    
                    
                   
                   

                </Columns>

                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" BorderColor="#663300" ForeColor="#CCCCFF" Font-Bold="True" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" /> 

            </asp:GridView>

           
        </section>
        <asp:HiddenField ID="idHiddenField" runat="server" />
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>


        <a href="IndexUI.aspx" >Index </a>
    </form>



    
    


</body>
</html>
