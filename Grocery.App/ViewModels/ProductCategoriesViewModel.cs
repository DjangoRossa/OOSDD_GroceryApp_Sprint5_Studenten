using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;

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

        private string searchText = string.Empty;

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

        private void GetProductCategoriesBySearch()
        {
            ProductCategories.Clear();
            var productCategories = _productCategoryService.GetAllOnCategoryId(category.Id);

            foreach (var productCategory in productCategories)
            {
                // Search by Product.Name (case-insensitive)
                if (string.IsNullOrWhiteSpace(searchText) ||
                    (productCategory.Product != null &&
                     productCategory.Product.name != null &&
                     productCategory.Product.name.Contains(searchText, StringComparison.OrdinalIgnoreCase)))
                {
                    ProductCategories.Add(productCategory);
                }
            }
        }

        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText;
            GetProductCategoriesBySearch();
        }
    }
}
