using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioACP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbNome.Text = Session["nome"].ToString();
            lbEmail.Text = Session["email"].ToString();
        }
    }
}