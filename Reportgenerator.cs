
namespace InventoryManagementSystem
{
    public class ReportGenerator
    {
        public void GenerateInventoryReport(Inventory inventory)
        {
            Console.WriteLine("\nInventory Report:");
        }
    }
}


/*using System;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
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
            Console.WriteLine($"{item.Product.Name}: {item.Quantity} units in stock (below threshold of {threshold})");
        }
    }

    public void GenerateTransactionReport(Inventory inventory)
    {
        Console.WriteLine("\nTransaction Report:");
        foreach (var transaction in inventory.GetTransactions())
        {
            Console.WriteLine($"{transaction.Date}: {transaction.Type} - {transaction.Quantity} units of {transaction.Product.Name}");
        }
    }
}

}
