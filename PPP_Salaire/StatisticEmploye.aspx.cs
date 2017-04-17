using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using PPP_Salaire.Entities;
using PPP_Salaire.Repositories;

namespace PPP_Salaire
{
    public partial class StatisticEmploye : System.Web.UI.Page
    {
        private EmployeRepository employeRepository = new EmployeRepository();
        PPPDBContext employeeDBContext = new PPPDBContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string employeId = Request.QueryString["Id"];
            Employe employe = this.employeRepository.GetById(Convert.ToInt32(employeId));
            this.SqlDataSource2.SelectCommand = " SELECT* FROM[DemandeConges] where Employe_Id =" + employe.Id;
            if (!IsPostBack)
            {
                GetChartTypes();

            }
        }

        private void GetChartTypes()
        {
            foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType), chartType), chartType.ToString());
                DropDownList1.Items.Add(li);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
        }

    }
}