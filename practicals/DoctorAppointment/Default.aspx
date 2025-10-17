<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Prac9_SU3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 100%;
            height: 236px;
        }
        .auto-style4 {
            height: 96px;
        }
        .auto-style5 {
            height: 256px;
        }
        .auto-style6 {
            height: 26px;
            text-align: right;
        }
        .auto-style7 {
            height: 96px;
            text-align: right;
        }
        .auto-style8 {
            text-align: right;
        }
        .auto-style9 {
            font-size: x-large;
            color: #CC33FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #00CC99">
        <div>
            <table class="auto-style3">
                <tr>
                    <td class="auto-style2" colspan="3"><strong>
                        <asp:Label ID="Label5" runat="server" CssClass="auto-style9" Text="Book your appointment with Dr C# to See Sharp."></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Your name is required!"></asp:RequiredFieldValidator>
                    </td>
                    <td rowspan="4">
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Your email is required!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label3" runat="server" Text="Select service:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddlService" runat="server">
                            <asp:ListItem>Eye Exam</asp:ListItem>
                            <asp:ListItem>Contact lens fitting</asp:ListItem>
                            <asp:ListItem>Eye health advice</asp:ListItem>
                            <asp:ListItem>Care for eye injuries</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlService" ErrorMessage="A service is required!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label4" runat="server" Text="Payment method:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:RadioButton ID="rbtnCash" runat="server" AutoPostBack="True" GroupName="PaymentMethod" OnCheckedChanged="rbtnCash_CheckedChanged" Text="Cash" />
                        <asp:RadioButton ID="rbtnMedicalAid" runat="server" AutoPostBack="True" GroupName="PaymentMethod" OnCheckedChanged="rbtnCash_CheckedChanged" Text="Medical Aid" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Button ID="btnBook" runat="server" OnClick="btnBook_Click" Text="Book" Width="187px" />
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="lblOutput" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style5">
                        <asp:Label ID="Label6" runat="server" Text="Bookings"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
