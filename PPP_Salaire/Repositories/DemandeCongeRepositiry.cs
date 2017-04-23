using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
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
        public IList<DemandeConge> ListerById(int id)
        {
            return this.db.DemandeConges.Where(d => d.Employe.Id == id).ToList();
        }
        public List<DemandeConge> GetByEmployeId(int id)
        {
            return db.DemandeConges.Where(d => d.Employe.Id == id).ToList();
            //return this.db.DemandeConges.Find(id);
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
        public string Inserer(int IdSelectedConge ,DateTime DateDebut, DateTime DateFin , int IdUser)
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
                +", @Raison," + "'EN_ATTENTE'" + " ," +
                IdUser +
                ")";
            return cmd;
        }
        public int DaysBetween(DateTime d1, DateTime d2)
        {
            TimeSpan span = d2.Subtract(d1);
            return (int)span.TotalDays;
        }
        public string Select()
        {
            return "SELECT [Raison], [Employe_Id] FROM [DemandeConges]";
        }
        public string SelectGrid()
        {
            return "SELECT[Id], [DateDebut], [DateFin], [DateSubmit], [CongeID], [NbreJours], [Raison], [Status] FROM[DemandeConges]";
        }
        public IList<DemandeConge> ListerBySelection(string columnName, string value , int IdUser)
        {
            List<DemandeConge> demandes = new List<DemandeConge>();

            string connectionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string cmdString = "SELECT * FROM DemandeConges WHERE " + columnName + " = '" + value + "' AND Employe_Id = " + IdUser.ToString();
            SqlCommand cmd = new SqlCommand(cmdString, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                demandes.Add(new DemandeConge()
                {
                    Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                    DateFin = rdr.GetString(rdr.GetOrdinal("DateFin")),
                    DateSubmit = rdr.GetString(rdr.GetOrdinal("DateSubmit")),
                    DateDebut = rdr.GetString(rdr.GetOrdinal("DateDebut")),
                    CongeID = rdr.GetInt32(rdr.GetOrdinal("CongeID")),
                    NbreJours = rdr.GetInt32(rdr.GetOrdinal("NbreJours")),
                    Raison = rdr.GetString(rdr.GetOrdinal("Raison")),
                    Status = rdr.GetString(rdr.GetOrdinal("Status"))
                });

            };

            return demandes;
        }
        
    }
}
