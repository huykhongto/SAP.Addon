using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Entities;

namespace SAP.Addon.Domain.Entities.Administration
{
    public class ADMMenu : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int? ActionId { get; set; }

        public int? OrderId { get; set; }

        public bool? Status { get; set; }

        public string CssClass { get; set; }
    }
}
