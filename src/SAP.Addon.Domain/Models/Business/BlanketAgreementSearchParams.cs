using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Business
{
    public class BlanketAgreementSearchParams
    {
        public int ABSID { get; set; }
        public int TOABSID { get; set; }
        public DateTime? STARTDATE { get; set; }
        public DateTime? TOSTARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
        public DateTime? TOENDDATE { get; set; }
        public DateTime? SIGNGDATE { get; set; }
        public DateTime? TOSIGNDATE { get; set; }
        public string BPCODE { get; set; }
        public string BPNAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATUS { get; set; }
        public string ITEMNAME { get; set; }
        public int SHOWINACTIVE { get; set; }
        public int USERSIGN { get; set; }
    }
}
