﻿using FoodTruck.Models;
using FoodTruck.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Controllers
{
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuRepository _repo;
        public MenuController(IMenuRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _repo.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _repo.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody]Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ok = await _repo.UpdateAsync(menu);
            if (ok)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _repo.CreateAsync(menu);
            return CreatedAtAction("ReadAsync", new { id }, menu);
        }
    }
}
