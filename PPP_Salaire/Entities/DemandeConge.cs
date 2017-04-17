using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PPP_Salaire.Entities
{
    public class DemandeConge
    {
        

        public int Id { get; set; }
        public string DateDebut { get; set; }
        public string DateFin { get; set; }
        public string DateSubmit { get; set; }
        public int CongeID { get; set; }
        public int NbreJours { get; set; }
        public string Raison { get; set; }

        public string Status { get; set; }

        public Employe Employe { get; set; }

    }
}