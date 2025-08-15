using System;

namespace Assignment3.Question3_Warehouse
{
    public class GroceryItem : IInventoryItem
    {
        public int Id { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; }

        public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }

        public override string ToString() =>
            $"{Name} (Expiry: {ExpiryDate:dd/MM/yyyy}, Qty: {Quantity}, ID: {Id})";
    }
}
