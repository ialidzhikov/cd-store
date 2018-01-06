<%@ Page Title="CdShop: Shopping Cart" Language="C#" MasterPageFile="~/CdShop.master"
    AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="Server">
    <p>
        <asp:Label ID="titleLabel" runat="server" Text="Your Shopping Cart"
            CssClass="CatalogTitle" />
    </p>
    <p>
        <asp:Label ID="statusLabel" runat="server" />
    </p>
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" BorderWidth="0px" DataKeyNames="Id" Width="100%" OnRowDeleting="grid_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Product Name" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" DataFormatString="{0:c}" />
            <asp:BoundField DataField="Attributes" HeaderText="Attributes" ReadOnly="True" SortExpression="Attributes" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="editQuantity" runat="server" CssClass="GridEditingRow"
                        Width="24px" MaxLength="2" Text='<%#Eval("Quantity")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" SortExpression="Subtotal" DataFormatString="{0:c}" />
        </Columns>
    </asp:GridView>
    <p align="right">
        <span>Total amount: </span>
        <asp:Label ID="totalAmountLabel" runat="server" Text="Label" />
    </p>
    <p align="right">
        <asp:Button ID="updateButton" runat="server" Text="Update Quantities" OnClick="updateButton_Click" />
        <asp:Button ID="checkoutButton" runat="server" Text="Proceed to Checkout" OnClick="checkoutButton_Click" /> 
    </p>
    <uc1:ProductRecommendations ID="recommendations" runat="server" />
</asp:Content>
