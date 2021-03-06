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
    public class RatingController : Controller
    {
        private readonly IRatingRepository _repo;
        public RatingController(IRatingRepository repo)
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

        //[HttpGet]
        //public IEnumerable<Rating> ReadRatingToTruck(int truckId)
        //{
        //    return _repo.GetRatingToFoodtruck(truckId);
        //}

        //[HttpGet("{id}")]
        //public IEnumerable<Rating> ReadRatingToUser(int userId)
        //{
        //    return _repo.GetRatingToUser(userId);
        //}

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
        public async Task<IActionResult> UpdateAsync([FromBody]Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ok = await _repo.UpdateAsync(rating);
            if (ok)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _repo.CreateAsync(rating);
            return CreatedAtAction("ReadAsync", new { id }, rating);
        }
    }
}
