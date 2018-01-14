<%@ Page Language="C#" MasterPageFile="~/CdShop.master" Title="CdShop: За какво се оглеждахте?" %>

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
    <h1>Оглеждахте се за музикални CD-та</h1>
    <p>
        За съжаление, страницата, която търсихте не съществува на нашия сайт!
    </p>
    <p>
        Моля посетете нашия
 <asp:HyperLink runat="server" Target="~/" Text="каталог" />,
 или се свържете с нас на friendly_support@example.com!
    </p>
    <p>Екипът на <b>CdShop</b></p>
</asp:Content>
