using SAP.Addon.Domain.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Mappers;

namespace SAP.Addon.Domain.Mappers.Administration
{
    public class ADMMenuMapper : BaseMapper<ADMMenu>
    {
        public ADMMenuMapper()
            : base()
        {
            ToTable("ADM_Menu");
            Property(g => g.Name);
            Property(g => g.OrderId);
            Property(g => g.ParentId);
            Property(g => g.CssClass);
            Property(g => g.Status);
        }
    }
}
