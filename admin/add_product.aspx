<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="add_product.aspx.cs" Inherits="admin_add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <h3>Add Products Page</h3>

    <asp:Table ID="t1" runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Product Name</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbName" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Product Description</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbDesc" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Product Price</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbPrice" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Product Quantity</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbQty" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>

         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Product Image</asp:TableCell>
            <asp:TableCell runat="server"><asp:FileUpload ID="fuImage" runat="server" /></asp:TableCell>
        </asp:TableRow>

         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Product Category</asp:TableCell>
            <asp:TableCell runat="server"><asp:DropDownList ID="ddCategory" runat="server"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>

         <asp:TableRow runat="server">
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" runat="server">
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Label ID="errlbl" Text="" runat="server"></asp:Label>
    <br />

</asp:Content>

