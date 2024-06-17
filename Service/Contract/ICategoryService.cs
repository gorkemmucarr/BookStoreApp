using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        void CreateCategory(CategoryDtoForCreate categoryDtoForCreate);
    }
}
