using System;

namespace Assignment3.Question3_Warehouse
{
    public class WareHouseManager
    {
        private readonly InventoryRepository<ElectronicItem> _electronics = new();
        private readonly InventoryRepository<GroceryItem> _groceries = new();

        public void SeedData()
        {
            // Electronics (id, name, qty, brand, warrantyMonths)
            _electronics.AddItem(new ElectronicItem(1, "Laptop", 14, "Macbook", 21));
            _electronics.AddItem(new ElectronicItem(2, "Smartphone", 17, "Iphone", 8));
            _electronics.AddItem(new ElectronicItem(3, "Tablet", 12, "Samsung", 22));

            // Groceries (id, name, qty, expiry)
            _groceries.AddItem(new GroceryItem(1, "Salt", 44, DateTime.Now.AddMonths(5)));
            _groceries.AddItem(new GroceryItem(2, "Milo", 30, DateTime.Now.AddDays(8)));
            _groceries.AddItem(new GroceryItem(3, "Bread", 23, DateTime.Now.AddMonths(1)));
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            var items = repo.GetAllItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items found.");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                int newQty = item.Quantity + quantity;
                repo.UpdateQuantity(id, newQty);
                Console.WriteLine($"Stock updated for {item.Name}: new quantity = {newQty}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Duplicate item error: {ex.Message}");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Not found error: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Invalid quantity error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error when increasing stock: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Item with ID {id} removed successfully.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Not found error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error when removing item: {ex.Message}");
            }
        }

        public void Run()
        {
            Console.WriteLine("=== Question 3: Warehouse Inventory Management ===\n");

            // Seed initial data
            SeedData();

            Console.WriteLine("--- Grocery Items ---");
            PrintAllItems(_groceries);

            Console.WriteLine("\n--- Electronic Items ---");
            PrintAllItems(_electronics);

            Console.WriteLine("\n--- Testing Exceptions & Edge Cases ---");

            // 1) Add a duplicate electronic item (ID 1 already exists)
            Console.WriteLine("\nAttempting to add duplicate electronic item (ID 1):");
            try
            {
                _electronics.AddItem(new ElectronicItem(1, "Gaming Console", 3, "Sony", 12));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // 2) Remove a non-existent grocery item (ID 99)
            Console.WriteLine("\nAttempting to remove non-existent grocery item (ID 99):");
            try
            {
                _groceries.RemoveItem(99);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // 3) Update with invalid quantity (negative)
            Console.WriteLine("\nAttempting to update quantity with invalid value (-5) for grocery ID 1:");
            try
            {
                _groceries.UpdateQuantity(1, -5);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // 4) Demonstrate IncreaseStock and RemoveItemById using methods (safe try-catch inside)
            Console.WriteLine("\nIncreasing stock for Electronic ID 2 by 5:");
            IncreaseStock(_electronics, 2, 5);

            Console.WriteLine("\nRemoving Electronic ID 3:");
            RemoveItemById(_electronics, 3);

            Console.WriteLine("\nFinal Electronic Items:");
            PrintAllItems(_electronics);

            Console.WriteLine("\nFinal Grocery Items:");
            PrintAllItems(_groceries);
        }
    }
}
