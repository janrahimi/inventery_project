namespace InventoryManagementSystem
{
    public class StockItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Location Location { get; set; }

        public StockItem(Product product, Location location)
        {
            Product = product;
            Quantity = 0;
            Location = location;
        }
    }
}
// har skapat en till klass