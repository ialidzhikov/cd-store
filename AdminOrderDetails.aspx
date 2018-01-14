<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminOrderDetails.aspx.cs" Inherits="AdminOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">Детайли на поръчка </span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <h2>
        <asp:Label ID="orderIdLabel" runat="server" CssClass="AdminTitle"
            Text="Order #000" />
    </h2>
    <span class="WideLabel">Общо:</span>
    <asp:Label ID="totalAmountLabel" runat="server" />
    <br />
    <span class="WideLabel">Дата на създаване:</span>
    <asp:TextBox ID="dateCreatedTextBox" runat="server" Width="400px"
        Enabled="false" />
    <br />
    <span class="WideLabel">Дата на доставяне:</span>
    <asp:TextBox ID="dateShippedTextBox" runat="server" Width="400px" />
    <br />
    <span class="WideLabel">Статус:</span>
    <asp:DropDownList ID="statusDropDown" runat="server" />
    <br />
    <span class="WideLabel">Код за оторизация:</span>
    <asp:TextBox ID="authCodeTextBox" runat="server" Width="400px" />
    <br />
    <span class="WideLabel">Номер на справка:</span>
    <asp:TextBox ID="referenceTextBox" runat="server" Width="400px" />
    <br />
    <span class="WideLabel">Коментари:</span>
    <asp:TextBox ID="commentsTextBox" runat="server" Width="400px" />
    <br />
    <span class="WideLabel">Име на клиент:</span>
    <asp:TextBox ID="customerNameTextBox" runat="server" Width="400px"
        Enabled="false" />
    <br />
    <span class="WideLabel">Адрес за доставка:</span>
    <asp:TextBox ID="shippingAddressTextBox" runat="server" Width="400px"
        Height="200px" TextMode="MultiLine" Enabled="false" />
    <br />
    <span class="WideLabel">Вид доставка:</span>
    <asp:TextBox ID="shippingTypeTextBox" runat="server" Width="400px"
        Enabled="false" />
    <br />
    <span class="WideLabel">Мейл на клиент:</span>
    <asp:TextBox ID="customerEmailTextBox" runat="server" Width="400px"
        Enabled="false" />

    <asp:Button ID="editButton" runat="server"
        Text="Редактирай" Width="100px" OnClick="editButton_Click" />
    <asp:Button ID="updateButton" runat="server"
        Text="Запази" Width="100px" OnClick="updateButton_Click" />
    <asp:Button ID="cancelButton" runat="server"
        Text="Отмени" Width="100px" OnClick="cancelButton_Click" />
    <br />
    <asp:Button ID="processOrderButton" runat="server"
        Text="Обработи поръчката" Width="310px"
        OnClick="processOrderButton_Click" />
    <br />
    <asp:Button ID="cancelOrderButton" runat="server"
        Text="Откажи Поръчката" Width="310px"
        OnClick="cancelOrderButton_Click" />
    <p>
        Поръчката съдържа следните продукти:
    </p>
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" BackColor="White" Width="100%">
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="Идентификатр"
                ReadOnly="True" SortExpression="ProductId" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="ProductName" HeaderText="Име на продукт"
                ReadOnly="True" SortExpression="ProductName" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Quantity" HeaderText="Количество"
                ReadOnly="True" SortExpression="Quantity" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="UnitCost" HeaderText="Единична цена"
                ReadOnly="True" SortExpression="UnitCost" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Subtotal" HeaderText="Общо"
                ReadOnly="True" SortExpression="Subtotal" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="Label1" runat="server" CssClass="AdminPageText"
        Text="Одит логове на поръчката:" />
    <br />
    <asp:GridView ID="auditGrid" runat="server"
        AutoGenerateColumns="False" BackColor="White"
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" GridLines="Horizontal" Width="100%">
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Идентификатор"
                ReadOnly="True" SortExpression="Id" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="DateStamp" HeaderText="Дата"
                ReadOnly="True" SortExpression="DateStamp" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="MessageNumber"
                HeaderText="Номер на съобщение" ReadOnly="True"
                SortExpression="MessageNumber" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Message" HeaderText="Съобщение"
                ReadOnly="True" SortExpression="Message" ItemStyle-HorizontalAlign="Center" />
        </Columns>
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C"
            HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True"
            ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"
            ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
</asp:Content>
