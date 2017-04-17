using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    [Serializable]//to store it in the viewstate
    public class Salaire
    {
        public int Id { get; set; }
        public decimal Salaire_de_base { get; set; }
        public decimal Heures_travaillées { get; set; }
        public decimal Heures_retards { get; set; }
        public decimal Heures_supplementaire { get; set; }

        public virtual Remuneration Remuneration { get; set; }
        public virtual Cotisation Cotisation { get; set; }

    }
}