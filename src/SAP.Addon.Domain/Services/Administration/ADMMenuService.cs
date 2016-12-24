using SAP.Addon.Domain.Entities.Administration;
using SAP.Addon.Domain.Interfaces.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;

namespace SAP.Addon.Domain.Services.Administration
{

    public interface IADMMenuService
    {
        IEnumerable<ADMMenu> Get();
        ADMMenu Get(int id);
        void Create(ADMMenu entity);
        void Update(ADMMenu entity);
        int Save();
        void Delete(ADMMenu entity);
    }

    public class ADMMenuService : IADMMenuService
    {
        private readonly IADMMenuRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ADMMenuService(IADMMenuRepository ADMMenuRepository, IUnitOfWork unitOfWork)
        {
            this.repository = ADMMenuRepository;
            //this.itemRepository = ADMMenuItemRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ADMMenu> Get()
        {
            return repository.GetAll();
        }

        public ADMMenu Get(int id)
        {
            return repository.GetById(id);
        }

        public void Create(ADMMenu entity)
        {
            repository.Add(entity);
        }

        public void Update(ADMMenu entity)
        {
            repository.Update(entity);
        }

        public void Delete(ADMMenu entity)
        {
            repository.Delete(entity);
        }

        public int Save()
        {
            try
            {
                return unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
            return 0;
        }
    }
}
