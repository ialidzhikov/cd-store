<%@ Page Language="C#" MasterPageFile="~/CdShop.master"
    AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product"
    Title="CdShop: Product Details Page" %>

<%@ Register Src="UserControls/ProductRecommendations.ascx" TagName="ProductRecommendations" TagPrefix="uc1" %>

<%@ Register Src="UserControls/ProductReviews.ascx" TagName="ProductReviews" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <asp:Label CssClass="CatalogTitle" ID="titleLabel" runat="server"
            Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Image ID="productImage" runat="server" ControlStyle-Width="300px" />
    </p>
    <p>
        <asp:Label ID="descriptionLabel" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <b>Цена:</b>
        <asp:Label CssClass="ProductPrice" ID="priceLabel" runat="server"
            Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="grid" AutoGenerateColumns="False" BorderWidth="0px" DataKeyNames="Id" Width="100%" runat="server">
            <Columns>
                <asp:BoundField DataField="Position" HeaderText="#" ReadOnly="True" SortExpression="Position" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Name" HeaderText="Име" ReadOnly="True" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Duration" HeaderText="Продължителност" ReadOnly="True" SortExpression="Duration" ItemStyle-HorizontalAlign="Center" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
    </p>
    <p>
        <asp:LinkButton ID="AddToCartButton" runat="server"
            OnClick="AddToCartButton_Click">Добави в количката</asp:LinkButton>
    </p>
    <uc1:ProductRecommendations ID="recommendations" runat="server" />
    <uc2:ProductReviews ID="ProductReviews1" runat="server" />
</asp:Content>
