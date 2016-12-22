using SAP.Addon.Domain.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;

namespace SAP.Addon.Domain.Repositories.Administration
{
    public class TerminologyItemRepository : RepositoryBase<TerminologyItem>, ITerminologyItemRepository
    {
        public TerminologyItemRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ITerminologyItemRepository : IRepository<TerminologyItem>
    {
    }
}
