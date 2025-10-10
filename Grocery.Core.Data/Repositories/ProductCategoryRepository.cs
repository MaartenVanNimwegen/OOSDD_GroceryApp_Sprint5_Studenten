
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategoryList;

        public ProductCategoryRepository()
        {
            productCategoryList = [
                new ProductCategory(1, "Zuivel", 1, 1),
                new ProductCategory(2, "Zuivel", 2, 1),
                new ProductCategory (3, "Brood", 3, 2),
                new ProductCategory(4, "Ontbijt", 4, 3)
            ];
        }

        public ProductCategory Get(int id)
        {
            var productCategory = productCategoryList.FirstOrDefault(c => c.Id == id);
            if (productCategory is null)
                throw new KeyNotFoundException($"Category with Id {id} was not found.");
            return productCategory;
        }

        public ProductCategory Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name must be provided.", nameof(name));

            var productCategory = productCategoryList.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
            if (productCategory is null)
                throw new KeyNotFoundException($"Category with name '{name}' was not found.");
            return productCategory;
        }

        public List<ProductCategory> GetAll()
        {
            return productCategoryList;
        }
    }
}
