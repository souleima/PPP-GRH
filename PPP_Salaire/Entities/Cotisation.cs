using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    public class Cotisation
    {
        public int Id { get; set; }
        public decimal Cotisations_AGFF { get; set; }
        public decimal Cotisations_APEC { get; set; }
        public decimal Cotisations_Urssaf { get; set; }
        public decimal Cotisation_CRDS { get; set; }
        public decimal Cotisation_CSG_déductible { get; set; }
    }
}