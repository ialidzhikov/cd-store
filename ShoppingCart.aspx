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
            <asp:BoundField DataField="Name" HeaderText="Име на продукта" ReadOnly="True" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Price" HeaderText="Цена" ReadOnly="True" SortExpression="Price" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Attributes" HeaderText="Характеристики" ReadOnly="True" SortExpression="Attributes" />
            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:TextBox ID="editQuantity" runat="server" CssClass="GridEditingRow"
                        Width="24px" MaxLength="2" Text='<%#Eval("Quantity")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Subtotal" HeaderText="Общо" ReadOnly="True" SortExpression="Subtotal" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Center" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Изтрий" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
    <p align="right">
        <span>Обща сума: </span>
        <asp:Label ID="totalAmountLabel" runat="server" Text="Label" />
    </p>
    <p align="right">
        <asp:Button ID="updateButton" runat="server" Text="Обнови" OnClick="updateButton_Click" />
        <asp:Button ID="checkoutButton" runat="server" Text="Продължи към плащане" OnClick="checkoutButton_Click" /> 
    </p>
    <uc1:ProductRecommendations ID="recommendations" runat="server" />
</asp:Content>
