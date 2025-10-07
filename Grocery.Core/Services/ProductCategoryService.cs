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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public ProductCategory? Get(string name)
        {
            return _productCategoryRepository.Get(name);
        }

        public ProductCategory? Get(int id)
        {
            return _productCategoryRepository.Get(id);
        }

        public List<ProductCategory> GetAll()
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll();
            return productCategories;
        }
    }
}
