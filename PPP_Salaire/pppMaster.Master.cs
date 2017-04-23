using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class pppMaster : System.Web.UI.MasterPage
    {

        public string user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["user"].ToString();

            if (Session["user"].ToString() != "admin")
            {
                GestionSalaireitem.Visible = false;
                GestionCongeitem.Visible = false;
                //DemanderCongeitem.Visible = false;
                GestionEmployeitem.Visible = false;
                AddEmployeritem.Visible = false;
                GestionCategorieitem.Visible = false;
                AddCategoryitem.Visible = false;
                parametrage.Visible = false;

            }


        }
    }
}