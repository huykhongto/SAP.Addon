using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Business
{
    public class CustomerSearchViewModel
    {
        public int Sel { get; set; }
        public string CC { get; set; }
        public string CN { get; set; }
        public string ADDR { get; set; }
        public string CG { get; set; }
        public string TEL { get; set; }
        public string CT { get; set; }
        public string Balance { get; set; }
        public string CreditLine { get; set; }
    }
}
