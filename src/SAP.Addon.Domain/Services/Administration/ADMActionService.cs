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

    public interface IADMActionService
    {
        IEnumerable<ADMAction> Get();
        ADMAction Get(int id);
        void Create(ADMAction entity);
        void Update(ADMAction entity);
        int Save();
        void Delete(ADMAction entity);
    }

    public class ADMActionService : IADMActionService
    {
        private readonly IADMActionRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ADMActionService(IADMActionRepository ADMActionRepository, IUnitOfWork unitOfWork)
        {
            this.repository = ADMActionRepository;
            //this.itemRepository = ADMActionItemRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ADMAction> Get()
        {
            return repository.GetAll();
        }

        public ADMAction Get(int id)
        {
            return repository.GetById(id);
        }

        public void Create(ADMAction entity)
        {
            repository.Add(entity);
        }

        public void Update(ADMAction entity)
        {
            repository.Update(entity);
        }

        public void Delete(ADMAction entity)
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
