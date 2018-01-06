<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBox.ascx.cs" Inherits="UserControls_SearchBox" %>

<asp:Panel ID="searchPanel" runat="server" DefaultButton="goButton">
    <table class="SearchBox">
        <tr>
            <td class="SearchBoxHead">Търсачка</td>
        </tr>
        <tr>
            <td class="SearchBoxContent">
                <asp:TextBox ID="searchTextBox" runat="server" Width="128px"
                    MaxLength="100" />
                <asp:Button ID="goButton" runat="server"
                    Text="Търси" Width="48px" OnClick="goButton_Click" /><br />
                <asp:CheckBox ID="allWordsCheckBox" runat="server"
                    Text="Търсене по всички думи" />
            </td>
        </tr>
    </table>
</asp:Panel>
