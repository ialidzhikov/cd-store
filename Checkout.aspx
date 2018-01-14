<%@ Page Title="" Language="C#" MasterPageFile="~/CdShop.master"
    AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<%@ Register TagPrefix="uc1" TagName="CustomerDetailsEdit"
    Src="UserControls/CustomerDetailsEdit.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="Server">
    <asp:Label ID="titleLabel" runat="server"
        CssClass="CatalogTitle" Text="Потвърдете вашата поръчка" />
    <br />
    <br />
    <asp:GridView ID="grid" runat="server" Width="100%"
        AutoGenerateColumns="False" DataKeyNames="Id"
        BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Име на продукта"
                ReadOnly="True" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Price" DataFormatString="{0:c}"
                HeaderText="Цена" ReadOnly="True"
                SortExpression="Price" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Quantity" HeaderText="Количество"
                ReadOnly="True" SortExpression="Quantity" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Subtotal" ReadOnly="True"
                DataFormatString="{0:c}" HeaderText="Общо"
                SortExpression="Subtotal" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label2" runat="server" Text="Total amount: "
        CssClass="ProductDescription" />
    <asp:Label ID="totalAmountLabel" runat="server" Text="Label"
        CssClass="ProductPrice" />
    <br />
    <br />
    <uc1:CustomerDetailsEdit ID="CustomerDetailsEdit1"
        runat="server" Editable="false" Title="User Details" />
    <br />
    <asp:Label ID="InfoLabel" runat="server" />
    <br />
    Вид доставка:
    <asp:DropDownList ID="shippingSelection" runat="server" />
    <br />
    <asp:Button ID="placeOrderButton" runat="server"
        Text="Поръчай" OnClick="placeOrderButton_Click" />
</asp:Content>
