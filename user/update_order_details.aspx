<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="update_order_details.aspx.cs" Inherits="user_update_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>Firstname</td>
            <td><asp:TextBox ID="tbfname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Lastname</td>
            <td><asp:TextBox ID="tblname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Address</td>
            <td><asp:TextBox ID="tbAddress" runat="server" TextMode="MultiLine" Height="76px" Width="199px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>City</td>
            <td><asp:TextBox ID="tbCity" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>State</td>
            <td><asp:TextBox ID="tbState" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Pincode</td>
            <td><asp:TextBox ID="tbPincode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Mobile No</td>
            <td><asp:TextBox ID="tbMobile" runat="server" TextMode="Phone"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" align="center"><asp:Button ID="btnUpdate" runat="server" Text="Update and Continue" OnClick="btnUpdate_Click" /></td>
        </tr>
    </table>
</asp:Content>

