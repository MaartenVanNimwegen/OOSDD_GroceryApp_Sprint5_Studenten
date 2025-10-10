using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;
        public double Price { get; set; }
        public DateOnly ShelfLife { get; set; }
        public Product(int id, string name, int stock, double price) : this(id, name, stock, price, default) { }

        public Product(int id, string name, int stock, double price, DateOnly shelfLife) : base(id, name) 
        {
            Stock = stock;
            Price = price;
            ShelfLife = shelfLife;
        }
        public override string? ToString()
        {
            return $"{Name} - van {Price} per stuk - {Stock} op voorraad";
        }
    }
}
