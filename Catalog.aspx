<%@ Page Title="CdShop: Catalog" Language="C#" MasterPageFile="~/CdShop.master"
    AutoEventWireup="true" CodeFile="Catalog.aspx.cs"
    Inherits="UserControls_Catalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">
    <h1>
        <asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle" runat="server" />
    </h1>
    <h2>
        <asp:Label ID="catalogDescriptionLabel" CssClass="CatalogDescription" runat="server" />
    </h2>
</asp:Content>
