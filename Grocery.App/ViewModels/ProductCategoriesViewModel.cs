using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{    
    // Enables query property binding for navigation, allowing the Category to be set via navigation parameters.
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        public ObservableCollection<ProductCategory> ProductCategories { get; set; } = [];

        // The currently selected category, set via navigation or directly.
        [ObservableProperty]
        private Category category = new(0, "None");

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        // Loads product categories for the specified category.
        public void LoadProductCategoriesByCategory(Category category)
        {
            ProductCategories.Clear();
            var productCategories = _productCategoryService.GetAllOnCategoryId(category.Id);
            foreach (var productCategory in productCategories)
                ProductCategories.Add(productCategory);
        }

        // Called automatically when the Category property changes.
        partial void OnCategoryChanged(Category value)
        {
            LoadProductCategoriesByCategory(value);
        }
    }
}
