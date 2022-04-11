using DesafioACP.DAL;
using DesafioACP.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioACP
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AtualizaGrid();
        }

        public void AtualizaGrid()
        {
            DALUsuario dal = new DALUsuario();
            gvUsuario.DataSource = dal.Listar();
            gvUsuario.DataBind();
        }

        private void LimparCampos()
        {
            tbId.Text = "";
            tbNome.Text = "";
            tbEmail.Text = "";
            tbSenha.Text = "";
            gvUsuario.SelectedIndex = -1;
        }

        protected void btCadastrar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            this.LimparCampos();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
            Panel1.Visible = false;
        }

        protected void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                DALUsuario dal = new DALUsuario();
                ModeloUsuario obj = new ModeloUsuario();

                if (tbNome.Text == "")
                {
                    throw new Exception("Insira o nome do usuário.");
                }
                else
                {
                    obj.Nome = tbNome.Text;
                }

                if (tbEmail.Text == "")
                {
                    throw new Exception("Insira o e-mail do usuário.");
                }
                else
                {
                    obj.Email = tbEmail.Text;
                }

                if (tbId.Text == "") // Significa que é um cadastro de um novo usuário
                {
                    if (tbSenha.Text == "")
                    {
                        throw new Exception("Insira uma senha para o usuário.");
                    }
                    else
                    {
                        obj.Senha = tbSenha.Text;
                    }
                    dal.Inserir(obj);
                    painelErro.Visible = false;
                    painelSucesso.Visible = true;
                    lbSucesso.Text = "Usuário cadastrado com sucesso. Código do usuário gerado: " + obj.Id.ToString();
                }
                else // Significa que é uma alteração dos dados de um usuário existente
                {
                    if (tbSenha.Text != "")
                    {
                        obj.Senha = tbSenha.Text;
                    }
                    obj.Id = Convert.ToInt32(tbId.Text);
                    dal.Alterar(obj);
                    painelErro.Visible = false;
                    painelSucesso.Visible = true;
                    lbSucesso.Text = "Usuário alterado com sucesso.";
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

        //protected void gvUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int index = e.RowIndex;
        //    int cod = Convert.ToInt32(gvUsuario.Rows[index].Cells[0].Text);
        //    DALUsuario dal = new DALUsuario();
        //    //dal.Excluir(cod);
        //    AtualizaGrid();
        //}

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;

            int index = gvUsuario.SelectedIndex;
            int cod = Convert.ToInt32(gvUsuario.Rows[index].Cells[0].Text);
            DALUsuario dal = new DALUsuario();
            ModeloUsuario obj = dal.GetRegistro(cod);
            tbId.Text = obj.Id.ToString();
            tbNome.Text = obj.Nome;
            tbEmail.Text = obj.Email;
        }

        protected void gvUsuario_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (gvUsuario.SelectedIndex == e.NewSelectedIndex)
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
    }
}