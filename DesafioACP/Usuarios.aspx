<%@ Page Title="Usuários" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="DesafioACP.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-xxl">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Usuários" Font-Size="Large"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="False" CellPadding="3" Width="700px" CssClass="table table-hover table-bordered" OnSelectedIndexChanged="gvUsuario_SelectedIndexChanged" OnSelectedIndexChanging="gvUsuario_SelectedIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="id">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Nome" DataField="nome">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="E-mail" DataField="email">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:CommandField SelectText="Editar" ShowSelectButton="True">
                    <ControlStyle CssClass="btn btn-primary" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle CssClass="thead-light" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <SelectedRowStyle CssClass="table-primary" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <asp:Button ID="btCadastrar" runat="server" CssClass="btn btn-success" Text="Cadastrar novo usuário" OnClick="btCadastrar_Click" />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="False" style="display: inline-block; margin-right: 20px">
            <form>
                <div class="mb-3">
                    <label class="form-label">Código do Usuário</label>
                    <asp:TextBox ID="tbId" runat="server" CssClass="form-control-sm" Enabled="False"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Nome</label>
                    <asp:TextBox ID="tbNome" runat="server" CssClass="form-control-sm" style="float: right;"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">E-mail</label>
                    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control-sm" style="float: right;"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Senha</label>
                    <asp:TextBox ID="tbSenha" runat="server" CssClass="form-control-sm" TextMode="Password" style="float: right;"></asp:TextBox>
                </div>
                <asp:Button ID="btConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btConfirmar_Click" />
                <asp:Button ID="btCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btCancelar_Click" />
            </form>
        </asp:Panel>
        <asp:Panel ID="painelErro" runat="server" Visible="False" style="vertical-align: top; display: inline-block; margin-left: 10px; margin-right: 10px">
            <div class="card border-danger mb-3" style="max-width: 18rem;">
                <div class="card-header">Erro</div>
                <div class="card-body text-danger">
                    <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btFecharErro" runat="server" Text="" CssClass="btn-close" OnClick="btFecharErro_Click"/>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="painelSucesso" runat="server" style="vertical-align: top; display: inline-block; margin-left: 10px; margin-right: 10px" Visible="False">
            <div class="card border-success mb-3" style="max-width: 18rem;">
                <div class="card-body text-success">
                    <asp:Label ID="lbSucesso" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btFecharSucesso" runat="server" Text="" CssClass="btn-close" OnClick="btFecharSucesso_Click"/>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
