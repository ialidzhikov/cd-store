<%@ Page Language="C#" MasterPageFile="~/CdShop.master" Title="BalloonShop: What are you looking for?" %>

<script runat="server">
 protected void Page_Load(object sender, EventArgs e)
 {
 // set the 404 status code
 Response.StatusCode = 404;
 }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Looking for balloons?</h1>
    <p>
        Unfortunately, the page that you asked for doesn't exist in our web site!
    </p>
    <p>
        Please visit our
 <asp:HyperLink runat="server" Target="~/" Text="catalog" />,
 or contact us at friendly_support@example.com!
    </p>
    <p>The <b>BalloonShop</b> team</p>
</asp:Content>
