using PPP_Salaire.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Xml;
using System.Web.Hosting;
using PPP_Salaire.Entities;

namespace PPP_Salaire
{
    public partial class GestionProfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPPConnectionString"].ToString());
            conn.Open();
            string query = " SELECT * FROM sys.columns WHERE object_id=OBJECT_ID('dbo.Employes')";
            SqlCommand cmd = new SqlCommand(query, conn);
           // Table table = new Table();
            string appPath = HostingEnvironment.ApplicationPhysicalPath + @"\" + "fieldsemploye.xml";
            XmlDocument doc;
            doc = new XmlDocument();
            doc.Load(appPath);
            TextBox res = new TextBox();

            //    
          

            var columns = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {

                    foreach (XmlNode n in doc.ChildNodes[1].ChildNodes)
                        if (reader[1].ToString() == n.Name)
                        {
                            columns.Add(reader[1].ToString());
               
                        }

                }
            }

            string query1 = "Select * from Employes where login='" + Session["user"].ToString() + "'";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            conn.Close();
            conn.Open();
            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    for (int i = 0; i < columns.Count(); i++)
                    {
                        TableRow tr = new TableRow();
                        TableCell tc = new TableCell();
                        TableCell tc1 = new TableCell();
                        TextBox txtBox = new TextBox();
                        TextBox txtBox1 = new TextBox();
                        txtBox.Text = columns[i].ToString() ;
                        txtBox.Enabled = false;
                        txtBox1.Text = reader1[columns[i]].ToString();
                        txtBox1.Enabled = false;
                        tc.Controls.Add(txtBox);
                        tc1.Controls.Add(txtBox1);
                        tr.Cells.Add(tc);
                        tr.Cells.Add(tc1);
                        table.Rows.Add(tr);

                    }
                }



            }

                    // form1.Controls.Add(res);
                    form1.Controls.Add(table);

                }

 
    }
    }
