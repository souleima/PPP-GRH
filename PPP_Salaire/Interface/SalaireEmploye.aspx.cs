using PPP_Salaire.Entities;
using PPP_Salaire.Repositories;
using PPP_Salaire.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using PPP_Salaire.XMLConfig;
using System.Reflection;
using System.Data;

namespace PPP_Salaire
{
    public partial class SalaireEmploye : System.Web.UI.Page
    {
        private EmployeRepository employeRepository = new EmployeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelDate.Text = DateTime.Now.ToShortDateString();
            string employeId = Request.QueryString["Id"];
            Employe employe = this.employeRepository.GetById(Convert.ToInt32(employeId));
            if (employe == null)
                Response.Redirect("~/Interface/GestionSalaire.aspx");
            if (employe.Salaire == null)
            {
                employe.Salaire = new Salaire();
                employe.Salaire.Cotisation = new Cotisation();
                employe.Salaire.Remuneration = new Remuneration();
            }
            ViewState["employe"] = employe;
            int gauche_droite = 0;
            foreach (var item in typeof(Employe).GetProperties())
            {
                var nomPropriete = item.Name;
                var valeurPropriete = item.GetValue(employe);

                if (item.PropertyType.Namespace.Equals("System")&& (!nomPropriete.Equals("login")
          &&(!nomPropriete.Equals("password"))))
                {
                    gauche_droite++;
                    Label lbl_nomPropriete = new Label();
                    lbl_nomPropriete.ID = "lbl_" + typeof(Employe) + nomPropriete;
                    lbl_nomPropriete.Text = nomPropriete.Replace("_", " ");
                    lbl_nomPropriete.Font.Bold = true;

                    Label lbl_valeurPropriete = new Label();
                    lbl_valeurPropriete.ID = "txt_" + typeof(Employe) + nomPropriete;
                    lbl_valeurPropriete.Text = valeurPropriete?.ToString();

                    TableRow tr;
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    tc1.Controls.Add(lbl_nomPropriete);
                    tc2.Controls.Add(lbl_valeurPropriete);

                    if (gauche_droite % 2 != 0)
                    {
                        tr = new TableRow();
                        tr.Cells.Add(tc1);
                        tr.Cells.Add(tc2);
                        this.TableInfoEmploye.Rows.Add(tr);
                    }
                    else
                    {
                        tr = this.TableInfoEmploye.Rows[this.TableInfoEmploye.Rows.Count - 1];
                        tr.Cells.Add(tc1);
                        tr.Cells.Add(tc2);
                    }
                }
            }

            gauche_droite = 0;
            foreach (var item in typeof(Salaire).GetProperties())
            {
                var nomPropriete = item.Name;
                var valeurPropriete = item.GetValue(employe.Salaire);
                if (item.PropertyType.Namespace.Equals("System") && (!nomPropriete.Equals("Id"))
                    && (MyXMLUtilities.GetAttributes(typeof(Salaire).Name).Contains(nomPropriete)))
                {
                    gauche_droite++;
                    Label lbl_nomPropriete = new Label();
                    lbl_nomPropriete.ID = "lbl_" + typeof(Salaire) + nomPropriete;
                    lbl_nomPropriete.Text = nomPropriete.Replace("_", " ");
                    lbl_nomPropriete.Font.Bold = true;

                    TextBox txt_valeurPropriete = new TextBox();
                    txt_valeurPropriete.ID = "txt_" + typeof(Salaire) + nomPropriete;
                    txt_valeurPropriete.Text = valeurPropriete?.ToString();
                    txt_valeurPropriete.Attributes.Add("class", "form-control");


                    RegularExpressionValidator rv = new RegularExpressionValidator();
                    rv.ControlToValidate = txt_valeurPropriete.ID;
                    rv.ErrorMessage = "erreur!!";
                    rv.ForeColor = System.Drawing.Color.Red;
                    rv.ValidationExpression = @"(^\d{1,18}\,\d{1,2}$)|(^\d{1,18}$)";

                    TableRow tr;
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    tc1.Controls.Add(lbl_nomPropriete);
                    tc2.Controls.Add(txt_valeurPropriete);
                    tc2.Controls.Add(rv);
                    if (gauche_droite % 2 != 0)
                    {
                        tr = new TableRow();
                        tr.Cells.Add(tc1);
                        tr.Cells.Add(tc2);
                        this.TableInfoSalaire.Rows.Add(tr);
                    }
                    else
                    {
                        tr = this.TableInfoSalaire.Rows[this.TableInfoSalaire.Rows.Count - 1];
                        tr.Cells.Add(tc1);
                        tr.Cells.Add(tc2);
                    }
                }
            }

            foreach (var item in typeof(Remuneration).GetProperties())
            {
                var nomPropriete = item.Name;
                var valeurPropriete = item.GetValue(employe.Salaire.Remuneration);
                if (item.PropertyType.Namespace.Equals("System") && (!nomPropriete.Equals("Id"))
                    && (MyXMLUtilities.GetAttributes(typeof(Remuneration).Name).Contains(nomPropriete)))
                {
                    Label lbl_nomPropriete = new Label();
                    lbl_nomPropriete.ID = "lbl_" + typeof(Remuneration) + nomPropriete;
                    lbl_nomPropriete.Text = nomPropriete.Replace("_", " ");
                    lbl_nomPropriete.Font.Bold = true;

                    TextBox txt_valeurPropriete = new TextBox();
                    txt_valeurPropriete.ID = "txt_" + typeof(Remuneration) + nomPropriete;
                    txt_valeurPropriete.Text = valeurPropriete?.ToString();
                    txt_valeurPropriete.Attributes.Add("class", "form-control");

                    RegularExpressionValidator rv = new RegularExpressionValidator();
                    rv.ControlToValidate = txt_valeurPropriete.ID;
                    rv.ErrorMessage = "erreur!!";
                    rv.ForeColor = System.Drawing.Color.Red;
                    rv.ValidationExpression = @"(^\d{1,18}\,\d{1,2}$)|(^\d{1,18}$)";

                    TableRow tr = new TableRow();
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    tc1.Controls.Add(lbl_nomPropriete);
                    tc2.Controls.Add(txt_valeurPropriete);
                    tc2.Controls.Add(rv);
                    tr.Cells.Add(tc1);
                    tr.Cells.Add(tc2);
                    this.TableInfoRemun.Rows.Add(tr);
                }

            }

            foreach (var item in typeof(Cotisation).GetProperties())
            {
                var nomPropriete = item.Name;
                var valeurPropriete = item.GetValue(employe.Salaire.Cotisation);
                if (item.PropertyType.Namespace.Equals("System") && (!nomPropriete.Equals("Id"))
                    && (MyXMLUtilities.GetAttributes(typeof(Cotisation).Name).Contains(nomPropriete)))
                {
                    Label lbl_nomPropriete = new Label();
                    lbl_nomPropriete.ID = "lbl_" + typeof(Cotisation) + nomPropriete;
                    lbl_nomPropriete.Text = nomPropriete.Replace("_", " ");
                    lbl_nomPropriete.Font.Bold = true;

                    TextBox txt_valeurPropriete = new TextBox();
                    txt_valeurPropriete.ID = "txt_" + typeof(Cotisation) + nomPropriete;
                    txt_valeurPropriete.Text = valeurPropriete.ToString();
                    txt_valeurPropriete.Attributes.Add("class", "form-control");

                    RegularExpressionValidator rv = new RegularExpressionValidator();
                    rv.ControlToValidate = txt_valeurPropriete.ID;
                    rv.ErrorMessage = "erreur!!";
                    rv.ForeColor = System.Drawing.Color.Red;
                    rv.ValidationExpression = @"(^\d{1,18}\,\d{1,2}$)|(^\d{1,18}$)";

                    TableRow tr = new TableRow();
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    tc1.Controls.Add(lbl_nomPropriete);
                    tc2.Controls.Add(txt_valeurPropriete);
                    tc2.Controls.Add(rv);
                    tr.Cells.Add(tc1);
                    tr.Cells.Add(tc2);
                    this.TableInfoCotis.Rows.Add(tr);
                }
            }
        }
        protected void BtnCalculerSalaire_Click(object sender, EventArgs e)
        {
            string regle = "";
            IDictionary<int, string>[] dictTab = MyXMLUtilities.GetRegle();
            IDictionary<int, string> dictSal = dictTab[0];
            IDictionary<int, string> dictRemun = dictTab[1];
            IDictionary<int, string> dictCotis = dictTab[2];
            IDictionary<int, string> dictArith = dictTab[3];
            for (int i = 0; i < dictSal.Count + dictRemun.Count + dictCotis.Count + dictArith.Count; i++)
            {
                string valeur = "";
                KeyValuePair<int, string> kvp = new KeyValuePair<int, string>();
                kvp = dictSal.Where(x => x.Key == i).FirstOrDefault();
                if (kvp.Value != null)
                {
                    valeur = getInputs(this.TableInfoSalaire, "txt_" + typeof(Salaire))
                        [kvp.Value.Replace(" ", "_")];
                }
                else
                {
                    kvp = dictRemun.Where(x => x.Key == i).FirstOrDefault();
                    if (kvp.Value != null)
                    {
                        valeur = getInputs(this.TableInfoRemun, "txt_" + typeof(Remuneration))
                        [kvp.Value.Replace(" ", "_")];
                    }
                    else
                    {
                        kvp = dictCotis.Where(x => x.Key == i).FirstOrDefault();
                        if (kvp.Value != null)
                        {
                            valeur = getInputs(this.TableInfoCotis, "txt_" + typeof(Cotisation))
                        [kvp.Value.Replace(" ", "_")];
                        }
                        else
                        {
                            kvp = dictArith.Where(x => x.Key == i).FirstOrDefault();
                            valeur = kvp.Value;
                        }
                    }
                }

                regle += valeur;
            }
            DataTable dt = new DataTable();
            string v = "";
            try
            {
                v = dt.Compute(regle.Replace(",", "."), "").ToString();
            }
            catch (SyntaxErrorException)
            {
                v = "formule invalide!!";
            }
            this.LblNetAPayer.Text = v.ToString();

        }
        protected void BtnSauvgarder_Click(object sender, EventArgs e)
        {
            Employe employe = (Employe)ViewState["employe"];
            foreach (var item in getInputs(this.TableInfoSalaire, "txt_" + typeof(Salaire)))
            {
                employe.Salaire.GetType().GetProperty(item.Key)
                    .SetValue(employe.Salaire, Convert.ToDecimal(item.Value), null);
            }
            foreach (var item in getInputs(this.TableInfoRemun, "txt_" + typeof(Remuneration)))
            {
                employe.Salaire.Remuneration.GetType().GetProperty(item.Key)
                    .SetValue(employe.Salaire.Remuneration, Convert.ToDecimal(item.Value), null);
            }
            foreach (var item in getInputs(this.TableInfoCotis, "txt_" + typeof(Cotisation)))
            {
                employe.Salaire.Cotisation.GetType().GetProperty(item.Key)
                    .SetValue(employe.Salaire.Cotisation, Convert.ToDecimal(item.Value), null);

            }
            this.employeRepository.Update(employe);
            imprimer();
        }
        private void imprimer()
        {
            var document = new Document(PageSize.A4, 50, 50, 25, 25);

            // Create a new PdfWriter object, specifying the output stream
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);

            // Open the Document for writing
            document.Open();
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            document.Add(new Paragraph("Fiche de paie", titleFont));
            document.Add(new Paragraph(DateTime.Now.ToShortDateString()));

            PdfPTable pdfTable = new PdfPTable(4);
            pdfTable.SpacingBefore = 10;
            pdfTable.DefaultCell.Padding = 5;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.Border = Rectangle.NO_BORDER;
            pdfTable.SetWidths(new int[] { 4, 5, 4, 5 });

            document.Add(new Paragraph("Employe:", subTitleFont));


            foreach (var item in getLabels(this.TableInfoEmploye, "txt_" + typeof(Employe)))
            {
                PdfPCell cell = new PdfPCell(new Phrase(item.Key.Replace("_", " ") + " :", boldTableFont));
                cell.Border = Rectangle.NO_BORDER;
                pdfTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(item.Value));
                cell.Border = Rectangle.NO_BORDER;
                pdfTable.AddCell(cell);
            }


            document.Add(pdfTable);




            PdfPTable pdfSalaire = new PdfPTable(4);
            pdfSalaire.SpacingBefore = 10;
            pdfSalaire.DefaultCell.Padding = 5;
            pdfSalaire.WidthPercentage = 100;
            pdfSalaire.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfSalaire.DefaultCell.BorderWidth = 1;
            pdfSalaire.SetWidths(new int[] { 4, 1, 4, 1 });

            foreach (var item in getInputs(this.TableInfoSalaire, "txt_" + typeof(Salaire)))
            {
                PdfPCell cell = new PdfPCell(new Phrase(item.Key.Replace("_", " ") + " :", boldTableFont));
                //cell.Border = Rectangle.NO_BORDER;
                pdfSalaire.AddCell(cell);
                cell = new PdfPCell(new Phrase(item.Value));
                //cell.Border = Rectangle.NO_BORDER;
                pdfSalaire.AddCell(cell);
            }

            document.Add(pdfSalaire);

            PdfPTable pdfBilanTable = new PdfPTable(2);
            pdfBilanTable.SpacingBefore = 10;
            pdfBilanTable.DefaultCell.Padding = 3;
            pdfBilanTable.WidthPercentage = 100;
            pdfBilanTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfBilanTable.DefaultCell.Border = Rectangle.NO_BORDER;

            PdfPTable pdfRemun = new PdfPTable(2);
            pdfRemun.DefaultCell.Padding = 1;
            pdfRemun.WidthPercentage = 100;
            pdfRemun.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfRemun.DefaultCell.Border = Rectangle.NO_BORDER;
            pdfRemun.SetWidths(new int[] { 5, 2 });

            PdfPTable pdfCotis = new PdfPTable(2);
            pdfCotis.DefaultCell.Padding = 1;
            pdfCotis.WidthPercentage = 100;
            pdfCotis.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCotis.DefaultCell.Border = Rectangle.NO_BORDER;
            pdfCotis.SetWidths(new int[] { 5, 2 });

            foreach (var item in getInputs(this.TableInfoRemun, "txt_" + typeof(Remuneration)))
            {
                PdfPCell cell = new PdfPCell(new Phrase(item.Key.Replace("_", " ") + " :", boldTableFont));
                //cell.Border = Rectangle.NO_BORDER;
                pdfRemun.AddCell(cell);
                cell = new PdfPCell(new Phrase(item.Value));
                //cell.Border = Rectangle.NO_BORDER;
                pdfRemun.AddCell(cell);
            }

            foreach (var item in getInputs(this.TableInfoCotis, "txt_" + typeof(Cotisation)))
            {
                PdfPCell cell = new PdfPCell(new Phrase(item.Key.Replace("_", " ") + " :", boldTableFont));
                //cell.Border = Rectangle.NO_BORDER;
                pdfCotis.AddCell(cell);
                cell = new PdfPCell(new Phrase(item.Value));
                //cell.Border = Rectangle.NO_BORDER;
                pdfCotis.AddCell(cell);
            }


            pdfBilanTable.AddCell(pdfRemun);
            pdfBilanTable.AddCell(pdfCotis);
            document.Add(pdfBilanTable);


            document.Add(new Paragraph("Net a payer : " + this.LblNetAPayer.Text));


            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename=salaire.pdf"));
            Response.BinaryWrite(output.ToArray());
        }
        private Dictionary<string, string> getInputs(Control control, string entityName)
        {
            Dictionary<string, string> inputsDictionnary = new Dictionary<string, string>();

            Action<Control> search = null;
            search = ctrl =>
            {
                foreach (Control child in ctrl.Controls)
                {
                    if (child is TextBox)
                        inputsDictionnary.Add(((TextBox)child).ID.Replace(entityName, ""), ((TextBox)child).Text);

                    search(child);
                }
            };
            search(control);

            return inputsDictionnary;
        }
        private Dictionary<string, string> getLabels(Control control, string entityName)
        {
            Dictionary<string, string> labelsDictionnary = new Dictionary<string, string>();

            Action<Control> search = null;
            search = ctrl =>
            {
                foreach (Control child in ctrl.Controls)
                {
                    if ((child is Label) && ((Label)child).ID.StartsWith("txt_"))
                        labelsDictionnary.Add(((Label)child).ID.Replace(entityName, ""), ((Label)child).Text);

                    search(child);
                }
            };
            search(control);

            return labelsDictionnary;
        }
    }
}