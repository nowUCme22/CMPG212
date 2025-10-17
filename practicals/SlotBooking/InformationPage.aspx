<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformationPage.aspx.cs" Inherits="Prac10_SU3.InformationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-size: xx-large;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            color: #FFFFFF;
            background-color: #0033CC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #CC99FF">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Slot Booking Confirmation"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOutput2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSession" runat="server">Session Date:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblModule" runat="server">Module:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="lblBookNewSlot" runat="server" CssClass="auto-style4" OnClick="lblBookNewSlot_Click" Text="Book new slot" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
