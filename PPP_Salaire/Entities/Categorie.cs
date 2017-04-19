using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Entities
{
    [Serializable]
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }
}