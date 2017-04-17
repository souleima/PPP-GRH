using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Repositories
{
    public class EmployeRepository : IEmployeRepository
    {
        PPPDBContext db = new PPPDBContext();

        public IList<Employe> Lister()
        {
        return this.db.Employes.ToList();
        }


        public Employe GetById(int id)
        {
            return this.db.Employes.Find(id);
        }

        public void Update(Employe e)
        {
            this.db.Entry(e).State = EntityState.Modified;
            this.db.SaveChanges();
        }

        public List<Employe> GetEmployes()
        {
            PPPDBContext employeeDBContext = new PPPDBContext();
            return employeeDBContext.Employes.Include("DemandeConges").ToList();
        }

        public List<DemandeConge> GetDemandeConges()
        {
            PPPDBContext employeeDBContext = new PPPDBContext();
            return employeeDBContext.DemandeConges.ToList();
        }
    }
}