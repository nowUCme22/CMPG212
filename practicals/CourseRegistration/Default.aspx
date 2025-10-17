<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SU3_Prac6.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 182px;
            height: 50px;
        }
        .auto-style3 {
            height: 26px;
            width: 182px;
        }
        .auto-style4 {
            width: 428px;
        }
        .auto-style6 {
            width: 138px;
        }
        .auto-style7 {
            height: 26px;
            width: 138px;
        }
        .auto-style8 {
            width: 182px;
            text-align: right;
        }
        .auto-style9 {
            height: 26px;
            width: 428px;
            text-align: center;
        }
        .auto-style10 {
            height: 26px;
            width: 182px;
            text-align: right;
        }
        .auto-style11 {
            height: 26px;
            width: 428px;
            text-align: left;
        }
        .auto-style12 {
            height: 26px;
            text-align: center;
        }
        .auto-style13 {
            color: #33CC33;
        }
        .auto-style14 {
            color: #FF0000;
        }
        .auto-style15 {
            width: 138px;
            height: 50px;
        }
        .auto-style16 {
            width: 428px;
            height: 50px;
        }
        .auto-style17 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style16">
                        <asp:Label ID="Label1" runat="server" style="font-size: xx-large; text-align: center" Text="Course Registration Form"></asp:Label>
                    </td>
                    <td class="auto-style17"></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Label ID="Label2" runat="server" Text="Student Name:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtName" runat="server" Width="332px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" CssClass="auto-style14" ErrorMessage="Name Required!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtEmail" runat="server" Width="328px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" CssClass="auto-style14" ErrorMessage="Email required!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" CssClass="auto-style14" ErrorMessage="Email required!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7"></td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style9">
                        <asp:Label ID="Label4" runat="server" Text="Available Courses"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style9">
                        <asp:ListBox ID="lstCourses" runat="server" BackColor="#66FFFF">
                            <asp:ListItem>Web Development</asp:ListItem>
                            <asp:ListItem>Artificial Intelligence</asp:ListItem>
                            <asp:ListItem>Data Science</asp:ListItem>
                            <asp:ListItem>Cybersecurity</asp:ListItem>
                        </asp:ListBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="Label5" runat="server" Text="Study mode:"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:DropDownList ID="ddlStudyMode" runat="server" Width="223px">
                            <asp:ListItem Selected="True" Value="0">Select study mode</asp:ListItem>
                            <asp:ListItem>Full time</asp:ListItem>
                            <asp:ListItem>Part-time</asp:ListItem>
                            <asp:ListItem>Only learning</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="rfvStudyMode" runat="server" ControlToValidate="ddlStudyMode" CssClass="auto-style14" ErrorMessage="Study Mode required" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">
                        <asp:Button ID="btnRegister" runat="server" BackColor="#66FFCC" OnClick="btnRegister_Click" Text="Register" />
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="btnClear" runat="server" BackColor="#FFFFCC" OnClick="btnClear_Click" Text="Clear" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12" colspan="4">
                        <asp:Label ID="lblOutput" runat="server" CssClass="auto-style13"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">
                        <asp:Image ID="imgCourses" runat="server" Height="232px" ImageAlign="Middle" Visible="False" Width="359px" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
