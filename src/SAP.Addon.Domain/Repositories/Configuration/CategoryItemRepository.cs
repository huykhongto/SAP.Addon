
using WebCore.Domain.Interfaces.Configuration;
using WebCore.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;

namespace WebCore.Domain.Repositories.Configuration
{
    public class CategoryItemRepository : RepositoryBase<CategoryItem>, ICategoryItemRepository
    {
        public CategoryItemRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

}
