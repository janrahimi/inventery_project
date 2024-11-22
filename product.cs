namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, Category category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }

        public override string ToString() => $"Product: {Name}, Price: {Price:C}, Category: {Category.Name}";
    }
}
