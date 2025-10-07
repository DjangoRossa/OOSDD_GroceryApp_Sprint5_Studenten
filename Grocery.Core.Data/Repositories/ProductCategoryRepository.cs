
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategoryRepository> productCategoryList;

        public ProductCategoryRepository()
        {
            productCategoryList = [
                new ProductCategory(1, "Zuivel", 1, 1),
                new ProductCategory(2, "Groenten", 2, 1),
                new ProductCategory(3, "Fruit", 3, 2)
            ];
        }

        public ProductCategory? Get(string name)
        {
            ProductCategory? category = productCategoryList.FirstOrDefault(c => c.Name.Equals(name));
            return category;
        }

        public ProductCategory? Get(int id)
        {
            ProductCategory? category = productCategoryList.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public List<ProductCategory> GetAll()
        {
            return productCategoryList;
        }
    }
}
