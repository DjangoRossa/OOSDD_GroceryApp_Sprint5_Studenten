
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categoryList;

        public CategoryRepository()
        {
            categoryList = [
                new Category(1, "Zuivel"),
                new Category(2, "Groenten"),
                new Category(3, "Fruit")
            ];
        }

        public Category? Get(string name)
        {
            Category? category = categoryList.FirstOrDefault(c => c.Name.Equals(name));
            return category;
        }

        public Category? Get(int id)
        {
            Category? category = categoryList.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public List<Category> GetAll()
        {
            return categoryList;
        }
    }
}
