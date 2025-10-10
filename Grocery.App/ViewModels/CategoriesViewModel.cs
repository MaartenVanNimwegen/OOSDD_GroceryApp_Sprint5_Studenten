using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;
        public ObservableCollection<Category> Categories { get; set; } = [];

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = [];
            Load();
        }

        public override void Load()
        {   
            Categories.Clear();
            foreach (var item in _categoryService.GetAll()) Categories.Add(item);
        }

        public override void OnAppearing()
        {
            Load();  
        }

        public override void OnDisappearing()
        {
            Categories.Clear();
        }

        [RelayCommand]
        public async Task SelectCategory(Category category)
        {
            if (category == null) return;
            await Shell.Current.GoToAsync($"{nameof(ProductCategoriesView)}", true);
        }
    }
}
