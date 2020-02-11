using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteTirelire.Outils
{
    public class TotalProduit
    {
        
            public string NomProduit { get; set; }
            public string chemin{ get; set; }
            public int IdProduit { get; set; }
            public double QuantitéTotal { get; set; }
        }
        public class TotalGlobal
        {
            public List<TotalProduit> ListIds { get; set; }
        }
    



}
