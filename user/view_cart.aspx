<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="view_cart.aspx.cs" Inherits="user_view_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <div>
   
        <asp:LinkButton Text="Back" ID="btnBack" OnClick="btnBack_Click" runat="server" ></asp:LinkButton>
        <br /><br />
        
        <asp:DataList ID="DL1" runat="server">
           <HeaderTemplate>
                <table border="1">
                    <tr style="background-color:silver;color:white;font-weight:bold;">
                        <td>Image</td>
                        <td>Name</td>
                        <td>Description</td>
                        <td>Price</td>
                        <td>Quantity</td>
                        <td>Id</td>
                        <td>Delete</td>

                    </tr>
           </HeaderTemplate>
            <ItemTemplate>
               
                <tr>
                    <td><img src="../<%#Eval("image") %>" height="100" width="100" alt="" /></td>
                    <td><%#Eval("name") %></td>
                    <td><%#Eval("description") %></td>
                    <td><%#Eval("price") %></td>
                    <td><%#Eval("qty") %></td>
                    <td><%#Eval("new_id") %></td>
                    <td><a href="delete_cart.aspx?id=<%#Eval("id") %>">Remove</a></td>
                </tr>
                                  
            </ItemTemplate>
          <FooterTemplate>
               </Table> 
          </FooterTemplate>
        </asp:DataList>

        <br />
        <p style="text-align:center">
            <asp:Label ID="lblTotal" runat="server" Text="$ 0.0"></asp:Label>
             <br />
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
        </p>
       <br />
   </div>
</asp:Content>

