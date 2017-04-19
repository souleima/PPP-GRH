﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class StatisticsConge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.GridView1.SelectedRow;
            Response.Redirect("~/StatisticEmploye.aspx?Id=" + row.Cells[1].Text);
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
            GetData();
        }
        private void GetData()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            SqlDSChart.ConnectionString = connetionString;
            SqlDSChart.SelectCommand = "SELECT Employes.Id, COUNT(DemandeConges.NbreJours) AS Expr1 FROM DemandeConges " +
                "INNER JOIN Employes ON DemandeConges.Employe_Id = Employes.Id Group By Employes.Id";
            Chart.ChartAreas["ChartArea1"].AxisY.Title = "Somme des jours conges";
            Chart.ChartAreas["ChartArea1"].AxisX.Title = "Id Employe";
            Chart.Series["Series1"].XValueMember = "Id";
            Chart.Series["Series1"].YValueMembers = "Expr1";
        }
    }
}