<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"
    AutoEventWireup="true" CodeFile="AdminDepartments.aspx.cs"
    Inherits="AdminDepartments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">Отдели
    </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <p>
        <asp:Label ID="statusLabel" runat="server" CssClass="AdminError" Text=""></asp:Label>
    </p>
    <asp:GridView ID="grid" runat="server" DataKeyNames="Id" Width="100%" AutoGenerateColumns="False" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowEditing="grid_RowEditing" OnRowDeleting="grid_RowDeleting" OnRowUpdating="grid_RowUpdating">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Име на отдел" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Описание на отдел" SortExpression="Description" ItemStyle-HorizontalAlign="Center">
                <EditItemTemplate>
                    <asp:TextBox ID="descriptionTextBox" runat="server" Text='<%# Bind("Description") %>' Height="70px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="AdminCategories.aspx?DepartmentID={0}"
                HeaderText="Категории" Text="Виж категориите" ItemStyle-HorizontalAlign="Center" />
            <asp:CommandField ShowEditButton="True" EditText="Редактирай" ItemStyle-HorizontalAlign="Center" />
            <asp:ButtonField CommandName="Delete" Text="Изтрий" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
    <p>Създай нов отдел:</p>
    <p>Име:</p>
    <asp:TextBox ID="newName" runat="server" Width="400px" />
    <p>Описание:</p>
    <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
    <p>
        <asp:Button ID="createDepartment" Text="Създай" runat="server" />
    </p>
</asp:Content>
