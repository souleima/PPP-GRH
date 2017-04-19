using PPP_Salaire.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class AjouterConge : System.Web.UI.Page
    {
        CongeRepository CongeRepo = new CongeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            SqlDSConge.ConnectionString = connetionString;
            SqlDSConge.SelectCommand = CongeRepo.Select();
            SqlDSConge.InsertCommand = CongeRepo.Inserer();

        }

    }
}