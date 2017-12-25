<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoriesList.ascx.cs" Inherits="UserControls_CategoriesList" %>
<asp:DataList ID="list" runat="server" Width="200px" CssClass="CategoriesList">
    <HeaderStyle CssClass="CategoriesListHead" />
    <HeaderTemplate>
        Choose a category
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl='<%# Link.ToCategory(Request.QueryString["DepartmentID"], Eval("Id").ToString()) %>'
            Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
            ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
            CssClass='<%# Eval("Id").ToString() == Request.QueryString["CategoryID"] ? "CategorySelected" : "CategoryUnselected" %>'>>
        </asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
