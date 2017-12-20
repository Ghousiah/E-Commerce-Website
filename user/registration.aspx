<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="user_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>First Name: </td>
            <td><asp:TextBox ID="tbFirstname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Last Name: </td>
            <td><asp:TextBox ID="tbLastname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email: </td>
            <td><asp:TextBox ID="tbEmail" runat="server" TextMode="Email"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password: </td>
            <td><asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Address: </td>
            <td><asp:TextBox ID="tbAddress" runat="server" Height="55px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td>City: </td>
            <td><asp:TextBox ID="tbCity" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>State: </td>
            <td><asp:TextBox ID="tbState" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Pincode: </td>
            <td><asp:TextBox ID="tbPincode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Mobile Number: </td>
            <td><asp:TextBox ID="tbMobile" runat="server" TextMode="Phone"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnRegister" Text="Register" runat="server" OnClick="btnRegister_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblMsg" Text="" runat="server" ForeColor="Green"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

