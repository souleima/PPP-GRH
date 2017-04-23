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
    public class EmployeRepository : IEmployeRepository
    {
        DBContext db = new DBContext();
        List<Employe> employes = new List<Employe>();

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

        public int GetByLogin(string login)
        {
            return db.Employes.Where(d => d.login == login).FirstOrDefault().Id;
        }

        public string Select()
        {
            return "SELECT [Id] FROM [Employes]";
        }

        public IList<Employe> ListerBySelection(string columnName, string value)
        {
            List<Employe> employes = new List<Employe>();

            string connectionString = ConfigurationManager.ConnectionStrings["PPPConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string cmdString = "SELECT * FROM[Employes] WHERE " + columnName + " = '" + value + "'";
            SqlCommand cmd = new SqlCommand(cmdString, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                employes.Add(new Employe()
                {
                    Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                    login = rdr.GetString(rdr.GetOrdinal("Login")),
                    password = rdr.GetString(rdr.GetOrdinal("Password")),
                    Nom = rdr.GetString(rdr.GetOrdinal("Nom")),
                    Prenom = rdr.GetString(rdr.GetOrdinal("Prenom")),
                    Adresse = rdr.GetString(rdr.GetOrdinal("Adresse")),
                    Num_SS = rdr.GetInt32(rdr.GetOrdinal("Num_SS")),
                    Date_dEmbauche = rdr.GetDateTime(rdr.GetOrdinal("Date_dEmbauche"))
                });

            };

            return employes;
        }
    }
}