using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Assignment3.Question5_Inventory
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private readonly List<T> _log = new();
        private readonly string _filePath;

        public InventoryLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            // avoid duplicate IDs
            if (_log.Exists(x => x.Id == item.Id))
                throw new InvalidOperationException($"Item with ID {item.Id} already exists in the log.");

            _log.Add(item);
        }

        public List<T> GetAll()
        {
            // return a copy to preserve encapsulation
            return new List<T>(_log);
        }

        public void SaveToFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                using var fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                JsonSerializer.Serialize(fs, _log, options);
                Console.WriteLine($"Saved {_log.Count} items to {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save to file '{_filePath}': {ex.Message}");
                // Re-throw if you want callers to handle; here we keep it user-friendly.
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine($"Data file not found at '{_filePath}'. Starting with an empty log.");
                    _log.Clear();
                    return;
                }

                using var fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var items = JsonSerializer.Deserialize<List<T>>(fs);
                _log.Clear();
                if (items != null) _log.AddRange(items);
                Console.WriteLine($"Loaded {_log.Count} items from {_filePath}");
            }
            catch (JsonException jex)
            {
                Console.WriteLine($"Data file '{_filePath}' is corrupt or not valid JSON: {jex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load from file '{_filePath}': {ex.Message}");
            }
        }

        public void Clear()
        {
            _log.Clear();
        }
    }
}
