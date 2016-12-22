using SAP.Addon.Domain.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Mappers;

namespace SAP.Addon.Domain.Mappers.Administration
{
    public class ADMActionMapper : BaseMapper<ADMAction>
    {
        public ADMActionMapper()
            : base()
        {
            ToTable("ADM_Action");
            Property(g => g.Name);
            Property(g => g.Description);
            Property(g => g.Area);
        }
    }
}
