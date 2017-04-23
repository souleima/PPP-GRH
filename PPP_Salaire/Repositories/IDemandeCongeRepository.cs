using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP_Salaire.Repositories
{
    interface IDemandeCongeRepository
    {
        IList<DemandeConge> Lister();
        IList<DemandeConge> ListerById(int id);
        List<DemandeConge> GetByEmployeId(int id);
        void Update(DemandeConge e);
        List<DemandeConge> GetDemandeConges();
        string Inserer(int IdSelectedConge, DateTime DateDebut, DateTime DateFin, int IdUser);
        int DaysBetween(DateTime d1, DateTime d2);
        string Select();
        string SelectGrid();
        IList<DemandeConge> ListerBySelection(string columnName, string value, int IdUser);
    }
}
