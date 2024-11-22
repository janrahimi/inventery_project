namespace InventoryManagementSystem.Models
{
    public class Location
    {
        public int Row { get; set; }
        public int Floor { get; set; }
        public int Shelf { get; set; }

        public Location(int row, int floor, int shelf)
        {
            Row = row;
            Floor = floor;
            Shelf = shelf;
        }

        public override string ToString()
        {
            return $"Row: {Row}, Floor: {Floor}, Shelf: {Shelf}";
        }
    }
}