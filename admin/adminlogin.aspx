<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="admin_adminlogin" %>


<!DOCTYPE html>
<html >
  <head>
    <meta charset="UTF-8">
    <title>Admin Login</title>
    
        <link rel="stylesheet" href="logincss/style.css">

  </head>

  <body>

    
<form id="f1" runat="server">
  <header>Login</header>
  <label>Username <span>*</span></label>
  <asp:TextBox ID="tblogin" runat="server"></asp:TextBox>
  
  <label>Password <span>*</span></label>
  <asp:TextBox ID="tbpassword" runat="server"></asp:TextBox>
    <br />  <br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
   
    <br />  <br />
    
     <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    <br />  <br />
    </form>
    
  </body>
</html>
