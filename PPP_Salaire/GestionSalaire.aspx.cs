using PPP_Salaire.Entities;
using PPP_Salaire.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class GestionSalaire : System.Web.UI.Page
    {
        private IEmployeRepository employeRepository = new EmployeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
                //lister tout les employes dans la gridView
                this.GridViewEmploye.DataSource = this.employeRepository.Lister();
                this.GridViewEmploye.DataBind();
                //configuration de la liste des noms des colonnes de la gridView pour le filtrage 
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM INFORMATION_SCHEMA.columns as name where table_name = 'Employes'", connetionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DropDownListRecherche.DataSource = dt;
                this.DropDownListRecherche.DataValueField = "COLUMN_NAME";
                this.DropDownListRecherche.DataTextField = "COLUMN_NAME";
                this.DropDownListRecherche.DataBind();

            }
        }
        protected void GridViewEmploye_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewEmploye.PageIndex = e.NewPageIndex;
            this.GridViewEmploye.DataSource = this.employeRepository.Lister();
            this.GridViewEmploye.DataBind();
        }
        protected void GridViewEmploye_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.GridViewEmploye.SelectedRow;
            Response.Redirect("~/SalaireEmploye.aspx?Id=" + row.Cells[1].Text);
        }
        //http://stackoverflow.com/questions/3757946/how-to-change-the-header-text-of-gridview-after-databound
        //http://stackoverflow.com/questions/14260753/get-the-gridview-column-header-text-always-returns-blank
        //http://stackoverflow.com/questions/16268996/asp-net-gridview-header-row-text-empty-when-allowsorting-enabled
        protected void GridViewEmploye_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    LinkButton Link = e.Row.Cells[i].Controls[0] as LinkButton;
                    Link.Text = Link.Text.Replace("_", " ");
                    //e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("_", " ");//when sorting is not enabled
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string columnName = this.DropDownListRecherche.SelectedValue;
            this.GridViewEmploye.DataSource = this.employeRepository.ListerBySelection(columnName, this.TxtArechrcher.Text);
            this.GridViewEmploye.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.GridViewEmploye.DataSource = this.employeRepository.Lister();
            this.GridViewEmploye.DataBind();
        }
    }
}