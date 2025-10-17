<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Prac10_SU3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 242px;
        }
        .auto-style3 {
            height: 26px;
            width: 242px;
        }
        .auto-style4 {
            color: #FF0000;
        }
        .auto-style5 {
            background-color: #CCFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #FF00FF">
        <div>
            <table style="width:100%;">
                <tr>
                    <td colspan="3">Welcome to TutorChain slot Booking System</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Enter your Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" CssClass="auto-style4" ErrorMessage="Please input a name"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Select study level:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlStudyLevel" runat="server">
                            <asp:ListItem>UnderGraduate</asp:ListItem>
                            <asp:ListItem>PostGraduate</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStudyLevel" CssClass="auto-style4" ErrorMessage="Please select a study level"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Button ID="btnContinue" runat="server" CssClass="auto-style5" OnClick="btnContinue_Click" Text="Continue" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
