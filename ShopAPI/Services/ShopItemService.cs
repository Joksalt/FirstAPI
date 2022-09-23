using ShopAPI.Models;
using ShopAPI.Repositories;
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
        ShopRepository _shopRepository = new();

        public ShopItemService()
        {
            _items = _shopRepository.GetAll();
        }

        public void Create(ShopItem shopItem)
        {
            _shopRepository.Create(shopItem);
        }

        public ShopItem GetById(int id)
        {
            return _shopRepository.GetById(id);
        }

        public List<ShopItem> GetAll()
        {
            return _shopRepository.GetAll();
        }

        public void Update(ShopItem item)
        {
            _shopRepository.Update(item);
        }

        public void Delete(int id)
        {
            _shopRepository.Delete(id);
        }
    }
}
