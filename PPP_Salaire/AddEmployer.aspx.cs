using PPP_Salaire.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class AddEmployer : System.Web.UI.Page
    {
    

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                FormView1.InsertItem(true);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                string script = "alert(\"This login exists!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
              
            }
        
    }
    }
}