<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SU3_Prac8_TakeHome.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 314px;
            text-align: center;
        }
        .auto-style2 {
            width: 179px;
            text-align: right;
        }
        .auto-style3 {
            width: 179px;
            height: 35px;
            text-align: right;
        }
        .auto-style4 {
            width: 314px;
            height: 35px;
            text-align: center;
        }
        .auto-style9 {
            width: 49%;
            height: 355px;
        }
        .auto-style15 {
            width: 179px;
            text-align: right;
            height: 11px;
        }
        .auto-style16 {
            width: 314px;
            text-align: center;
            height: 11px;
        }
        .auto-style17 {
            width: 179px;
            text-align: right;
            height: 48px;
        }
        .auto-style18 {
            width: 314px;
            text-align: center;
            height: 48px;
        }
        .auto-style19 {
            height: 48px;
        }
        .auto-style20 {
            width: 179px;
            text-align: right;
            height: 37px;
        }
        .auto-style21 {
            width: 314px;
            text-align: center;
            height: 37px;
        }
        .auto-style22 {
            width: 179px;
            height: 26px;
            text-align: right;
        }
        .auto-style23 {
            width: 314px;
            height: 26px;
            text-align: center;
        }
        .auto-style24 {
            width: 179px;
            height: 31px;
            text-align: right;
        }
        .auto-style25 {
            width: 314px;
            height: 31px;
            text-align: center;
        }
        .auto-style26 {
            text-align: justify;
        }
        .auto-style27 {
            color: #FDFF00;
        }
        .auto-style28 {
            background-color: #CC99FF;
        }
        .auto-style29 {
            height: 33px;
            text-align: left;
        }
        .auto-style30 {
            text-align: left;
        }
        .auto-style31 {
            background-color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-image: url('images/7c6ff020b826ba88c6084ae682d75dc3.jpg'); background-repeat: no-repeat">
        <div style="height: 529px">
            <table class="auto-style9">
                <tr>
                    <td class="auto-style17"></td>
                    <td class="auto-style18" style="text-align: center">
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style27" Text="Virtual Volleyball Coaching Class Booking"></asp:Label>
                    </td>
                    <td class="auto-style19" style="text-align: center"></td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style16"></td>
                    <td class="auto-style26" rowspan="9">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="99px" Width="188px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20" style="text-align: right">
                        <asp:Label ID="Label2" runat="server" Text="Names:"></asp:Label>
                    </td>
                    <td class="auto-style21">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtEmail" runat="server" style="text-align: center"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        <asp:Label ID="Label4" runat="server" Text="Student Number:"></asp:Label>
                    </td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txtStudentNumber" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="Label5" runat="server" Text="Select Campus:"></asp:Label>
                    </td>
                    <td class="auto-style25">
                        <asp:RadioButton ID="rbtnMC" runat="server" AutoPostBack="True" CssClass="auto-style28" GroupName="Campuses" OnCheckedChanged="rbtnMC_CheckedChanged" Text="MC" />
                        <asp:RadioButton ID="rbtnPC" runat="server" AutoPostBack="True" CssClass="auto-style28" GroupName="Campuses" OnCheckedChanged="rbtnMC_CheckedChanged" Text="PC" />
                        <asp:RadioButton ID="rbtnVC" runat="server" AutoPostBack="True" CssClass="auto-style28" GroupName="Campuses" OnCheckedChanged="rbtnMC_CheckedChanged" Text="VC" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style1">
                        <asp:Button ID="btnBook" runat="server" OnClick="btnBook_Click" Text="Book" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style29" colspan="2">
                        <asp:Label ID="lblOutput1" runat="server" CssClass="auto-style31"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style30" colspan="2">
                        <asp:Label ID="lblOutput2" runat="server" CssClass="auto-style31"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
