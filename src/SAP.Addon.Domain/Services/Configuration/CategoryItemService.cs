using WebCore.Domain.Interfaces.Configuration;
using WebCore.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;
using System.Collections;

namespace WebCore.Domain.Services.Configuration
{
    public interface ICategoryItemService
    {
        IEnumerable<CategoryItem> Get();
        CategoryItem Get(int id);
        void Create(CategoryItem entity);
        void Update(CategoryItem entity);
        int Save();
        void Delete(CategoryItem entity);
        IEnumerable<CategoryItem> GetItemByCode(string categoryCode);
    }

    public class CategoryItemService : ICategoryItemService
    {
        private readonly ICategoryItemRepository repository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryItemService(ICategoryItemRepository CategoryItemRepository , ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.repository = CategoryItemRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CategoryItem> Get()
        {
            return repository.GetAll();
        }

        public CategoryItem Get(int id)
        {
            return repository.GetById(id);
        }

        public void Create(CategoryItem entity)
        {
            repository.Add(entity);
        }

        public void Update(CategoryItem entity)
        {
            repository.Update(entity);
        }

        public void Delete(CategoryItem entity)
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

        public IEnumerable<CategoryItem> GetItemByCode(string code)
        {
            var ter = categoryRepository.GetMany(c=>c.Code==code).FirstOrDefault();
            if (ter != null)
                return repository.GetMany(i => i.CategoryId == ter.Id).OrderBy(m => m.OrderId);
            return new List<CategoryItem>();
        }
    }

}
