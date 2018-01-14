<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminProducts.aspx.cs" Inherits="AdminProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">Продукти в категория
 <asp:HyperLink ID="catLink" runat="server" />
    </span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <p>
        <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
    </p>
    <asp:GridView ID="grid" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" Width="100%" OnRowEditing="grid_RowEditing" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowUpdating="grid_RowUpdating">
        <Columns>
            <asp:ImageField DataImageUrlField="Thumbnail" DataImageUrlFormatString="ProductImages/{0}" HeaderText="Изображение" ControlStyle-Width="100px">
                <ItemStyle HorizontalAlign="Center" />
            </asp:ImageField>
            <asp:TemplateField HeaderText="Име на продукта" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                <EditItemTemplate>
                    <asp:TextBox ID="nameTextBox" runat="server" Width="97%" CssClass="GridEditingRow" Text='<%# Bind("Name") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Описание" SortExpression="Description" ItemStyle-HorizontalAlign="Center">
                <EditItemTemplate>
                    <asp:TextBox ID="descriptionTextBox" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Цена" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"
                        Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="priceTextBox" runat="server" Width="45px"
                        Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'>
                    </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Малка картина" SortExpression="Thumbnail">
                <EditItemTemplate>
                    <asp:TextBox ID="thumbTextBox" Width="80px" runat="server" Text='<%# Bind("Thumbnail") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Thumbnail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Голяма картина" SortExpression="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="imageTextBox" Width="80px" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="PromoDept" HeaderText="Промоция отдел" SortExpression="PromoDept" ItemStyle-HorizontalAlign="Center" />
            <asp:CheckBoxField DataField="PromoFront" HeaderText="Промоция каталог" SortExpression="PromoFront" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1"
                        runat="server" Text="Избери"
                        NavigateUrl='<%# "AdminProductDetails.aspx?DepartmentID=" + Request.QueryString["DepartmentID"] + "&amp;CategoryID=" + Request.QueryString["CategoryID"] + "&amp;ProductID=" + Eval("Id") %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" EditText="Редактирай" UpdateText="Запази" CancelText="Откажи" />
        </Columns>
    </asp:GridView>
    <p>Създай нов продукт към тази категория:</p>
    <p>
        <span class="WideLabel">Име:</span>
        <asp:TextBox ID="newName" runat="server" Width="400px" />
    </p>
    <p>
        <span class="WideLabel">Описание:</span>
        <asp:TextBox ID="newDescription" runat="server" Width="400px"
            Height="70px" TextMode="MultiLine" />
    </p>
    <p>
        <span class="WideLabel">Цена:</span>
        <asp:TextBox ID="newPrice" runat="server" Width="400px">0.00</asp:TextBox>
    </p>
    <p>
        <span class="WideLabel">Малка картина:</span>
        <asp:TextBox ID="newThumbnail" runat="server" Width="400px">Generic1.png</asp:TextBox>
    </p>
    <p>
        <span class="WideLabel">Голяма картина:</span>
        <asp:TextBox ID="newImage" runat="server" Width="400px">Generic2.png</asp:TextBox>
    </p>
    <p>
        <span class="widelabel">Промоция отдел:</span>
        <asp:CheckBox ID="newPromoDept" runat="server" />
    </p>
    <p>
        <span class="widelabel">Промоция каталог:</span>
        <asp:CheckBox ID="newPromoFront" runat="server" />
    </p>
    <asp:Button ID="createProduct" runat="server" Text="Създай" OnClick="createProduct_Click" />
</asp:Content>
