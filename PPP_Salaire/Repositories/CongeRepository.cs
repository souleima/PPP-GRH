using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Repositories
{
    public class CongeRepository
    {
        public string SelectAll()
        {
            return "SELECT [Nom] FROM [Conges]";
        }
    }
}