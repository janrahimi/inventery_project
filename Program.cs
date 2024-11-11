using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

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
            Id = id;
            Customer = customer;
            Items = new List<OrderItems>();
        }

        public void AddItem(OrderItem item){
            Items.Add(item);
        }



    }


}
