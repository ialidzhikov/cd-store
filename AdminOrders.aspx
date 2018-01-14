<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminOrders.aspx.cs" Inherits="AdminOrders" %>


<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">
        Поръчки
    </span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <asp:SqlDataSource ID="CustomerNameDS" runat="server"
        ConnectionString="<%$ ConnectionStrings:CdShopConnection %>"
        SelectCommand="SELECT vw_aspnet_Users.UserName,
 vw_aspnet_Users.UserId FROM vw_aspnet_Users INNER JOIN
 aspnet_UsersInRoles ON vw_aspnet_Users.UserId =
 aspnet_UsersInRoles.UserId INNER JOIN aspnet_Roles ON
 aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId WHERE
 (aspnet_Roles.RoleName = 'Customers')" />
    Покажи поръчки по клиент
 <asp:DropDownList ID="userDropDown" runat="server"
     DataSourceID="CustomerNameDS" DataTextField="UserName"
     DataValueField="UserId" />
    <asp:Button ID="byCustomerGo" runat="server"
        Text="Търси" OnClick="byCustomerGo_Click" />
    <br />
    Покажи поръчка по идентификатор
 <asp:TextBox ID="orderIDBox" runat="server" Width="77px" />
    <asp:Button ID="byIDGo" runat="server" Text="Търси" OnClick="byIDGo_Click" />
    <br />
    Покажи най-скорошните
 <asp:TextBox ID="recentCountTextBox" runat="server" MaxLength="4"
     Width="40px">20</asp:TextBox>
    поръчки
 <asp:Button ID="byRecentGo" runat="server"
     Text="Търси" OnClick="byRecentGo_Click" />
    <br />
    Покажи всички поръчки, създадени между
 <asp:TextBox ID="startDateTextBox" runat="server" Width="72px" />
    и
 <asp:TextBox ID="endDateTextBox" runat="server" Width="72px" />
    <asp:Button ID="byDateGo" runat="server"
        Text="Търси" OnClick="byDateGo_Click" />
    <br />
    Покажи всички поръчки, чакащи проверка на наличност
 <asp:Button ID="awaitingStockGo" runat="server"
     Text="Търси" OnClick="awaitingStockGo_Click" />
    <br />
    Покажи всички поръчки, чакащи доставка
 <asp:Button ID="awaitingShippingGo" runat="server"
     Text="Търси" OnClick="awaitingShippingGo_Click" />
    <br />
    <asp:Label ID="errorLabel" runat="server" CssClass="AdminError" EnableViewState="False"></asp:Label>
    <asp:RangeValidator ID="startDateValidator" runat="server" ControlToValidate="startDateTextBox" Display="None" ErrorMessage="RangeValidator" MaximumValue="1/1/2015" MinimumValue="1/1/1999" Type="Date"></asp:RangeValidator>
    <asp:RangeValidator ID="endDateValidator" runat="server" ControlToValidate="endDateTextBox" Display="None" ErrorMessage="Invalid end date" MaximumValue="1/1/2015" MinimumValue="1/1/1999"></asp:RangeValidator>
    <asp:CompareValidator ID="compareDatesValidator" runat="server" ControlToCompare="endDateTextBox" ControlToValidate="startDateTextBox" Display="None" ErrorMessage="Start date should be more recent" Operator="LessThan" Type="Date"></asp:CompareValidator>
    <asp:ValidationSummary ID="validateSummary" runat="server" CssClass="AdminError" HeaderText="Data validation errors:" />
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderId" OnSelectedIndexChanged="grid_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="Идентификатор"
                ReadOnly="True" SortExpression="OrderID" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="DateCreated"
                HeaderText="Дата на създаване" ReadOnly="True"
                SortExpression="DateCreated" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="DateShipped"
                HeaderText="Дата на доставяне" ReadOnly="True"
                SortExpression="DateShipped" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="StatusAsString" HeaderText="Статус"
                ReadOnly="True" SortExpression="StatusAsString" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="CustomerName"
                HeaderText="Име на клиент" ReadOnly="True"
                SortExpression="CustomerName" ItemStyle-HorizontalAlign="Center" />
            <asp:ButtonField CommandName="Select" Text="Избери" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
