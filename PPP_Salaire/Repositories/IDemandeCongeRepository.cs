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
        DemandeConge GetById(int id);
        void Update(DemandeConge e);
    }
}
