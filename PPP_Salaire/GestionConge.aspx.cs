using PPP_Salaire.Entities;
using PPP_Salaire.Repositories;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
namespace PPP_Salaire
{
    public partial class GestionConge : System.Web.UI.Page
    {
        DBContext employeeDBContext = new DBContext();
        IEmployeRepository employeRep = new EmployeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
                //lister tout les employes dans la gridView
                this.GridViewEmploye.DataSource = this.employeRep.Lister();
                this.GridViewEmploye.DataBind();
                //configuration de la liste des noms des colonnes de la gridView pour le filtrage 
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM INFORMATION_SCHEMA.columns as name where table_name = 'Employes'", connetionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "COLUMN_NAME";
                DropDownList1.DataTextField = "COLUMN_NAME";
                DropDownList1.DataBind();
            }

        }
        //adapter au changement de l'index de la gridView
        protected void GridViewEmploye_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewEmploye.PageIndex = e.NewPageIndex;
            this.GridViewEmploye.DataSource = this.employeRep.Lister();
            this.GridViewEmploye.DataBind();
        }
        //lancer la page correspondante à la selction de l'employe dans la gridView
        protected void GridViewEmploye_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.GridViewEmploye.SelectedRow;
            Response.Redirect("~/CongeEmploye.aspx?Id=" + row.Cells[1].Text);
        }
        //attacher les donnens aux lignes de la gridView
        protected void GridViewEmploye_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    LinkButton Link = e.Row.Cells[i].Controls[0] as LinkButton;
                }
            }
        }
        //fonction pour filtrage des donnees dans la gridView
        protected void FilterResult(object sender, EventArgs e)
        {
            string columnName = DropDownList1.SelectedValue;
            this.GridViewEmploye.DataSource = this.employeRep.ListerBySelection(columnName, TxId.Text);
            this.GridViewEmploye.DataBind();

        }

    }
}