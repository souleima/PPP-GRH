using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class GestionConge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.GridView1.SelectedRow;
            Response.Redirect("~/CongeEmploye.aspx?Id=" + row.Cells[1].Text);
        }
    }
}