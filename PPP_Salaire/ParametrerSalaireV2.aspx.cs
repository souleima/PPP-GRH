using PPP_Salaire.Entities;
using PPP_Salaire.XMLConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace PPP_Salaire
{
    public partial class ParametrerSalaireV2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["expressionsAttSalaire"] = new Dictionary<int, string>();
                ViewState["expressionsCotisation"] = new Dictionary<int, string>();
                ViewState["expressionsRemuneration"] = new Dictionary<int, string>();
                ViewState["expressionsArithmethiques"] = new Dictionary<int, string>();
                ViewState["expressionsIndice"] = 0;

                RenderCheckBoxes(typeof(Salaire), this.ChkListAttSalaire);
                RenderCheckBoxes(typeof(Remuneration), this.ChkListRemuneration);
                RenderCheckBoxes(typeof(Cotisation), this.ChkListCotisation);

                foreach (var item in this.DivKeys.Controls)
                {
                    if (item is Button)
                        ((Button)item).Enabled = false;
                }



            }
            IDictionary<int, string>[] dictTab = MyXMLUtilities.GetRegle();
            IDictionary<int, string> dictSal = dictTab[0];
            IDictionary<int, string> dictRemun = dictTab[1];
            IDictionary<int, string> dictCotis = dictTab[2];
            IDictionary<int, string> dictArith = dictTab[3];
            for (int i = 0; i < dictSal.Count + dictRemun.Count + dictCotis.Count + dictArith.Count; i++)
            {
                Label lbl = new Label();
                lbl.ID = "lblid" + i;
                KeyValuePair<int, string> kvp = new KeyValuePair<int, string>();
                kvp = dictSal.Where(x => x.Key == i).FirstOrDefault();
                lbl.ForeColor = System.Drawing.Color.LawnGreen;
                if (kvp.Value == null)
                {
                    kvp = dictRemun.Where(x => x.Key == i).FirstOrDefault();
                    lbl.ForeColor = System.Drawing.Color.Blue;

                }

                if (kvp.Value == null)
                {
                    kvp = dictCotis.Where(x => x.Key == i).FirstOrDefault();
                    lbl.ForeColor = System.Drawing.Color.Brown;
                }

                if (kvp.Value == null)
                {
                    kvp = dictArith.Where(x => x.Key == i).FirstOrDefault();
                    lbl.ForeColor = System.Drawing.Color.DarkSalmon;
                }
                lbl.Text = kvp.Value;
                this.goregle.Controls.Add(lbl);
            }

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
                    if (MyXMLUtilities.GetAttributes(myEntity.Name, "ByDefaults").Contains(nomPropriete))
                    {
                        lstitem.Enabled = false;
                        lstitem.Selected = true;
                    }
                    if (MyXMLUtilities.GetAttributes(myEntity.Name, "CheckedAttributes").Contains(nomPropriete))
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

        protected void BtnSaisirRegle_Click(object sender, EventArgs e)
        {
            this.ChkListAttSalaire.Visible = false;
            this.ListBoxAttSalaire.Visible = true;
            this.ListBoxAttSalaire.DataSource = getCheckedItems(this.ChkListAttSalaire);
            this.ListBoxAttSalaire.DataBind();
            this.BtnSelectAttSalaire.Visible = true;

            this.ChkListCotisation.Visible = false;
            this.ListBoxCotisation.Visible = true;
            this.ListBoxCotisation.DataSource = getCheckedItems(this.ChkListCotisation);
            this.ListBoxCotisation.DataBind();
            this.BtnSelectCotisation.Visible = true;

            this.ChkListRemuneration.Visible = false;
            this.ListBoxRemuneration.Visible = true;
            this.ListBoxRemuneration.DataSource = getCheckedItems(this.ChkListRemuneration);
            this.ListBoxRemuneration.DataBind();
            this.BtnSelectRemuneration.Visible = true;

            this.BtnSaisirRegle.Visible = false;
            this.PanelCalc.Visible = true;

            foreach (var item in this.DivKeys.Controls)
            {
                if (item is Button)
                    ((Button)item).Enabled = true;
            }
        }

        protected void BtnSelectAttSalaire_Click(object sender, EventArgs e)
        {
            if (this.ListBoxAttSalaire.SelectedIndex != -1)
            {
                ((IDictionary<int, string>)ViewState["expressionsAttSalaire"])
                   .Add(((int)ViewState["expressionsIndice"]), this.ListBoxAttSalaire.SelectedItem.Text);
                ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            }
            majExpression();
        }

        protected void BtnSelectCotisation_Click(object sender, EventArgs e)
        {
            if (this.ListBoxCotisation.SelectedIndex != -1)
            {
                ((IDictionary<int, string>)ViewState["expressionsCotisation"])
                .Add(((int)ViewState["expressionsIndice"]), this.ListBoxCotisation.SelectedItem.Text);
                ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            }
            majExpression();
        }

        protected void BtnSelectRemuneration_Click(object sender, EventArgs e)
        {
            if (this.ListBoxRemuneration.SelectedIndex != -1)
            {
                ((IDictionary<int, string>)ViewState["expressionsRemuneration"])
                    .Add(((int)ViewState["expressionsIndice"]), this.ListBoxRemuneration.SelectedItem.Text);
                ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            }
            majExpression();
        }

        private void majExpression()
        {
            this.ExpressionDiv.Controls.Clear();
            IDictionary<int, string> dict1 = (IDictionary<int, string>)ViewState["expressionsAttSalaire"];
            IDictionary<int, string> dict2 = (IDictionary<int, string>)ViewState["expressionsRemuneration"];
            IDictionary<int, string> dict3 = (IDictionary<int, string>)ViewState["expressionsCotisation"];
            IDictionary<int, string> dict4 = (IDictionary<int, string>)ViewState["expressionsArithmethiques"];

            for (int i = 0; i < (int)ViewState["expressionsIndice"]; i++)
            {
                Label lbl = new Label();
                bool trouve = false;
                int j = 0;
                while ((!trouve) && (j < dict1.Count))
                {
                    if (dict1.ElementAt(j).Key == i)
                    {
                        lbl.Text = dict1.ElementAt(j).Value;
                        lbl.ForeColor = System.Drawing.Color.LawnGreen;
                        trouve = true;
                    }
                    j++;
                }
                j = 0;
                while ((!trouve) && (j < dict2.Count))
                {
                    if (dict2.ElementAt(j).Key == i)
                    {
                        lbl.Text = dict2.ElementAt(j).Value;
                        lbl.ForeColor = System.Drawing.Color.Blue;
                        trouve = true;
                    }
                    j++;
                }
                j = 0;
                while ((!trouve) && (j < dict3.Count))
                {
                    if (dict3.ElementAt(j).Key == i)
                    {
                        lbl.Text = dict3.ElementAt(j).Value;
                        lbl.ForeColor = System.Drawing.Color.Brown;
                        trouve = true;
                    }
                    j++;
                }
                j = 0;
                while ((!trouve) && (j < dict4.Count))
                {
                    if (dict4.ElementAt(j).Key == i)
                    {
                        lbl.Text = dict4.ElementAt(j).Value;
                        lbl.ForeColor = System.Drawing.Color.DarkSalmon;
                        trouve = true;
                    }
                    j++;
                }

                this.ExpressionDiv.Controls.Add(lbl);
            }
        }

        //calculatrice

        protected void btn_1_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
               .Add(((int)ViewState["expressionsIndice"]), "1");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_2_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
               .Add(((int)ViewState["expressionsIndice"]), "2");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_3_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
               .Add(((int)ViewState["expressionsIndice"]), "3");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_4_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "4");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_5_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "5");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_6_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "6");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_7_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "7");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_8_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "8");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_9_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "9");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_0_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "0");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_po_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "(");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_pf_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), ")");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_plus_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "+");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_mult_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "*");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_div_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "/");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_moins_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "-");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_0_Click1(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), "0");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_point_Click(object sender, EventArgs e)
        {
            ((IDictionary<int, string>)ViewState["expressionsArithmethiques"])
              .Add(((int)ViewState["expressionsIndice"]), ".");
            ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) + 1;
            majExpression();
        }

        protected void btn_supp_Click(object sender, EventArgs e)
        {
            if ((int)ViewState["expressionsIndice"] > 0)
            {
                ViewState["expressionsIndice"] = ((int)ViewState["expressionsIndice"]) - 1;
                IDictionary<int, string> dict1 = (IDictionary<int, string>)ViewState["expressionsAttSalaire"];
                IDictionary<int, string> dict2 = (IDictionary<int, string>)ViewState["expressionsRemuneration"];
                IDictionary<int, string> dict3 = (IDictionary<int, string>)ViewState["expressionsCotisation"];
                IDictionary<int, string> dict4 = (IDictionary<int, string>)ViewState["expressionsArithmethiques"];
                bool trouve = false;
                int i = 0;
                while ((!trouve) && (i < dict1.Count))
                {
                    if (dict1.ElementAt(i).Key == (int)ViewState["expressionsIndice"])
                    {
                        trouve = true;
                        dict1.Remove(dict1.ElementAt(i).Key);
                    }
                    i++;
                }
                i = 0;
                while ((!trouve) && (i < dict2.Count))
                {
                    if (dict2.ElementAt(i).Key == (int)ViewState["expressionsIndice"])
                    {
                        trouve = true;
                        dict2.Remove(dict2.ElementAt(i).Key);
                    }
                    i++;
                }
                i = 0;
                while ((!trouve) && (i < dict3.Count))
                {
                    if (dict3.ElementAt(i).Key == (int)ViewState["expressionsIndice"])
                    {
                        trouve = true;
                        dict3.Remove(dict3.ElementAt(i).Key);
                    }
                    i++;
                }
                i = 0;
                while ((!trouve) && (i < dict4.Count))
                {
                    if (dict4.ElementAt(i).Key == (int)ViewState["expressionsIndice"])
                    {
                        trouve = true;
                        dict4.Remove(dict4.ElementAt(i).Key);
                    }
                    i++;
                }
                ViewState["expressionsAttSalaire"] = dict1;
                ViewState["expressionsRemuneration"] = dict2;
                ViewState["expressionsCotisation"] = dict3;
                ViewState["expressionsArithmethiques"] = dict4;
                majExpression();
            }
        }

        protected void BtnSauvgarder_Click(object sender, EventArgs e)
        {
            MyXMLUtilities.UpdateChosenAttributes(typeof(Salaire).Name, getNonDefaultCheckedItems(this.ChkListAttSalaire));
            MyXMLUtilities.UpdateChosenAttributes(typeof(Cotisation).Name, getNonDefaultCheckedItems(this.ChkListCotisation));
            MyXMLUtilities.UpdateChosenAttributes(typeof(Remuneration).Name, getNonDefaultCheckedItems(this.ChkListRemuneration));

            IDictionary<int, string> dict1 = (IDictionary<int, string>)ViewState["expressionsAttSalaire"];
            IDictionary<int, string> dict2 = (IDictionary<int, string>)ViewState["expressionsRemuneration"];
            IDictionary<int, string> dict3 = (IDictionary<int, string>)ViewState["expressionsCotisation"];
            IDictionary<int, string> dict4 = (IDictionary<int, string>)ViewState["expressionsArithmethiques"];
            int count = (int)ViewState["expressionsIndice"];
            MyXMLUtilities.SauvgarderRegle(dict1, dict2, dict3, dict4, count);
            Response.Redirect("~/GestionSalaire.aspx");
        }
    }
}