using SAP.Addon.Domain.Entities.Administration;
using SAP.Addon.Domain.Repositories.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;

namespace SAP.Addon.Domain.Services.Administration
{
    public interface ITerminologyService
    {
        IEnumerable< Terminology> GetTerminologies();
         Terminology GetTerminology(int id);
        void CreateTerminology( Terminology Terminology);
        void SaveTerminology();

        void UpdateTerminology(Terminology Terminology);
        void RemoveTerminology(int id);
        IEnumerable<TerminologyItem> GetItemByCode(string TerminologyCode);
    }

    public class TerminologyService : ITerminologyService
    {
        private readonly ITerminologyRepository TerminologysRepository;
        private readonly ITerminologyItemRepository TerminologyItemRepository;
        private readonly IUnitOfWork unitOfWork;

        public TerminologyService(ITerminologyRepository terminologysRepository, ITerminologyItemRepository terminologyItemRepository, IUnitOfWork unitOfWork)
        {
            this.TerminologysRepository = terminologysRepository;
            this.TerminologyItemRepository = terminologyItemRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Terminology> GetTerminologies()
        {
            var Terminologys = TerminologysRepository.GetAll();
            return Terminologys;
        }

        public Terminology GetTerminology(int id)
        {
            var Terminology = TerminologysRepository.GetById(id);
            return Terminology;
        }

        public void CreateTerminology(Terminology Terminology)
        {
            TerminologysRepository.Add(Terminology);
        }

        public void UpdateTerminology(Terminology Terminology)
        {
            TerminologysRepository.Update(Terminology);
        }
        public void RemoveTerminology(int id)
        {
            Terminology entity = TerminologysRepository.GetById(id);
            TerminologysRepository.Delete(entity);
        }

        public void SaveTerminology()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<TerminologyItem> GetItemByCode(string TerminologyCode)
        {
            var ter = TerminologysRepository.GetMany(t => t.Code == TerminologyCode).FirstOrDefault();
            if (ter != null)
                return TerminologyItemRepository.GetMany(i => i.TerminologyId == ter.Id).OrderBy(m=>m.OrderId);
            return new List<TerminologyItem>();
        }
    }
}
