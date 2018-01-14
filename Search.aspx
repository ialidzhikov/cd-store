<%@ Page Language="C#" MasterPageFile="~/CdShop.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Title="" %>

<%@ Register Src="UserControls/ProductsList.ascx" TagName="ProductsList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label CssClass="CatalogTitle" ID="titleLabel" runat="server">
    </asp:Label>
    <br />
    <asp:Label CssClass="CatalogDescription" ID="descriptionLabel" runat="server"></asp:Label>
</asp:Content>
