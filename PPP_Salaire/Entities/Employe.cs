using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PPP_Salaire.Entities
{
    [Serializable]
    public class Employe
    {
        public int Id { get; set; }
        //........GestionSalaire.aspx.cs : ligne 56
        public string login { get; set; }
        public string password { get; set; }
        //........
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public int Num_SS { get; set; }
        public DateTime Date_dEmbauche { get; set; }

        public Categorie Categorie_id { get; set; }
        public Salaire Salaire { get; set; }
        public List<DemandeConge> DemandeConges { get; set; }
    }
}