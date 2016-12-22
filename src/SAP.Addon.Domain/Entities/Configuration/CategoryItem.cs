using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Entities;

namespace WebCore.Domain.Models.Configuration
{
    public class CategoryItem : BaseEntity
    {
        public int? CategoryId { get; set; }

        public string Name { get; set; }

        public int? OrderId { get; set; }

        public string Code { get; set; }
    }
}
