
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Entities.Configuration;

namespace WebCore.Domain.Mappers.Configuration
{
    public class CategoryItemMapper : BaseMapper<CategoryItem>
    {
        public CategoryItemMapper()
            : base()
        {
            ToTable("CategoryItem");
            Property(g => g.Code);
            Property(g => g.Name);
            Property(g => g.OrderId);
            Property(g => g.CategoryId);
        }
    }
}
