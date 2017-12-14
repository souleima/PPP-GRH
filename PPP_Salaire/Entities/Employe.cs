using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PPP_Salaire.Entities
{
    [Serializable]
    public class Employe
    {
        public int Id { get; set; }
        [Index("login", IsUnique = true)]
        [MaxLength(450)]
        public string login { get; set; }
        public string password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public int NumSS { get; set; }
        public DateTime DateEmbauche { get; set; }

        public Categorie CategorieId { get; set; }
        public virtual Salaire Salaire { get; set; }
        public List<DemandeConge> DemandeConges { get; set; }
    }
}