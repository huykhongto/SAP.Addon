using SAP.Addon.Domain.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Administration
{
    public class MenuViewModel 
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int? ActionId { get; set; }

        public int? OrderId { get; set; }

        public bool? Status { get; set; }

        public string CssClass { get; set; }
        //public ADMAction Action { get; set; }

        public string ActionName { get; set; }
        public string ActionArea { get; set; }

    }
}
