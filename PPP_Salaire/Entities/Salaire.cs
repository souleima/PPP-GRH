using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    public class Salaire
    {
        public int Id { get; set; }
        public decimal Salaire_de_base { get; set; }
        public int Heures_travaillées { get; set; }
        public int Heures_retards { get; set; }
        public int Heures_supplementaire { get; set; }

        public Remuneration Remuneration { get; set; }
        public Cotisation Cotisation { get; set; }

    }
}