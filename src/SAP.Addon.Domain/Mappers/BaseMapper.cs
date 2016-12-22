
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Entities;
using WebCore.Domain.Models;

namespace WebCore.Domain.Mappers
{
    public class BaseMapper<T> :  EntityTypeConfiguration<T>  where T : BaseEntity
    {
        public BaseMapper()
        {
            //ToTable("Gadgets");
            Property(g => g.Id).HasColumnName("Id").IsRequired();
            Property(g => g.CreatedDate).HasColumnName("CreatedDate");
            Property(g => g.CreatedUserId).HasColumnName("CreatedUserId");
            Property(g => g.ModifiedDate).HasColumnName("ModifiedDate");
            Property(g => g.ModifiedUserId).HasColumnName("ModifiedUserId");
            Property(g => g.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
