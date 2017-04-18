﻿using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Repositories
{
    public class EmployeRepository : IEmployeRepository
    {
        DBContext db = new DBContext();

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
            DBContext employeeDBContext = new DBContext();
            return employeeDBContext.Employes.Include("DemandeConges").ToList();
        }

    }
}