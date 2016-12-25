using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Entities.Configuration;
using WebCore.Domain.Interfaces;
using WebCore.Domain.Interfaces.Configuration;

namespace WebCore.Domain.Repositories.Configuration
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
