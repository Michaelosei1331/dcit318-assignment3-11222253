using Assignment3.Question3_Warehouse;
using System;

namespace Assignment3.Question5_Inventory
{
    public class InventoryApp
    {
        private readonly InventoryLogger<InventoryItem> _logger;

        public InventoryApp(string filePath)
        {
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void SeedSampleData()
        {
            // Add 3–5 sample immutable InventoryItem records
            try
            {
                _logger.Add(new InventoryItem(1, "Eraser", 125, DateTime.Now));
                _logger.Add(new InventoryItem(2, "Exercisebook", 60, DateTime.Now.AddDays(-2)));
                _logger.Add(new InventoryItem(3, "Pencil Pack", 300, DateTime.Now.AddDays(-5)));
                Console.WriteLine("Sample data seeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning while seeding data: {ex.Message}");
            }
        }

        public void SaveData()
        {
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            if (items.Count == 0)
            {
                Console.WriteLine("No inventory items to display.");
                return;
            }

            Console.WriteLine("Inventory Items:");
            foreach (var i in items)
            {
                Console.WriteLine($"{i.Name} (ID: {i.Id}) - Qty: {i.Quantity} - Added: {i.DateAdded:dd/MM/yyyy}");
            }
        }

        // Helper to clear in-memory log to simulate a new session
        public void ClearMemory()
        {
            _logger.Clear();
            Console.WriteLine("In-memory log cleared (simulated new session).");
        }
    }
}
