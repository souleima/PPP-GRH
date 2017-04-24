using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPP_Salaire.Repositories;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;

namespace PPP_Salaire
{
    public partial class DemanderConge : System.Web.UI.Page
    {
        DBContext employeeDBContext = new DBContext();
        IDemandeCongeRepository demandeCongeRep = new DemandeCongeRepositiry();
        IEmployeRepository employeRep = new EmployeRepository();
        ICongeRepository congeRep = new CongeRepository();
        int IdSelectedConge;
        public static List<DateTime> list = new List<DateTime>();
        DateTime DateDebut, DateFin;
        string columnName;
        int IdUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            //stocker l'id de l'utilisateur connecté
            IdUser = employeRep.GetByLogin(Session["user"].ToString());
            if (!IsPostBack)
            {
                string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
                //charger les demandes de conges correspondantes à ce user
                BindGrid();
                //Specify the connectionString , insert, select cmd of the formView
                SqlDSForm.SelectCommand = demandeCongeRep.Select();
                SqlDSForm.ConnectionString = connetionString;
                //configuration de la liste des types de conges
                SqlDSList.ConnectionString = connetionString;
                SqlDSList.SelectCommand = congeRep.Select();
                //config de la list des colonnes de la gridView pour le filtrage 
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM INFORMATION_SCHEMA.columns as name where table_name = 'DemandeConges'", connetionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownListColumn.DataSource = dt;
                DropDownListColumn.DataValueField = "COLUMN_NAME";
                DropDownListColumn.DataTextField = "COLUMN_NAME";
                DropDownListColumn.DataBind();
            }
        }
        private void BindGrid()
        {
            //charger les demandes de conges correspondantes à ce user
            this.GridViewDemandesConge.DataSource = this.demandeCongeRep.ListerById(IdUser);
            this.GridViewDemandesConge.DataBind();
        }
        //supprimer demande si son status est "EN_ATTENTE" par clik sur le boutton "Annuler"
        protected void BtAnuulerDemande_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldID");
            var result = employeeDBContext.DemandeConges.SingleOrDefault((dem => dem.Id.ToString().Equals(hd.Value)));
            if (result != null)
            {
                employeeDBContext.DemandeConges.Remove(result);
                employeeDBContext.SaveChanges();
            }
            Show(" Demande Supprimé");
            Response.Redirect("DemanderConge.aspx");
        }
        //specifier que la demande n'est pas etait traité par l'admin --- > peut etre supprimé
        protected Boolean IsEnAttente(String Status)
        {
            return Status.Equals("EN_ATTENTE");
        }
        //selctionner deux jours sur le calendrier 
        protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (list.Count() < 1)
            {
                if (e.Day.IsSelected == true)
                {
                    list.Add(e.Day.Date);
                }
                Session["SelectedDates"] = list;
            }
        }
        //updater le changement des selections sur le calendrier
        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    Calendar.SelectedDates.Add(dt);
                }
            }
        }
        //specifier la commande d'insertion du formulaire de demande de conge
        protected void FormDemande_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            if (Calendar.SelectedDates.Count == 0)
            {
                Show("Select tow dates from the calendar");
            }
            else
            {
                DateDebut = Calendar.SelectedDates[0];
                DateFin = Calendar.SelectedDates[1];
            }
            //recuperer l'id du conge selectionner dans la liste
            IdSelectedConge = this.DropDownList1.SelectedIndex;
            //commande d'insertion de la demande
            SqlDSForm.InsertCommand = demandeCongeRep.Inserer(IdSelectedConge + 1, DateDebut, DateFin, IdUser);
        }
        //traitement suite a l'insertion
        protected void FormDemande_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Calendar.SelectedDates.Clear();
            list.Clear();
            Show("Demande Envoyé");
        }
        //fonction de popup
        public void Show(string msg)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + msg + "'); window.location='" + Request.ApplicationPath + "Interface/DemanderConge.aspx';", true);

            }
        }
        //fondtion de recherche dans la gridView
        protected void FilterResult(object sender, EventArgs e)
        {
            columnName = DropDownListColumn.SelectedValue;
            this.GridViewDemandesConge.DataSource = this.demandeCongeRep.ListerBySelection(columnName, TxId.Text, IdUser);
            this.GridViewDemandesConge.DataBind();

        }
        //changer l'index de la gripView 
        protected void GridViewEmploye_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewDemandesConge.PageIndex = e.NewPageIndex;
            this.GridViewDemandesConge.DataSource = this.demandeCongeRep.Lister();
            this.GridViewDemandesConge.DataBind();
        }
        //attacher les donnees avec les lignes de la gridView
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
        //charger la gridView dans un fichier excel
        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridViewDemandesConge.AllowPaging = false;
                this.BindGrid();

                GridViewDemandesConge.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridViewDemandesConge.HeaderRow.Cells)
                {
                    cell.BackColor = GridViewDemandesConge.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridViewDemandesConge.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridViewDemandesConge.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridViewDemandesConge.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridViewDemandesConge.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //  Confirms that an HtmlForm control is rendered for the specified ASP.NET server control at run time.
        }
    }
}