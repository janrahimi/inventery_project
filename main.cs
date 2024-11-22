using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using System;

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
            var tabletLocation = new Location(5, 2, 20); // Row 5, Floor 2, Shelf 20

            inventory.AddProduct(tabletProduct, tabletLocation);
           // inventory.Addstock(2,5);

            inventory.GetProductLocation(3); // For Tablet

            inventory.RemoveStock(1, 3, new Driver("Emily Clark", "Global Haulage", "TRK9876", DateTime.Now));
            inventory.GetDriverLog();

            var customer = new Customer(1, "Jan", "rahimi.john10@gmail.com");
            var order = new Order(1, customer);
            order.AddItem(new OrderItem(laptopProduct, 2));
            inventory.ProcessOrder(order);

            reportGenerator.GenerateInventoryReport(inventory);
            reportGenerator.GenerateLowStockReport(inventory, 3);

            // Adding user management
            User admin = new User("admin", "password123", Role.Admin);
            User employee = new User("employee", "password456", Role.Employee);

            Console.WriteLine("\nUser Role:");
            Console.WriteLine($"{admin.Username}: {admin.Role}");
            Console.WriteLine($"{employee.Username}: {employee.Role}");
        }
    }
}
