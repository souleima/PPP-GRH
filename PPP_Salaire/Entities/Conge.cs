using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    public class Conge
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int NbJours { get; set; }
        public int Par_Jours_De_Travail { get; set; }
        public int Justifié { get; set; }

    }
}