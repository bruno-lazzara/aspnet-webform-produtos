using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioACP
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                lbUsuarioLogado.Visible = true;
                lbUsuarioLogado.Text = "Usuário: " + Session["email"].ToString();
            }
        }
    }
}