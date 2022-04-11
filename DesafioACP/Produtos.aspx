<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="DesafioACP.Produtos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-xxl">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Estoque de produtos" Font-Size="Large"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvProduto" runat="server" AutoGenerateColumns="False" CellPadding="3" Width="900px" OnRowDeleting="gvProduto_RowDeleting" CssClass="table table-hover table-bordered" OnSelectedIndexChanged="gvProduto_SelectedIndexChanged" OnSelectedIndexChanging="gvProduto_SelectedIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="id">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Nome do Produto" DataField="nome">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Quantidade" DataField="quantidade">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="preco" HeaderText="Preço">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="usuario" HeaderText="Última Edição">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:CommandField SelectText="Editar" ShowSelectButton="True">
                    <ControlStyle CssClass="btn btn-primary" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True">
                    <ControlStyle CssClass="btn btn-danger" />
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
        <asp:Button ID="btInserir" runat="server" CssClass="btn btn-success" Text="Inserir novo produto" OnClick="btInserir_Click" />
        <asp:LinkButton runat="server" ID="btExportar" ValidationGroup="edt" CssClass="btn btn-outline-danger" OnClick="btExportar_Click" Style="margin-left: 10px;">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-file-pdf" viewBox="0 0 16 16">
                <path d="M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"/>
                <path d="M4.603 12.087a.81.81 0 0 1-.438-.42c-.195-.388-.13-.776.08-1.102.198-.307.526-.568.897-.787a7.68 7.68 0 0 1 1.482-.645 19.701 19.701 0 0 0 1.062-2.227 7.269 7.269 0 0 1-.43-1.295c-.086-.4-.119-.796-.046-1.136.075-.354.274-.672.65-.823.192-.077.4-.12.602-.077a.7.7 0 0 1 .477.365c.088.164.12.356.127.538.007.187-.012.395-.047.614-.084.51-.27 1.134-.52 1.794a10.954 10.954 0 0 0 .98 1.686 5.753 5.753 0 0 1 1.334.05c.364.065.734.195.96.465.12.144.193.32.2.518.007.192-.047.382-.138.563a1.04 1.04 0 0 1-.354.416.856.856 0 0 1-.51.138c-.331-.014-.654-.196-.933-.417a5.716 5.716 0 0 1-.911-.95 11.642 11.642 0 0 0-1.997.406 11.311 11.311 0 0 1-1.021 1.51c-.29.35-.608.655-.926.787a.793.793 0 0 1-.58.029zm1.379-1.901c-.166.076-.32.156-.459.238-.328.194-.541.383-.647.547-.094.145-.096.25-.04.361.01.022.02.036.026.044a.27.27 0 0 0 .035-.012c.137-.056.355-.235.635-.572a8.18 8.18 0 0 0 .45-.606zm1.64-1.33a12.647 12.647 0 0 1 1.01-.193 11.666 11.666 0 0 1-.51-.858 20.741 20.741 0 0 1-.5 1.05zm2.446.45c.15.162.296.3.435.41.24.19.407.253.498.256a.107.107 0 0 0 .07-.015.307.307 0 0 0 .094-.125.436.436 0 0 0 .059-.2.095.095 0 0 0-.026-.063c-.052-.062-.2-.152-.518-.209a3.881 3.881 0 0 0-.612-.053zM8.078 5.8a6.7 6.7 0 0 0 .2-.828c.031-.188.043-.343.038-.465a.613.613 0 0 0-.032-.198.517.517 0 0 0-.145.04c-.087.035-.158.106-.196.283-.04.192-.03.469.046.822.024.111.054.227.09.346z"/>
            </svg> Exportar
        </asp:LinkButton>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="False" CssClass="auto-style1" Style="display: inline-block; margin-right: 20px; margin-top: 10px;">
            <form>
                <div class="mb-3">
                    <label class="form-label">Código do Produto</label>
                    <asp:TextBox ID="tbId" runat="server" CssClass="form-control-sm" Enabled="False"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Nome do Produto</label>
                    <asp:TextBox ID="tbProduto" runat="server" CssClass="form-control-sm" Style="float: right;"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Preço</label>
                    <asp:TextBox ID="tbPreco" runat="server" CssClass="form-control-sm" TextMode="Number" Style="float: right;"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Quantidade</label>
                    <asp:TextBox ID="tbQuantidade" runat="server" CssClass="form-control-sm" TextMode="Number" Style="float: right;"></asp:TextBox>
                </div>
                <asp:Button ID="btConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btConfirmar_Click" />
                <asp:Button ID="btCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btCancelar_Click" />
            </form>
        </asp:Panel>
        <asp:Panel ID="painelErro" runat="server" Visible="False" Style="vertical-align: top; display: inline-block; margin-left: 10px; margin-right: 10px">
            <div class="card border-danger mb-3" style="max-width: 18rem;">
                <div class="card-header">Erro</div>
                <div class="card-body text-danger">
                    <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btFecharErro" runat="server" Text="" CssClass="btn-close" OnClick="btFecharErro_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="painelSucesso" runat="server" Style="vertical-align: top; display: inline-block; margin-left: 10px; margin-right: 10px" Visible="False">
            <div class="card border-success mb-3" style="max-width: 18rem;">
                <div class="card-body text-success">
                    <asp:Label ID="lbSucesso" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btFecharSucesso" runat="server" Text="" CssClass="btn-close" OnClick="btFecharSucesso_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
