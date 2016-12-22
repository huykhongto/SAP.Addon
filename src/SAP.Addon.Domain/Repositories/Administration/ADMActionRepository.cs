using SAP.Addon.Domain.Entities.Administration;
using SAP.Addon.Domain.Interfaces.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;
using WebCore.Domain.Repositories;

namespace SAP.Addon.Domain.Repositories.Administration
{
    public class ADMActionRepository : RepositoryBase<ADMAction>, IADMActionRepository
    {
        public ADMActionRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

}
