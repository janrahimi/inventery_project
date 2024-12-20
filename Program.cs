using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    public class InventorySystem
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Inventory Management System!");

            Inventory inventory = new Inventory();
            ReportGenerator reportGenerator = new ReportGenerator();

            var electronicsCategory = new Category("Electronics");
            var laptopProduct = new Product(1, "Laptop", electronicsCategory, 1200.00m);
            var phoneProduct = new Product(2, "iPhone", electronicsCategory, 800.00m);

            var laptopLocation = new Location(1, 1, 5); // Row, Floor, Shelf
            var phoneLocation = new Location(2, 3, 10);

            var driver1 = new Driver("John Smith", "ABC Logistics", "TRK1234", DateTime.Now);
            var driver2 = new Driver("Jane Doe", "XYZ Freight", "TRK5678", DateTime.Now);

            inventory.AddProduct(laptopProduct, laptopLocation);
            inventory.AddProduct(phoneProduct, phoneLocation);

            inventory.AddStock(1, 10, driver1);
            inventory.AddStock(2, 5, driver2);
            inventory.GetProductLocation(1);
            inventory.GetProductLocation(2);

            var tabletProduct = new Product(3, "Tablet", electronicsCategory, 600.00m);
            var tabletLocation = new Location(5, 2, 20);

            inventory.AddProduct(tabletProduct, tabletLocation);
            inventory.GetProductLocation(3);

            inventory.RemoveStock(1, 3, new Driver("Emily Clark", "Global Haulage", "TRK9876", DateTime.Now));
            inventory.GetDriverLog();

            var customer = new Customer(1, "Jan", "rahimi.john10@gmail.com");
            var order = new Order(1, customer);
            order.AddItem(new OrderItem(laptopProduct, 2));
            inventory.ProcessOrder(order);

            reportGenerator.GenerateInventoryReport(inventory);
            reportGenerator.GenerateLowStockReport(inventory, 3);

            User admin = new User("admin", "password123", Role.Admin);
            User employee = new User("employee", "password456", Role.Employee);

            Console.WriteLine("\nUser Role:");
            Console.WriteLine($"{admin.Username}: {admin.Role}");
            Console.WriteLine($"{employee.Username}: {employee.Role}");
        }
    }

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

        public void UpdatePrice(string name, Category category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        public override string ToString() => $"Product: {Name}, Price: {Price:C}, Category: {Category.Name}";
    }

    public enum Category// här jag har ändrat klass till enum
     {
          Electronics,
         Clothing,
         Food,
         Furniture,
         Books
     }
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public Supplier(int id, string name, string contactInfo)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; }

        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
            Items = new List<OrderItem>();
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    public class Inventory
    {
        private List<StockItem> stockItems = new List<StockItem>();
        private List<Transaction> transactions = new List<Transaction>();
        private List<Driver> drivers = new List<Driver>();

        public void AddProduct(Product product, Location location)
        {
            stockItems.Add(new StockItem(product, location));
            Console.WriteLine($"{product.Name} added to inventory at {location}");
        }

        public StockItem GetProductLocation(int productId)
        {
            var stockItem = stockItems.FirstOrDefault(s => s.Product.Id == productId);
            if (stockItem != null)
            {
                Console.WriteLine($"{stockItem.Product.Name} is located at {stockItem.Location}");
                return stockItem;
            }
            else
            {
                Console.WriteLine("Product not found in inventory.");
                return null;
            }
        }

        public void AddStock(int productId, int quantity, Driver driver)
        {
            var stockItem = stockItems.Find(s => s.Product.Id == productId);
            if (stockItem != null)
            {
                stockItem.Quantity += quantity;
                transactions.Add(new Transaction(stockItem.Product, quantity, TransactionType.IN));
                drivers.Add(driver);
                Console.WriteLine($"{quantity} units of {stockItem.Product.Name} added to stock. Driver: {driver}");
            }
        }

        public void RemoveStock(int productId, int quantity, Driver driver)
        {
            var stockItem = stockItems.Find(s => s.Product.Id == productId);
            if (stockItem != null && stockItem.Quantity >= quantity)
            {
                stockItem.Quantity -= quantity;
                transactions.Add(new Transaction(stockItem.Product, quantity, TransactionType.OUT));
                drivers.Add(driver);
                Console.WriteLine($"{quantity} units of {stockItem.Product.Name} removed from stock. Driver: {driver}");
            }
        }

        public void ProcessOrder(Order order)
        {
            foreach (var item in order.Items)
            {
                var stockItem = stockItems.Find(s => s.Product.Id == item.Product.Id);
                if (stockItem != null && stockItem.Quantity >= item.Quantity)
                {
                    stockItem.Quantity -= item.Quantity;
                    transactions.Add(new Transaction(stockItem.Product, item.Quantity, TransactionType.OUT));
                    Console.WriteLine($"{item.Quantity} unit(s) of {item.Product.Name} sold to {order.Customer.Name}");
                }
            }
        }

        public void GetDriverLog()
        {
            Console.WriteLine("\nDriver Log:");
            foreach (var driver in drivers)
            {
                Console.WriteLine(driver);
            }
        }
    }

    public class StockItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Location Location { get; set; }

        public StockItem(Product product, Location location)
        {
            Product = product;
            Location = location;
            Quantity = 0;
        }
    }

    public enum TransactionType
    {
        IN,
        OUT
    }

    public class Location
    {
        public int Row { get; set; }
        public int Floor { get; set; }
        public int Shelf { get; set; }

        public Location(int row, int floor, int shelf)
        {
            Row = row;
            Floor = floor;
            Shelf = shelf;
        }
    }

    public class Driver
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string TruckNumber { get; set; }
        public DateTime DateTime { get; set; }

        public Driver(string name, string company, string truckNumber, DateTime dateTime)
        {
            Name = name;
            Company = company;
            TruckNumber = truckNumber;
            DateTime = dateTime;
        }
    }

    public class ReportGenerator
    {
        public void GenerateInventoryReport(Inventory inventory)
        {
            Console.WriteLine("\nInventory Report:");
            foreach (var item in inventory.GetStockItems())
            {
                Console.WriteLine($"{item.Product.Name}: {item.Quantity} units in stock");
            }
        }

        public void GenerateLowStockReport(Inventory inventory, int threshold)
        {
            Console.WriteLine("\nLow Stock Report:");
            foreach (var item in inventory.GetStockItems().Where(i => i.Quantity < threshold))
            {
                Console.WriteLine($"{item.Product.Name}: {item.Quantity} units");
            }
        }
    }

    public enum Role
    {
        Admin,
        Manager,
        Employee
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
