using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category? Get(string name)
        {
            return _categoryRepository.Get(name);
        }

        public Category? Get(int id)
        {
            return _categoryRepository.Get(id);
        }

        public List<Category> GetAll()
        {
            List<Category> categories = _categoryRepository.GetAll();
            return categories;
        }
    }
}
