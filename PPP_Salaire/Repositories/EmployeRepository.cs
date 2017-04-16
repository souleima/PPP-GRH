using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Repositories
{
    public class EmployeRepository : IEmployeRepository
    {
        IList<Employe> EmployesList = new List<Employe>();

        public IList<Employe> Lister()
        {
            for (int i = 0; i < 200; i++)
            {
                Employe employe = new Employe
                {
                    Nom = "nom" + i,
                    Id = i,
                    Adresse = "Adresse" + i,
                    Num_SS = 100000 + i,
                    Date_dEmbauche = DateTime.Now,
                    Prenom = "prenom" + i,
                    Salaire = new Salaire
                    {
                        Id = i * i,
                        Heures_retards = i * i * i,
                        Heures_supplementaire = i * i * i * i,
                        Heures_travaillées = 2 * i,
                        Salaire_de_base = 3 * i,
                        Cotisation = new Cotisation
                        {
                            Id = i * i * 4,
                            Cotisations_AGFF = 2 * i,
                            Cotisations_APEC = 3 * i,
                            Cotisations_Urssaf = 6 * i,
                            Cotisation_CRDS = 2 * i,
                            Cotisation_CSG_déductible = 4 * i
                        },
                        Remuneration = new Remuneration
                        {
                            Id = i * i + i,
                            Primes_éventuelles = i * 8,
                            Remboursement_transports_en_commun = i * 10
                        }
                    }
                };
                this.EmployesList.Add(employe);
            }
            return this.EmployesList;
        }


        public Employe GetById(int id)
        {
            Lister();
            foreach (var item in this.EmployesList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
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