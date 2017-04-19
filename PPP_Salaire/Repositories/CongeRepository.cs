using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPP_Salaire.Repositories
{
    public class CongeRepository
    {
        public string Select()
        {
            return "SELECT [Nom] FROM [Conges]";
        }
        public string Inserer()
        {
            return "INSERT INTO [Conges]( [Nom] ) VALUES (@Nom)";
        }
    }
}