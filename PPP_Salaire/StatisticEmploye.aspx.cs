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
using System.Configuration;

namespace PPP_Salaire
{
    public partial class StatisticEmploye : System.Web.UI.Page
    {
        IEmployeRepository employeRepository = new EmployeRepository();
        DBContext employeeDBContext = new DBContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string employeId = Request.QueryString["Id"];
            Employe employe = this.employeRepository.GetById(Convert.ToInt32(employeId));
            this.SqlDSEmployeConge.SelectCommand = " SELECT* FROM[DemandeConges] where Employe_Id =" + employe.Id;
            if (!IsPostBack)
            {
                GetData();
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
            Chart.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
            GetData();
        }

        private void GetData()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            SqlDSEmployeConge.ConnectionString = connetionString;
            Chart.ChartAreas["ChartArea1"].AxisY.Title = "NbreJours";
            Chart.ChartAreas["ChartArea1"].AxisX.Title = "DateDebut";
            Chart.Series["Series1"].XValueMember = "DateDebut";
            Chart.Series["Series1"].YValueMembers = "NbreJours";
        }

    }
}