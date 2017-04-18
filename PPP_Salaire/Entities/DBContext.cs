using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace PPP_Salaire.Entities
{
    public class DBContext : DbContext
    {
        public DbSet<DemandeConge> DemandeConges { get; set; }
        public DbSet<Conge> Conges { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
    }
}