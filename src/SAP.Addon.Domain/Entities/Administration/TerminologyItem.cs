using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Entities.Administration
{
    public class TerminologyItem
    {
        public int Id { get; set; }

        public int? TerminologyId { get; set; }

        public string Name { get; set; }

        public int? OrderId { get; set; }

        public string Code { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? IsDeleted { get; set; }

    }

}
