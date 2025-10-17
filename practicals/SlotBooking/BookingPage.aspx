<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingPage.aspx.cs" Inherits="Prac10_SU3.BookingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 243px;
        }
        .auto-style2 {
            margin-left: 1px;
        }
        .auto-style3 {
            background-color: #CCFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #CC99FF">
        <div>
            <table style="width:100%;">
                <tr>
                    <td colspan="3">Specify the module and the date for your slot booking</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:Label ID="lblOutput" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblModule" runat="server">Select Module:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlModule" runat="server">
                            <asp:ListItem>CMPG111</asp:ListItem>
                            <asp:ListItem>CMPG112</asp:ListItem>
                            <asp:ListItem>ITSP111</asp:ListItem>
                            <asp:ListItem>ITSP113</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Select a date on the calendar:"></asp:Label>
                    </td>
                    <td>
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" CssClass="auto-style2" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnBook" runat="server" CssClass="auto-style3" OnClick="btnBook_Click" Text="Book" Width="190px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
