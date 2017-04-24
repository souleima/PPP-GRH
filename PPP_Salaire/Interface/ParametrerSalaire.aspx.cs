
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPP_Salaire
{
    public partial class ParametrerSalaire : System.Web.UI.Page
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

                foreach (var item in this.DivKeys.Controls)
                {
                    if (item is Button)
                        ((Button)item).Enabled = false;
                }
            }
        }
        protected void BtnAjouterAttributSalaire_Click(object sender, EventArgs e)
        {
            if (!this.TxtAttributSalaire.Text.Trim().Equals(""))
            {
                if (this.ListBoxAttributSalaire.Items.FindByText(this.TxtAttributSalaire.Text) == null)
                    this.ListBoxAttributSalaire.Items.Add(this.TxtAttributSalaire.Text);
                this.BtnSupprimerAttributSalaire.Enabled = true;
                this.TxtAttributSalaire.Text = "";
            }
        }
        protected void BtnSuprimerAttributSalaire_Click(object sender, EventArgs e)
        {
            if (this.ListBoxAttributSalaire.SelectedIndex != -1)
                this.ListBoxAttributSalaire.Items.Remove(this.ListBoxAttributSalaire.SelectedItem.Text);
            if (this.ListBoxAttributSalaire.Items.Count == 0)
                this.BtnSupprimerAttributSalaire.Enabled = false;
        }
        protected void BtnAjouterRemuneration_Click(object sender, EventArgs e)
        {
            if (!this.TxtRemuneration.Text.Trim().Equals(""))
            {
                if (this.ListBoxRemuneration.Items.FindByText(this.TxtRemuneration.Text) == null)
                    this.ListBoxRemuneration.Items.Add(this.TxtRemuneration.Text);
                this.BtnSupprimerRemuneration.Enabled = true;
                this.TxtRemuneration.Text = "";
            }
        }
        protected void BtnSupprimerRemuneration_Click(object sender, EventArgs e)
        {
            if (this.ListBoxRemuneration.SelectedIndex != -1)
                this.ListBoxRemuneration.Items.Remove(this.ListBoxRemuneration.SelectedItem.Text);
            if (this.ListBoxRemuneration.Items.Count == 0)
                this.BtnSupprimerRemuneration.Enabled = false;
        }
        protected void BtnAjouterCotisation_Click(object sender, EventArgs e)
        {
            if (!this.TxtCotisation.Text.Trim().Equals(""))
            {
                if (this.ListBoxCotisation.Items.FindByText(this.TxtCotisation.Text) == null)
                    this.ListBoxCotisation.Items.Add(this.TxtCotisation.Text);
                this.BtnSupprimerCotisitaion.Enabled = true;
                this.TxtCotisation.Text = "";
            }
        }
        protected void BtnSupprimerCotisitaion_Click(object sender, EventArgs e)
        {
            if (this.ListBoxCotisation.SelectedIndex != -1)
                this.ListBoxCotisation.Items.Remove(this.ListBoxCotisation.SelectedItem.Text);
            if (this.ListBoxCotisation.Items.Count == 0)
                this.BtnSupprimerCotisitaion.Enabled = false;
        }
        protected void BtnSelectAttSalaire_Click(object sender, EventArgs e)
        {
            if (this.ListBoxAttributSalaire.SelectedIndex != -1)
            {
                ((IDictionary<int, string>)ViewState["expressionsAttSalaire"])
                   .Add(((int)ViewState["expressionsIndice"]), this.ListBoxAttributSalaire.SelectedItem.Text);
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
        protected void BtnDown_Click(object sender, EventArgs e)
        {

            foreach (var item in this.DivKeys.Controls)
            {
                if (item is Button)
                    ((Button)item).Enabled = true;
            }
            this.BtnSupprimerCotisitaion.Enabled = false;
            this.BtnSupprimerRemuneration.Enabled = false;
            this.BtnSupprimerAttributSalaire.Enabled = false;
            this.BtnAjouterAttributSalaire.Enabled = false;
            this.BtnAjouterCotisation.Enabled = false;
            this.BtnAjouterRemuneration.Enabled = false;
            this.TxtAttributSalaire.Enabled = false;
            this.TxtCotisation.Enabled = false;
            this.TxtRemuneration.Enabled = false;
            this.BtnSelectAttSalaire.Enabled = true;
            this.BtnSelectCotisation.Enabled = true;
            this.BtnSelectRemuneration.Enabled = true;
            this.BtnUP.Enabled = true;
            this.BtnDown.Enabled = false;
        }
        protected void BtnUP_Click(object sender, EventArgs e)
        {
            foreach (var item in this.DivKeys.Controls)
            {
                if (item is Button)
                    ((Button)item).Enabled = false;
            }
            this.BtnSupprimerCotisitaion.Enabled = true;
            this.BtnSupprimerRemuneration.Enabled = true;
            this.BtnSupprimerAttributSalaire.Enabled = true;
            this.BtnAjouterAttributSalaire.Enabled = true;
            this.BtnAjouterCotisation.Enabled = true;
            this.BtnAjouterRemuneration.Enabled = true;
            this.TxtAttributSalaire.Enabled = true;
            this.TxtCotisation.Enabled = true;
            this.TxtRemuneration.Enabled = true;
            this.BtnSelectAttSalaire.Enabled = false;
            this.BtnSelectCotisation.Enabled = false;
            this.BtnSelectRemuneration.Enabled = false;
            this.BtnUP.Enabled = false;
            this.BtnDown.Enabled = true;
            ViewState["expressionsAttSalaire"] = new Dictionary<int, string>();
            ViewState["expressionsCotisation"] = new Dictionary<int, string>();
            ViewState["expressionsRemuneration"] = new Dictionary<int, string>();
            ViewState["expressionsArithmethiques"] = new Dictionary<int, string>();
            ViewState["expressionsIndice"] = 0;
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


    }
}