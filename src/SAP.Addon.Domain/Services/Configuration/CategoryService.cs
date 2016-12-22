
using WebCore.Domain.Interfaces.Configuration;
using WebCore.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;
using WebCore.Domain.Entities.Configuration;

namespace WebCore.Domain.Services.Configuration
{
    public interface ICategoryService
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        void Create(Category entity);
        void Update(Category entity);
        int Save();
        void Delete(Category entity);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository CategoryRepository,  IUnitOfWork unitOfWork)
        {
            this.repository = CategoryRepository;
            //this.itemRepository = categoryItemRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> Get()
        {
            return repository.GetAll();
        }

        public Category Get(int id)
        {
            return repository.GetById(id);
        }

        public void Create(Category entity)
        {
            repository.Add(entity);
        }

        public void Update(Category entity)
        {
            repository.Update(entity);
        }

        public void Delete(Category entity)
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
