using SAP.Addon.Domain.Entities.Administration;
using SAP.Addon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;

namespace SAP.Addon.Domain.Repositories.Administration
{
    public class TerminologyRepository : RepositoryBase<Terminology>, ITerminologyRepository
    {
        public TerminologyRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ITerminologyRepository : IRepository<Terminology>
    {
    }
}
