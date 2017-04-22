using PPP_Salaire.Entities;
using PPP_Salaire.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class CongeEmploye : System.Web.UI.Page
    {

        private IDemandeCongeRepository employeCongeRepository = new DemandeCongeRepositiry();
        private IEmployeRepository employeRepository = new EmployeRepository();
        DBContext employeeDBContext = new DBContext();
        string connetionString;
        string columnName;
        int IdUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            string employeId = Request.QueryString["Id"];
            //stocker l'id de l'utilisateur connecté
            IdUser = employeRepository.GetByLogin(Session["user"].ToString());
            Employe employe = this.employeRepository.GetById(Convert.ToInt32(employeId));
            connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;

            if (employe == null)
                Response.Redirect("~/GestionSalaire.aspx");
            else
            {

                if (!Page.IsPostBack)
                {
                    FillData(employe);
                }
            }
        }
        //remplir les donnees correspondantes à l'employe choisi
        private void FillData(Employe emp)
        {
            this.GridViewDemande.DataSource = employeCongeRepository.GetByEmployeId(emp.Id);
            this.GridViewDemande.DataBind();

            //config de la list des colonnes de la gridView pour le filtrage 
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM INFORMATION_SCHEMA.columns as name where table_name = 'DemandeConges'", connetionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownListColumn.DataSource = dt;
            DropDownListColumn.DataValueField = "COLUMN_NAME";
            DropDownListColumn.DataTextField = "COLUMN_NAME";
            DropDownListColumn.DataBind();
        }
        //specifier que la demande n'est pas etait traité par l'admin --- > accepte ou refuse
        protected Boolean IsEnAttente(String Status)
        {
            return Status.Equals("EN_ATTENTE");
        }
        //updater le status de la demande concernée :
        //accepter
        protected void btAccept_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldID");
            var result = employeeDBContext.DemandeConges.SingleOrDefault((dem => dem.Id.ToString().Equals(hd.Value)));
            if (result != null)
            {
                result.Status = "ACCEPTE";
                employeeDBContext.SaveChanges();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Demande Acceptee'); window.location='" 
                + Request.ApplicationPath + "CongeEmploye.aspx?Id="+ Request.QueryString["Id"] + "';", true);
        }
        //refuser
        protected void btRefuser_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldID2");
            var result = employeeDBContext.DemandeConges.SingleOrDefault((dem => dem.Id.ToString().Equals(hd.Value)));
            if (result != null)
            {
                result.Status = "REFUSE";
                employeeDBContext.SaveChanges();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Demande Refusee'); window.location='" 
                + Request.ApplicationPath + "CongeEmploye.aspx?Id=" + Request.QueryString["Id"] + "';", true);
        }
        //changer l'index de la gripView 
        protected void GridViewDemande_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewDemande.PageIndex = e.NewPageIndex;
            this.GridViewDemande.DataSource = this.employeCongeRepository.Lister();
            this.GridViewDemande.DataBind();
        }
        //fondtion de recherche dans la gridView
        protected void FilterResult(object sender, EventArgs e)
        {
            columnName = DropDownListColumn.SelectedValue;
            this.GridViewDemande.DataSource = this.employeCongeRepository.ListerBySelection(columnName, TxId.Text, IdUser);
            this.GridViewDemande.DataBind();

        }
    }
}