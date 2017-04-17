using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Repositories
{
    public class CongeRepository
    {
        PPPDBContext db = new PPPDBContext();

        public IList<Conge> Lister()
        {
            return this.db.Conges.ToList();
        }

        public Conge GetById(int id)
        {
            return this.db.Conges.Find(id);
        }

        public void Update(Conge c)
        {
            this.db.Entry(c).State = EntityState.Modified;
            this.db.SaveChanges();
        }

    }
}