using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Business
{
    public class BlanketAgreementItemSearchViewModel
    {
        public string IC { get; set; }
        public string IN { get; set; }
        public string UOM { get; set; }
        public string IG { get; set; }
        public string MF { get; set; }
        public string RM { get; set; }
        public decimal? Vat { get; set; }
        public decimal? BasePrice { get; set; }

    }
}
