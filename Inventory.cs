using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
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
            Console.WriteLine($"{quantity} units of {stockItem.Product.Name} added to stock at {stockItem.Location}. Driver: {driver}");
        }
        else
        {
            Console.WriteLine("Product not found.");
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
        else
        {
            Console.WriteLine("Insufficient stock or product not found.");
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
            else
            {
                Console.WriteLine($"Insufficient stock for {item.Product.Name}");
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

    public List<StockItem> GetStockItems() => stockItems;
    public List<Transaction> GetTransactions() => transactions;
}

}
