using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Services
{
    public class ShopItemService
    {
        List<ShopItem> _items = new List<ShopItem>();
        FileStorageService _fileService = new FileStorageService();

        public void Create(ShopItem shopItem)
        {
            _items.Add(shopItem);

            _fileService.Write(_items);
        }

        public ShopItem GetById(int id)
        {
            _items = _fileService.Read();

            var existingItem = _items.FirstOrDefault(x => x.Id == id);

            if(existingItem == null)
            {
                throw new ArgumentNullException($"ShopItem {id} not found!");
            }

            return existingItem;
        }


        //to do:
        public List<ShopItem> GetAll()
        {
            _items = _fileService.Read();
            return _items;
        }

        public void Update(ShopItem item)
        {
            var existingItem = GetById(item.Id);

            existingItem.Name = item.Name;
            existingItem.Price = item.Price;

            _items.Remove(existingItem);
            _items.Add(existingItem);

            _fileService.Write(_items);

        }

        public void Delete(int id)
        {
            _items.Remove(GetById(id));

            _fileService.Write(_items);
        }
    }
}
