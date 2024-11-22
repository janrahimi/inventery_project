using System.Collections.Generic;

namespace InventoryManagementSystem.Models
{
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
}
