using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Controllers
{
    [Route("api/[controller]")]
    public class DishController : Controller
    {
        private readonly IDishRepository _repo;
        public DishController(IDishRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = _repo.GetDish(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _repo.DeleteDishAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody]Dish dish, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ok = await _repo.UpdateDishAsync(dish);
            if (ok)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ok = await _repo.CreateDishAsync(dish);
            return CreatedAtAction("Get", new { ok }, dish);
        }
    }
}
