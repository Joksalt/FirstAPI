using Newtonsoft.Json;
using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Services
{
    public class FileStorageService
    {
        private readonly string filePath = "ShopItemData.json";

        public void Write(List<ShopItem> items)
        {
            var jsonData = JsonConvert.SerializeObject(items);
            File.WriteAllText(filePath, jsonData);
        }

        public List<ShopItem> Read()
        {
            var fileData = File.ReadAllText(filePath);
            var items = JsonConvert.DeserializeObject<List<ShopItem>>(filePath);
            return items;
        }
    }
}
