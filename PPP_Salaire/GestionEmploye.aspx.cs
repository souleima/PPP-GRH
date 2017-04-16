using PPP_Salaire.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class GestionEmploye : System.Web.UI.Page
    {

      
        protected void Show_Click(object sender, EventArgs e)
        {

          
        }

     

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddEmployer.aspx");
        }

        protected void GridViewEmployer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.GridViewEmployer.SelectedRow;
         
            Response.Redirect("~/AddEmployer.aspx?Id=" + row.Cells[1].Text);
        }
    }
}