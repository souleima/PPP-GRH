using PPP_Salaire.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP_Salaire.Repositories
{
    public interface IEmployeRepository
    {
        IList<Employe> Lister();
        Employe GetById(int id);
        void Update(Employe e);
        List<Employe> GetEmployes();
        IList<Employe> ListerBySelection(string columnName, string value);
        string Select();
        int GetByLogin(string login);
    }
}
