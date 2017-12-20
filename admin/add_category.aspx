<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="add_category.aspx.cs" Inherits="admin_add_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>Enter Category</td>
            <td>
                <asp:textbox id="tbCategory" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:button id="btnAdd" runat="server" text="Add Category" OnClick="btnAdd_Click" />
            </td>
        </tr>
    </table>

    <asp:DataList ID="d1" runat="server">
        <HeaderTemplate><table></HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("product_category") %></td>
                <td><a href="delete.aspx?category=<%#Eval("product_category") %>">Delete</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:DataList>
</asp:Content>

