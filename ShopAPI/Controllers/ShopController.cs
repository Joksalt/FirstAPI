using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("ShopItems")]
    public class ShopController : ControllerBase
    {
        private readonly ShopItemService _shopService;

        public ShopController(ShopItemService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public IActionResult Create(ShopItem item)
        {
            _shopService.Create(item);
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Update(ShopItem item)
        {
            try
            {
                _shopService.Update(item);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult GetAll ()
        {
            return Ok(_shopService.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_shopService.GetById(id));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _shopService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
