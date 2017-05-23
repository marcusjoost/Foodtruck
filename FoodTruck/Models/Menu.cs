using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
        public int FoodTruckId { get; set; }
    }
}
