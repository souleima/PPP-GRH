using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class DemanderConge : System.Web.UI.Page
    {

        PPPDBContext employeeDBContext = new PPPDBContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int id = int.Parse(DropDownList1.SelectedValue);
            TextBox tx = (TextBox)(this.FormView1.FindControl("CongeIDTextBox"));
            tx.Text = DropDownList1.SelectedValue;
        }

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
        }

        protected Boolean IsEnAttente(int Id)
        {
            var result = employeeDBContext.DemandeConges.SingleOrDefault((dem => dem.Id == Id));
            Console.WriteLine(result.Status);
            return result.Status.Equals("EN_ATTENTE");
        }

        protected void FormView1_DataBound(object sender, EventArgs e)
        {

            TextBox tx =this.FormView1.FindControl("Employe_IdTextBox") as TextBox;
            tx.Text = "1";
        }
        //protected void DateDebut_clicked(object sender, EventArgs e)
        //{
        //    TextBox tx =(TextBox) (this.FormView1.FindControl("DateDebutLabel"));
        //    //tx.Text = 
        //    Calendar1.Visible = true;
        //}
    }
}