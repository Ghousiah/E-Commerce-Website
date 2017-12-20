<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="display_item.aspx.cs" Inherits="user_display_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="last">
                <a href="product_desc.aspx?id=<%#Eval("id") %>">
                    <img src="../<%#Eval("Images") %>" alt="" /></a>
                <div class="product-info">
                    <h3><%#Eval("Name") %></h3>
                    <div class="product-desc">
                        <h4>Quantity in Stock : <%#Eval("Quantity") %></h4>
                        <p><%#Eval("Description")  %></p>
                        <strong class="price"><%#Eval("Price") %></strong>
                    </div>
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

