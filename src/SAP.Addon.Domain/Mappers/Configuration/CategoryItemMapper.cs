using WebCore.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
