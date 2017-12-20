<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="product_desc.aspx.cs" Inherits="user_product_desc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <asp:ListView ID="L1" runat="server">
        <ItemTemplate>
            <div style="height: 300px; width: 600px; border-width: 1px; border-style: solid;">
                <div style="height: 300px; width: 200px; border-width: 1px; float: left; border-style: solid;">
                    <img src="../<%#Eval("Images") %>" height="300" width="200" alt="" />
                </div>
                <div style="height: 300px; width: 396px; border-style: solid; border-width: 1px; float: left;">
                    <br />
                    <br />
                    <br />
                    Item Name : <%#Eval("Name") %>
                    <br />
                    Item Description : <%#Eval("Description") %>
                    <br />
                    Item Price : <%#Eval("Price") %>
                    <br />
                    Available Quantity : <%#Eval("Quantity") %>
                    <br />
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <div>
    <asp:Label ID="lblQty" Text="Enter Quantity" runat="server"></asp:Label>
    <asp:TextBox ID="tbQty" runat="server"></asp:TextBox>
    
    <asp:Button ID="btnAddtoCart" Text="Add To Cart" runat="server" OnClick="btnAddtoCart_Click" />&nbsp;&nbsp;
    <asp:LinkButton ID="lbtnBack" Text="Back" runat="server" OnClick="lbtnBack_Click"></asp:LinkButton>
    <br />
    <asp:Label ID="lblErr" runat="server" Text="" ForeColor="Red"></asp:Label>
     <br />
        </div>
</asp:Content>

