using System.Collections.ObjectModel;
using AndroidX.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;

        public ObservableCollection<Category> Categories { get; set; }

        [ObservableProperty]
        Category? _name;

        public CategoriesViewModel(ICategoryService categoryService, GlobalViewModel global)
        {
            _categoryService = categoryService;
            Categories = new(_categoryService.GetAll());
        }

        // Navigates to the ProductCategoriesView for the selected category.
        [RelayCommand]
        public async Task SelectCategory(Category category)
        {
            Dictionary<string, object> paramater = new() { { nameof(Category), category } };
            await Shell.Current.GoToAsync($"{nameof(Views.ProductCategoriesView)}", true, paramater);
        }
    }
}
