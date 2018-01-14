<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CdShop : Login</title>
    <link rel="stylesheet" href="/static/css/bootstrap.css" media="screen" />
    <link rel="stylesheet" href="/static/css/style.css" media="screen" />
    <script src="/static/js/jquery.js"></script>
    <script src="/static/js/bootstrap.js"></script>
</head>
<body>
    <div class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <a href="/" class="navbar-brand">
                    <img src="/images/logo-header.jpg" />
                    CdShop
                </a>
                <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse" id="navbar-main">
                <ul class="nav navbar-nav navbar-right">
                </ul>
            </div>
        </div>
    </div>

    <div class="container" id="main-container">
        <div class="row col-lg-10 page-header">
            <h1>Вход</h1>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <form id="registrationForm" runat="server">
                    <fieldset>
                        <asp:Panel ID="searchPanel" runat="server" DefaultButton="loginControl$LoginButton">
                            <asp:Login ID="loginControl" runat="server">
                                <LayoutTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="control-label">Потребителско име:</asp:Label>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                            ControlToValidate="UserName" ErrorMessage="Потребителското име е задължително."
                                            ToolTip="Потребителското име е задължително." ValidationGroup="loginControl">Потребителското име е задължително.</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="control-label">Парола:</asp:Label>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="Паролата е задължителна." ToolTip="Паролата е задължителна." ValidationGroup="loginControl">Паролата е задължителна.</asp:RequiredFieldValidator>
                                    </div>
                                    <div>
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Запомни ме" />
                                    </div>
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    <asp:Button ID="LoginButton" class="btn btn-primary" runat="server" CommandName="Login" Text="Влез" ValidationGroup="loginControl" />
                                </LayoutTemplate>
                            </asp:Login>
                        </asp:Panel>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
