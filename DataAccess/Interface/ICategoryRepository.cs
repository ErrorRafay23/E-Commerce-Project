using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using DOL = DataObjectLayer;

namespace DataAccess.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<List<Category?>> GetCategoryById(int id);
        Task<List<Category>> InsertCategory(Category request);
        Task<List<Category>?> UpdateCategory(int id, Category request);
        Task<List<Category>> DeleteCategory(int id);

    }
}
