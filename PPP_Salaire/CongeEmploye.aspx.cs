using PPP_Salaire.Entities;
using PPP_Salaire.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class CongeEmploye : System.Web.UI.Page
    {

        private EmployeRepository employeRepository = new EmployeRepository();
        DBContext employeeDBContext = new DBContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string employeId = Request.QueryString["Id"];
            Employe employe = this.employeRepository.GetById(Convert.ToInt32(employeId));

            if (!Page.IsPostBack)
            {
                FillData(employe);
            }
        }
        private void FillData(Employe emp)
        {
            this.GridView1.DataSource = employeeDBContext.DemandeConges.Where(
                demande => demande.Employe.Id == emp.Id ).ToList();
            this.GridView1.DataBind();
        }
        protected Boolean IsEnAttente(String Status)
        {
            return Status.Equals("EN_ATTENTE");
        }

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
        }

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
        }
    }
}