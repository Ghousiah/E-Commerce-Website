﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="display_order.aspx.cs" Inherits="admin_display_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:gray; color:white;">
                    <th>Id</th>
                    <th>firstname</th>
                    <th>lastname</th>
                    <th>city</th>
                    <th>state</th>
                    <th>pincode</th>
                    <th>View Full Order</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("id") %></td>
                <td><%#Eval("firstname") %></td>
                <td><%#Eval("lastname") %></td>
                <td><%#Eval("city") %></td>
                <td><%#Eval("state") %></td>
                <td><%#Eval("pincode") %></td>
                <td><a href="view_full_order.aspx?id=<%#Eval("id") %>">View Full Order</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

