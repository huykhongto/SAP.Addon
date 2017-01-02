using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Business
{
    public class MeasureListViewModel
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string UoM { get; set; }
        public string UoMType { get; set; }
        public decimal ItemsPerUoM { get; set; }
        public string Description { get; set; }
        public string Default { get; set; }
    }
}
