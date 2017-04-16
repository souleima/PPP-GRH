using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    public class Remuneration
    {
        public int Id { get; set; }
        public decimal Remboursement_transports_en_commun { get; set; }
        public decimal Primes_éventuelles { get; set; }
    }
}