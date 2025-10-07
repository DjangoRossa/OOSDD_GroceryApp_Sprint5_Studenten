using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        public ProductCategory? Get(string name);
        public ProductCategory? Get(int id);
        public List<ProductCategory> GetAll();
    }
}