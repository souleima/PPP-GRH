using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PPP_Salaire.Utilities
{
    public static class LiteralControlUtility
    {
        public static LiteralControl Espace()
        {
            return new LiteralControl("&nbsp;");
        }

        public static LiteralControl Retour_a_la_ligne()
        {
            return new LiteralControl("</br>");
        }
    }
}