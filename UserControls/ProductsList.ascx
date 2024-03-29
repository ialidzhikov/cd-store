﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductsList.ascx.cs" Inherits="UserControls_ProductsList" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<uc1:Pager ID="topPager" runat="server" Visible="False" />
<!--<h2>
    <asp:Label CssClass="CatalogDescription" Text="Тази седмица предлагаме на специални цени следните фантастични музикални CD-та:" runat="server">
    </asp:Label>
</h2>-->
<asp:DataList ID="list" runat="server" RepeatColumns="2" CssClass="ProductList" EnableViewState="False" OnItemDataBound="list_ItemDataBound">
    <ItemTemplate>
        <h3 class="ProductTitle">
            <a href="<%# Link.ToProduct(Eval("Id").ToString()) %>">
                <%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>
            </a>
        </h3>
        <a href="<%# Link.ToProduct(Eval("Id").ToString()) %>">
            <img width="100" border="0"
                src="<%# Link.ToProductImage(Eval("Thumbnail").ToString()) %>"
                alt='<%# HttpUtility.HtmlEncode(Eval("Name").ToString())%>' />
        </a>
        <%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>
        <p class="DetailSection">
            Цена:
            <%# Eval("Price", "{0:c}") %>
        </p>
        <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
    </ItemTemplate>
</asp:DataList>
<uc1:Pager ID="bottomPager" runat="server" Visible="False" />
