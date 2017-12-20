<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="testing.aspx.cs" Inherits="user_testing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
     <asp:Button ID="btnCookie" runat="server" Text="Display Cookie" OnClick="btnCookie_Click" Height="39px" Width="292px" />
     <br /> <br />
    <asp:Label ID="lblCookie" runat="server" Text=""></asp:Label>      
</asp:Content>

