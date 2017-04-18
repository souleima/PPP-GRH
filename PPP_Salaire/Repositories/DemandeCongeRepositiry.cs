using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Repositories
{
    public class DemandeCongeRepositiry : IDemandeCongeRepository
    {
        DBContext db = new DBContext();
        public IList<DemandeConge> Lister()
        {
            return this.db.DemandeConges.ToList();
        }


        public DemandeConge GetById(int id)
        {
            return this.db.DemandeConges.Find(id);
        }

        public void Update(DemandeConge e)
        {
            this.db.Entry(e).State = EntityState.Modified;
            this.db.SaveChanges();
        }

        public List<DemandeConge> GetDemandeConges()
        {
            DBContext demandeCongeDBContext = new DBContext();
            return demandeCongeDBContext.DemandeConges.ToList();
        }
        public string Inserer(int IdSelectedConge ,DateTime DateDebut, DateTime DateFin)
        {

            string currentDate = DateTime.Today.ToShortDateString(); ;

            string NbJours = DaysBetween(DateDebut, DateFin).ToString();
            string cmd = "INSERT INTO[DemandeConges] ([DateDebut], [DateFin], " +
                "[DateSubmit] , [CongeID], [NbreJours], [Raison], [Status], [Employe_Id]) " +
                "VALUES('"
                + DateDebut.ToShortDateString() +"','"
                + DateFin.ToShortDateString() +"' , '" 
                + currentDate + "'," 
                + IdSelectedConge + ","
                +NbJours 
                +", @Raison," + "'EN_ATTENTE'" + " , @Employe_Id)";
            return cmd;
        }
        int DaysBetween(DateTime d1, DateTime d2)
        {
            TimeSpan span = d2.Subtract(d1);
            return (int)span.TotalDays;
        }
        public string Select()
        {
            return "SELECT [Raison], [Employe_Id] FROM [DemandeConges]";
        }
    }
}
