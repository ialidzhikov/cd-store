<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserControls_UserInfo" %>
<table cellspacing="0" border="0" width="200px">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <tr>
                <td class="UserInfoHead">Добре дошли!</td>
            </tr>
            <tr>
                <td class="UserInfoContent">Не сте влезнали в системата.
                    <asp:LoginStatus ID="LoginStatus1" LoginText="Влезте" runat="server" />
                    или
                    <asp:HyperLink runat="server" ID="registerLink" NavigateUrl="~/Register.aspx" Text="се регистрирайте" ToolTip="Go to the registration page" />
                </td>
            </tr>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrators">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server" FormatString="Добре дошъл, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <a href="/">Магазин</a>
                            <br />
                            <a href="AdminDepartments.aspx">Каталог</a>
                            <br />
                            <a href="AdminShoppingCart.aspx">Колички</a>
                            <br />
                            <a href="AdminOrders.aspx">Поръчки</a>
                            <br />
                            <asp:LoginStatus ID="LoginStatus2" LogoutText="Изход" runat="server" />
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Customers">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server"
                                FormatString="Добре дошъл, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <asp:HyperLink runat="server" ID="detailsLink"
                                NavigateUrl="~/CustomerDetails.aspx"
                                Text="Профил"
                                ToolTip="Edit your personal details" />
                            <br />
                            <asp:LoginStatus ID="LoginStatus1" LogoutText="Изход" runat="server" />
                        </td>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</table>
