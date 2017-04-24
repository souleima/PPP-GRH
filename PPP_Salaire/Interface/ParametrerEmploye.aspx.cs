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
    public partial class ParametrerEmploye : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (fields.Items.Count==0)
            { RenderCheckBoxes(typeof(Employe), this.fields); }

        }
        private void RenderCheckBoxes(Type myEntity, CheckBoxList targetList)
        {
            foreach (var item in myEntity.GetProperties())
            {
                var nomPropriete = item.Name;
                if (item.PropertyType.Namespace.Equals("System") && (!nomPropriete.Equals("Id")))
                {
                    ListItem lstitem = new ListItem();
                    lstitem.Value = "chkbx" + myEntity + nomPropriete;
                    if (XMLConfig.MyXMLUtilities.GetAttributes(myEntity.Name).Contains(nomPropriete))
                    {
                        lstitem.Enabled = false;
                        lstitem.Selected = true;
                    }
                    if (XMLConfig.MyXMLUtilities.GetAttributes(myEntity.Name).Contains(nomPropriete))
                    {
                        lstitem.Selected = true;
                    }
                    lstitem.Text = nomPropriete.Replace("_", " ");
                    targetList.Items.Add(lstitem);
                }
            }
        }

        private IList<string> getCheckedItems(CheckBoxList checkList)
        {
            IList<string> list = new List<string>();
            foreach (ListItem item in checkList.Items)
            {
                if (item.Selected == true)
                {
                    list.Add(item.Text);
                }
            }
            return list;
        }

        private IList<string> getNonDefaultCheckedItems(CheckBoxList checkList)
        {
            IList<string> list = new List<string>();
            foreach (ListItem item in checkList.Items)
            {
                if (item.Selected == true && item.Enabled == true)
                {
                    list.Add(item.Text.Replace(" ", "_"));
                }
            }
            return list;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            IList<string> il = getCheckedItems(fields);

            string appPath = HostingEnvironment.ApplicationPhysicalPath + @"\" + "fieldsemploye.xml";
            XmlDocument doc;
            doc = new XmlDocument();
          //  doc.Load(appPath);
            XmlTextWriter wr = new XmlTextWriter(appPath, System.Text.Encoding.UTF8);
            wr.Formatting = Formatting.Indented;
            wr.WriteStartDocument(true);
            wr.WriteStartElement("Employe");
            for (int i=0; i<il.Count;i++)
            {
                wr.WriteStartElement(il[i].ToString());
                wr.WriteEndElement();
            }
            wr.WriteEndDocument();
            wr.Flush();
            wr.Close();

            XMLConfig.MyXMLUtilities.UpdateChosenAttributes(typeof(Employe).Name, getNonDefaultCheckedItems(this.fields));
        }

    }

}