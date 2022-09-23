using ShopAPI.Interfaces;
using ShopAPI.Models;
using ShopAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Repositories
{
    public class ShopRepository : IRepository<ShopItem>
    {
        private readonly FileStorageService _fileService = new FileStorageService();
        private List<ShopItem> _items;

        public ShopRepository()
        {
            _items = _fileService.Read();
        }

        public void Create(ShopItem entity)
        {
            _items.Add(entity);
            
            _fileService.Write(_items);
        }

        public void Delete(int id)
        {
            var entity = _items.FirstOrDefault(x => x.Id == id);
            
            _items.Remove(entity);

            _fileService.Write(_items);
        }

        public ShopItem GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public List<ShopItem> GetAll()
        {
            return _items;
        }

        public void Update(ShopItem entity)
        {
            var oldItem = GetById(entity.Id);

            _items.Remove(oldItem);
            _items.Add(entity);

            _fileService.Write(_items);
        }
    }
}
