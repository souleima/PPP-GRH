using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    [Serializable]//to store it in the viewstate
    public class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public int Num_SS { get; set; }
        public DateTime Date_dEmbauche { get; set; }

        public  virtual Salaire Salaire { get; set; }
        public List<DemandeConge> DemandeConges { get; set; }
    }
}