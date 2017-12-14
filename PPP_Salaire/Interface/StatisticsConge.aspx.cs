using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Data;

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
        //retrieve the Chart type selected
        private void GetChartTypes()
        {
            foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem(Enum.GetName(typeof(SeriesChartType), chartType), chartType.ToString());
                DropDownList1.Items.Add(li);
            }
        }
        //Show the statistics of a selected employe
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.GridView1.SelectedRow;
            Response.Redirect("~/Interface/StatisticEmploye.aspx?Id=" + row.Cells[1].Text);
        }
        //load the selected chart type
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
            LoadData();
        }
        //get the data to display in the chart according to the user selection
        private void GetData()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            //dropdownlist config --> select column's names 
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT table_name FROM INFORMATION_SCHEMA.TABLES", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownListTable.DataSource = ds;
                DropDownListTable.DataTextField = "table_name";
                DropDownListTable.DataValueField = "table_name";
                DropDownListTable.DataBind();
                con.Close();
            }
            //dropdownlist config --> select column's names 
            string tableName = DropDownListTable.SelectedValue;
            string cmdX = "SELECT * FROM INFORMATION_SCHEMA.columns as name where table_name = '" + tableName + "'";
            SqlDataAdapter daX = new SqlDataAdapter(cmdX, connetionString);
            DataTable dt = new DataTable();
            daX.Fill(dt);
            //load the columns' names in the list for the X axis
            DropDownListX.DataSource = dt;
            DropDownListX.DataValueField = "COLUMN_NAME";
            DropDownListX.DataTextField = "COLUMN_NAME";
            DropDownListX.DataBind();
            //load the columns' names in the list for the Y axis
            DropDownListY.DataSource = dt;
            DropDownListY.DataValueField = "COLUMN_NAME";
            DropDownListY.DataTextField = "COLUMN_NAME";
            DropDownListY.DataBind();

        }
        //load the selected table column names
        protected void DropDownListTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListX.Items.Clear();
            string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            string tableName = DropDownListTable.SelectedValue;
            string cmdX = "SELECT * FROM INFORMATION_SCHEMA.columns as name where table_name = '" + tableName + "'";
            //dropdownlist config --> select column's names 
            SqlDataAdapter daX = new SqlDataAdapter(cmdX, connetionString);
            DataTable dt = new DataTable();
            daX.Fill(dt);
            DropDownListX.DataSource = dt;
            DropDownListX.DataValueField = "COLUMN_NAME";
            DropDownListX.DataTextField = "COLUMN_NAME";
            DropDownListX.DataBind();
            DropDownListY.DataSource = dt;
            DropDownListY.DataValueField = "COLUMN_NAME";
            DropDownListY.DataTextField = "COLUMN_NAME";
            DropDownListY.DataBind();
        }
        //show the Chart with the user specifications
        protected void BtChart_Click(object sender, EventArgs e)
        {
            LoadData();

        }
        public void LoadData()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            SqlDSChart.ConnectionString = connetionString;
            SqlDSChart.SelectCommand = "SELECT " + DropDownListX.SelectedValue + " , " + DropDownListY.SelectedValue + " From " + DropDownListTable.SelectedValue;

            //fix the axis names
            Chart.ChartAreas["ChartArea1"].AxisY.Title = tbY.Text;
            Chart.ChartAreas["ChartArea1"].AxisX.Title = tbX.Text;

            //set the axis value sources
            Chart.Series["Series1"].XValueMember = DropDownListX.SelectedValue;
            Chart.Series["Series1"].YValueMembers = DropDownListY.SelectedValue;
        }
        ////Working on this ...................
        //protected void btnExportPDF_Click(object sender, EventArgs e)
        //{
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        this.Chart.SaveImage(stream, ChartImageFormat.Png);
        //        iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
        //        chartImage.ScalePercent(75f);
        //        pdfDoc.Add(chartImage);
        //        pdfDoc.Close();

        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=Chart.pdf");
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.Write(pdfDoc);
        //        Response.End();
        //    }
        //}

    }
}