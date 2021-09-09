using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Models
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }

        public String Description { get; set; }

        public float UnitPrice { get; set; }
    }
}
