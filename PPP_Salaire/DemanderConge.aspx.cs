using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPP_Salaire.Repositories;
using System.Configuration;

namespace PPP_Salaire
{
    public partial class DemanderConge : System.Web.UI.Page
    {

        DBContext employeeDBContext = new DBContext();
        DemandeCongeRepositiry demandeCongeRep = new DemandeCongeRepositiry();
        CongeRepository congeRep = new CongeRepository();
        int IdSelectedConge;
        public static List<DateTime> list = new List<DateTime>();
        public static List<DateTime> ListDates = new List<DateTime>();
        DateTime DateDebut,DateFin;

        protected void Page_Load(object sender, EventArgs e)
        {

            string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            //get the selected item Id (correspondant to the DB id ) from the dropdown list
            IdSelectedConge = this.DropDownList1.SelectedIndex;
            //Specify the connectionString , insert, select cmd of the formView
            SqlDSForm.SelectCommand = demandeCongeRep.Select();
            SqlDSForm.ConnectionString = connetionString;
            //DropdownList
            SqlDSList.ConnectionString = connetionString;
            SqlDSList.SelectCommand = congeRep.Select();
            //GridView
            SqlDSGrid.ConnectionString = connetionString;
            SqlDSGrid.SelectCommand = "SELECT[Id], [DateDebut], [DateFin], [DateSubmit], [CongeID], [NbreJours], [Raison], [Status] FROM[DemandeConges]";

        }
        
        //Delete the "DemandeConge" befor it's handeled by the admin ( 'EN_ATTENTE')
        protected void Button1_Click(object sender, EventArgs e)
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

        //Specify if the item is pending show the delete button for the employe
        protected Boolean IsEnAttente(String Status)
        {
            return Status.Equals("EN_ATTENTE");
        }

        protected void FormDemande_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Calendar.SelectedDates.Clear();
            ListDates.Clear();
            list.Clear();
            Show("Demande Envoyé");
        }

        public void Show(string msg)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('"+msg+"'); window.location='" + Request.ApplicationPath + "DemanderConge.aspx';", true);

            }
        }

        protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (list.Count() < 2) { 
            if (e.Day.IsSelected == true )
            {
                list.Add(e.Day.Date);
            }
            Session["SelectedDates"] = list;
            }
        }

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

        protected void FormDemande_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            DateDebut = Calendar.SelectedDates[0];
            DateFin = Calendar.SelectedDates[1];
            SqlDSForm.InsertCommand = demandeCongeRep.Inserer(IdSelectedConge+1, DateDebut, DateFin);
        }
    }
}