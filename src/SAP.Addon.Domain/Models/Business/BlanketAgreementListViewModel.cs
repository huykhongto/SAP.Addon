using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Business
{
    public class BlanketAgreementListViewModel
    {
        public int AgrNo { get; set; }
        public int? SAPAgrNo { get; set; }

        public string ContractNo { get; set; }
        public string BpCode { get; set; }
        public string BpName { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string StaffName { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool? Active { get; set; }
    }
}
