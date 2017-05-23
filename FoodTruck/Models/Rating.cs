﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int FoodTruckId { get; set; }
        public int UserId { get; set; }
        public int Stars { get; set; }
        public string Review { get; set; }
    }
}
