﻿<%@ Page Language="C#" MasterPageFile="~/CdShop.master"
    AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product"
    Title="CdShop: Product Details Page" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

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
        <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
    </p>
    <p>
        <asp:LinkButton ID="AddToCartButton" runat="server"
            OnClick="AddToCartButton_Click">Добави в количката</asp:LinkButton>
    </p>
    <uc1:ProductRecommendations ID="recommendations" runat="server" />
</asp:Content>
