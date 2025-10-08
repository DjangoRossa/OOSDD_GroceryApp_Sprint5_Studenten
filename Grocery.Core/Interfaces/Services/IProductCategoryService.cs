using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        public List<ProductCategory> GetAll();

        public List<ProductCategory> GetAllOnCategoryId(int id);
    }
}
