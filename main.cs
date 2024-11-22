using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using System;

namespace InventoryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Inventory Management System!");
            
            // Example instantiation
            var inventory = new Inventory();
            var reportGenerator = new ReportGenerator();

            // Add business logic here
        }
    }
}
