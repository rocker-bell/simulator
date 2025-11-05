using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BlockchainSimulator.Models
{
    public static class FileStorage
    {
        private static string filePath = "blockchain_data.json";  // Path to store blockchain data

        // Save the blockchain to a JSON file
        public static void SaveBlockchain(List<Block> blockchain)
        {
            var jsonData = JsonConvert.SerializeObject(blockchain, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);  // Save blockchain data to the file
        }

        // Load the blockchain from the JSON file
        public static List<Block> LoadBlockchain()
        {
            if (!File.Exists(filePath)) return new List<Block>();  // Return empty list if the file doesn't exist

            var jsonData = File.ReadAllText(filePath);  // Read JSON data from the file
            return JsonConvert.DeserializeObject<List<Block>>(jsonData);  // Deserialize into a list of blocks
        }
    }
}
