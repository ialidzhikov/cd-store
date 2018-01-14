<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminCategories.aspx.cs" Inherits="AdminCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">Категории в 
 <asp:HyperLink ID="deptLink" runat="server" />
    </span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <p>
        <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
    </p>
    <asp:GridView ID="grid" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" Width="100%" OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating" OnRowDeleting="grid_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Име на категория" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Category Description" SortExpression="Description" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine"
                        Text='<%# Bind("Description") %>' Height="70px" Width="400px" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Продукти" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text="Виж продуктите" ID="link" NavigateUrl='<%# "AdminProducts.aspx?DepartmentID=" + 
                            Request.QueryString["DepartmentID"] + "&amp;CategoryID=" + Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" EditText="Редактирай" ItemStyle-HorizontalAlign="Center" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Изтрий" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
    <p>Създай нова категория:</p>
    <p>Име:</p>
    <asp:TextBox ID="newName" runat="server" Width="400px" />
    <p>Описание:</p>
    <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
    <p>
        <asp:Button ID="createCategory" Text="Създай" runat="server" OnClick="createCategory_Click" />
    </p>
</asp:Content>
