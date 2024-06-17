using Entities.Dtos;
using Entities.Models;
using Repositories.Contract;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateCategory(CategoryDtoForCreate categoryDtoForCreate)
        {
            Category category = new Category()
            {
                //CategoryId = categoryDtoForCreate.CategoryId,
                CategoryName = categoryDtoForCreate.CategoryName
            };
            _manager.CategoryRepository.Create(category);
            _manager.Save();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = _manager.CategoryRepository.GetAllCategories();
            return categories;
        }
    }
}
