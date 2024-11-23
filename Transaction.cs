namespace InventoryManagementSystem
{
    public class Transaction
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }

        public Transaction(Product product, int quantity, TransactionType type)
        {
            Product = product;
            Quantity = quantity;
            Type = type;
            Date = DateTime.Now;
        }
    }

    public enum TransactionType
    {
        IN,
        OUT
    }
}
