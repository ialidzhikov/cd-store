<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBox.ascx.cs" Inherits="UserControls_SearchBox" %>

<asp:Panel ID="searchPanel" runat="server" DefaultButton="goButton">
    <table class="SearchBox">
        <tr>
            <td class="SearchBoxHead">Search the Catalog</td>
        </tr>
        <tr>
            <td class="SearchBoxContent">
                <asp:TextBox ID="searchTextBox" runat="server" Width="128px"
                    MaxLength="100" />
                <asp:Button ID="goButton" runat="server"
                    Text="Go" Width="36px" OnClick="goButton_Click" /><br />
                <asp:CheckBox ID="allWordsCheckBox" runat="server"
                    Text="Search for all words" />
            </td>
        </tr>
    </table>
</asp:Panel>
