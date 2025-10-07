using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class ProductCategory : Model
    {
        public ProductCategory(int id, string name, int productId, int categoryId) : base(id, name)
        {
            Id = id;
            Name = name;
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}
