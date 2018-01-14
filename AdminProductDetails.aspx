<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminProductDetails.aspx.cs" Inherits="AdminProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder"
    runat="Server">
    <span class="AdminTitle">Обратно към
 <asp:HyperLink ID="catLink" runat="server" />
    </span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder"
    runat="Server">
    <asp:Label CssClass="AdminTitle" ID="productNameLabel" runat="server" />
    <p>
        <asp:Label ID="statusLabel" CssClass="AdminError" runat="server" />
    </p>
    <p>
        Продуктът принадлежи към следните категории:
 <asp:Label ID="categoriesLabel" runat="server" />
    </p>
    <p>
        Премахни продукта от тази категория:
 <asp:DropDownList ID="categoriesListRemove" runat="server" />
        <asp:Button ID="removeButton" runat="server" Text="Премахни"
            OnClick="removeButton_Click" />
        <asp:Button ID="deleteButton" runat="server" Text="Изтрий от каталога"
            OnClick="deleteButton_Click" />
    </p>
    <p>
        Добави продукта в тази категория:
 <asp:DropDownList ID="categoriesListAssign" runat="server" />
        <asp:Button ID="assignButton" runat="server" Text="Добави"
            OnClick="assignButton_Click" />
        <p>
            Прехвърли продукта в тази категория:
 <asp:DropDownList ID="categoriesListMove" runat="server" />
            <asp:Button ID="moveButton" runat="server" Text="Прехвърли"
                OnClick="moveButton_Click" />
        </p>
        <p>
            Изображение 1:
 <asp:Label ID="Image1Label" runat="server" />
            <asp:FileUpload ID="image1FileUpload" runat="server" />
            <asp:Button ID="upload1Button" runat="server" Text="Качи" OnClick="upload1Button_Click" /><br />
            <asp:Image ID="image1" runat="server" ControlStyle-Width="300px" />
        </p>
        <p>
            Изображение 2:
 <asp:Label ID="Image2Label" runat="server" />
            <asp:FileUpload ID="image2FileUpload" runat="server" />
            <asp:Button ID="upload2Button" runat="server" Text="Качи" OnClick="upload2Button_Click" /><br />
            <asp:Image ID="image2" runat="server" ControlStyle-Width="300px" />
        </p>
</asp:Content>
