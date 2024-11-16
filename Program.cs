﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Transactions;
using InventoryManagementSystem;

namespace InventoryManagementSystem
{
    public class InventorySystem{
        public static void main(String[] args){
            Console.WriteLine("welcome to inventory management system!");

            Inventory inventory = new Inventory();
            ReportGenerator reportGenerator = new ReportGenerator();

            var electronicsCategory = new Category("electronics");
            var LaptopProduct = new Product(1, "laptop", electronicsCategory, 1200.00m);
            var PhoneProduct = new Product(2,"iphone", electronicsCategory, 800.00m);

            inventory.AddProduct(LaptopProduct);
            inventory.AddProduct(PhoneProduct);

            inventory.AddStock(1,10);
            inventory.AddStock(2,5);

               var customer = new Customer(1, "Jan", "rahimi.john10@gmail.com");
            var order = new Order(1, customer);
            order.AddItem(new OrderItem(laptopProduct, 2));
            inventory.ProcessOrder(order);

            reportGenerator.GeneratInventoryReport(inventory);
            reportGenerator.GeneratLowStockReport(inventory, 3);

            // adding user management

            User admin = new User("admin", "password 123", Role.Admin);
            User employee = new User("employee", "password 456", Role.employee);

            Console.WriteLine("\n User Role:");
            Console.WriteLine($"{admin.Username}:{admin.Role}");
            Console.WriteLine($"{employee.Username}:{employee.Role}");



        }
    }

    // class for product

    public class Product
    {
        public int Id{get;set; }
        public String Name{get; set; }
        public Category Category{get; set; }
        public decimal Price{get; set; }

        public Product(int Id, String Name, Category Category, decimal price){
           this.Id = Id;
            this.Name = Name;
            this.Category = Category;
            this.Price = price;

        }

        public void UppdatePrice(String Name, Category category, decimal Price){
            this.Name = Name;
            this.Category = category;
            this.Price = Price;

        }

        public override string ToString()=> $" product:{Name}, price: {Price:C}, Category:{Category.Name}";
        {

        }


    }

    public class Category{
        
        public string Name{get; set;}

        public Category(string name)
        {
            Name = name;
        }
    
    }

    // supplier class 

    public class Supplier{
        public int Id{get; set;}
        public String Name{get;set;}
        public String ContactInfo{get;set;}

        public Supplier(int Id, String Name, String ContactInfo){
            this.Id = Id;
            this.Name = Name;
            this.ContactInfo = ContactInfo;
        }

    }

    public class Customer{
        public int Id{get; set;}
        public String Name{get;set;}
        public String Email{get;set;}

        public Customer(int Id, String Name, String Email){
            this.Id= Id;
            this.Name = Name;
            this.Email = Email;
        }
    }

    public class Order{
        public int Id{get; set;}
        public Customer Customer{get; set;}
        public List<OrderItems>Items {get; set;}

        public Order(int Id, Customer customer){
            this.Id = id;
            this.Customer = customer;
            this.Items = new List<OrderItems>();
        }

        public void AddItem(OrderItem item){
            Items.Add(item);
        }

    }

    // order item class

    public class OrderItem{
        public Product product{get; set;}
        public int Quantity{get;set;}


        public OrderItem(Product product, int Quantity){
            this.product = product;
            this.Quantity = Quantity;
        }
        

    }

    // inventery class

    public class Inventory{
        private List<StockItem>StockItemsItems = new <StockItem>();
        private List<Transaction>Transactions = new <Transaction>();

        public void AddProduct(Product product){
            stockItems.Add(new StockItem(product));
            Console.WriteLine($"{product.Name}added to inventory.");

        }

        public void RemoveStock(int productId){
            var Items = stockItems.fint(s => Items.product.Id ==ProductId);
            if(Items!=null){
                StockItems.Remove(item);
                Console.WriteLine($"{Item.Product.Name} removed frome the inventory list");
            }
            else{
                Console.WriteLine("product not found");
            }

        }
        public void AddStock(int ProductId, int Quantity){
            var Items = StockItemsItems.Find(s=> Items.Product.Id == ProductId);
            if(Items!= null){
               Items.Quantity += Quantity;
               Transactions.Add(new Transaction.(Items.product,Quantity, TransactionsType.IN));
               Console.WriteLine($"{quantity}unite of {Item.Product.Name} added to stock");
            }
        }

        public void ProcessOrder(Order order){
            foreach(var item in order.Items){
                var stockItems.Find(s => s.product.id == item.Product.Id);
                if(stockItems != null && stockItems.Quantity >= item.Quantity){
                   stockItems.Quantity -= item.Quantity;
                   Transactions.Add(new Transaction(stockItem.Product, item.Quantity, TransactionsType.Out));
                   Console.WriteLine($"{item.Quantity} unit of {item.Product.Name} sold to {order.Customer.Name}");

                }
                else{
                    Console.WriteLine($"insufficient stock for{item.Prodct.Name}");
                }

            }
        }

        public List<StockItem> GetStockItems() => stockItems;
        public List<Transaction> GetTransactions() =>Transactions;

    }

    //  stockitem class 

    public class StockItem{
        public Product Product {get; set;}
        public int Quantity{get; set;}

        public StockItem(Product product){
            Product= product;
            Quantity = 0;
        }
    }

    // transaction class 

    public class Transaction(){
        public Product product{get; set;}
        public int Quantity{get; set;}
        public TransactionType Type {get;set;}
        public DateTime date{get; set;}

        public Transaction(Product product, int quantity, TransactionType type){
            Product = product;
            Quantity = quantity;
            Type = type;
            Date = DateTime.Now;
        }

    }

    // Transaction enum

    public enum TransactionType{
        IN, 
        OUT,
    }

    // Warehouse class 

    public class Warehouse{
        public string Location{get; set;}
        public string Manager{get;set;}

        public Warehouse(string location, string manager){
            Location = location;
            Manager = manager;
        }
    }

    // location class in warhouse

    public class Location{
        public int Row{get;set;}
        public int Floor{get;set;}
        public int Shelf{get;set;}

        public Location(int row, int floor, int shelf){
            Row = row;
        Floor = floor;
        Shelf = shelf;

        }
    }

        // ReportGenerator Class with Additional Reports

        public class ReportGenerator{

            public void GeneratInventoryReport(Inventory inventory){
                Console.WriteLine("\nInventorY Report:");
                foreach(var Item in inventory.GetStockItems()){
                    Console.WriteLine($"{Item.Product.Name}:{Item.Quantity} units in stock");

                }
            }
            public void GeneratLowStockReport(Inventory inventory, int threshold){
                Console.WriteLine("\n Low StoCK Report");
                foreach(var item in inventory.GetStockItems().Where(i => i.Quantity<threshold)){
                    Console.WriteLine($"{item.Product.Name}:{item.Quantity} units in stock(below threshold of{threshold})");
                }
            }

            public void GeneratTransactionRepor(Inventory inventory){
                Console.WriteLine("\n Transaction report:");
                foreach(var transaction in inventory.GetTransactions()){
                    Console.WriteLine($"{transaction.date}:{transaction.Type}-{transaction.Quantity} units of {transaction.product.Name}");
                }
            }
        }

        // user class with role_base access

        public class User{
            public string Username{get; set;}
            public string Password{get; set;}
            public Role Role{get; set;}

            public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
              
        } 

        // enum with additional roles

    public enum Role{
        Admin,
        Manager,
        Employee,

    }


}
