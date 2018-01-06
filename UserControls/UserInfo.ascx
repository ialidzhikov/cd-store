<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserControls_UserInfo" %>
<table cellspacing="0" border="0" width="200px">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <tr>
                <td class="UserInfoHead">Добре дошли!</td>
            </tr>
            <tr>
                <td class="UserInfoContent">Не сте влезнали в системата.
                    <asp:LoginStatus ID="LoginStatus1" runat="server" />
                    или
                    <asp:HyperLink runat="server" ID="registerLink" NavigateUrl="~/Register.aspx" Text="Register" ToolTip="Go to the registration page" />
                </td>
            </tr>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrators">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server" FormatString="Hello, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <asp:LoginStatus ID="LoginStatus2" runat="server" />
                            <br />
                            <a href="/">CdShop</a>
                            <br />
                            <a href="AdminDepartments.aspx">Catalog Admin</a>
                            <br />
                            <a href="AdminShoppingCart.aspx">Cart Admin</a>
                            <br />
                            <a href="AdminOrders.aspx">Orders Admin</a>
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Customers">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server"
                                FormatString="Hello, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <asp:LoginStatus ID="LoginStatus1" runat="server" />
                            <br />
                            <asp:HyperLink runat="server" ID="detailsLink"
                                NavigateUrl="~/CustomerDetails.aspx"
                                Text="Edit Details"
                                ToolTip="Edit your personal details" />
                        </td>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</table>
