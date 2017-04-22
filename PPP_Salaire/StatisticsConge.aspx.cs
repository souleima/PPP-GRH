using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        //retrieve the Chart type selected
        private void GetChartTypes()
        {
            foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType), chartType), chartType.ToString());
                DropDownList1.Items.Add(li);
            }
        }
        //Show the statistics of a selected employe
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.GridView1.SelectedRow;
            Response.Redirect("~/StatisticEmploye.aspx?Id=" + row.Cells[1].Text);
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
    }
}