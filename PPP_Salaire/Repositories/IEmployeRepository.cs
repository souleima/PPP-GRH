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
    }
}
