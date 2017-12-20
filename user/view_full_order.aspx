<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="view_full_order.aspx.cs" Inherits="user_view_full_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    
     <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:gray; color:white;">
                    <th>Id</th>
                    <th>firstname</th>
                    <th>lastname</th>
                    <th>email</th>
                    <th>address</th>
                    <th>city</th>
                    <th>state</th>
                    <th>pincode</th>                   
                    <th>mobile</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("id") %></td>
                <td><%#Eval("firstname") %></td>
                <td><%#Eval("lastname") %></td>
                <td><%#Eval("email") %></td>
                <td><%#Eval("address") %></td>
                <td><%#Eval("city") %></td>
                <td><%#Eval("state") %></td>
                <td><%#Eval("pincode") %></td> 
                <td><%#Eval("mobile") %></td>               
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <br /><br /><br />

    
    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:gray; color:white;">
                    <th>Product Image</th>
                    <th>Product Name</th>
                    <th>Product Price</th>
                    <th>Product Qty</th>                                      
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><img src="<%#Eval("product_images") %>" height="100" width="100" /></td>
                <td><%#Eval("product_name") %></td>
                <td><%#Eval("product_price") %></td>
                <td><%#Eval("product_qty") %></td>                
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
</asp:Content>

