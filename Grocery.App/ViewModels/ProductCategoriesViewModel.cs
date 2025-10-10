using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        public ObservableCollection<ProductCategory> ProductCategories { get; set; } = [];

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
            ProductCategories = [];
            Load();
        }

        public override void Load()
        {   
            ProductCategories.Clear();
            foreach (var item in _productCategoryService.GetAll()) ProductCategories.Add(item);
        }

        public override void OnAppearing()
        {
            Load();  
        }

        public override void OnDisappearing()
        {
            ProductCategories.Clear();
        }
    }
}
