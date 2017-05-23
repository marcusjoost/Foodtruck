using FoodTruck.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Models.Truck> Trucks { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Menu> Menues { get; set; }
    }
}
