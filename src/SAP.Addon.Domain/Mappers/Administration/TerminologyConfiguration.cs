using SAP.Addon.Domain.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Mapping.Administration
{
    public class TerminologyConfiguration : EntityTypeConfiguration<Terminology>
    {
        public TerminologyConfiguration()
        {
            ToTable("Terminology");
            Property(g => g.Id).IsRequired();
            Property(g => g.Code).IsRequired();
            Property(g => g.Name);
            Property(g => g.OrderId);
            Property(g => g.CreatedUserId);
            Property(g => g.CreatedDate);
            Property(g => g.ModifiedUserId);
            Property(g => g.ModifiedDate);
            Property(g => g.IsDeleted);
        }
    }
}
