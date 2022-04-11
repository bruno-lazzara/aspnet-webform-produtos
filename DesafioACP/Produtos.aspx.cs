using DesafioACP.DAL;
using DesafioACP.MODELO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioACP
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AtualizaGrid();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        public void AtualizaGrid()
        {
            DALProduto dal = new DALProduto();
            gvProduto.DataSource = dal.Listar();
            gvProduto.DataBind();
        }

        private void LimparCampos()
        {
            tbId.Text = "";
            tbProduto.Text = "";
            tbPreco.Text = "";
            tbQuantidade.Text = "";
            gvProduto.SelectedIndex = -1;
        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            this.LimparCampos();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
            Panel1.Visible = false;
            painelErro.Visible = false;
            painelSucesso.Visible = false;
        }

        protected void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                DALProduto dal = new DALProduto();
                ModeloProduto obj = new ModeloProduto();

                if (tbProduto.Text == "")
                {
                    throw new Exception("Insira um nome para o produto.");
                }
                else
                {
                    obj.NomeProduto = tbProduto.Text;
                }

                if (tbPreco.Text != "")
                {
                    if (Convert.ToInt32(tbPreco.Text) < 0)
                    {
                        throw new Exception("Preço inválido. O preço do produto deve ser maior ou igual a zero.");
                    }
                    else
                    {
                        obj.Preco = Convert.ToInt32(tbPreco.Text);
                    }
                }

                if (tbQuantidade.Text != "")
                {
                    if (Convert.ToInt32(tbQuantidade.Text) < 0)
                    {
                        throw new Exception("Quantidade inválida. A quantidade de produtos deve ser maior ou igual a zero.");
                    }
                    else
                    {
                        obj.Quantidade = Convert.ToInt32(tbQuantidade.Text);
                    }
                }

                obj.UltimaAlteracaoPor = Convert.ToInt32(Session["id"]);

                if (tbId.Text == "") // Significa que é um cadastro de um novo produto
                {
                    dal.Inserir(obj);
                    painelErro.Visible = false;
                    painelSucesso.Visible = true;
                    lbSucesso.Text = "Produto cadastrado com sucesso. Código do produto gerado: " + obj.Id.ToString();
                }
                else // Significa que é uma alteração dos dados de um produto existente
                {
                    obj.Id = Convert.ToInt32(tbId.Text);
                    dal.Alterar(obj);
                    painelErro.Visible = false;
                    painelSucesso.Visible = true;
                    lbSucesso.Text = "Produto alterado com sucesso.";
                }

                this.LimparCampos();
            }
            catch (Exception ex)
            {
                painelSucesso.Visible = false;
                painelErro.Visible = true;
                lbErro.Text = ex.Message;
            }

            AtualizaGrid();
        }

        protected void gvProduto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int alteradoPor = Convert.ToInt32(Session["id"]);
            int index = e.RowIndex;
            int cod = Convert.ToInt32(gvProduto.Rows[index].Cells[0].Text);
            DALProduto dal = new DALProduto();
            dal.ExcluirQuantidade(cod, alteradoPor);
            AtualizaGrid();
        }

        protected void gvProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;

            int index = gvProduto.SelectedIndex;
            int cod = Convert.ToInt32(gvProduto.Rows[index].Cells[0].Text);
            DALProduto dal = new DALProduto();
            ModeloProduto obj = dal.GetRegistro(cod);
            tbId.Text = obj.Id.ToString();
            tbProduto.Text = obj.NomeProduto;
            tbPreco.Text = obj.Preco.ToString();
            tbQuantidade.Text = obj.Quantidade.ToString();
        }

        protected void gvProduto_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (gvProduto.SelectedIndex == e.NewSelectedIndex)
            {
                e.Cancel = true;
                LimparCampos();
            }
        }

        protected void btFecharErro_Click(object sender, EventArgs e)
        {
            painelErro.Visible = false;
        }

        protected void btFecharSucesso_Click(object sender, EventArgs e)
        {
            painelSucesso.Visible = false;
        }

        protected void btExportar_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    this.AtualizaGrid();
                    string fonte = gvProduto.Font.ToString();
                    gvProduto.Columns[5].Visible = false;
                    gvProduto.Columns[6].Visible = false;

                    Phrase phrase = new Phrase();
                    phrase.Add(new Chunk("\nNome da Empresa\n\n", FontFactory.GetFont(fonte, 18, Font.BOLD)));
                    phrase.Add(new Chunk("Relatório de Estoque\n\n", FontFactory.GetFont(fonte, 14)));
                    phrase.Add(new Chunk("Gerado por:\n", FontFactory.GetFont(fonte)));
                    phrase.Add(new Chunk(Session["nome"].ToString() + "\n", FontFactory.GetFont(fonte)));
                    phrase.Add(new Chunk(Session["email"].ToString() + "\n\n", FontFactory.GetFont(fonte)));
                    phrase.Add(new Chunk("Tabela 'produto' exportada em " + DateTime.Now.ToString() + "\n", FontFactory.GetFont(fonte)));

                    gvProduto.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    pdfDoc.Add(phrase);
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Tabela_de_produtos_" + DateTime.Now.ToString() + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}