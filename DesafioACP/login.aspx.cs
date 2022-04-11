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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btEntrar_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string senha = tbSenha.Text;

            DALUsuario dal = new DALUsuario();
            ModeloUsuario obj = dal.GetRegistro(email);

            if (email != "" && email == obj.Email && senha == obj.Senha)
            {
                Session["id"] = obj.Id;
                Session["nome"] = obj.Nome;
                Session["email"] = email;
                lbErro.Visible = false;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lbErro.Visible = true;
                lbErro.Text = "E-mail e/ou senha incorretos.";
            }
        }
    }
}