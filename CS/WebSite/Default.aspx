<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ExportOnServer\Download Grid in .pdf</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="ASPxGv" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" KeyFieldName="ProductID">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" 
                    VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="4">
                </dx:GridViewDataCheckColumn>
            </Columns>
        </dx:ASPxGridView>    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
            SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice], [Discontinued] FROM [Products]">
        </asp:SqlDataSource> 
        <dx:ASPxGridViewExporter ID="Exporter" GridViewID="ASPxGv" FileName="grid" runat="server">
        </dx:ASPxGridViewExporter>
    </div>
    <div>
        <table style="border-width: 0px">
            <tr>
                <td>
                    <dx:ASPxButton Text="Export on Server" runat="server" ID="Save" onclick="Save_Click">
                    </dx:ASPxButton>
                </td>
                <td>
                    <dx:ASPxButton Text="Download" runat="server" ID="Export" onclick="Export_Click">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
