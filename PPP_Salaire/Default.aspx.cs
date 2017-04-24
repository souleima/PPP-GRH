using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PPP_Salaire
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPPConnectionString"].ToString());
            conn.Open();
            string query = " select count(*) from Employes where login='" + logintext.Text + "' and  password='" + password.Text + "'";
            SqlCommand cmd = new SqlCommand(query,conn);
            string output = cmd.ExecuteScalar().ToString();
            if (output == "1")
            {

                Session["user"] = logintext.Text;
                Response.Redirect("DemanderConge.aspx");
            }
            else
                Faillogin.Text="Login Failed";


        }
    }
}