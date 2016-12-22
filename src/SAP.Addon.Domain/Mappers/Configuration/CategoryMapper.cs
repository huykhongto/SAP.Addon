using WebCore.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Entities.Configuration;

namespace WebCore.Domain.Mappers.Configuration
{
    public class CategoryMapper : BaseMapper<Category>
    {
        public CategoryMapper()
            : base()
        {
            ToTable("Category");
            Property(g => g.Code);
            Property(g => g.Name);
            Property(g => g.OrderId);
        }
    }
}
