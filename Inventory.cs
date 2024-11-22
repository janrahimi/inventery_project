using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class Inventory
    {
        private List<StockItem> stockItems = new List<StockItem>();

        public void AddProduct(Product product, Location location)
        {
            stockItems.Add(new StockItem(product, location));
        }
        
        // Add additional Inventory-related methods as required
    }
}
