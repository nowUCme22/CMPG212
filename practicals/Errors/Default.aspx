<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SU3_Prac_5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #808080">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 72px;
        }
        .auto-style3 {
            width: 135px;
        }
        .auto-style4 {
            width: 149px;
        }
        .auto-style5 {
            width: 100%;
            height: 108px;
            margin-bottom: 86px;
        }
        .auto-style6 {
            width: 149px;
            height: 30px;
        }
        .auto-style7 {
            width: 72px;
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
        }
        .auto-style9 {
            height: 23px;
        }
        .auto-style10 {
            height: 301px;
        }
        .auto-style11 {
            color: #FF3300;
            font-size: large;
        }
        .auto-style14 {
            font-size: medium;
        }
    </style>
</head>
<body style="height: 323px">
    <form id="form1" runat="server" class="auto-style10">
        <div>
        </div>
        <strong>
        <asp:Label ID="lblTitle" runat="server" style="font-size: xx-large; color: #0066FF" Text="Art Club Pen Order Form"></asp:Label>
        </strong>
        <table class="auto-style5">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtFName" runat="server" Width="121px"></asp:TextBox>
                </td>
                <td>Last Name:
                    <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLName" runat="server" ControlToValidate="txtLName" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <p class="auto-style3">
                        Phone Number:</p>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPhoneNr" runat="server"></asp:TextBox>
                </td>
                <td>Email Address:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Pen selection for Order:</td>
                <td class="auto-style7"></td>
                <td class="auto-style8">
                    <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" Width="99px" OnClick="btnPlaceOrder_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Color: </td><td class="auto-style2">
                <asp:DropDownList ID="ddlColor" runat="server">
                    <asp:ListItem>Red</asp:ListItem>
                    <asp:ListItem>Black</asp:ListItem>
                    <asp:ListItem>Blue</asp:ListItem>
                    <asp:ListItem>Green</asp:ListItem>
                </asp:DropDownList>
                </td><td>Amount:
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="rvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Amount not valid" MaximumValue="50" MinimumValue="1"></asp:RangeValidator>
                </td>
           </tr>
             <tr>
                <td colspan="3"> <strong>
                    <asp:Label ID="lblResult2" runat="server" CssClass="auto-style14"></asp:Label>
                    </strong></td>
           </tr>
             <tr>
                <td class="auto-style9" colspan="3"><em>
                    <asp:Label ID="lblAmount" runat="server"></asp:Label>
                    </em></td>
           </tr>
             <tr>
                <td colspan="3"><em>
                    <asp:Label ID="lblTax" runat="server"></asp:Label>
                    </em></td>
           </tr>
             <tr>
                <td colspan="3"><strong>
                    <asp:Label ID="lblTotal" runat="server" CssClass="auto-style11"></asp:Label>
                    </strong></td>
           </tr>
        </table>
    </form>
</body>
</html>
