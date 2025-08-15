using System;

namespace Assignment3.Question5_Inventory
{
    // Immutable record representing an inventory item
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;
}
