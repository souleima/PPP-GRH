using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    [Serializable]//to store it in the viewstate
    public class Cotisation
    {
        public int Id { get; set; }
        public decimal Cotisations_Urssaf { get; set; }
        public decimal Cotisations_chômage { get; set; }
        public decimal Cotisations_retraite_complémentaire_ARRCO { get; set; }
        public decimal Cotisations_retraite_complémentaire_AGIRC { get; set; }
        public decimal Cotisations_AGFF { get; set; }
        public decimal Cotisations_APEC { get; set; }
        public decimal Cotisations_prévoyance { get; set; }
        public decimal Cotisations_mutuelle { get; set; }
        public decimal Cotisations_retraite_supplémentaire { get; set; }
        public decimal Cotisation_CSG_déductible { get; set; }
        public decimal Cotisation_CSG_non_déductible { get; set; }
        public decimal Cotisation_CRDS { get; set; }
        public decimal Acomptes_sur_salaire { get; set; }
        public decimal Titres_restaurant { get; set; }
    }
}