<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"
    AutoEventWireup="true" CodeFile="AdminDepartments.aspx.cs"
    Inherits="AdminDepartments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">CdShop Admin
 <br />
        Departments
    </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <p>
        <asp:Label ID="statusLabel" runat="server" CssClass="AdminError" Text="Label"></asp:Label>
    </p>
    <asp:GridView ID="grid" runat="server" DataKeyNames="Id" Width="100%" AutoGenerateColumns="False" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowEditing="grid_RowEditing" OnRowDeleting="grid_RowDeleting" OnRowUpdating="grid_RowUpdating">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Department Name" SortExpression="Name" />
            <asp:TemplateField HeaderText="Department Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="descriptionTextBox" runat="server" Text='<%# Bind("Description") %>' Height="70px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="AdminCategories.aspx?DepartmentID={0}" HeaderText="View Categories" Text="View Categories" />
            <asp:CommandField ShowEditButton="True" />
            <asp:ButtonField CommandName="Delete" Text="Delete" />
        </Columns>
    </asp:GridView>
    <p>Create a new department:</p>
    <p>Name:</p>
    <asp:TextBox ID="newName" runat="server" Width="400px" />
    <p>Description:</p>
    <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
    <p>
        <asp:Button ID="createDepartment" Text="Create Department" runat="server" /></p>
</asp:Content>
