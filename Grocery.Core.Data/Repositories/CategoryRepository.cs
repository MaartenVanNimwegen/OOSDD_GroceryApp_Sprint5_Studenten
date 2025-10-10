
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly List<Category> categoryList;

        public CategoryRepository()
        {
            categoryList = [
                new Category(1, "Zuivel"),
                new Category(2, "Brood"),
                new Category(3, "Ontbijt"),
            ];
        }

        public Category Get(int id)
        {
            var category = categoryList.FirstOrDefault(c => c.Id == id);
            if (category is null)
                throw new KeyNotFoundException($"Category with Id {id} was not found.");
            return category;
        }

        public Category Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name must be provided.", nameof(name));

            var category = categoryList.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
            if (category is null)
                throw new KeyNotFoundException($"Category with name '{name}' was not found.");
            return category;
        }

        public List<Category> GetAll()
        {
            return categoryList;
        }
    }
}
