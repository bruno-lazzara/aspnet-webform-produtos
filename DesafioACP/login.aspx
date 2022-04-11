<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DesafioACP.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-sm">
            <div class="text-center">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="XX-Large" Text="Login"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="tbEmail" runat="server" AutoCompleteType="Disabled" TextMode="Email" placeholder="Email" Width="250px"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="tbSenha" runat="server" AutoCompleteType="Disabled" TextMode="Password" placeholder="Senha" Width="250px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btEntrar" runat="server" Font-Names="Calibri" Font-Size="Large" Text="Entrar" CssClass="btn btn-primary" OnClick="btEntrar_Click" />
                <br />
                <br />
                <asp:Label ID="lbErro" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red" Visible="False"></asp:Label>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
