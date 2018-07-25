<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customer_Mail.aspx.cs" Inherits="Customer_Mail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblMsg" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td>
                    Card Number:
                </td>
                <td>
                    <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>