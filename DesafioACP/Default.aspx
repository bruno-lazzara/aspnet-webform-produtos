<%@ Page Title="Página Inicial" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DesafioACP.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-sm" style="margin-top: 30px">
        <div class="card text-white bg-success mb-3" style="margin-top: 30px; max-width: 18rem;">
            <div class="card-header">
                Usuário Logado
            </div>
            <div class="card-body">
                <asp:Label ID="Label4" runat="server" Text="Nome: "></asp:Label>
                <asp:Label ID="lbNome" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Email: "></asp:Label>
                <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
