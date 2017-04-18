using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    [Serializable]//to store it in the viewstate
    public class Remuneration
    {
        public int Id { get; set; }
        public decimal Remboursement_transports_en_commun { get; set; }
        public decimal Primes_éventuelles { get; set; }
        public decimal Avantages_en_nature_éventuels { get; set; }
        public decimal Remboursement_de_frais { get; set; }
        public decimal prime_ancienneté { get; set; }
        public decimal prime_de_productivité { get; set; }
    }
}