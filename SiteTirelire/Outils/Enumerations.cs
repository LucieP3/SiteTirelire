using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteTirelire.Outils
{
    public enum EtatsCommande
    {
        Inactive = 0,
        Active = 1,
        Preparee = 2,
        Expediee = 3,
        Receptionnee = 4,
        Suspendue = 5

    }

    public enum EtatsAvis
    {
        Rejete = 0,
        NonApprouve = 1,
        Approuve = 2
    }
}