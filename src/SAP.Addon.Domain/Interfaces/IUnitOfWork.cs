using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Domain.Interfaces
{
  public interface IUnitOfWork
    {
      void Commit();
    }
}
